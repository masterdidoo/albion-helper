using System;

namespace Albion.Model.Data
{
    public class CostCalcOptions
    {
        private bool _isArtefactsLongBuyEnabled = true;
        private bool _isBmDisabled;
        private bool _isLongBuyDisabled;
        private bool _isLongSellDisabled;
        private bool _isSalvageDisabled;
        private bool _isCraftDisabled;
        private bool _isFocus;
        private bool _isCraftOnlyNotResources;
        private bool _isRefineFocus;
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
                Changed?.Invoke();
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

        public bool IsCraftOnlyNotResources
        {
            get => _isCraftOnlyNotResources;
            set
            {
                if (_isCraftOnlyNotResources == value) return;
                _isCraftOnlyNotResources = value;
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
    }
}