using System;

namespace Albion.Model.Items
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
}