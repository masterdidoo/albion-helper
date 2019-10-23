using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class LongSellProfit : BaseMarketProfit
    {
        public LongSellProfit(CommonItem item, ITownManager townManager) : base(item, townManager)
        {
        }

        protected override void OrdersUpdated(ItemMarketData imd)
        {
            Price = imd.BestPrice;
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.FromMarketItems[TownId];
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
                SetIncome(_price.LongSell(), 1); //-1.5% and -3%
            }
        }

        #endregion
    }
}