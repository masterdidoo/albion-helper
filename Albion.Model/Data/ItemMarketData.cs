using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public abstract class ItemMarketData
    {
        public DateTime UpdateTime { get; set; }

        public List<AuctionItem> Orders { get; set; } = new List<AuctionItem>();

        public event Action<ItemMarketData> OrdersUpdated;

        public abstract void AppendOrSetOrders(IEnumerable<AuctionItem> auctionItems);

        protected void AddOrders(IEnumerable<AuctionItem> auctionItems)
        {
            Orders.AddRange(auctionItems);
            OrdersUpdatedInvoke();
        }

        public void AppendOrders(IEnumerable<AuctionItem> auctionItems)
        {
            UpdateTime = DateTime.Now;
            var items = auctionItems.ToDictionary(k => k.Id);
            Orders.RemoveAll(x => items.ContainsKey(x.Id));
            Orders.AddRange(items.Values);
            OrdersUpdatedInvoke();
        }

        public void SetOrders(IEnumerable<AuctionItem> auctionItems, DateTime? time = null)
        {
            if (time != null) UpdateTime = time.Value;
            Orders = auctionItems.ToList();
            OrdersUpdatedInvoke();
        }

        public abstract void ClearOrders(int qualityLevel);

        protected void OrdersUpdatedInvoke()
        {
            OrdersUpdated?.Invoke(this);
        }

        public void ClearOrders()
        {
            Orders = new List<AuctionItem>();
            OrdersUpdatedInvoke();
        }
    }
}