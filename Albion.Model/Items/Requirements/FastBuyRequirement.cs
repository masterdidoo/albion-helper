using Albion.Model.Data;

namespace Albion.Model.Items.Requirements
{
    public class FastBuyRequirement : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.FromMarketItems[(int)CostCalcOptions.Instance.BuyTown];

        public FastBuyRequirement()
        {
            CostCalcOptions.Instance.BuyTownChanged += OnSetItem;
        }

        protected override void OnUpdateSilver()
        {
            Cost = Silver;
        }
    }
}