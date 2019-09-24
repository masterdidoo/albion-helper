using System;
using System.Linq;

namespace Albion.Db.Items
{
    public class CraftingRequirement
    {
        public BaseResource[] CraftResources { get; set; }
        public long Silver { get; set; }
        public long Cost => Silver + CraftResources.Sum(c => c.Cost);

        public override string ToString()
        {
            if (CraftResources.Length==0) return String.Empty;
            return string.Join(", ", CraftResources.Select(x=>x.ToString()));
        }
    }
}