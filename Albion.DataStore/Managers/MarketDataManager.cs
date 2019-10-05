using System;
using Albion.DataStore.DataModel;
using Albion.DataStore.Model;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.DataStore.Managers
{
    public class MarketDataManager : BaseDataManager<MarketData, ItemMarket>, IMarketDataManager
    {
        public event Action SellTownChanged;

        protected override ItemMarket CreateData(string id)
        {
            return new ProxyMarketData(id, this);
        }

        public int SellTown { get; private set; }

        public void SelectSellTown(int id)
        {
            if (SellTown == id) return;
            SellTown = id;
            SellTownChanged?.Invoke();
        }
    }
}