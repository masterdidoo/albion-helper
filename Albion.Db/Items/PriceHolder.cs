using System;
using Albion.Common;
using GalaSoft.MvvmLight;

namespace Albion.Db.Items
{
    public class PriceHolder
    {
        private readonly IPlayerContext _context;

        public PriceHolder(IPlayerContext context)
        {
            this._context = context;
        }

        public PriceItem[] Sells { get; } = new PriceItem[(int) Location.None];
        public PriceItem[] Byes { get; } = new PriceItem[(int) Location.None];

        public PriceItem Sell => Sells[_context.TownIndex];

        public PriceItem Bye => Byes[_context.TownIndex];

        public void UpdateBye(long price, bool isSngle)
        {
            if (!isSngle)
                if (price < Bye.Price || Bye.Time == DateTime.MinValue)
                    return;

            Bye.Price = price;
            Bye.Time = DateTime.Now;
        }

        public void UpdateSell(long price, bool isSngle)
        {
            if (!isSngle)
                if (price > Sell.Price || Sell.Time == DateTime.MinValue)
                    return;

            Sell.Price = price;
            Sell.Time = DateTime.Now;
        }
    }
}