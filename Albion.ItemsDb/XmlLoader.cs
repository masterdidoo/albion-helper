using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Albion.ItemsDb.Entity;
using Albion.ItemsDb.Requirements;
using Albion.Model.Items;

namespace Albion.ItemsDb
{
    public class XmlLoader
    {
        public Dictionary<string, IItem> XmlItems { get; private set; }

        public Dictionary<string, BaseItem> Items { get; } = new Dictionary<string, BaseItem>();

        public static items Load()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Albion.ItemsDb.Xmls.items.xml");
            if (stream == null) return null;
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(items));
                var items = (items) xml.Deserialize(tr);

                return items;
            }
        }

        public IEnumerable<BaseItem> LoadModel()
        {
            var itemsDb = Load();

            XmlItems = itemsDb.Items.Cast<IItem>().ToDictionary(k => k.uniquename, v => v);

            var enItems = XmlItems.Values.OfType<IItemEnchantments>().SelectMany(CreateEnItems);

            var items = XmlItems.Values.Select(CreateOrGetItem).Concat(enItems);

            return items;
        }

        private IEnumerable<BaseItem> CreateEnItems(IItemEnchantments arg)
        {
            if (arg.enchantments == null) yield break;

            foreach (var enchantments in arg.enchantments)
            {
                var craftingRequirements = EnCreateCraftingRequirements(enchantments);
                if (craftingRequirements == null) continue;

                var item = CreateBaseItem(arg, arg.uniquename + "_LEVEL" + enchantments.enchantmentlevel,
                    craftingRequirements);

                yield return item;
            }
        }

        private BaseItem CreateBaseItem(IItem arg, string id, IEnumerable<CraftingRequirement> craftingRequirements)
        {
            var item = new BaseItem
            {
                Id = id,
                ShopCategory = (ShopCategory) arg.shopcategory,
                ShopSubCategory = (ShopSubCategory) arg.shopsubcategory1,
                CraftingRequirements = craftingRequirements.ToArray()
            };

            Items.Add(item.Id, item);

            return item;
        }

        private IEnumerable<CraftingRequirement> EnCreateCraftingRequirements(EnchantmentsEnchantment arg)
        {
            if (arg.craftingrequirements != null)
                return CreateCraftingRequirements(arg.craftingrequirements);
            return null;
        }

        private BaseItem CreateOrGetItem(IItem arg)
        {
            if (Items.TryGetValue(arg.uniquename, out var item)) return item;

            return CreateItem(arg);
        }

        private BaseItem CreateOrGetItem(string id)
        {
            if (Items.TryGetValue(id, out var item)) return item;

            return CreateItem(XmlItems[id]);
        }

        private BaseItem CreateItem(IItem arg)
        {
            var item = CreateBaseItem(arg, arg.uniquename, CreateCraftingRequirements(arg.craftingrequirements));

            return item;
        }

        private IEnumerable<CraftingRequirement> CreateCraftingRequirements(Craftingrequirements[] arg)
        {
            if (arg == null) yield break;
            foreach (var cr in arg)
                yield return new CraftingRequirement
                {
                    Silver = cr.silver,
                    AmountCrafted = cr.amountcrafted,
                    Resources = CreateResources(cr.craftresource, cr.currency, cr.playerfactionstanding).ToArray()
                };
        }

        private IEnumerable<CraftingResource> CreateResources(craftingrequirementsCraftresource[] craftresource,
            craftingrequirementsCurrency[] currency, craftingrequirementsPlayerfactionstanding[] playerfactionstanding)
        {
            if (playerfactionstanding != null)
            {
            }

            if (currency != null)
            {
            }

            if (craftresource == null) yield break;

            foreach (var crr in craftresource)
                yield return new CraftingResource
                {
                    Item = CreateOrGetItem(crr.uniquename),
                    Count = crr.count
                };
        }
    }
}