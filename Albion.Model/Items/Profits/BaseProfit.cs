using System;

namespace Albion.Model.Items.Profits
{
    public class BaseProfit : NotifyEntity
    {
        private long _profit;
        private long _silver;

        public BaseProfit(CommonItem item)
        {
            Item = item;
        }

        public CommonItem Item { get; }

        public long Silver
        {
            get => _silver;
            set
            {
                if (_silver == value) return;
                _silver = value;
                OnPropertyChanged();
            }
        }

        public long Profit
        {
            get => _profit;
            set
            {
                if (_profit == value) return;
                _profit = value;
                UpdateProfit?.Invoke();
                OnPropertyChanged();
            }
        }

        public event Action UpdateProfit;
    }
}