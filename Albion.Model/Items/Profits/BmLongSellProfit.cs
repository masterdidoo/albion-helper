using Albion.Common;
using Albion.Model.Data;

namespace Albion.Model.Items.Profits
{
    public class BmLongSellProfit : BaseProfit
    {
        public override string Type => "BL";

        public BmLongSellProfit(CommonItem item) : base(item)
        {
            GetMarketData().OrdersUpdated += OnOrdersUpdated;
        }

        private void OnOrdersUpdated(ItemMarketData imd)
        {
            Price = imd.BestPrice;
        }

        protected ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.FromMarketItems[(int)Location.BlackMarket];
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
                if (_price != GetMarketData().BestPrice)
                    GetMarketData().SetBestPrice(_price);
            }
        }

        #endregion
    }
}