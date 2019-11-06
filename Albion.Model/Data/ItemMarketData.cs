using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemMarketData
    {
        public DateTime UpdateTime { get; set; }

        public List<AuctionItem> Orders { get; set; } = new List<AuctionItem>();

        public event Action<ItemMarketData> OrdersUpdated;

        public void AppendOrSetOrders(IEnumerable<AuctionItem> auctionItems)
        {
            var max = auctionItems.Select(k => k.QualityLevel).DefaultIfEmpty(0).Max();
            var min = auctionItems.Select(k => k.QualityLevel).DefaultIfEmpty(0).Min();
            Orders.RemoveAll(x => x.QualityLevel >= min && x.QualityLevel <= max);
            Orders.AddRange(auctionItems);
            OrdersUpdated?.Invoke(this);
        }

        public void AppendOrders(IEnumerable<AuctionItem> auctionItems)
        {
            UpdateTime = DateTime.Now;
            var items = auctionItems.ToDictionary(k => k.Id);
            Orders.RemoveAll(x => items.ContainsKey(x.Id));
            Orders.AddRange(items.Values);
            OrdersUpdated?.Invoke(this);
        }

        public void SetOrders(IEnumerable<AuctionItem> auctionItems, DateTime? time = null)
        {
            if (time != null) UpdateTime = time.Value;
            Orders = auctionItems.ToList();
            OrdersUpdated?.Invoke(this);
        }

        public void ClearOrders()
        {
            Orders = new List<AuctionItem>();
            OrdersUpdated?.Invoke(this);
        }
    }
}