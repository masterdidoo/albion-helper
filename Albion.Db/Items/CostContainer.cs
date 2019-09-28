using System;
using Albion.Common;
using Albion.Db.Items.Requirements;

namespace Albion.Db.Items
{
    public class PricesContainer
    {
        public PricesContainer() { }
        public PricesContainer(int size)
        {
            BuyPrices = new long[(int)Location.None + 1];
            BuyTimes = new DateTime[(int)Location.None + 1];

            SellPrices = new long[(int)Location.None + 1];
            SellTimes = new DateTime[(int)Location.None + 1];
        }

        public string Id { get; set; }

        public long[] BuyPrices { get; set; }
        public DateTime[] BuyTimes { get; set; }

        public long[] SellPrices { get; set; }
        public DateTime[] SellTimes { get; set; }
    }

    public class CostContainer
    {
        private readonly PricesContainer _pricesContainer;

        public CostContainer(IPlayerContext context, SimpleItem item)
        {
            Context = context;
            Item = item;

            if (context != null) context.TownIndexChanged += ContextOnTownIndexChanged;

            _pricesContainer = context?.LoadPricesContainer(item.Id);

            if (_pricesContainer == null)
            {
                _pricesContainer = new PricesContainer(0);

                for (var i = 0; i < _pricesContainer.SellPrices.Length; i++)
                {
                    _pricesContainer.SellPrices[i] = BaseRequirement.MaxNullPrice;
                    _pricesContainer.BuyPrices[i] = -BaseRequirement.MaxNullPrice;
                }
            }


//            context.TownIndexChanged += Updated;
        }

        private void ContextOnTownIndexChanged()
        {
            Updated?.Invoke();
        }

        private IPlayerContext Context { get; }
        private SimpleItem Item { get; }

        public long CraftTax => Item.ItemValue * 5 / 100 * Context.GetCraftTax(Item.ShopCategory); //10% tax

        public long SellPrice => _pricesContainer.SellPrices[Context.TownIndex];
        public DateTime SellTime => _pricesContainer.SellTimes[Context.TownIndex];
        public long BuyPrice => _pricesContainer.BuyPrices[Context.TownIndex];
        public DateTime BuyTime => _pricesContainer.BuyTimes[Context.TownIndex];

        public long CraftReturn => Context.GetReturn(Item.Craftingcategory);

        public event Action Updated;

        #region Update From Net

        public bool UpdateBye(long price, bool isSngle)
        {
            if (!isSngle)
                if (price < _pricesContainer.BuyPrices[Context.TownIndex])
                    return false;

            _pricesContainer.BuyPrices[Context.TownIndex] = price;
            _pricesContainer.BuyTimes[Context.TownIndex] = DateTime.Now;

            Update();

            return true;
        }

        public bool UpdateSell(long price, bool isSngle)
        {
            if (!isSngle)
                if (price > _pricesContainer.SellPrices[Context.TownIndex])
                    return false;

            _pricesContainer.SellPrices[Context.TownIndex] = price;
            _pricesContainer.SellTimes[Context.TownIndex] = DateTime.Now;

            Update();

            return true;
        }

        private void Update()
        {
            Context.SavePricesContainer(Item.Id, _pricesContainer);
            Updated();
        }

        #endregion
    }
}