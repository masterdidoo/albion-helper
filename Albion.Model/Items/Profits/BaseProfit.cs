using System;
using System.Linq;

namespace Albion.Model.Items.Profits
{
    public abstract class BaseProfit : NotifyEntity
    {
        private bool _isChanged;

        protected BaseProfit(CommonItem item)
        {
            Item = item;
            Item.CostUpdate += ItemOnCostUpdate;
            TreeProps = new TreeProps();
            TreeProps.IsSelectedUpdate += TreePropsOnIsSelectedUpdate;
        }

        public CommonItem Item { get; }

        public TreeProps TreeProps { get; }

        private void TreePropsOnIsSelectedUpdate()
        {
            if (!TreeProps.IsSelected) return;
            foreach (var profit in Item.Profits.Where(x => x != this)) profit.TreeProps.IsSelected = false;
            Item.Profitt = this;
        }

        private void ItemOnCostUpdate()
        {
            _isChanged = false;
            if (Item.Cost == 0)
            {
                Profit = 0;
                ProfitPercent = 0;
                ProfitSum = 0;
            }
            else
            {
                Profit = Income - Item.Cost;
                ProfitPercent = Profit * 100 / Item.Cost;
                ProfitSum = Profit * Count;
            }

            if (_isChanged) Updated?.Invoke();
        }

        protected void SetIncome(long income, int count)
        {
            Income = income;
            Count = count;
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
                _isChanged = true;
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
                _isChanged = true;
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
                _isChanged = true;
            }
        }

        #endregion

        #region Count

        private int _count;

        public int Count
        {
            get => _count;
            private set
            {
                if (_count == value) return;
                _count = value;
                RaisePropertyChanged();
                _isChanged = true;
            }
        }

        #endregion

        #region ProfitSum

        private long _profitSum;

        public long ProfitSum
        {
            get => _profitSum;
            private set
            {
                if (_profitSum == value) return;
                _profitSum = value;
                RaisePropertyChanged();
                _isChanged = true;
            }
        }

        public abstract string Type { get; }

        #endregion

    }
}