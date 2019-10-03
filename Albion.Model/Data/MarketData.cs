using System;
using Albion.Common;

namespace Albion.Model.Data
{
    public class MarketData
    {
        private long _buyPrice;
        private long _sellPrice;
        public PriceData[] SellPriceDatas { get; set; } = new PriceData[(int) (Location.None + 1)];
        public PriceData[] BuyPriceDatas { get; set; } = new PriceData[(int) (Location.None + 1)];

        public long SellPrice
        {
            get => _sellPrice;
            set
            {
                if (_sellPrice == value) return;
                _sellPrice = value;
                UpdateSellPrice?.Invoke(value);
            }
        }

        public long BuyPrice
        {
            get => _buyPrice;
            set
            {
                if (_buyPrice == value) return;
                _buyPrice = value;
                UpdateBuyPrice?.Invoke(value);
            }
        }

        public event Action<long> UpdateSellPrice;
        public event Action<long> UpdateBuyPrice;
    }
}