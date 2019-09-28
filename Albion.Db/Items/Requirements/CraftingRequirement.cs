using System;
using System.Linq;
using Albion.Db.Items.Requirements.Resources;

namespace Albion.Db.Items.Requirements
{
    public class CraftingRequirement : BaseRequirement
    {
        private readonly SimpleItem Item;

        public CraftingRequirement(SimpleItem item, CraftResource[] craftResources, long silver)
        {
            Silver = silver;
            Item = item;
            CraftResources = craftResources;

            foreach (var cr in craftResources) cr.Item.Updated += OnUpdated;

            OnUpdated();
        }

        public long Silver { get; }

        public CraftResource[] CraftResources { get; }

        public override DateTime? Time => CraftResources.Min(x => x.Time);

        public long Tax => Item.CostContainer.CraftTax;

        private void OnUpdated()
        {
            if (CraftResources == null || CraftResources.Length == 0) return;
            var craftCost = CraftResources.All(c => c.Cost.HasValue) ? CraftResources.Sum(c => c.Cost) * 100 / Item.CostContainer.CraftReturn : null;
            var cost = Tax + Silver + craftCost;
            Cost = cost;
        }

        public override string ToString()
        {
            var strs = CraftResources.Select(x => x.ToString()).ToList();
            if (Silver > 0) strs.Add($"Silver {Silver}");
            return string.Join(", ", strs);
        }
    }
}