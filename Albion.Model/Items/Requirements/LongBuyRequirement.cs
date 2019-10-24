using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        public LongBuyRequirement(ITownManager townManager) : base(townManager)
        {
        }

        protected override void OrdersUpdated(ItemMarketData imd)
        {
            Price = imd.BestPrice;
        }

        protected override ItemMarketData GetMarketData()
        {
            return Item.ItemMarket.ToMarketItems[TownId];
        }

        protected void OnUpdatePrice()
        {
            var cost = Price == 0 ? 0 : Price + 10000 + (Price + 10000) * 15 / 1000; //+1 silver and +1,5%
            SetCost(cost, 1);
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