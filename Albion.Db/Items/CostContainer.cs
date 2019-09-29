using System;
using System.Linq;
using Albion.Common;

namespace Albion.Db.Items
{
    public class PricesContainer
    {
        public PricesContainer()
        {
            BuyPrices = new long?[(int)Location.None + 1];
            BuyTimes = new DateTime?[(int)Location.None + 1];

            SellPrices = new long?[(int)Location.None + 1];
            SellTimes = new DateTime?[(int)Location.None + 1];

            BuyPricesList = new AuctionItem[(int)Location.None + 1][];
            SellPricesList = new AuctionItem[(int)Location.None + 1][];
        }

        public PricesContainer(int size)
        {
            BuyPrices = new long?[(int) Location.None + 1];
            BuyTimes = new DateTime?[(int) Location.None + 1];

            SellPrices = new long?[(int) Location.None + 1];
            SellTimes = new DateTime?[(int) Location.None + 1];

            BuyPricesList = new AuctionItem[(int)Location.None + 1][];
            SellPricesList = new AuctionItem[(int)Location.None + 1][];
        }

        public string Id { get; set; }

        public long?[] BuyPrices { get; set; }
        public DateTime?[] BuyTimes { get; set; }

        public long?[] SellPrices { get; set; }
        public DateTime?[] SellTimes { get; set; }

        public AuctionItem[][] BuyPricesList { get; }
        public AuctionItem[][] SellPricesList { get; }
    }

    public class CostContainer
    {
        private readonly PricesContainer _pricesContainer;

        public CostContainer(IPlayerContext context, SimpleItem item)
        {
            Context = context;
            Item = item;

            if (context != null) context.TownIndexChanged += ContextOnTownIndexChanged;

            _pricesContainer = context?.LoadPricesContainer(item.Id) ?? new PricesContainer(0);

//            context.TownIndexChanged += Updated;
        }

        private IPlayerContext Context { get; }
        private SimpleItem Item { get; }

        public long CraftTax => Item.ItemValue * 5 / 100 * Context.GetCraftTax(Item.ShopCategory); //10% tax

        public long? SellPrice
        {
            get => _pricesContainer.SellPrices[Context.TownIndex];
            set => _pricesContainer.SellPrices[Context.TownIndex] = value;
        }

        public DateTime? SellTime => _pricesContainer.SellTimes[Context.TownIndex];

        public long? BuyPrice
        {
            get => _pricesContainer.BuyPrices[Context.TownIndex];
            set => _pricesContainer.BuyPrices[Context.TownIndex] = value;
        }

        public DateTime? BuyTime => _pricesContainer.BuyTimes[Context.TownIndex];

        public long CraftReturn => Context.GetReturn(Item.Craftingcategory);

        public long? SellPrice2 => _pricesContainer.SellPrices[Context.TownIndexSell];
        public long? BuyPrice2 => _pricesContainer.BuyPrices[Context.TownIndexSell];
        public DateTime? SellTime2 => _pricesContainer.SellTimes[Context.TownIndexSell];
        public DateTime? BuyTime2 => _pricesContainer.BuyTimes[Context.TownIndexSell];
        public event Action SellUpdated;

        private void ContextOnTownIndexChanged()
        {
            Updated?.Invoke();
            SellUpdated?.Invoke();
        }

        public event Action Updated;

        public void Save()
        {
            Context.SavePricesContainer(Item.Id, _pricesContainer);
        }

        #region Update From Net

        public void UpdateBye(IGrouping<string, AuctionItem> item, bool isSngle)
        {
            var arr = item.ToArray();
            if (arr.Length > 1)
            {
                _pricesContainer.BuyPricesList[Context.TownIndexSell] = arr;
            }
            var max = arr.Max(x => x.UnitPriceSilver);
            UpdateBye(max, isSngle);
        }

        public bool UpdateBye(long price, bool isSngle)
        {
            if (!isSngle)
                if (price < _pricesContainer.BuyPrices[Context.TownIndex])
                    return false;

            _pricesContainer.BuyPrices[Context.TownIndexSell] = price;
            _pricesContainer.BuyTimes[Context.TownIndexSell] = DateTime.Now;

            Update();

            return true;
        }

        public void UpdateSell(IGrouping<string, AuctionItem> item, bool isSngle)
        {
            var arr = item.ToArray();
            if (arr.Length > 1)
            {
                _pricesContainer.SellPricesList[Context.TownIndexSell] = arr;
            }
            var min = arr.Min(x => x.UnitPriceSilver);
            UpdateSell(min, isSngle);
        }

        public bool UpdateSell(long price, bool isSngle)
        {
            if (!isSngle)
                if (price > _pricesContainer.SellPrices[Context.TownIndex])
                    return false;

            _pricesContainer.SellPrices[Context.TownIndexSell] = price;
            _pricesContainer.SellTimes[Context.TownIndexSell] = DateTime.Now;

            Update();

            return true;
        }

        private void Update()
        {
            //Context.SavePricesContainer(Item.Id, _pricesContainer);
            if (Context.TownSell == Context.Town) Updated();
            else SellUpdated();
        }

        #endregion
    }
}