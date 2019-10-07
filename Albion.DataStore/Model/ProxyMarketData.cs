using System;
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
            manager.SellTownChanged += ManagerOnSellTownChanged;
            manager.TownChanged += ManagerOnTownChanged;
            ManagerOnSellTownChanged();
            ManagerOnTownChanged();
        }

        private void ManagerOnSellTownChanged()
        {
            UpdateSellFastPrice -= OnUpdateSellFastPrice;
            UpdateSellLongPrice -= OnUpdateSellLongPrice;

            SellLongPrice = _marketData.SellPriceDatas[_manager.SellTown].Price;
            SellFastPrice = _marketData.BuyPriceDatas[_manager.SellTown].Price;

            UpdateSellFastPrice += OnUpdateSellFastPrice;
            UpdateSellLongPrice += OnUpdateSellLongPrice;
        }

        private void ManagerOnTownChanged()
        {
            UpdateBuyPrice -= OnUpdateBuyPrice;
            UpdateSellPrice -= OnUpdateSellPrice;

            SellPrice = _marketData.SellPriceDatas[_manager.Town].Price;
            BuyPrice = _marketData.BuyPriceDatas[_manager.Town].Price;

            UpdateBuyPrice += OnUpdateBuyPrice;
            UpdateSellPrice += OnUpdateSellPrice;
        }

        private void OnUpdateBuyPrice()
        {
            if (_manager.SellTown == _manager.Town)
            {
                SellFastPrice = BuyPrice;
                return;
            }

            _marketData.SellPriceDatas[_manager.Town].Price = SellPrice;
            _marketData.SellPriceDatas[_manager.Town].Pos = DateTime.Now;

            _manager.Rep.Upsert(_marketData);
        }

        private void OnUpdateSellPrice()
        {
            if (_manager.SellTown == _manager.Town)
            {
                SellLongPrice = SellPrice;
                return;
            }

            _marketData.SellPriceDatas[_manager.Town].Price = SellPrice;
            _marketData.SellPriceDatas[_manager.Town].Pos = DateTime.Now;

            _manager.Rep.Upsert(_marketData);
        }

        private void OnUpdateSellLongPrice()
        {
            if (_manager.SellTown == _manager.Town)
            {
                SellPrice = SellLongPrice;
                return;
            }

            _marketData.SellPriceDatas[_manager.SellTown].Price = SellLongPrice;
            _marketData.SellPriceDatas[_manager.SellTown].Pos = DateTime.Now;

            _manager.Rep.Upsert(_marketData);
        }

        private void OnUpdateSellFastPrice()
        {
            if (_manager.SellTown == _manager.Town)
            {
                SellPrice = SellLongPrice;
                return;
            }

            _marketData.BuyPriceDatas[_manager.SellTown].Price = SellFastPrice;
            _marketData.BuyPriceDatas[_manager.SellTown].Pos = DateTime.Now;

            _manager.Rep.Upsert(_marketData);
        }
    }
}