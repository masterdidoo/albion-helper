using System;

namespace Albion.Db.Items.Requirements
{
    public abstract class BaseRequirement
    {
        public abstract DateTime Time { get; }
        public abstract long Cost { get; }

        public long Silver { get; set; }
        public abstract long Tax { get; }
    }
}