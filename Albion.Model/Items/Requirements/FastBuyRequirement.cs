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
                Price = 0;
                SetCost(0, 0);
                return;
            }

            Price = bestOrder.UnitPriceSilver;
            var cost = Price;
            var count = imd.Orders.Where(x => x.QualityLevel >= Item.QualityLevel && x.UnitPriceSilver == Price)
                .Select(x => x.Amount).DefaultIfEmpty(0).Sum();

//            var count = imd.Orders.OrderBy(x => x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
//            var cost = imd.BestPrice;
            SetCost(cost, count);
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.FromMarketItems[TownId];
        }

        protected override void OnUpdatePrice()
        {
        }

        public override string Type => "FB";
    }
}