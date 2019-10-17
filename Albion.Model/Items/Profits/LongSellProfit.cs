using Albion.Model.Data;
using Albion.Model.Items.Requirements;

namespace Albion.Model.Items.Profits
{
    public class LongSellProfit : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.FromMarketItems[(int)CostCalcOptions.Instance.SellTown];

        public LongSellProfit()
        {
            CostCalcOptions.Instance.SellTownChanged += OnSetItem;
        }

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver * 45 / 1000; //-1.5% and -3%
        }
    }
}