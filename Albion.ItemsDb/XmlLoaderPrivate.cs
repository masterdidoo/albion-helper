using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Albion.Db.Xml.Entity.Building;
using Albion.Db.Xml.Entity.Item;
using Albion.Db.Xml.Enums;
using Albion.Db.Xml.Requirements;
using Albion.Model.Buildings;
using Albion.Model.Data;
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

        private Dictionary<string, AOResourcesResourcesResourceResourceTier> ResourceItemValues { get; set; }

        private readonly IBuildingDataManager _buildingDataManager;

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
            var item = CreateCommonItem(arg, GetId(arg), CreateCraftingRequirements(arg.craftingrequirements, (arg as SimpleItem)?.resourcetype != null, arg.uniquename),
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
            var im = new ItemMarket();
            var main = CreateCommonItemExt(iItem, itemId, craftingRequirements, enchant, 1, im, enchantIp);
            main.QualityLevels = Empty;
            if (iItem is IItemPowered)
            {
                main.QualityLevels = new CommonItem[4];
                for (int i = 1; i < 5; i++)
                {
                    main.QualityLevels[i-1] =
                    CreateCommonItemExt(iItem, itemId, craftingRequirements, enchant, i+1, im, enchantIp);
                }
            }
            return main;
        }

        CommonItem[] Empty = new CommonItem[0];

        private CommonItem CreateCommonItemExt(IItem iItem, string itemId,
            IEnumerable<BaseResorcedRequirement> craftingRequirements, int enchant, int qualityLevel,
            ItemMarket itemMarket, int enchantIp = 0)
        {

//            BaseResorcedRequirement[] crs = (iItem.shopcategory == shopCategory.token) ? _empty : craftingRequirements.ToArray();
            BaseResorcedRequirement[] crs = craftingRequirements.ToArray();
            var item = new CommonItem(crs, itemMarket,
                BuildingByItem(iItem.uniquename),
                qualityLevel,
                _buyTownManager, 
                _sellTownManager
                )
            {
#if DEBUG
                Debug = iItem,
#endif
                MemId = _memCounter++,
                Id = itemId,
                Name = Localization.TryGetValue("@ITEMS_"+iItem.uniquename, out var name) ? name : itemId,
                Tir = iItem.tier,
                Enchant = enchant,
                ShopCategory = (ShopCategory) iItem.shopcategory,
                ShopSubCategory = (ShopSubCategory) iItem.shopsubcategory1,
                IsSalvageable = (iItem as IItemSalvageable)?.salvageable ?? false,
                ItemValue = GetItemValue(iItem, enchant, crs),
                ItemFame = GetItemFame(iItem, crs),
                ItemPower = enchantIp > 0
                    ? enchantIp
                    : (iItem as IItemPowered)?.itempower ?? (iItem as IItemPowered2)?.dummyitempower ?? 0
            };

            item.IsCraftable = //iItem.unlockedtocraft &&
                               !(itemId.Contains("_CAPEITEM_") && itemId.EndsWith("_BP") &&
                                 item.CraftingBuilding == NoneBuilding)
                               && item.CraftingRequirements.Length > 0;
            //            item.IsCraftable = item.CraftingBuilding != NoneBuilding || item.CraftingRequirements.Length > 0 && (item.CraftingRequirements[0] as CraftingRequirement)?.Silver > 0;
            //                               || item.ShopCategory == ShopCategory.Artefacts;

            item.Init();

            Items.Add(item.Id + (qualityLevel > 1 ? $"_{qualityLevel}" : ""), item);

            if (iItem is ItemsJournalitem journalitem)
            {
                AddJournal(journalitem, item);
            }

//            if (iItem.shopcategory == shopCategory.token && iItem.unlockedtocraft) Debug.WriteLine("tk");

            return item;
        }

        private void AddJournal(ItemsJournalitem journalitem, CommonItem item)
        {
            var journal = new Journal(item)
            {
                MaxFame = journalitem.maxfame
            };

            var itemIds = journalitem.famefillingmissions.Where(x => x.craftitemfame != null).SelectMany(x => x.craftitemfame).SelectMany(x => x.validitem)
                .Select(x => x.id);

            foreach (var itemId in itemIds)
            {
                Journals.Add(itemId, journal);
            }
        }

        public Dictionary<string, Journal> Journals { get; private set; }

        private double GetItemFame(IItem iItem, BaseResorcedRequirement[] crs)
        {
            if (ResourceItemValues.TryGetValue(iItem.uniquename, out var res))
                return res.famevalue;

            if (crs.Length >0) return crs[0].Resources.Sum(r=>r.Item.ItemFame * r.Count);
            return 0;
        }

        private double GetItemValue(IItem iItem, int enchant, BaseResorcedRequirement[] crs)
        {
            var iv = (iItem as IItemValued)?.itemvalue ?? 0;
            if (iv > 0) return iv;

            if (ResourceItemValues.TryGetValue(iItem.uniquename, out var res))
                return res.resourcevalue * 2; //TODO проверить xml

//            if (iItem.shopcategory == shopCategory.resources)
//                return iItem.tier < 3 ? 0 : iItem.tier > 2 ? ResourceItemValues[enchant][iItem.tier - 3] : iItem.tier;
//
            if (iItem is SimpleItem item && item.foodcategory == "plants")
                return 4;
//
//            if (iItem.shopsubcategory1 == shopSubCategory.royalsigils && iItem.tier == 4)
//                return 128;
//
//            if (iItem.shopcategory == shopCategory.artefacts)
//                return (int?)(iItem as IItemValued)?.itemvalue ?? 1000;
//
//            if (iItem.shopcategory == shopCategory.resources)
//                return iItem.tier < 3 ? 0 : iItem.tier > 2 ? ResourceItemValues[enchant][iItem.tier - 3] : iItem.tier;

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
            foreach (var c in CreateCraftingRequirements(enchantment.craftingrequirements, false, itemId))
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
            res.Add(new CraftingResource(Items[id], 1, false));

            return new UpgradeRequirement(res.ToArray());
        }


        private IEnumerable<CraftingRequirement> CreateCraftingRequirements(Craftingrequirements[] arg, bool isTransmut,
            string itemId)
        {
            Journals.TryGetValue(itemId, out var journal);

            if (arg == null) yield break;
            foreach (var cr in arg)
            {
                var res = CreateResources(cr.craftresource, cr.currency, cr.playerfactionstanding);
                if (isTransmut)
                    yield return new TransmutRequirement(res.ToArray())
                    {
                        Silver = cr.silver * 10000,
                        AmountCrafted = cr.amountcrafted
                    };
                else
                {
                    yield return new CraftingRequirement(res.ToArray())
                    {
                        Silver = cr.silver * 10000,
                        AmountCrafted = cr.amountcrafted,
                        Journal = journal
                    };
                }
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
                    crr.count,
                    crr.maxreturnamount == null
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
            return new CraftBuilding(itemBuilding, _craftTownManager)
            {
                Id = id,
                Name = Localization.TryGetValue("@BUILDINGS_"+id, out var name) ? name : id,
            };
        }
    }
}