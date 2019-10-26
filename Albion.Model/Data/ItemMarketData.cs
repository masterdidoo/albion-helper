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
        public long BestPrice { get; set; }

        public DateTime UpdateTime { get; set; }

        public List<AuctionItem> Orders { get; set; } = new List<AuctionItem>();

        public event Action<ItemMarketData> OrdersUpdated;

        public void AppendOrders(IEnumerable<AuctionItem> auctionItems)
        {
            UpdateTime = DateTime.Now;
            var items = auctionItems.ToDictionary(k => k.Id);
            Orders.RemoveAll(x => items.ContainsKey(x.Id));
            Orders.AddRange(items.Values);
            BestPrice = GetBestPrice();
            OrdersUpdated?.Invoke(this);
        }

        protected abstract long GetBestPrice();

        public void SetOrders(IEnumerable<AuctionItem> auctionItems, DateTime? time = null, bool isSilent = false)
        {
            if (time != null) UpdateTime = time.Value;
            Orders = auctionItems.ToList();
            BestPrice = GetBestPrice();
            if (!isSilent) OrdersUpdated?.Invoke(this);
        }

        public void SetBestPrice(long silver)
        {
            //if (BestPrice == silver) return;
            BestPrice = silver;
            OrdersUpdated?.Invoke(this);
        }
    }
}