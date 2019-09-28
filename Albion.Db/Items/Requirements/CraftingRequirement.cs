using System;
using System.Linq;
using Albion.Db.Items.Requirements.Resources;

namespace Albion.Db.Items.Requirements
{
    public class CraftingRequirement : BaseRequirement
    {
        private readonly SimpleItem item;
        private long? _cost;

        public CraftingRequirement(SimpleItem item, CraftResource[] craftResources)
        {
            this.item = item;
            CraftResources = craftResources;

            foreach (var cr in craftResources) cr.Item.Updated += OnUpdated;

            OnUpdated();
        }

        public CraftResource[] CraftResources { get; }

        public override DateTime? Time => CraftResources.Min(x => x.Time);

        public override long? Cost => _cost;

        public override long Tax => item.CostContainer.CraftTax;

        private void OnUpdated()
        {
            if (CraftResources == null || CraftResources.Length == 0) return;
            var craftCost = CraftResources.Sum(c => c.Cost) * 100 / item.CostContainer.CraftReturn;
            var cost = Tax + Silver + craftCost;
            if (cost == _cost) return;
            _cost = cost;

            Updated?.Invoke();

            RaisePropertyChanged(nameof(Cost));
        }

        public override string ToString()
        {
            var strs = CraftResources.Select(x => x.ToString()).ToList();
            if (Silver > 0) strs.Add($"Silver {Silver}");
            return string.Join(", ", strs);
        }

        public event Action Updated;
    }
}