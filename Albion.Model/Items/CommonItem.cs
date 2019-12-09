using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Model.Buildings;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Profits;
using Albion.Model.Items.Requirements;
using Albion.Model.Managers;

namespace Albion.Model.Items
{
    public class CommonItem : BaseCostableEntity
    {
        public static readonly HashSet<ShopCategory> SimpleItems = new HashSet<ShopCategory>
        {
            Model.Items.Categories.ShopCategory.Accessories,
//            Model.Items.Categories.ShopCategory.Consumables,
            Model.Items.Categories.ShopCategory.Armor,
            Model.Items.Categories.ShopCategory.Melee,
            Model.Items.Categories.ShopCategory.Ranged,
            Model.Items.Categories.ShopCategory.Magic
        };


        public int QualityLevel { get; }

        private readonly FastBuyRequirement _fastBuyRequirement;

        private readonly LongBuyRequirement _longBuyRequirement;
        private BaseRequirement _requirement;

        public CommonItem(BaseResorcedRequirement[] craftingRequirements,
            ItemMarket itemMarket,
            CraftBuilding craftingBuilding,
            int qualityLevel,
            ITownManager buyTownManager,
            ITownManager sellTownManager
        )
        {
            QualityLevel = qualityLevel;
            CraftingRequirements = craftingRequirements;
            IsArtefacted = CraftingRequirements.SelectMany(x => x.Resources)
                .Any(r => r.Item.ShopCategory == ShopCategory.Artefacts || r.Item.ShopCategory == ShopCategory.Token);

            CraftingBuilding = craftingBuilding;
            ItemMarket = itemMarket;

            _longBuyRequirement = new LongBuyRequirement(buyTownManager);
            _fastBuyRequirement = new FastBuyRequirement(buyTownManager);

            LongSellProfit = new LongSellProfit(this, sellTownManager);
            FastSellProfit = new FastSellProfit(this, sellTownManager);
            BmFastSellProfit = new BmFastSellProfit(this);
            BmLongSellProfit = new BmLongSellProfit(this);

            CostCalcOptions.Instance.Changed += RequirementsOnUpdated;
        }

        public FastSellProfit FastSellProfit { get; }
        public BmFastSellProfit BmFastSellProfit { get; }

        public BmLongSellProfit BmLongSellProfit { get; }

        public SalvageProfit SalvageProfit { get; private set; }
        public LongSellProfit LongSellProfit { get; }

        public IEnumerable<object> Components => Profits.Cast<object>().Concat(Requirements);

        private IEnumerable<BaseRequirement> FullRequirements
        {
            get
            {
                yield return _fastBuyRequirement;
                yield return _longBuyRequirement;
                foreach (var cr in CraftingRequirements) yield return cr;
            }
        }

        public IEnumerable<BaseRequirement> Requirements
        {
            get
            {
                yield return _fastBuyRequirement;
                yield return _longBuyRequirement;
                if (IsCraftable)
                    foreach (var cr in CraftingRequirements) yield return cr;
            }
        }

        public IEnumerable<BaseProfit> Profits
        {
            get
            {
                if (SalvageProfit != null) yield return SalvageProfit;
                yield return BmFastSellProfit;
                yield return BmLongSellProfit;
                yield return FastSellProfit;
                yield return LongSellProfit;
            }
        }

        private IEnumerable<BaseRequirement> RequirementsAutoMin
        {
            get
            {
                if (!CostCalcOptions.Instance.IsCraftDisabled)
                    if (IsCraftable)
                    if (!(CostCalcOptions.Instance.IsDisableCraftResources && IsResource))
                    {
                        foreach (var cr in CraftingRequirements) yield return cr;
                        if (CostCalcOptions.Instance.IsItemsOnlyCraft && IsItem) yield break;
                    }
                yield return _fastBuyRequirement;
                if (!CostCalcOptions.Instance.IsLongBuyDisabled || CostCalcOptions.Instance.IsArtefactsLongBuyEnabled &&
                    ShopCategory == ShopCategory.Artefacts)
                    yield return _longBuyRequirement;
            }
        }

        private IEnumerable<BaseProfit> ProfitsAutoMin
        {
            get
            {
                if (!CostCalcOptions.Instance.IsSalvageDisabled)
                    if (SalvageProfit != null)
                        yield return SalvageProfit;
                if (!CostCalcOptions.Instance.IsBmDisabled)
                {
                    yield return BmFastSellProfit;
                    if (!CostCalcOptions.Instance.IsLongSellDisabled)
                        yield return BmLongSellProfit;
                }

                yield return FastSellProfit;
                if (!CostCalcOptions.Instance.IsLongSellDisabled)
                    yield return LongSellProfit;
            }
        }

        public int MemId { get; set; }

        public ItemMarket ItemMarket { get; }

        #region For UI

        public TreeProps TreeProps { get; } = new TreeProps {IsExpanded = false};

        #endregion

        public BaseRequirement Requirement
        {
            get => _requirement;
            set
            {
                Cost = value.Cost;
                if (_requirement != value)
                {
                    _requirement = value;
                    RaisePropertyChanged();
                }
                RequirementUpdated?.Invoke();
            }
        }

        public bool IsArtefacted { get; }

        public void Init()
        {
            if (IsSalvageable &&
                //!IsResource &&
                CraftingRequirements.Length > 0 && CraftingRequirements[0].Resources.Length > 0)
                SalvageProfit = new SalvageProfit(this);

            foreach (var cr in Profits)
                //cr.SetItem(this);
                cr.Updated += ProfitsOnUpdated;

            foreach (var cr in FullRequirements)
            {
                cr.SetItem(this);
                cr.Updated += RequirementsOnUpdated;
            }

            RequirementsOnUpdated();
        }

        private void ProfitsOnUpdated()
        {
            var max = long.MinValue;
            BaseProfit maxItem = null;

            foreach (var item in ProfitsAutoMin)
            {
                item.TreeProps.IsSelected = false;
                //item.TreeProps.IsExpanded = false;
                if (max < item.Income)
                {
                    max = item.Income;
                    maxItem = item;
                }
            }

            if (maxItem != null)
            {
                maxItem.TreeProps.IsSelected = true;
                //maxItem.TreeProps.IsExpanded = true;
            }
        }

        private void RequirementsOnUpdated()
        {
            var min = long.MaxValue;
            BaseRequirement minItem = null;

            foreach (var item in RequirementsAutoMin)
            {
                item.TreeProps.IsSelected = false;
                //item.TreeProps.IsExpanded = false;
                if (min > item.Cost && item.Cost > 0)
                {
                    min = item.Cost;
                    minItem = item;
                }
            }

            if (minItem != null)
                minItem.TreeProps.IsSelected = true;
            else
                Cost = 0;
        }

        public event Action RequirementUpdated;

        #region Profitt

        private BaseProfit _profitt;

        public BaseProfit Profitt
        {
            get => _profitt;
            set
            {
                if (_profitt == value) return;
                if (_profitt != null) _profitt.Updated -= ProfittOnUpdated;
                _profitt = value;
                if (_profitt != null) _profitt.Updated += ProfittOnUpdated;
                RaisePropertyChanged();
                ProfittOnUpdated();
            }
        }

        private void ProfittOnUpdated()
        {
            ProfitUpdated?.Invoke();
        }

        public event Action ProfitUpdated;

        #endregion

        public CommonItem[] QualityLevels { get; set; }

        public bool IsResource => ShopCategory == ShopCategory.Resources;
        public bool IsItem => SimpleItems.Contains(ShopCategory);

        #region From Config
#if DEBUG
        public object Debug { get; set; }
#endif

        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        public CraftBuilding CraftingBuilding { get; }
        public int ItemPower { get; set; }

        public int Tir { get; set; }
        public int Enchant { get; set; }

        public string Name { get; set; }

        public string FullName => QualityLevel > 1 ? $"{Tir}.{Enchant}.{QualityLevel} {Name}" : $"{Tir}.{Enchant} {Name}";

        public BaseResorcedRequirement[] CraftingRequirements { get; }
        public int ItemValue { get; set; }
        public bool IsSalvageable { get; set; }
        public bool IsCraftable { get; set; }

        public override string ToString()
        {
            return Id;
        }

        #endregion
    }
}