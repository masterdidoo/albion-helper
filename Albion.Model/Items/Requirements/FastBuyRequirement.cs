using System.Linq;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Requirements
{
    public class FastBuyRequirement : BaseMarketRequirement
    {
        public FastBuyRequirement(ITownManager townManager) : base(townManager)
        {
        }

        protected override void OrdersUpdated(ItemMarketData imd)
        {
            var count = imd.Orders.OrderByDescending(x => x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
            var cost = imd.BestPrice;
            SetCost(cost, count);
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.FromMarketItems[TownId];
        }

        public override string Type => "FB";
    }
}