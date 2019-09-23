using System;
using System.Linq;

namespace Albion.Db.Items
{
    public class CraftingRequirement
    {
        public CraftResource[] CraftResources { get; set; }
        public long Silver { get; set; }

        public override string ToString()
        {
            if (CraftResources.Length==0) return String.Empty;
            return string.Join(", ", CraftResources.Select(x=>x.ToString()));
        }
    }
}