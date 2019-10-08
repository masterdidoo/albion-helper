﻿using System.Collections.Generic;
using System.Linq;
using Albion.Db.Xml.Entity.Building;
using Albion.Db.Xml.Requirements;
using Albion.Model.Buildings;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Requirements;
using Albion.Model.Items.Requirements.Resources;
using Albion.Model.Managers;

namespace Albion.Db.Xml
{
    public partial class XmlLoader
    {
        private const string LevelNameConst = "@";
        private readonly IBuildingDataManager _buildingDataManager;
        private readonly IMarketDataManager _marketDataManager;

        private int _memCounter;

        private IEnumerable<CommonItem> CreateEnchantedItems(IItemEnchantments iItem)
        {
            if (iItem.enchantments == null) yield break;

            foreach (var enchantment in iItem.enchantments)
            {
                var craftingRequirements = EnCreateCraftingRequirements(iItem.uniquename, enchantment);

                var item = CreateCommonItem(iItem, iItem.uniquename + LevelNameConst + enchantment.enchantmentlevel,
                    craftingRequirements, enchantment.enchantmentlevel,
                    enchantment.itempower > 0 ? enchantment.itempower : enchantment.dummyitempower);

                yield return item;
            }
        }

        private CommonItem CreateCommonItem(IItem iItem, string itemId,
            IEnumerable<BaseResorcedRequirement> craftingRequirements, int enchant = 0, int enchantIp = 0)
        {
            var item = new CommonItem(craftingRequirements.ToArray(), _marketDataManager.GetData(itemId),
                BuildingByItem(itemId))
            {
                MemId = _memCounter++,
                Id = itemId,
                Name = Localization.TryGetValue(iItem.uniquename, out var name) ? name : itemId,
                Tir = iItem.tier,
                Enchant = enchant,
                ShopCategory = (ShopCategory) iItem.shopcategory,
                ShopSubCategory = (ShopSubCategory) iItem.shopsubcategory1,
                ItemPower = enchantIp > 0
                    ? enchantIp
                    : (iItem as IItemPowered)?.itempower ?? (iItem as IItemPowered2)?.dummyitempower ??
                      (iItem as IItemValued)?.itemvalue ?? 0
            };

            item.Init();

            Items.Add(item.Id, item);

            return item;
        }

        private CraftBuilding BuildingByItem(string itemId)
        {
            if (ItemIdToCraftBuildingId.TryGetValue(itemId, out var buildingId)) return CraftBuildings[buildingId];
            return NoneBuilding;
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

        private CraftBuilding CreateCraftBuilding(craftBuilding craftBuilding)
        {
            var id = craftBuilding.uniquename;
            var itemBuilding = _buildingDataManager.GetData(id);
            return new CraftBuilding(itemBuilding)
            {
                Id = id
            };
        }
    }
}