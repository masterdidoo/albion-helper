using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemMarket
    {
        public MinItemMarketData[] FromMarketItems { get; } = new MinItemMarketData[(int) Location.None];
        public MaxItemMarketData[] ToMarketItems { get; } = new MaxItemMarketData[(int) Location.None];
    }
}