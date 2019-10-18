using Albion.DataStore.Managers;
using Albion.Model.Data;

namespace Albion.DataStore.Model
{
    public class ProxyMarketData : ItemMarket
    {
        private readonly MarketDataManager _manager;

        public ProxyMarketData(string id, MarketDataManager manager)
        {
            _manager = manager;

            var orders = manager.GetOrders(id);
            foreach (var marketData in orders)
                if (marketData.IsFrom)
                {
                    FromMarketItems[marketData.TownId].SetOrders(marketData.Orders, marketData.UpdateTime);
                    FromMarketItems[marketData.TownId].SetBestPrice(marketData.BestPrice);
                }
                else
                {
                    ToMarketItems[marketData.TownId].SetOrders(marketData.Orders, marketData.UpdateTime);
                    ToMarketItems[marketData.TownId].SetBestPrice(marketData.BestPrice);
                }

            for (var i = 0; i < FromMarketItems.Length; i++)
            {
                var item = FromMarketItems[i];
                var townId = i;
                item.UpdateOrders += () => manager.Save(id, townId, true, item);
            }

            for (var i = 0; i < ToMarketItems.Length; i++)
            {
                var item = ToMarketItems[i];
                var townId = i;
                item.UpdateOrders += () => manager.Save(id, townId, false, item);
            }
        }
    }
}