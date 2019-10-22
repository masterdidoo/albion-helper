using System;
using System.Linq;

namespace Albion.Model.Items.Profits
{
    public class TreeProps : NotifyEntity
    {
        #region IsSelected

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                RaisePropertyChanged();
                IsSelectedUpdate?.Invoke();
            }
        }

        #endregion

        #region IsExpanded

        private bool _isExpanded;

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded == value) return;
                _isExpanded = value;
                RaisePropertyChanged();
            }
        }

        public event Action IsSelectedUpdate;

        #endregion
    }

    public class BaseProfit : NotifyEntity
    {
        public BaseProfit(CommonItem item)
        {
            Item = item;
            Item.CostUpdate += ItemOnCostUpdate;
            TreeProps = new TreeProps();
            TreeProps.IsSelectedUpdate += TreePropsOnIsSelectedUpdate;
        }

        private void TreePropsOnIsSelectedUpdate()
        {
            if (!TreeProps.IsSelected) return;
            foreach (var profit in Item.Profits.Where(x=>x!=this))
            {
                profit.TreeProps.IsSelected = false;
            }
            Item.Profitt = this;
        }

        public CommonItem Item { get; }

        public TreeProps TreeProps { get; }

        private void ItemOnCostUpdate()
        {
            Profit = Income - Item.Cost;
            ProfitPercent = Profit * 100 / Item.Cost;
            Updated?.Invoke();
        }

        protected void SetIncome(long income)
        {
            Income = income;
            ItemOnCostUpdate();
        }

        public event Action Updated;

        #region ProfitPercent

        private long _profitPercent;

        public long ProfitPercent
        {
            get => _profitPercent;
            private set
            {
                if (_profitPercent == value) return;
                _profitPercent = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Profit

        private long _profit;

        public long Profit
        {
            get => _profit;
            private set
            {
                if (_profit == value) return;
                _profit = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Income

        private long _income;

        public long Income
        {
            get => _income;
            private set
            {
                if (_income == value) return;
                _income = value;
                RaisePropertyChanged();
            }
        }

        #endregion
    }
}