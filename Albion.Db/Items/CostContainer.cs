using System;
using Albion.Common;

namespace Albion.Db.Items
{
    public class CostContainer
    {
        public long[] BuyPrices = new long[(int) Location.None + 1];
        public DateTime[] BuyTimes = new DateTime[(int) Location.None + 1];

        public long[] SellPrices = new long[(int) Location.None + 1];
        public DateTime[] SellTimes = new DateTime[(int) Location.None + 1];

        public CostContainer(IPlayerContext context, SimpleItem item)
        {
            Context = context;
            Item = item;
//            context.TownIndexChanged += Updated;
        }

        private IPlayerContext Context { get; }
        private SimpleItem Item { get; }

        public long CraftTax => Item.ItemValue * 5 / 100 * Context.GetCraftTax(Item.ShopCategory); //10% tax

        public long SellPrice => SellPrices[Context.TownIndex];
        public DateTime SellTime => SellTimes[Context.TownIndex];
        public long BuyPrice => BuyPrices[Context.TownIndex];
        public DateTime BuyTime => BuyTimes[Context.TownIndex];

        public event Action Updated;

        #region Update From Net

        public void UpdateBye(long price, bool isSngle)
        {
            if (!isSngle)
                if (price < BuyPrices[Context.TownIndex] || BuyTimes[Context.TownIndex] == DateTime.MinValue)
                    return;

            BuyPrices[Context.TownIndex] = price;
            BuyTimes[Context.TownIndex] = DateTime.Now;

            Updated();
        }

        public void UpdateSell(long price, bool isSngle)
        {
            if (!isSngle)
                if (price > SellPrices[Context.TownIndex] || SellTimes[Context.TownIndex] == DateTime.MinValue)
                    return;

            SellPrices[Context.TownIndex] = price;
            SellTimes[Context.TownIndex] = DateTime.Now;

            Updated();
        }

        #endregion
    }
}