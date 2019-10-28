using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Albion.Db.Xml.Entity.Building;
using Albion.Db.Xml.Entity.Item;
using Albion.Model.Buildings;
using Albion.Model.Data;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Model.Managers;

namespace Albion.Db.Xml
{
    public partial class XmlLoader
    {
        private readonly ITownManager _buyTownManager;
        private readonly ITownManager _sellTownManager;
        private readonly ITownManager _craftTownManager;

        public Dictionary<string, IItem> XmlItems { get; private set; }

        public Dictionary<string, CommonItem> Items { get; private set; }

        public XmlLoader(IBuildingDataManager buildingDataManager, ITownManager craftTownManager, ITownManager buyTownManager, ITownManager sellTownManager)
        {
            _buyTownManager = buyTownManager;
            _sellTownManager = sellTownManager;
            _craftTownManager = craftTownManager;
            _buildingDataManager = buildingDataManager;
        }

        public static items LoadItemsXml()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Albion.Db.Xml.Xmls.items.xml");
            if (stream == null) return null;
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(items));
                var items = (items) xml.Deserialize(tr);

                return items;
            }
        }

        public static buildings LoadBuildingsXml()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Albion.Db.Xml.Xmls.buildings.xml");
            if (stream == null) return null;
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(buildings));
                var items = (buildings) xml.Deserialize(tr);

                return items;
            }
        }

        public static Dictionary<string, string> LoadLocalizationXml()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Albion.Db.Xml.Xmls.localization.xml");
            if (stream == null) return null;
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(tmx));
                var items = (tmx) xml.Deserialize(tr);

                return items.body.Where(s => s.tuid.StartsWith("@ITEMS_") || s.tuid.StartsWith("@BUILDINGS_")).SelectMany(x => x.tuv
                    .Where(lr => lr.lang == "RU-RU").Select(lr => new
                    {
//                        tuid = x.tuid.Substring(7),
                        x.tuid,
                        lr.seg
                    }))
                    .ToDictionary(k => k.tuid, v => v.seg);
            }
        }

        public int LoadModel()
        {
            Localization = XmlLoader.LoadLocalizationXml();

            NoneBuilding = new CraftBuilding(new ItemBuilding(), _craftTownManager);
            var buildingsDb = LoadBuildingsXml();
            var itemsDb = LoadItemsXml();

            var xmlCraftBuildings = buildingsDb.Items.OfType<craftBuilding>().Where(x =>
                x.tier == 8 && x.favoritedish != null && x.craftingitemlist != null &&
                x.craftingitemlist[0].craftitem != null);

            ItemIdToCraftBuildingId = xmlCraftBuildings
                .SelectMany(x=>
                    x.craftingitemlist[0].craftitem
                        .Select(ci=>new {
                            itemId = ci.uniquename,
                            buildingId = x.uniquename
                        }))
                .ToDictionary(k=>k.itemId, v=>v.buildingId);

            CraftBuildings = xmlCraftBuildings.Select(CreateCraftBuilding).ToDictionary(k=>k.Id);

            //            buildingsDb.Items.OfType<CraftBuilding>()

            XmlItems = itemsDb.Items.Cast<IItem>().ToDictionary(k => k.uniquename, v => v);

            Items = new Dictionary<string, CommonItem>();

            var enItems = XmlItems.Values.OfType<IItemEnchantments>().SelectMany(CreateEnchantedItems);

            var items = XmlItems.Values.Select(CreateOrGetItem).Concat(enItems);

            var cnt = items.Count();

            Artefacts =  Items.Values.SelectMany(x=>x.CraftingRequirements).SelectMany(x=>x.Resources.Where(a=>a.Item.ShopCategory==ShopCategory.Artefacts).Select(
                a =>
                new {
                    x.Item.CraftingBuilding,
                    art=a.Item
                }))
                .Distinct()
//                .GroupBy(x=>new {x.CraftingBuilding, x.art.CraftingRequirements[0].Resources[0].Item})
                .GroupBy(x=>x.art.CraftingRequirements[0].Resources[0].Item)
                .Select(v=>new ArtefactStat(null, v.Key, v.Select(a=>a.art).ToArray()))
                .ToArray();

            return cnt;
        }

        public ArtefactStat[] Artefacts { get; set; }

        public Dictionary<string, string> Localization { get; set; }

        public Dictionary<string, CraftBuilding> CraftBuildings { get; set; }

        public Dictionary<string, string> ItemIdToCraftBuildingId { get; private set; }
        public CraftBuilding NoneBuilding { get; private set; }
    }
}