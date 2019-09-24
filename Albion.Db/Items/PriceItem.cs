using System;

namespace Albion.Db.Items
{
    public class PriceItem
    {
        public bool IsCnown { get; set; }

        public DateTime Time { get; set; }

        public long Price { get; set; }
    }
}