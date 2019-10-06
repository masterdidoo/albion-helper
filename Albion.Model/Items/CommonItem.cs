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
        private readonly FastSellProfit _fastSellProfit;
        private readonly LongBuyRequirement _longBuyRequirement;
        private readonly LongSellProfit _longSellProfit;
        private long _profit;

        public CommonItem(BaseResorcedRequirement[] craftingRequirements, ItemMarket itemMarket,
            CraftBuilding craftingBuilding)
        {
            _craftingRequirements = craftingRequirements;
            _craftingBuilding = craftingBuilding;
            ItemMarket = itemMarket;

            _longBuyRequirement = new LongBuyRequirement();
            _fastBuyRequirement = new FastBuyRequirement();

            _longSellProfit = new LongSellProfit(this);
            _fastSellProfit = new FastSellProfit(this);


            foreach (var profit in Profits) profit.UpdateProfit += OnUpdateProfit;

            foreach (var cr in Requirements)
            {
                cr.SetItem(this);
                cr.UpdateCost += RequirementOnUpdateCost;
            }

            RequirementOnUpdateCost();
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

        public IEnumerable<BaseRequirement> Requirements
        {
            get
            {
                yield return _fastBuyRequirement;
                yield return _longBuyRequirement;
                foreach (var cr in _craftingRequirements) yield return cr;
            }
        }

        public IEnumerable<BaseProfit> Profits
        {
            get
            {
                yield return _fastSellProfit;
                yield return _longSellProfit;
            }
        }


        public int MemId { get; set; }

        public ItemMarket ItemMarket { get; }
        internal ItemBuilding ItemBuilding => _craftingBuilding.ItemBuilding;

        #region For UI

        public bool IsExpanded { get; set; } = true;

        #endregion

        private void OnUpdateProfit()
        {
            Profit = Profits.Max(p => p.Profit);
        }

        private void RequirementOnUpdateCost()
        {
            var min = long.MaxValue;
            BaseRequirement minItem = null;

            foreach (var item in Requirements)
                if (min > item.Cost && item.Cost > 0)
                {
                    min = item.Cost;
                    minItem = item;
                }

            if (minItem != null)
            {
                minItem.IsMin = true;
                minItem.IsExpanded = true;
                Cost = minItem.Cost;
            }
            else
            {
                Pos = DateTime.MinValue;
                Cost = 0;
            }

            //Cost = Requirements.Select(x => x.Cost).Where(x => x > 0).DefaultIfEmpty(0).Min();
        }

        public override string ToString()
        {
            return Id;
        }

        public void UpdateMinCost(BaseRequirement requirement)
        {
            foreach (var item in Requirements)
                if (item != requirement)
                    item.IsMin = false;
            Cost = requirement.Cost;
        }

        #region From Config

        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        private readonly BaseResorcedRequirement[] _craftingRequirements;
        private readonly CraftBuilding _craftingBuilding;
        public int ItemPower { get; set; }

        public int Tir { get; set; }
        public int Enchant { get; set; }

        public string Name { get; set; }

        public string FullName => $"{Tir}.{Enchant} {Name}";

        #endregion
    }
}