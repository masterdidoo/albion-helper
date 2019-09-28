using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Db.Items.Requirements;

namespace Albion.Db.Items
{
    public class SimpleItem : BaseItem
    {
        private CraftingRequirement[] _craftingRequirements;
        private long _cost = BaseRequirement.MaxNullPrice;
        public bool IsExpanded => true;

        public SimpleItem(string id, IPlayerContext context) : base(id)
        {
            CostContainer = new CostContainer(context, this);

            FastBuyRequirement = new FastBuyRequirement(CostContainer);
            LongBuyRequirement = new LongBuyRequirement(CostContainer);

            CostContainer.Updated += OnUpdated;
            OnUpdated();
        }

        private void OnUpdated()
        {
            BaseRequirement minR = null;
            long min = BaseRequirement.MaxNullPrice;
            foreach (var r in Requirements)
            {
                r.IsMin = false;
                r.IsExpanded = false;
                if (r.Cost < min)
                {
                    min = r.Cost;
                    minR = r;
                }
            }

            Cost = min;

            if (minR != null)
            {
                minR.IsExpanded = true;
                minR.IsMin = true;
            }
                RaisePropertyChanged(nameof(Profit));
        }

        #region FromConfig
        public int Tier { get; set; }
        public float Weight { get; set; }
        public string Uisprite => Id.Substring(3);

        public CraftingRequirement[] CraftingRequirements
        {
            get => _craftingRequirements;
            set
            {
                if (_craftingRequirements != null)
                {
                    foreach (var cr in _craftingRequirements)
                    {
                        cr.Updated -= OnUpdated;
                    }
                }
                _craftingRequirements = value;
                if (_craftingRequirements != null)
                {
                    foreach (var cr in _craftingRequirements)
                    {
                        cr.Updated += OnUpdated;
                    }

                    OnUpdated();
                }
            }
        }

        public Craftingcategory Craftingcategory { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public long ItemValue { get; set; }
        #endregion

        public IEnumerable<BaseRequirement> Requirements
        {
            get
            {
                yield return FastBuyRequirement;
                yield return LongBuyRequirement;
                if (CraftingRequirements == null) yield break;

                foreach (var requirement in CraftingRequirements)
                {
                    yield return requirement;
                }
            }
        }

        public CostContainer CostContainer { get; }

        public FastBuyRequirement FastBuyRequirement { get; }
        public LongBuyRequirement LongBuyRequirement { get; }

        public long Cost
        {
            get => _cost;
            set
            {
                if (_cost == value) return;
                _cost = value;
                Updated?.Invoke();
                RaisePropertyChanged();
            }
        }

        public DateTime Time => Requirements.Min(r=>r.Time);//{ get; set; }

        public long Profit => Cost == 0 ? -100 : (CostContainer.SellPrice * 100 / Cost) - 100;

        public event Action Updated;
    }
}