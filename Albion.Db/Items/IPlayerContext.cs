using System;

namespace Albion.Db.Items
{
    public interface IPlayerContext
    {
        int TownIndex { get; set; }
        long GetCraftTax(ShopCategory shopCategory);

        event Action TownIndexChanged;
    }
}