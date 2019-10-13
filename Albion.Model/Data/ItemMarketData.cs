using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemMarketData
    {
        private long _bestPrice;

        public long BestPrice
        {
            get => _bestPrice;
            set
            {
                if (_bestPrice == value) return;
                _bestPrice = value;
                UpdateBestPrice?.Invoke();
            }
        }

        public DateTime UpdateTime { get; set; }

        public List<AuctionItem> Orders { get; set; } = new List<AuctionItem>();

        public event Action UpdateBestPrice;

        public event Action UpdateOrders;

        public void AppendOrders(IEnumerable<AuctionItem> auctionItems)
        {
            UpdateTime = DateTime.Now;
            var items = auctionItems.ToDictionary(k => k.Id);
            Orders.RemoveAll(x => items.ContainsKey(x.Id));
            Orders.AddRange(items.Values);
            UpdateOrders?.Invoke();
        }

        public void SetOrders(IEnumerable<AuctionItem> auctionItems)
        {
            UpdateTime = DateTime.Now;
            Orders = auctionItems.ToList();
            UpdateOrders?.Invoke();
        }
    }
}