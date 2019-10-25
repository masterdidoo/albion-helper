using System;
using System.Linq;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseRequirement : NotifyEntity
    {
        private bool _isChanged;

        public abstract string Type { get; }

        protected BaseRequirement()
        {
            TreeProps = new TreeProps();
            TreeProps.IsSelectedUpdate += TreePropsOnIsSelectedUpdate;
        }

        public CommonItem Item { get; private set; }

        public TreeProps TreeProps { get; }

        private void TreePropsOnIsSelectedUpdate()
        {
            if (!TreeProps.IsSelected) return;
            foreach (var profit in Item.Requirements.Where(x => x != this)) profit.TreeProps.IsSelected = false;
            Item.Requirement = this;
        }

        internal void SetItem(CommonItem item)
        {
            if (Item == item) return;
            Item = item;
            OnSetItem();
        }

        protected abstract void OnSetItem();

        protected void SetCost(long cost, int count)
        {
            _isChanged = false;

            Cost = cost;
            Count = count;
            if (_isChanged) Updated?.Invoke();
        }

        public event Action Updated;

        #region Cost

        private long _cost;

        public long Cost
        {
            get => _cost;
            private set
            {
                if (_cost == value) return;
                _cost = value;
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
    }

    public enum RequirementType
    {
        LB,
        FB,
        CR,
        UP
    }
}