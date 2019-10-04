﻿using System;
using System.Collections.Generic;
using Albion.DataStore.Db;
using Albion.Model.Data;
using LiteDB;

namespace Albion.DataStore.Managers
{
    public abstract class BaseDataManager<TData, TItem>
    {
        public int Town { get; private set; }

        protected BaseDataManager()
        {
            _data = new Dictionary<string, TItem>();
            var db = DataBase.Instance;
            Rep = db.GetCollection<TData>();
        }

        internal LiteCollection<TData> Rep { get; }

        public void SelectTown(int id)
        {
            if (Town == id) return;
            Town = id;
            TownChanged?.Invoke();
        }

        protected readonly Dictionary<string, TItem> _data;

        public TItem GetData(string id)
        {
            if (_data.TryGetValue(id, out var data)) return data;
            data = CreateData(id);
            _data.Add(id, data);
            return data;
        }


        public event Action TownChanged;

        protected abstract TItem CreateData(string id);
    }
}