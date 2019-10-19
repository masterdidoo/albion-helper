using System;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseMarketRequirement : BaseRequirement
    {
        private readonly ITownManager _townManager;
        private long _silver;
        private ItemMarketData _itemMarketData;

        protected abstract ItemMarketData ItemMarketData { get; }

        public int TownId => _townManager.TownId;

        protected BaseMarketRequirement() { }

        protected BaseMarketRequirement(ITownManager townManager)
        {
            _townManager = townManager;
            townManager.TownChanged += OnSetItem;
        }

        /// <summary>
        /// меняет только пользователь
        /// </summary>
        public long Silver
        {
            get => _silver;
            set
            {
                if (_silver == value) return;
                _silver = value;
                ItemMarketData.SetBestPrice(Silver);
                Pos = DateTime.Now;
                OnUpdateSilver();
                OnPropertyChanged(nameof(Silver));
            }
        }

        protected override void OnSetItem()
        {
            if (_itemMarketData!=null) _itemMarketData.UpdateBestPrice -= OnUpdateSellPrice;
            _itemMarketData = ItemMarketData;
            ItemMarketData.UpdateBestPrice += OnUpdateSellPrice;
            OnUpdateSellPrice();
        }

        /// <summary>
        /// вызывается при смене города и обновлении из net-пакета
        /// </summary>
        private void OnUpdateSellPrice()
        {
            if (_silver == ItemMarketData.BestPrice) return;
            _silver = ItemMarketData.BestPrice;
            Pos = ItemMarketData.UpdateTime;
            OnUpdateSilver();
            OnPropertyChanged(nameof(Silver));
        }

        protected abstract void OnUpdateSilver();
    }
}