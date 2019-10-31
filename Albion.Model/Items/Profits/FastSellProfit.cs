using System.Linq;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseMarketProfit
    {
        public FastSellProfit(CommonItem item, ITownManager townManager) : base(item, townManager)
        {
        }

        protected override void OrdersUpdated(ItemMarketData imd)
        {
            var bestOrder = imd.Orders.Where(x => x.QualityLevel <= Item.QualityLevel)
                .OrderByDescending(x => x.UnitPriceSilver).FirstOrDefault();
            if (bestOrder == null)
            {
                SetIncome(0, 0);
                return;
            }

            Price = bestOrder.UnitPriceSilver;

            var income = Price.FastSell();
            var count = imd.Orders.Where(x => x.QualityLevel <= Item.QualityLevel && x.UnitPriceSilver == Price)
                .Select(x => x.Amount).DefaultIfEmpty(0).Sum();
//            var count = bestOrder?.Amount ?? 0;
//            var income = bestOrder?.UnitPriceSilver.FastSell() ?? 0;
//            var count = imd.Orders.Where(x=>x.QualityLevel <= Item.QualityLevel).OrderByDescending(x => x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
//            var income = imd.BestPrice.FastSell();
            SetIncome(income, count);
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.ToMarketItems[TownId];
        }

        public override string Type => "FS";

        protected override void OnUpdatePrice()
        {
        }
    }
}