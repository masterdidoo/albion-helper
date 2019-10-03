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
        private const string LevelNameConst = "_LEVEL";

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

        private IEnumerable<BaseItem> CreateEnItems(IItemEnchantments iItem)
        {
            if (iItem.enchantments == null) yield break;

            foreach (var enchantment in iItem.enchantments)
            {
                var craftingRequirements = EnCreateCraftingRequirements(iItem.uniquename, enchantment);
                if (craftingRequirements == null) continue;

                var item = CreateBaseItem(iItem, iItem.uniquename + LevelNameConst + enchantment.enchantmentlevel,
                    craftingRequirements);

                yield return item;
            }
        }

        private BaseItem CreateBaseItem(IItem iItem, string itemId,
            IEnumerable<CraftingRequirement> craftingRequirements)
        {
            var item = new BaseItem
            {
                Id = itemId,
                ShopCategory = (ShopCategory) iItem.shopcategory,
                ShopSubCategory = (ShopSubCategory) iItem.shopsubcategory1,
                CraftingRequirements = craftingRequirements.ToArray()
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
                new CraftingRequirement
                {
                    Silver = 0,
                    AmountCrafted = 1,
                    Resources = res.ToArray()
                };
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