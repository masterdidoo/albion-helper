using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Model.Buildings;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Profits;
using Albion.Model.Items.Requirements;

namespace Albion.Model.Items
{
    public class CommonItem : BaseCostableEntity
    {
        private readonly FastBuyRequirement _fastBuyRequirement;
        public FastSellProfit FastSellProfit { get; }
        public SalvageProfit SalvageProfit { get; }

        private readonly LongBuyRequirement _longBuyRequirement;
        public LongSellProfit LongSellProfit { get; }
        private long _profit = -100;
        private long _sale;

        public CommonItem(BaseResorcedRequirement[] craftingRequirements, ItemMarket itemMarket,
            CraftBuilding craftingBuilding)
        {
            CraftingRequirements = craftingRequirements;
            CraftingBuilding = craftingBuilding;
            ItemMarket = itemMarket;

            _longBuyRequirement = new LongBuyRequirement();
            _fastBuyRequirement = new FastBuyRequirement();

            LongSellProfit = new LongSellProfit();
            FastSellProfit = new FastSellProfit();

            if (CraftingRequirements.Length > 0 && CraftingRequirements[0].Resources.Length > 0)
                SalvageProfit = new SalvageProfit();

            CostCalcOptions.Instance.Changed += RequirementOnUpdateCost;
            CostCalcOptions.Instance.Changed += OnUpdateProfitOrCost;
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

        public IEnumerable<BaseRequirement> Components => ProfitsAll.Concat(RequirementsAll);

        private IEnumerable<BaseRequirement> RequirementsAll
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

        private IEnumerable<BaseRequirement> ProfitsAutoMax
        {
            get
            {
                if (SalvageProfit != null) yield return SalvageProfit;
                yield return FastSellProfit;
                if (!CostCalcOptions.Instance.IsLongSellDisabled)
                    yield return LongSellProfit;
            }
        }


        public int MemId { get; set; }

        public ItemMarket ItemMarket { get; }
        internal ItemBuilding ItemBuilding => CraftingBuilding.ItemBuilding;

        #region For UI

        public bool IsExpanded { get; set; } = false;

        #endregion

        public void Init()
        {
            foreach (var profit in ProfitsAll)
            {
                profit.SetItem(this);
                profit.UpdateCost += OnUpdateProfitOrCost;
                profit.Selected += UpdateMaxSale;
            }

            foreach (var cr in RequirementsAll)
            {
                cr.SetItem(this);
                cr.UpdateCost += RequirementOnUpdateCost;
                cr.Selected += UpdateMinCost;
            }

            UpdateCost += OnUpdateProfitOrCost;

            RequirementOnUpdateCost();
        }

        private void UpdateMaxSale(BaseRequirement requirement)
        {
            foreach (var item in ProfitsAll)
                if (item != requirement)
                    item.IsSelected = false;

            Sale = requirement.Cost;

            Profit = Cost > 0 ? (requirement.Cost - Cost) * 100 / Cost : -100;
        }

        public long Sale
        {
            get => _sale;
            set
            {
                if (_sale == value) return;
                _sale = value;
                UpdateSale?.Invoke();
                OnPropertyChanged();
            }
        }

        public event Action UpdateSale ;

        private void OnUpdateProfitOrCost()
        {
            var max = 0L;
            BaseRequirement maxItem = null;

            foreach (var item in ProfitsAutoMax)
            {
                item.IsSelected = false;
                if (max < item.Cost && item.Cost > 0)
                {
                    max = item.Cost;
                    maxItem = item;
                }
            }

            if (maxItem != null)
            {
                maxItem.IsSelected = true;
                maxItem.IsExpanded = true;
                //Cost = minItem.Cost; set from UpdateMaxProfit
                Profit = Cost > 0 ? (max - Cost) * 100 / Cost : -100;
            }
            else
            {
                Profit = -100;
            }

            //Pos = Components.Max(x => x.Pos).AddTicks(1);
        }

        public void UpdateMinCost(BaseRequirement requirement)
        {
            foreach (var item in RequirementsAll)
                if (item != requirement)
                    item.IsSelected = false;
            Cost = requirement.Cost;
        }

        private void RequirementOnUpdateCost()
        {
            var min = long.MaxValue;
            BaseRequirement minItem = null;

            foreach (var item in RequirementsAutoMin)
            {
                item.IsSelected = false;
                item.IsExpanded = false;
                if (min > item.Cost && item.Cost > 0)
                {
                    min = item.Cost;
                    minItem = item;
                }
            }

            var pos = Components.Max(x => x.Pos);
            Pos = (pos.Ticks > 1) ? pos.AddTicks(-1) : pos;

            if (minItem != null)
            {
                minItem.IsSelected = true;
                minItem.IsExpanded = true;
                //Cost = minItem.Cost; set from UpdateMinCost
            }
            else
            {
                Cost = 0;
            }

            //Cost = Requirements.Select(x => x.Cost).Where(x => x > 0).DefaultIfEmpty(0).Min();
        }

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

        public override string ToString()
        {
            return Id;
        }

        #endregion
    }
}