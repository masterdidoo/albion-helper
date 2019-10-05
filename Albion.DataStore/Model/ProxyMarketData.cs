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
            UpdateSellFastPrice -= SellUpdatePrice;
            UpdateSellLongPrice -= SellUpdatePrice;

            SellLongPrice = _marketData.SellPriceDatas[_manager.SellTown].Price;
            SellFastPrice = _marketData.BuyPriceDatas[_manager.SellTown].Price;

            UpdateSellFastPrice += SellUpdatePrice;
            UpdateSellLongPrice += SellUpdatePrice;
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
            if (_manager.SellTown == _manager.Town)
            {
                SellFastPrice = BuyPrice;
                SellLongPrice = SellPrice;
                return;
            }

            _marketData.BuyPriceDatas[_manager.Town].Price = BuyPrice;
            _marketData.BuyPriceDatas[_manager.Town].Pos = DateTime.Now;
            _marketData.SellPriceDatas[_manager.Town].Price = SellPrice;
            _marketData.SellPriceDatas[_manager.Town].Pos = DateTime.Now;

            _manager.Rep.Upsert(_marketData);
        }

        private void SellUpdatePrice()
        {
            if (_manager.SellTown == _manager.Town)
            {
                BuyPrice = SellFastPrice;
                SellPrice = SellLongPrice;
                return;
            }

            _marketData.BuyPriceDatas[_manager.SellTown].Price = SellFastPrice;
            _marketData.BuyPriceDatas[_manager.SellTown].Pos = DateTime.Now;
            _marketData.SellPriceDatas[_manager.SellTown].Price = SellLongPrice;
            _marketData.SellPriceDatas[_manager.SellTown].Pos = DateTime.Now;

            _manager.Rep.Upsert(_marketData);
        }
    }
}