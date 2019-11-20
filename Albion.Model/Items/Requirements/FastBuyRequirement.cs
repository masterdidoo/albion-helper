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
                Count = 0;
                Price = 0;
                return;
            }

            Count = imd.Orders.Where(x => x.QualityLevel >= Item.QualityLevel && x.UnitPriceSilver == Price)
                .Select(x => x.Amount).DefaultIfEmpty(0).Sum();

            Price = bestOrder.UnitPriceSilver;
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.FromMarketItems[TownId];
        }

        protected override void OnUpdatePrice()
        {
            SetCost(Price, Count);
        }

        public override string Type => "FB";
    }
}