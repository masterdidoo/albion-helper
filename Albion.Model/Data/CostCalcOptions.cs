using System;

namespace Albion.Model.Data
{
    public class CostCalcOptions
    {
        public static CostCalcOptions Instance { get; } = new CostCalcOptions();

        private bool _isArtefactsLongBuyEnabled = true;
        private bool _isLongBuyDisabled;
        private bool _isLongSellDisabled;

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

        public event Action Changed;
    }
}