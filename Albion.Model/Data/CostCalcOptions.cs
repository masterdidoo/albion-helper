using System;

namespace Albion.Model.Data
{
    public class CostCalcOptions
    {
        private bool _isArtefactsLongBuyEnabled = true;
        private bool _isBmDisabled;
        private bool _isLongBuyDisabled = true;
        private bool _isLongSellDisabled;
        private bool _isSalvageDisabled;
        private bool _isCraftDisabled;
        private bool _isFocus;
        private bool _isItemsOnlyCraft;
        private bool _isRefineFocus;
        private bool _isDisableCraftResources;
        private bool _isDisableUpgrade;
        private bool _isBaseResourcesLongBuyEnabled = true;
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

        public bool IsBaseResourcesLongBuyEnabled
        {
            get => _isBaseResourcesLongBuyEnabled;
            set
            {
                if (_isBaseResourcesLongBuyEnabled == value) return;
                _isBaseResourcesLongBuyEnabled = value;
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
                ProfitsChanged?.Invoke();
            }
        }

        public bool IsBmDisabled
        {
            get => _isBmDisabled;
            set
            {
                if (_isBmDisabled == value) return;
                _isBmDisabled = value;
                Changed?.Invoke();
            }
        }

        public bool IsSalvageDisabled
        {
            get => _isSalvageDisabled;
            set
            {
                if (_isSalvageDisabled == value) return;
                _isSalvageDisabled = value;
                ProfitsChanged?.Invoke();
            }
        }

        public bool IsCraftDisabled
        {
            get => _isCraftDisabled;
            set
            {
                if (_isCraftDisabled == value) return;
                _isCraftDisabled = value;
                Changed?.Invoke();
            }
        }

        public bool IsItemsOnlyCraft
        {
            get => _isItemsOnlyCraft;
            set
            {
                if (_isItemsOnlyCraft == value) return;
                _isItemsOnlyCraft = value;
                Changed?.Invoke();
            }
        }

        public bool IsDisableCraftResources
        {
            get => _isDisableCraftResources;
            set
            {
                if (_isDisableCraftResources == value) return;
                _isDisableCraftResources = value;
                Changed?.Invoke();
            }
        }

        public bool IsDisableUpgrade
        {
            get => _isDisableUpgrade;
            set
            {
                if (_isDisableUpgrade == value) return;
                _isDisableUpgrade = value;
                Changed?.Invoke();
            }
        }

        public bool IsFocus
        {
            get => _isFocus;
            set
            {
                if (_isFocus == value) return;
                _isFocus = value;
                IsFocusChanged?.Invoke();
            }
        }

        public bool IsRefineFocus
        {
            get => _isRefineFocus;
            set
            {
                if (_isRefineFocus == value) return;
                _isRefineFocus = value;
                IsFocusChanged?.Invoke();
            }
        }

        public event Action Changed;
        public event Action IsFocusChanged;
        public event Action ProfitsChanged;
    }
}