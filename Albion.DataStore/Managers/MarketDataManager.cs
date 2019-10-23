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
            throw new NotImplementedException();
        }

        public IEnumerable<OrdersData> GetOrders()
        {
            return Rep.FindAll();
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