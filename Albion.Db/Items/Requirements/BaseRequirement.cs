using System;
using GalaSoft.MvvmLight;

namespace Albion.Db.Items.Requirements
{
    public abstract class BaseRequirement : ObservableObject
    {
        private long? _cost;
        private bool _isExpanded;
        private bool _isMin;

        public bool IsExpanded
        {
            get => _isExpanded;
            set => Set(ref _isExpanded, value);
        }

        public bool IsMin
        {
            get => _isMin;
            set => Set(ref _isMin, value);
        }

        public bool IsSelected { get; set; }

        public abstract DateTime? Time { get; }

        public long? Cost
        {
            get => _cost;
            set
            {
                if (Set(ref _cost, value)) Updated?.Invoke();
            }
        }

        public event Action Updated;
    }
}