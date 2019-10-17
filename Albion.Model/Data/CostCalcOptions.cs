using System;
using Albion.Common;

namespace Albion.Model.Data
{
    public class CostCalcOptions
    {
        private Location _buyTown;
        private Location _craftTown;
        private bool _isArtefactsLongBuyEnabled = true;
        private bool _isLongBuyDisabled;
        private bool _isLongSellDisabled;
        private Location _sellTown;
        public static CostCalcOptions Instance { get; } = new CostCalcOptions();

        public bool IsLongBuyDisabled
        {
            get => _isLongBuyDisabled;
            set
            {
                if (_isLongBuyDisabled == value) return;
                _isLongBuyDisabled = value;
                Changed?.Invoke();
            }
        }

        public bool IsArtefactsLongBuyEnabled
        {
            get => _isArtefactsLongBuyEnabled;
            set
            {
                if (_isArtefactsLongBuyEnabled == value) return;
                _isArtefactsLongBuyEnabled = value;
                Changed?.Invoke();
            }
        }

        public bool IsLongSellDisabled
        {
            get => _isLongSellDisabled;
            set
            {
                if (_isLongSellDisabled == value) return;
                _isLongSellDisabled = value;
                Changed?.Invoke();
            }
        }

        public Location CraftTown
        {
            get => _craftTown;
            set
            {
                if (_craftTown == value) return;
                _craftTown = value;
                CraftTownChanged?.Invoke();
            }
        }

        public Location SellTown
        {
            get => _sellTown;
            set
            {
                if (_sellTown == value) return;
                _sellTown = value;
                SellTownChanged?.Invoke();
            }
        }

        public Location BuyTown
        {
            get => _buyTown;
            set
            {
                if (_buyTown == value) return;
                _buyTown = value;
                BuyTownChanged?.Invoke();
            }
        }

        public event Action Changed;
        public event Action BuyTownChanged;
        public event Action SellTownChanged;
        public event Action CraftTownChanged;
    }
}