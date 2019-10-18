using System;
using System.Collections;
using System.Collections.Generic;
using Albion.DataStore.DataModel;
using Albion.DataStore.Model;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.DataStore.Managers
{
    public class MarketDataManager : BaseDataManager<OrdersData, ItemMarket>, IMarketDataManager
    {
        protected override ItemMarket CreateData(string id)
        {
            return new ProxyMarketData(id, this);
        }

        public IEnumerable<OrdersData> GetOrders(string id)
        {
            return Rep.Find(e => e.ItemId == id);
        }

        public void Save(string id, int townId, bool isFrom, ItemMarketData item)
        {
            Rep.Upsert(new OrdersData()
            {
                Id = $"{id}-{isFrom}-{townId}",
                ItemId = id,
                TownId = townId,
                IsFrom = isFrom,
                Orders = item.Orders,
                UpdateTime = item.UpdateTime,
                BestPrice = item.BestPrice,
            });
        }
    }
}