using System.Collections.Generic;
using System.Linq;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Requirements;

namespace Albion.Model.Items
{
    public class CommonItem : BaseCostableEntity
    {
        private readonly FastBuyRequirement _fastBuyRequirement;
        private readonly LongBuyRequirement _longBuyRequirement;

        public CommonItem(BaseResorcedRequirement[] craftingRequirements)
        {
            _craftingRequirements = craftingRequirements;
            _longBuyRequirement = new LongBuyRequirement();
            _fastBuyRequirement = new FastBuyRequirement();

            MarketData = new MarketData();
            BuildingData = new BuildingData();

            foreach (var cr in Requirements)
            {
                cr.SetParent(this);
                cr.UpdateCost += CrOnUpdateCost;
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

        public int MemId { get; set; }

        public MarketData MarketData { get; }
        public BuildingData BuildingData { get; }

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
        public int ItemPower { get; set; }

        #endregion
    }
}