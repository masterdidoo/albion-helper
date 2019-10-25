using System;
using System.Collections.Generic;
using Albion.Common;

namespace Albion.DataStore.DataModel
{
    public class OrdersData
    {
        public int Id { get; set; }

        public string ItemId { get; set; }
        public int TownId { get; set; }
        public List<AuctionItem> Orders { get; set; }
        public bool IsFrom { get; set; }
        public DateTime UpdateTime { get; set; }
        public long BestPrice { get; set; }
    }
}