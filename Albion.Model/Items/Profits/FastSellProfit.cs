using Albion.Model.Data;
using Albion.Model.Items.Requirements;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[TownId];

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver * 3 /100;//-3%
        }

        public FastSellProfit(ITownManager townManager) : base(townManager)
        {
        }
    }
}