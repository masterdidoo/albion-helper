using System.Linq;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class LongSellProfit : BaseMarketProfit
    {
        public override string Type => "LS";

        public LongSellProfit(CommonItem item, ITownManager townManager) : base(item, townManager)
        {
        }

        protected override void OrdersUpdated(ItemMarketData imd)
        {
            var bestOrder = imd.Orders.Where(x => x.QualityLevel >= Item.QualityLevel)
                .OrderBy(x => x.UnitPriceSilver).FirstOrDefault();
            if (bestOrder == null)
            {
                Price = 0;
                return;
            }

            Price = bestOrder.UnitPriceSilver.FastSell();
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.FromMarketItems[TownId];
        }

        protected void OnUpdatePrice()
        {
            var cost = Price == 0 ? 0 : (Price - 10000).LongSell(); //-1.5% and -3%
            SetIncome(cost, 1);
        }

        #region Price

        private long _price;

        public long Price
        {
            get => _price;
            set
            {
                if (_price == value) return;
                _price = value;
                RaisePropertyChanged();
                OnUpdatePrice();
            }
        }

        #endregion
    }
}