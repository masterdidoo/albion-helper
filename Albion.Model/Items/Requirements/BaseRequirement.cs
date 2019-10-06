namespace Albion.Model.Items.Requirements
{
    public abstract class BaseRequirement : BaseCostableEntity
    {
        private bool _isExpanded;

        private bool _isMin;

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded == value) return;
                _isExpanded = value;
                OnPropertyChanged();
            }
        }

        public bool IsMin
        {
            get => _isMin;
            set
            {
                if (_isMin == value) return;
                _isMin = value;
                OnPropertyChanged();
                if (value) Item.UpdateMinCost(this);
            }
        }

        public CommonItem Item { get; private set; }

        internal void SetItem(CommonItem item)
        {
            Item = item;
            OnSetItem();
        }

        protected abstract void OnSetItem();
    }
}