using System;
using System.Linq;
using Albion.Db.Items.Requirements.Resources;

namespace Albion.Db.Items.Requirements
{
    public class CraftingRequirement : BaseRequirement
    {
        private readonly SimpleItem item;

        public CraftingRequirement(SimpleItem item)
        {
            this.item = item;
        }

        public CraftResource[] CraftResources { get; set; }
        public override DateTime Time => CraftResources.Min(x => x.Time);
        public override long Cost => Tax + Silver + CraftResources.Sum(c => c.Cost);
        public override long Tax => item.CostContainer.CraftTax;

        public override string ToString()
        {
            var strs = CraftResources.Select(x => x.ToString()).ToList();
            if (Silver > 0) strs.Add($"Silver {Silver}");
            return string.Join(", ", strs);
        }
    }
}