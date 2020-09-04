using System;
using System.Collections.Generic;
using System.Linq;
using Albion.DataStore.DataModel;
using Albion.Model.Data;
using Albion.Model.Managers;
using LiteDB;

namespace Albion.DataStore.Managers
{
    public class MarketDataManager : BaseDataManager<OrdersData, ItemMarket>, IMarketDataManager
    {
        private readonly object _lockObject = new object();

        public MarketDataManager()
        {
            SelectedItemRep = Db.GetCollection<SelectedItem>();
        }

        private LiteCollection<SelectedItem> SelectedItemRep { get; }

        protected override ItemMarket CreateData(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrdersData> GetOrders()
        {
            return Rep.FindAll();
        }

        public IEnumerable<string> GetSelectedItems()
        {
            return SelectedItemRep.FindAll().Select(x => x.ItemId);
        }

        public void SetSelectedItems(IEnumerable<string> ids)
        {
            Db.LiteDatabase.DropCollection(nameof(SelectedItem));
            SelectedItemRep.InsertBulk(ids.Select(x => new SelectedItem {ItemId = x}));
        }

        public void Save(string id, int townId, bool isFrom, ItemMarketData item)
        {
            var ord = new OrdersData
            {
                //Id = new OrdersDataId(id, townId, isFrom),
                Id = $"{id},{townId},{isFrom}",
                ItemId = id,
                TownId = townId,
                IsFrom = isFrom,
                Orders = item.Orders,
                UpdateTime = item.UpdateTime,
            };
            lock (_lockObject)
            {
                var rowId = new BsonValue(ord.Id);
                Rep.Upsert(rowId, ord);
            }
        }

        public void DeleteOrders(int townId, bool isFrom)
        {
            Rep.Delete(x => x.TownId == townId && x.IsFrom == isFrom);
        }

        public void DeleteOrders(string id, int townId, bool isFrom)
        {
            //Rep.Delete(new BsonValue(new OrdersDataId(id, townId, isFrom)));
            Rep.Delete($"{id},{townId},{isFrom}");
        }
    }
}