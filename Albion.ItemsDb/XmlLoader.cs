using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Albion.Db.Xml.Entity.Building;
using Albion.Db.Xml.Entity.Item;
using Albion.Model.Items;

namespace Albion.Db.Xml
{
    public partial class XmlLoader
    {
        public Dictionary<string, IItem> XmlItems { get; private set; }

        public Dictionary<string, CommonItem> Items { get; private set; }

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

        public IEnumerable<CommonItem> LoadModel()
        {
            //var buildingsDb = LoadBuildingsXml();
            var itemsDb = LoadItemsXml();

//            buildingsDb.Items.OfType<CraftBuilding>()

            XmlItems = itemsDb.Items.Cast<IItem>().ToDictionary(k => k.uniquename, v => v);

            Items = new Dictionary<string, CommonItem>();

            var enItems = XmlItems.Values.OfType<IItemEnchantments>().SelectMany(CreateEnchantedItems);

            var items = XmlItems.Values.Select(CreateOrGetItem).Concat(enItems);

            return items;
        }
    }
}