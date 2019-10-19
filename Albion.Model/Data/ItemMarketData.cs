using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class MinItemMarketData : ItemMarketData
    {
        protected override long GetBestPrice()
        {
            return Orders.Select(x => x.UnitPriceSilver).DefaultIfEmpty(0).Min(x => x);
        }
    }
    public class MaxItemMarketData : ItemMarketData
    {
        protected override long GetBestPrice()
        {
            return Orders.Select(x => x.UnitPriceSilver).DefaultIfEmpty(0).Max(x=>x);
        }
    }
    public abstract class ItemMarketData
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
            BestPrice = GetBestPrice();
            UpdateOrders?.Invoke();
        }

        protected abstract long GetBestPrice();

        public void SetOrders(IEnumerable<AuctionItem> auctionItems, DateTime time)
        {
            UpdateTime = time;
            Orders = auctionItems.ToList();
            BestPrice = GetBestPrice();
            UpdateOrders?.Invoke();
        }

        public void SetBestPrice(long silver)
        {
            if (BestPrice == silver) return;
            BestPrice = silver;
            UpdateOrders?.Invoke();
        }
    }
}