using System;
using System.Linq;

namespace Albion.Db.Items
{
    public class CraftingRequirement
    {
        public CraftResource[] CraftResources { get; set; }
        public long Silver { get; set; }
        public long Cost => CraftResources.Sum(c=>c.Item.MinCost)

        public override string ToString()
        {
            if (CraftResources.Length==0) return String.Empty;
            return string.Join(", ", CraftResources.Select(x=>x.ToString()));
        }
    }
}