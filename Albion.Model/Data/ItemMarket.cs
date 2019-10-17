using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemMarket
    {
        public MinItemMarketData[] FromMarketItems { get; }
        public MaxItemMarketData[] ToMarketItems { get; }

        public ItemMarket()
        {
            FromMarketItems = Enumerable.Repeat(0, (int)Location.None).Select(x => new MinItemMarketData()).ToArray();
            ToMarketItems = Enumerable.Repeat(0, (int)Location.None).Select(x => new MaxItemMarketData()).ToArray();
        }
}
}