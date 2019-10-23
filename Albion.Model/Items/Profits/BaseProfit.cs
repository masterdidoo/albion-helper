using System;
using System.Linq;

namespace Albion.Model.Items.Profits
{
    public class BaseProfit : NotifyEntity
    {
        public BaseProfit(CommonItem item)
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

            Updated?.Invoke();
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
            }
        }

        #endregion
    }
}