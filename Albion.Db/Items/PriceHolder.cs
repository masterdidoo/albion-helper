using System;

namespace Albion.Db.Items
{
    public class PriceHolder
    {
        public PriceItem Sell { get; } = new PriceItem();

        public PriceItem Bye { get; } = new PriceItem();

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