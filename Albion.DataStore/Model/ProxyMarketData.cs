using Albion.DataStore.DataModel;
using Albion.DataStore.Managers;
using Albion.Model.Data;

namespace Albion.DataStore.Model
{
    public class ProxyMarketData : ItemMarket
    {
        private readonly MarketDataManager _manager;
        private readonly MarketData _marketData;

        public ProxyMarketData(string id, MarketDataManager manager)
        {
            _manager = manager;
            _marketData = manager.Rep.FindById(id) ?? new MarketData(id);
            manager.TownChanged += ManagerOnTownChanged;
            ManagerOnTownChanged();
        }

        private void ManagerOnTownChanged()
        {
            UpdateBuyPrice -= UpdatePrice;
            UpdateSellPrice -= UpdatePrice;

            SellPrice = _marketData.SellPriceDatas[_manager.Town].Price;
            BuyPrice = _marketData.BuyPriceDatas[_manager.Town].Price;

            UpdateBuyPrice += UpdatePrice;
            UpdateSellPrice += UpdatePrice;
        }

        private void UpdatePrice()
        {
            _marketData.BuyPriceDatas[_manager.Town].Price = BuyPrice;
            _marketData.SellPriceDatas[_manager.Town].Price = SellPrice;

            _manager.Rep.Upsert(_marketData);
        }
    }
}