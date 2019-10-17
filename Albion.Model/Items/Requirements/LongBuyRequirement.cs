using Albion.Model.Data;

namespace Albion.Model.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[(int) CostCalcOptions.Instance.BuyTown];

        public LongBuyRequirement()
        {
            CostCalcOptions.Instance.BuyTownChanged += OnSetItem;
        }

        protected override void OnUpdateSilver()
        {
            Cost = Silver == 0 ? 0 : (Silver + 10000) + (Silver + 10000) * 15 / 1000; //+1 silver and +1,5%
        }
    }
}