using Albion.Model.Data;
using Albion.Model.Managers;
using System.Linq;

namespace Albion.Model.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        public LongBuyRequirement(ITownManager townManager) : base(townManager)
        {
        }

        protected override void OrdersUpdated(ItemMarketData imd)
        {
            var bestOrder = imd.Orders.Where(x => x.QualityLevel <= Item.QualityLevel)
                .OrderByDescending(x => x.UnitPriceSilver).FirstOrDefault();
            if (bestOrder == null)
            {
                Price = 0;
                return;
            }

            Price = bestOrder.UnitPriceSilver;
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.ToMarketItems[TownId];
        }

        protected override void OnUpdatePrice()
        {
            var cost = Price == 0 ? 0 : Price + 10000 + (Price + 10000) * 15 / 1000; //+1 silver and +1,5%
            SetCost(cost, 1);
        }


        public override string Type => "LB";
    }
}