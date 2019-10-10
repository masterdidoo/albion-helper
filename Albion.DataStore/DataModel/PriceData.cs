using System;
using System.Collections.Generic;
using Albion.Common;

namespace Albion.DataStore.DataModel
{
    public class PriceData
    {
        public long Price { get; set; }
        public DateTime Pos { get; set; }

        public List<AuctionItem> AuctionItems { get; set; }
    }
}