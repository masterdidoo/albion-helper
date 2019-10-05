using System;

namespace Albion.Model.Data
{
    public class ItemMarket
    {
        private long _buyPrice;
        private long _sellFastPrice;
        private long _sellLongPrice;
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

        public long SellFastPrice
        {
            get => _sellFastPrice;
            set
            {
                if (_sellFastPrice == value) return;
                _sellFastPrice = value;
                UpdateSellFastPrice?.Invoke();
            }
        }

        public long SellLongPrice
        {
            get => _sellLongPrice;
            set
            {
                if (_sellLongPrice == value) return;
                _sellLongPrice = value;
                UpdateSellLongPrice?.Invoke();
            }
        }


        public event Action UpdateSellFastPrice;
        public event Action UpdateSellLongPrice;

        public event Action UpdateSellPrice;
        public event Action UpdateBuyPrice;
    }
}