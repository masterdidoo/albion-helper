using System;

namespace Albion.Db.Items
{
    public class PriceItem
    {
        public bool IsMin { get; set; }

        public DateTime Time { get; set; }

        public long Price { get; set; }
    }
}