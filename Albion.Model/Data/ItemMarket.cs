﻿using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemMarket
    {
        private long _buyPrice;
        private long _sellFastPrice;
        private long _sellLongPrice;
        public ItemMarketData FastSaleItem { get; set; } = new ItemMarketData();
        public ItemMarketData LongSaleItem { get; set; } = new ItemMarketData();
        public ItemMarketData FastBuyItem { get; set; } = new ItemMarketData();
        public ItemMarketData LongBuyItem { get; set; } = new ItemMarketData();

        public long BuyPrice
        {
            get => _buyPrice;
            set
            {
                if (_buyPrice == value) return;
                _buyPrice = value;
                UpdateBuyPrice?.Invoke();
            }
        }

        public long SellFastPrice
        {
            get => _sellFastPrice;
            set
            {
                if (_sellFastPrice == value) return;
                _sellFastPrice = value;
                UpdateSellFastPrice?.Invoke();
            }
        }

        public long SellLongPrice
        {
            get => _sellLongPrice;
            set
            {
                if (_sellLongPrice == value) return;
                _sellLongPrice = value;
                UpdateSellLongPrice?.Invoke();
            }
        }

        public DateTime SellFastPos { get; set; }
        public DateTime SellLongPos { get; set; }
        public DateTime BuyPos { get; set; }
        public DateTime SellPos { get; set; }

        public List<AuctionItem> AuctionBuyOffers { get; set; } = new List<AuctionItem>();


        public event Action UpdateSellFastPrice;
        public event Action UpdateSellLongPrice;

        public event Action UpdateSellPrice;
        public event Action UpdateBuyPrice;

        public void SetBuyOffers(Location sellTown, IEnumerable<AuctionItem> auctionItems)
        {
            AuctionBuyOffers = auctionItems.ToList();
        }

        public void AppendBuyOffers(Location sellTown, IEnumerable<AuctionItem> auctionItems)
        {
            var items = auctionItems.ToDictionary(k => k.Id);
            AuctionBuyOffers.RemoveAll(x => items.ContainsKey(x.Id));
            AuctionBuyOffers.AddRange(items.Values);
        }
    }

    public class MarketOrder
    {
        public long Price { get; set; }
        public int Count { get; set; }
    }
}