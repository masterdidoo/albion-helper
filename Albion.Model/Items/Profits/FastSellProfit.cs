using Albion.Model.Data;
using Albion.Model.Items.Requirements;

namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[(int) CostCalcOptions.Instance.SellTown];

        public FastSellProfit()
        {
            CostCalcOptions.Instance.SellTownChanged += OnSetItem;
        }

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver * 3 /100;//-3%
        }
    }
}