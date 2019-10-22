using System;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseRequirement : BaseCostableEntity
    {
        public CommonItem Item { get; private set; }

        internal void SetItem(CommonItem item)
        {
            Item = item;
            //OnCostChanged(); нужно если значения будут грузиться сразу при создании
        }

        #region prop IsExpanded

        private bool _isExpanded;
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

        #endregion

        #region prop IsSelected

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged();
                OnSelected();
            }
        }
        #endregion

        protected virtual void OnSelected()
        {
            if (!IsSelected) return;
            foreach (var item in Item.Requirements)
                if (item != this)
                    item.IsSelected = false;
            Item.Requirement = this;
        }

        protected override void OnCostChanged()
        {
            var min = long.MaxValue;
            BaseRequirement minItem = null;

            foreach (var requirement in Item.Requirements)
            {
//                requirement.IsSelected = false;
//                requirement.IsExpanded = false;
                if (min > requirement.Cost && requirement.Cost > 0)
                {
                    min = requirement.Cost;
                    minItem = requirement;
                }
            }

            if (minItem != null)
            {
                if (minItem == this && IsSelected) Item.RaiseCostChanged();
                minItem.IsSelected = true;
//                minItem.IsExpanded = true;
            }
        }
    }
}