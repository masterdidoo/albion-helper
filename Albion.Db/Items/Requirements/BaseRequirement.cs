using System;
using GalaSoft.MvvmLight;

namespace Albion.Db.Items.Requirements
{
    public abstract class BaseRequirement
    {
        public const long MaxNullPrice = long.MaxValue / 10000;

        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }

        public abstract DateTime Time { get; }
        public abstract long Cost { get; }

        public long Silver { get; set; }
        public abstract long Tax { get; }
    }
}