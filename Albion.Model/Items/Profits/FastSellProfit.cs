using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseMarketProfit
    {
        public FastSellProfit(ITownManager townManager) : base(townManager)
        {
        }

        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[TownId];

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver * 3 / 100; //-3%
        }
    }
}