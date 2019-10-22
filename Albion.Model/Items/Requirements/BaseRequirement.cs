using System;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseRequirement : BaseCostableEntity
    {
        private bool _isExpanded;

        private bool _isSelected;

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

        public bool IsSelected
        {
            get => _isSelected;
            set => SetSelected(value);
        }

        protected virtual void SetSelected(bool value)
        {
            if (_isSelected == value) return;
            _isSelected = value;
            RaisePropertyChanged(nameof(IsSelected));
            if (value) Selected?.Invoke(this);
        }

        public CommonItem Item { get; private set; }

        public event Action<BaseRequirement> Selected;

        internal void SetItem(CommonItem item)
        {
            Item = item;
            OnSetItem();
        }

        protected abstract void OnSetItem();
    }
}