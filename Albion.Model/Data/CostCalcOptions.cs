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

        public event Action Changed;
    }
}