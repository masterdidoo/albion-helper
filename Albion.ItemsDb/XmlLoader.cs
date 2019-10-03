using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Albion.ItemsDb.Entity;
using Albion.ItemsDb.Requirements;
using Albion.Model;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Model.Requirements;

namespace Albion.ItemsDb
{
    public class XmlLoader
    {
        private const string LevelNameConst = "_LEVEL";

        public Dictionary<string, IItem> XmlItems { get; private set; }

        public Dictionary<string, CommonItem> Items { get; } = new Dictionary<string, CommonItem>();

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

        public IEnumerable<CommonItem> LoadModel()
        {
            var itemsDb = Load();

            XmlItems = itemsDb.Items.Cast<IItem>().ToDictionary(k => k.uniquename, v => v);

            var enItems = XmlItems.Values.OfType<IItemEnchantments>().SelectMany(CreateEnItems);

            var items = XmlItems.Values.Select(CreateOrGetItem).Concat(enItems);

            return items;
        }

        private IEnumerable<CommonItem> CreateEnItems(IItemEnchantments iItem)
        {
            if (iItem.enchantments == null) yield break;

            foreach (var enchantment in iItem.enchantments)
            {
                var craftingRequirements = EnCreateCraftingRequirements(iItem.uniquename, enchantment);

                var item = CreateBaseItem(iItem, iItem.uniquename + LevelNameConst + enchantment.enchantmentlevel,
                    craftingRequirements);

                yield return item;
            }
        }

        private CommonItem CreateBaseItem(IItem iItem, string itemId,
            IEnumerable<CraftingRequirement> craftingRequirements)
        {
            var item = new CommonItem(craftingRequirements.ToArray())
            {
                Id = itemId,
                ShopCategory = (ShopCategory) iItem.shopcategory,
                ShopSubCategory = (ShopSubCategory) iItem.shopsubcategory1,
            };

            Items.Add(item.Id, item);

            return item;
        }

        /// <summary>
        ///     enchanted versions
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="enchantment"></param>
        /// <returns></returns>
        private IEnumerable<CraftingRequirement> EnCreateCraftingRequirements(string itemId,
            EnchantmentsEnchantment enchantment)
        {
            if (enchantment.craftingrequirements != null)
                foreach (var c in CreateCraftingRequirements(enchantment.craftingrequirements))
                    yield return c;
            if (enchantment.upgraderequirements != null)
                yield return CreateUpgradeRequirements(itemId, enchantment);
        }

        /// <summary>
        ///     upgrade existed
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="enchantment"></param>
        /// <returns></returns>
        private CraftingRequirement CreateUpgradeRequirements(string itemId,
            EnchantmentsEnchantment enchantment)
        {
            var id = enchantment.enchantmentlevel > 1
                ? itemId + LevelNameConst + (enchantment.enchantmentlevel - 1)
                : itemId;
            var res = CreateResources(enchantment.upgraderequirements).ToList();
            res.Add(new CraftingResource
            {
                Item = Items[id],
                Count = 1
            });

            return
                new CraftingRequirement(res.ToArray())
                {
                    Silver = 0,
                    AmountCrafted = 1,
                };
        }

        private CommonItem CreateOrGetItem(IItem arg)
        {
            if (Items.TryGetValue(arg.uniquename, out var item)) return item;

            return CreateItem(arg);
        }

        private CommonItem CreateOrGetItem(string id)
        {
            if (Items.TryGetValue(id, out var item)) return item;

            return CreateItem(XmlItems[id]);
        }

        private CommonItem CreateItem(IItem arg)
        {
            var item = CreateBaseItem(arg, arg.uniquename, CreateCraftingRequirements(arg.craftingrequirements));

            return item;
        }

        private IEnumerable<CraftingRequirement> CreateCraftingRequirements(Craftingrequirements[] arg)
        {
            if (arg == null) yield break;
            foreach (var cr in arg)
                yield return new CraftingRequirement(CreateResources(cr.craftresource, cr.currency, cr.playerfactionstanding).ToArray())
                {
                    Silver = cr.silver * 10000,
                    AmountCrafted = cr.amountcrafted,
                };
        }

        private IEnumerable<CraftingResource> CreateResources(rementsResource[] craftresource,
            craftingrequirementsCurrency[] currency = null,
            craftingrequirementsPlayerfactionstanding[] playerfactionstanding = null)
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