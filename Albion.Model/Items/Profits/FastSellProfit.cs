using Albion.Model.Data;
using Albion.Model.Items.Requirements;

namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.FastSaleItem;

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver * 3 /100;//-3%
        }
    }
}