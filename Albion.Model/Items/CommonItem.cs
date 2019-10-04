using System.Collections.Generic;
using System.Linq;
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

        public CommonItem(BaseResorcedRequirement[] craftingRequirements, ItemMarket itemMarket, CraftBuilding craftingBuilding)
        {
            _craftingRequirements = craftingRequirements;
            _craftingBuilding = craftingBuilding;
            _longBuyRequirement = new LongBuyRequirement();
            _fastBuyRequirement = new FastBuyRequirement();

            ItemMarket = itemMarket;

            foreach (var cr in Requirements)
            {
                cr.SetItem(this);
                cr.UpdateCost += CrOnUpdateCost;
            }

            CrOnUpdateCost();
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

        private void CrOnUpdateCost()
        {
            Cost = Requirements.Select(x => x.Cost).Where(x => x > 0).DefaultIfEmpty(0).Min();
        }

        public override string ToString()
        {
            return Id;
        }

        #region From Config

        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        private readonly BaseResorcedRequirement[] _craftingRequirements;
        private readonly CraftBuilding _craftingBuilding;
        public int ItemPower { get; set; }

        #endregion
    }
}