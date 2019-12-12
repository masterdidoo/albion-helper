using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemMarket
    {
        public ItemFromMarketData[] FromMarketItems { get; }
        public ItemToMarketData[] ToMarketItems { get; }

        public ItemMarket()
        {
            FromMarketItems = Enumerable.Repeat(0, (int)Location.None+1).Select(x => new ItemFromMarketData()).ToArray();
            ToMarketItems = Enumerable.Repeat(0, (int)Location.None+1).Select(x => new ItemToMarketData()).ToArray();
        }
}
}