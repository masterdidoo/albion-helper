using System;

namespace Albion.Model.Data
{
    public class ItemMarket
    {
        private long _buyPrice;
        private long _sellPrice;

        public long SellPrice
        {
            get => _sellPrice;
            set
            {
                if (_sellPrice == value) return;
                _sellPrice = value;
                UpdateSellPrice?.Invoke();
            }
        }

        public long BuyPrice
        {
            get => _buyPrice;
            set
            {
                if (_buyPrice == value) return;
                _buyPrice = value;
                UpdateBuyPrice?.Invoke();
            }
        }

        public event Action UpdateSellPrice;
        public event Action UpdateBuyPrice;
    }
}