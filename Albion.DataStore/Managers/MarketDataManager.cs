using Albion.DataStore.DataModel;
using Albion.DataStore.Model;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.DataStore.Managers
{
    public class MarketDataManager : BaseDataManager<MarketData, ItemMarket>, IMarketDataManager
    {
        protected override ItemMarket CreateData(string id)
        {
            return new ProxyMarketData(id, this);
        }
    }
}