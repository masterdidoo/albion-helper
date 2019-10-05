using System;
using System.Collections.Generic;
using Albion.Model.Buildings;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Requirements;

namespace Albion.Model.Items
{
    public class CommonItem : BaseCostableEntity
    {
        private readonly FastBuyRequirement _fastBuyRequirement;
        private readonly LongBuyRequirement _longBuyRequirement;

        public CommonItem(BaseResorcedRequirement[] craftingRequirements, ItemMarket itemMarket,
            CraftBuilding craftingBuilding)
        {
            _craftingRequirements = craftingRequirements;
            _craftingBuilding = craftingBuilding;
            _longBuyRequirement = new LongBuyRequirement();
            _fastBuyRequirement = new FastBuyRequirement();

            ItemMarket = itemMarket;

            foreach (var cr in Requirements)
            {
                cr.SetItem(this);
                cr.UpdateCost += RequirementOnUpdateCost;
            }

            RequirementOnUpdateCost();
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


        public int MemId { get; set; }

        public ItemMarket ItemMarket { get; }
        internal ItemBuilding ItemBuilding => _craftingBuilding.ItemBuilding;

        #region For UI

        public bool IsExpanded { get; set; } = true;

        #endregion

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