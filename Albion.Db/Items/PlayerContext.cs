using System;

namespace Albion.Db.Items
{
    public class PlayerContext : IPlayerContext
    {
        public PlayerContext()
        {
        }

        public int TownIndex { get; set; }

        public long GetCraftTax(ShopCategory shopCategory)
        {
            return 10;
        }

        public event Action TownIndexChanged;
    }
}