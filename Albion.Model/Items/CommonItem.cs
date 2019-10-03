using System.Collections.Generic;
using System.Linq;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Requirements;

namespace Albion.Model.Items
{
    public class CommonItem : BaseCostableEntity
    {
        public CommonItem(CraftingRequirement[] craftingRequirements)
        {
            CraftingRequirements = craftingRequirements;
            LongBuyRequirement = new LongBuyRequirement();
            FastBuyRequirement = new FastBuyRequirement();

            foreach (var cr in Requirements)
            {
                cr.SetParent(this);
                cr.UpdateCost += CrOnUpdateCost;
            }
        }

        #region From Config

        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        public CraftingRequirement[] CraftingRequirements { get; }
        public int ItemPower { get; set; }

        #endregion

        public IEnumerable<BaseRequirement> Requirements
        {
            get
            {
                yield return FastBuyRequirement;
                yield return LongBuyRequirement;
                foreach (var cr in CraftingRequirements)
                {
                    yield return cr;
                }
            }
        }

        public LongBuyRequirement LongBuyRequirement { get; }
        public FastBuyRequirement FastBuyRequirement { get; }

        public MarketData MarketData { get; set; }
        public Building Building { get; set; }

        private void CrOnUpdateCost()
        {
            Cost = CraftingRequirements.Min(x => x.Cost);
        }

        public override string ToString()
        {
            return Id;
        }
    }

    public class FastBuyRequirement : BaseRequirement
    {
        protected override void OnSetParent(CommonItem item)
        {
            item.MarketData.UpdateSellPrice += OnUpdateSellPrice;
        }

        private void OnUpdateSellPrice()
        {
            throw new System.NotImplementedException();
        }
    }

    public class LongBuyRequirement : BaseRequirement
    {
        protected override void OnSetParent(CommonItem item)
        {
            item.MarketData.UpdateBuyPrice += OnUpdateBuyPrice;
        }

        private void OnUpdateBuyPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}