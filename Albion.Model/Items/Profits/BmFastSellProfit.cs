using System.Linq;
using Albion.Common;
using Albion.Model.Data;

namespace Albion.Model.Items.Profits
{
    public class BmFastSellProfit : BaseProfit
    {
        public BmFastSellProfit(CommonItem item) : base(item)
        {
            Item.ItemMarket.ToMarketItems[(int) Location.BlackMarket].OrdersUpdated += OnOrdersUpdated;
        }

        private void OnOrdersUpdated(ItemMarketData imd)
        {
            var count = imd.Orders.OrderByDescending(x => x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
            var income = imd.BestPrice.FastSell();
            SetIncome(income, count);
        }
    }
}