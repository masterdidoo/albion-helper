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
            var count = imd.Orders.OrderByDescending(x => x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
            var income = imd.BestPrice.FastSell();
            SetIncome(income, count);
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.ToMarketItems[TownId];
        }
    }
}