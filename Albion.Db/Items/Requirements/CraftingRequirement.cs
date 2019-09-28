using System;
using System.Linq;
using Albion.Db.Items.Requirements.Resources;

namespace Albion.Db.Items.Requirements
{
    public class CraftingRequirement : BaseRequirement
    {
        private readonly SimpleItem item;
        private CraftResource[] _craftResources;
        private long _cost = MaxNullPrice;

        public CraftingRequirement(SimpleItem item)
        {
            this.item = item;

            OnUpdated();
        }

        public CraftResource[] CraftResources
        {
            get => _craftResources;
            set
            {
                if (_craftResources != null)
                {
                    foreach (var cr in _craftResources)
                    {
                        cr.Item.Updated -= OnUpdated;
                    }
                }
                _craftResources = value;
                if (_craftResources != null)
                {
                    foreach (var cr in _craftResources)
                    {
                        cr.Item.Updated += OnUpdated;
                    }

                    OnUpdated();
                }
            }
        }

        private void OnUpdated()
        {
            if (CraftResources == null || CraftResources.Length==0 ) return;
            var craftCost = CraftResources.Sum(c => c.Cost) * 100 / item.CostContainer.CraftReturn;
            var cost = Tax + Silver + craftCost;
            if (cost==_cost) return;
            _cost = cost;

            Updated?.Invoke();

            RaisePropertyChanged(nameof(Cost));
        }

        public override DateTime Time => CraftResources.Min(x => x.Time);

        public override long Cost
        {
            get => _cost;
        }

        public override long Tax => item.CostContainer.CraftTax;

        public override string ToString()
        {
            var strs = CraftResources.Select(x => x.ToString()).ToList();
            if (Silver > 0) strs.Add($"Silver {Silver}");
            return string.Join(", ", strs);
        }

        public event Action Updated;
    }
}