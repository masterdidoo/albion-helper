using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemToMarketData : ItemMarketData
    {
        public override void AppendOrSetOrders(IEnumerable<AuctionItem> auctionItems)
        {
            var max = auctionItems.Select(k => k.QualityLevel).DefaultIfEmpty(0).Max();
            Orders.RemoveAll(x => x.QualityLevel <= max);
            AddOrders(auctionItems);
        }

        public override void ClearOrders(int qualityLevel)
        {
            Orders.RemoveAll(x => x.QualityLevel <= qualityLevel); //to
            OrdersUpdatedInvoke();
        }
    }
}