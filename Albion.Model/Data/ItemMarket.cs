using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemMarket
    {
        public ItemMarketData[] FromMarketItems { get; } = new ItemMarketData[(int) Location.None];
        public ItemMarketData[] ToMarketItems { get; } = new ItemMarketData[(int) Location.None];

//        public ItemMarketData FastSaleItem { get; } = new MinItemMarketData();
//        public ItemMarketData LongSaleItem { get; } = new MaxItemMarketData();
//        public ItemMarketData FastBuyItem { get; } = new MaxItemMarketData();
//        public ItemMarketData LongBuyItem { get; } = new MinItemMarketData();
    }
}