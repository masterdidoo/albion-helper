using System;
using Albion.Common;

namespace Albion.Db.Items
{
    public interface IPlayerContext
    {
        int TownIndex { get; }
        Location Town { get; set; }
        long GetCraftTax(ShopCategory shopCategory);

        event Action TownIndexChanged;
        void SavePricesContainer(string id, PricesContainer pricesContainer);
        PricesContainer LoadPricesContainer(string id);
        long GetReturn(Craftingcategory category);
    }
}