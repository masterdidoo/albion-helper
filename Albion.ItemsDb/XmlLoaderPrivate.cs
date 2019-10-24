﻿using System.Collections.Generic;
using System.Linq;
using Albion.Db.Xml.Entity.Building;
using Albion.Db.Xml.Enums;
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


        private static readonly int[][] ResourceItemValues =
        {
            new[] {6, 14, 30, 62, 126, 254},
            new[] {0, 30, 62, 126, 254, 510},
            new[] {0, 54, 118, 246, 502, 1014},
            new[] {0, 102, 230, 486, 998, 2022}
        };

        private readonly IBuildingDataManager _buildingDataManager;
        private readonly IMarketDataManager _marketDataManager;

        private int _memCounter;


        private CommonItem CreateOrGetItem(IItem arg)
        {
            if (Items.TryGetValue(GetId(arg), out var item)) return item;

            return CreateItem(arg);
        }

        private CommonItem CreateOrGetItem(string id)
        {
            if (Items.TryGetValue(id, out var item)) return item;

            return CreateItem(XmlItems[id]);
        }

        private CommonItem CreateItem(IItem arg)
        {
            var item = CreateCommonItem(arg, GetId(arg), CreateCraftingRequirements(arg.craftingrequirements),
                (arg as IItemEnchantmentLevel)?.enchantmentlevel ?? 0);

            return item;
        }

        private IEnumerable<CommonItem> CreateEnchantedItems(IItemEnchantments iItem)
        {
            if (iItem.enchantments == null) yield break;

            foreach (var enchantment in iItem.enchantments)
            {
                var craftingRequirements = EnCreateCraftingRequirements(iItem.uniquename, enchantment);

                var item = CreateCommonItem(iItem, GetId(iItem.uniquename, enchantment.enchantmentlevel),
                    craftingRequirements, enchantment.enchantmentlevel,
                    enchantment.itempower > 0 ? enchantment.itempower : enchantment.dummyitempower);

                yield return item;
            }
        }

        private CommonItem CreateCommonItem(IItem iItem, string itemId,
            IEnumerable<BaseResorcedRequirement> craftingRequirements, int enchant, int enchantIp = 0)
        {
            BaseResorcedRequirement[] crs = craftingRequirements.ToArray();
            var item = new CommonItem(crs, _marketDataManager.GetData(itemId),
                BuildingByItem(iItem.uniquename),
                _buyTownManager, 
                _sellTownManager
                )
            {
#if DEBUG
                Debug = iItem,
#endif
                MemId = _memCounter++,
                Id = itemId,
                Name = Localization.TryGetValue(iItem.uniquename, out var name) ? name : itemId,
                Tir = iItem.tier,
                Enchant = enchant,
                ShopCategory = (ShopCategory) iItem.shopcategory,
                ShopSubCategory = (ShopSubCategory) iItem.shopsubcategory1,
                ItemValue = GetItemValue(iItem, enchant, crs),
                ItemPower = enchantIp > 0
                    ? enchantIp
                    : (iItem as IItemPowered)?.itempower ?? (iItem as IItemPowered2)?.dummyitempower ??
                      (int?) (iItem as IItemValued)?.itemvalue * 100 ?? 0
            };

            item.Init();

            Items.Add(item.Id, item);

            return item;
        }

        private int GetItemValue(IItem iItem, int enchant, BaseResorcedRequirement[] crs)
        {
            if (iItem.shopsubcategory1 == shopSubCategory.royalsigils && iItem.tier == 4)
                return 128;

            if (iItem.shopcategory == shopCategory.artefacts)
                return 1000;

            if (iItem.shopcategory == shopCategory.resources)
                return iItem.tier < 3 ? 0 : iItem.tier > 2 ? ResourceItemValues[enchant][iItem.tier - 3] : iItem.tier;

            int iv = (int?) (iItem as IItemValued)?.itemvalue ?? 0;
            if (iv > 0) return iv;

            if (crs.Length >0) return crs[0].Resources.Sum(r=>r.Item.ItemValue * r.Count);
            return 0;
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
            var id = GetId(itemId, enchantment.enchantmentlevel - 1);
            var res = CreateResources(enchantment.upgraderequirements).ToList();
            res.Add(new CraftingResource(Items[id],1));

            return new UpgradeRequirement(res.ToArray());
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
                (
                    CreateOrGetItem(GetId(crr.uniquename, crr.enchantmentlevel)),
                    crr.count
                );
        }

        private string GetId(string uniquename, int enchantmentlevel)
        {
            return enchantmentlevel > 0
                ? uniquename + LevelNameConst + enchantmentlevel
                : uniquename;
        }

        private string GetId(IItem iItem)
        {
            return iItem is IItemEnchantmentLevel ie
                ? GetId(iItem.uniquename, ie.enchantmentlevel)
                : iItem.uniquename;
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