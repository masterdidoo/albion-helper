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
    public class CommonItem : NotifyEntity
    {
        private readonly FastBuyRequirement _fastBuyRequirement;
        public FastSellProfit FastSellProfit { get; }
        public BmFastSellProfit BmFastSellProfit { get; }
        public SalvageProfit SalvageProfit { get; }

        private readonly LongBuyRequirement _longBuyRequirement;
        public LongSellProfit LongSellProfit { get; }
        private long _profit = -100;
        private BaseRequirement _requirement = EmptyRequirement.Empty;

        public CommonItem(BaseResorcedRequirement[] craftingRequirements, 
            ItemMarket itemMarket,
            CraftBuilding craftingBuilding,
            ITownManager buyTownManager,
            ITownManager sellTownManager
            )
        {
            CraftingRequirements = craftingRequirements;
            CraftingBuilding = craftingBuilding;
            ItemMarket = itemMarket;

            _longBuyRequirement = new LongBuyRequirement(buyTownManager);
            _fastBuyRequirement = new FastBuyRequirement(buyTownManager);

            LongSellProfit = new LongSellProfit(sellTownManager);
            FastSellProfit = new FastSellProfit(sellTownManager);
            BmFastSellProfit = new BmFastSellProfit(sellTownManager);

            if (CraftingRequirements.Length > 0 && CraftingRequirements[0].Resources.Length > 0)
                SalvageProfit = new SalvageProfit();

            CostCalcOptions.Instance.Changed += RequirementOnUpdateCost;
        }

        public long Profit
        {
            get => _profit;
            protected set
            {
                if (_profit == value) return;
                _profit = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<BaseRequirement> Components => ProfitsAll.Concat(Requirements);

        public IEnumerable<BaseRequirement> Requirements
        {
            get
            {
                yield return _fastBuyRequirement;
                yield return _longBuyRequirement;
                foreach (var cr in CraftingRequirements) yield return cr;
            }
        }

        private IEnumerable<BaseRequirement> ProfitsAll
        {
            get
            {
                if (SalvageProfit != null) yield return SalvageProfit;
                yield return BmFastSellProfit;
                yield return FastSellProfit;
                yield return LongSellProfit;
            }
        }

        private IEnumerable<BaseRequirement> RequirementsAutoMin
        {
            get
            {
                yield return _fastBuyRequirement;
                if (!CostCalcOptions.Instance.IsLongBuyDisabled || CostCalcOptions.Instance.IsArtefactsLongBuyEnabled &&
                    ShopCategory == ShopCategory.Artefacts)
                    yield return _longBuyRequirement;
                foreach (var cr in CraftingRequirements) yield return cr;
            }
        }

        public int MemId { get; set; }

        public ItemMarket ItemMarket { get; }

        #region For UI

        public bool IsExpanded { get; set; } = false;

        #endregion

        public void Init()
        {
            foreach (var profit in ProfitsAll)
            {
                profit.SetItem(this);
            }

            foreach (var cr in Requirements)
            {
                cr.SetItem(this);
            }

            RequirementOnUpdateCost();
        }

        public BaseRequirement Requirement
        {
            get => _requirement;
            set
            {
                if (_requirement == value) return;
                _requirement = value;
                OnPropertyChanged();
                RaiseCostChanged();
            }
        }

        public void RaiseCostChanged()
        {
            CostChanged?.Invoke();
        }

        public event Action CostChanged;

        #region From Config

        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        public CraftBuilding CraftingBuilding { get; }
        public int ItemPower { get; set; }

        public int Tir { get; set; }
        public int Enchant { get; set; }

        public string Name { get; set; }

        public string FullName => $"{Tir}.{Enchant} {Name}";

        public BaseResorcedRequirement[] CraftingRequirements { get; }
        public int ItemValue { get; set; }
        public bool IsResource => ShopCategory == ShopCategory.Resources;
#if DEBUG
        public object Debug { get; set; }
#endif
        public override string ToString()
        {
            return Id;
        }

        #endregion
    }
}