using Albion.Model.Data;
using Albion.Model.Items.Requirements;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class LongSellProfit : BaseMarketProfit
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.FromMarketItems[TownId];

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver * 45 / 1000; //-1.5% and -3%
        }

        public LongSellProfit(ITownManager townManager) : base(townManager)
        {
        }
    }
}