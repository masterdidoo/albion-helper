using System;
using GalaSoft.MvvmLight;

namespace Albion.Db.Items.Requirements
{
    public abstract class BaseRequirement : ObservableObject
    {
        private bool _isExpanded;
        private bool _isMin;
        public const long MaxNullPrice = long.MaxValue / 10000;

        public bool IsExpanded
        {
            get => _isExpanded;
            set => Set(ref _isExpanded , value);
        }

        public bool IsMin
        {
            get => _isMin;
            set => Set(ref _isMin, value);
        }

        public bool IsSelected { get; set; }

        public abstract DateTime Time { get; }
        public abstract long Cost { get; }

        public long Silver { get; set; }
        public abstract long Tax { get; }
    }
}