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
            var bestOrder = imd.Orders.Where(x => x.QualityLevel >= Item.QualityLevel)
                .OrderBy(x => x.UnitPriceSilver).FirstOrDefault();
            if (bestOrder == null)
            {
                SetCost(0, 0);
                return;
            }

            var cost = bestOrder.UnitPriceSilver.FastSell();
            var count = imd.Orders.Where(x => x.QualityLevel >= Item.QualityLevel && x.UnitPriceSilver == bestOrder.UnitPriceSilver)
                .Select(x => x.Amount).DefaultIfEmpty(0).Sum();

//            var count = imd.Orders.OrderBy(x => x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
//            var cost = imd.BestPrice;
            SetCost(cost, count);
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.FromMarketItems[TownId];
        }

        public override string Type => "FB";
    }
}