using System.Collections.Generic;
using System.Linq;
using Albion.Db.Xml.Requirements;
using Albion.Model.Data;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Model.Managers;
using Albion.Model.Requirements;
using Albion.Model.Requirements.Resources;

namespace Albion.Db.Xml
{
    public partial class XmlLoader
    {
        private const string LevelNameConst = "_LEVEL";

        private int _memCounter;
        private readonly IMarketDataManager _marketDataManager;
        private readonly IBuildingDataManager _buildingDataManager;

        public XmlLoader(IMarketDataManager marketDataManager, IBuildingDataManager buildingDataManager)
        {
            _marketDataManager = marketDataManager;
            _buildingDataManager = buildingDataManager;
        }

        private IEnumerable<CommonItem> CreateEnchantedItems(IItemEnchantments iItem)
        {
            if (iItem.enchantments == null) yield break;

            foreach (var enchantment in iItem.enchantments)
            {
                var craftingRequirements = EnCreateCraftingRequirements(iItem.uniquename, enchantment);

                var item = CreateCommonItem(iItem, iItem.uniquename + LevelNameConst + enchantment.enchantmentlevel,
                    craftingRequirements);

                item.ItemPower = enchantment.itempower > 0 ? enchantment.itempower : enchantment.dummyitempower;

                yield return item;
            }
        }

        private CommonItem CreateCommonItem(IItem iItem, string itemId,
            IEnumerable<BaseResorcedRequirement> craftingRequirements)
        {
            var item = new CommonItem(craftingRequirements.ToArray(), _marketDataManager.GetData(itemId), _buildingDataManager.GetData(BuildingByItem(itemId)))
            {
                MemId = _memCounter++,
                Id = itemId,
                ShopCategory = (ShopCategory) iItem.shopcategory,
                ShopSubCategory = (ShopSubCategory) iItem.shopsubcategory1,
                ItemPower = (iItem as IItemPowered)?.itempower ?? (iItem as IItemPowered2)?.dummyitempower ??
                            (iItem as IItemValued)?.itemvalue ?? 0
            };

            Items.Add(item.Id, item);

            return item;
        }

        private string BuildingByItem(string itemId)
        {
            return itemId;
        }

        /// <summary>
        ///     enchanted versions
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="enchantment"></param>
        /// <returns></returns>
        private IEnumerable<BaseResorcedRequirement> EnCreateCraftingRequirements(string itemId,
            EnchantmentsEnchantment enchantment)
        {
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
        private BaseResorcedRequirement CreateUpgradeRequirements(string itemId,
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

            return new UpgradeRequirement(res.ToArray());
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
            var item = CreateCommonItem(arg, arg.uniquename, CreateCraftingRequirements(arg.craftingrequirements));

            return item;
        }

        private IEnumerable<CraftingRequirement> CreateCraftingRequirements(Craftingrequirements[] arg)
        {
            if (arg == null) yield break;
            foreach (var cr in arg)
            {
                var res = CreateResources(cr.craftresource, cr.currency, cr.playerfactionstanding);
                yield return new CraftingRequirement(res.ToArray())
                {
                    Silver = cr.silver * 10000,
                    AmountCrafted = cr.amountcrafted
                };
            }
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