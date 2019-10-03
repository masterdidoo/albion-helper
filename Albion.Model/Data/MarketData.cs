using System;
using Albion.Common;

namespace Albion.Model.Data
{
    public class MarketData
    {
        public PriceData[] SellPriceDatas { get; set; } = new PriceData[(int) (Location.None + 1)];
        public PriceData[] BuyPriceDatas { get; set; } = new PriceData[(int) (Location.None + 1)];

        public event Action UpdateSellPrice;
        public event Action UpdateBuyPrice;
    }
}