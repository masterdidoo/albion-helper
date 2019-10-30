using System;
using System.Collections.Generic;
using Albion.DataStore.Db;
using LiteDB;

namespace Albion.DataStore.Managers
{
    public abstract class BaseDataManager<TData, TItem>
    {
        protected readonly Dictionary<string, TItem> Data;
        protected DataBase Db;

        protected BaseDataManager()
        {
            Data = new Dictionary<string, TItem>();
            Db = DataBase.Instance;
            Rep = Db.GetCollection<TData>();
        }

        internal LiteCollection<TData> Rep { get; }

        public TItem GetData(string id)
        {
            if (Data.TryGetValue(id, out var data)) return data;
            data = CreateData(id);
            Data.Add(id, data);
            return data;
        }

        protected abstract TItem CreateData(string id);
    }
}