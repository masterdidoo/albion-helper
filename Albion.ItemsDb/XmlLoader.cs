using System.Collections.Generic;
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
        private readonly ITownManager _craftTownManager;
        private readonly ITownManager _sellTownManager;

        public XmlLoader(IBuildingDataManager buildingDataManager, ITownManager craftTownManager,
            ITownManager buyTownManager, ITownManager sellTownManager)
        {
            _buyTownManager = buyTownManager;
            _sellTownManager = sellTownManager;
            _craftTownManager = craftTownManager;
            _buildingDataManager = buildingDataManager;
        }

        public Dictionary<string, IItem> XmlItems { get; private set; }

        public Dictionary<string, CommonItem> Items { get; private set; }

        public ArtefactStat[] Artefacts { get; set; }

        public Dictionary<string, string> Localization { get; set; }

        public Dictionary<string, CraftBuilding> CraftBuildings { get; set; }

        public Dictionary<string, string> ItemIdToCraftBuildingId { get; private set; }
        public CraftBuilding NoneBuilding { get; private set; }

        public static items LoadItemsXml()
        {
            var path = GetPath("items.xml");
            using (var stream = File.Open(path, FileMode.Open))
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(items));
                var items = (items) xml.Deserialize(tr);

                return items;
            }
        }

        public static buildings LoadBuildingsXml()
        {
            var path = GetPath("buildings.xml");
            using (var stream = File.Open(path, FileMode.Open))
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(buildings));
                var items = (buildings) xml.Deserialize(tr);

                return items;
            }
        }

        public static AOResourcesResourcesResource[] LoadResourcesXml()
        {
            var path = GetPath("resources.xml");
            using (var stream = File.Open(path, FileMode.Open))
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(AOResources));
                var items = (AOResources) xml.Deserialize(tr);

                return items.Items.OfType<AOResourcesResources>().First().Resource;
            }
        }

        public static Dictionary<string, string> LoadLocalizationXml()
        {
            var path = GetPath("localization.xml");
            using (var stream = File.Open(path, FileMode.Open))
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(tmx));
                var items = (tmx) xml.Deserialize(tr);

                return items.body.Where(s => s.tuid.StartsWith("@ITEMS_") || s.tuid.StartsWith("@BUILDINGS_"))
                    .SelectMany(x => x.tuv
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
            Localization = LoadLocalizationXml();

            NoneBuilding = new CraftBuilding(new ItemBuilding(), _craftTownManager);
            var resourcesDb = LoadResourcesXml();
            var buildingsDb = LoadBuildingsXml();
            var itemsDb = LoadItemsXml();

            var xmlCraftBuildings = buildingsDb.Items.OfType<craftBuilding>().Where(x =>
                x.tier == 8 && x.favoritedish != null && x.craftingitemlist != null &&
                x.craftingitemlist[0].craftitem != null);

            ResourceItemValues = resourcesDb
                .SelectMany(x=>x.ResourceTier.Select(z=>new {
                    name = $"T{z.value}_{x.name}",
                    val = z
                })).ToDictionary(k=>k.name, v=>v.val);

            ItemIdToCraftBuildingId = xmlCraftBuildings
                .SelectMany(x =>
                    x.craftingitemlist[0].craftitem
                        .Select(ci => new
                        {
                            itemId = ci.uniquename,
                            buildingId = x.uniquename
                        }))
                .ToDictionary(k => k.itemId, v => v.buildingId);

            CraftBuildings = xmlCraftBuildings.Select(CreateCraftBuilding).ToDictionary(k => k.Id);

            //            buildingsDb.Items.OfType<CraftBuilding>()

            XmlItems = itemsDb.Items.Cast<IItem>().ToDictionary(GetId, v => v);

            Items = new Dictionary<string, CommonItem>();
            Journals = new Dictionary<string, Journal>();
            JournalsItems = new Dictionary<string, Journal>();

            //Journalitems _EMPTY
            foreach (var journalitem in XmlItems.Values.OfType<ItemsJournalitem>().Select(CreateOrGetItem))
            {
            }
            //Journalitems _FULL
            foreach (var journalitem in XmlItems.Values.OfType<ItemsJournalitem>().Select(CreateOrGetItem))
            {
            }

            var enItems = XmlItems.Values.OfType<IItemEnchantments>().SelectMany(CreateEnchantedItems);

            var items = XmlItems.Values.Where(x=>!(x is ItemsJournalitem)).Select(CreateOrGetItem).Concat(enItems);

            var cnt = items.Count();

            Artefacts = Items.Values.SelectMany(x => x.CraftingRequirements).SelectMany(x => x.Resources
                    .Where(a => a.Item.ShopCategory == ShopCategory.Artefacts).Select(
                        a =>
                            new
                            {
                                x.Item.CraftingBuilding,
                                art = a.Item
                            }))
                .Distinct()
//                .GroupBy(x=>new {x.CraftingBuilding, x.art.CraftingRequirements[0].Resources[0].Item})
                .GroupBy(x => x.art.CraftingRequirements[0].Resources[0].Item)
                .Select(v => new ArtefactStat(null, v.Key, v.Select(a => a.art).ToArray()))
                .ToArray();

            return cnt;
        }

        private static string GetPath(string name)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Xmls", name);
            return path;
        }
    }
}