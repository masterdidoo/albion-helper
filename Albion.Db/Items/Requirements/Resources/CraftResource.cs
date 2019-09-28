using System;

namespace Albion.Db.Items.Requirements.Resources
{
    public class CraftResource
    {
        public SimpleItem Item { get; set; }
        public int Count { get; set; }
        public long? Cost => Item.Cost * Count;
        public DateTime? Time => Item.Time;

        public bool IsExpanded => true;

        public override string ToString()
        {
            return $"{Item} {Count}";
        }
    }
}