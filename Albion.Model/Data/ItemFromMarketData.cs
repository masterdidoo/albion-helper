using System.Collections.Generic;
using System.Linq;
using Albion.Common;

namespace Albion.Model.Data
{
    public class ItemFromMarketData : ItemMarketData
    {
        public override void AppendOrSetOrders(IEnumerable<AuctionItem> auctionItems)
        {
            var min = auctionItems.Select(k => k.QualityLevel).DefaultIfEmpty(10).Min();
            Orders.RemoveAll(x => x.QualityLevel >= min);
            AddOrders(auctionItems);
        }

        public override void ClearOrders(int qualityLevel)
        {
            Orders.RemoveAll(x => x.QualityLevel >= qualityLevel); //from
            OrdersUpdatedInvoke();
        }
    }
}