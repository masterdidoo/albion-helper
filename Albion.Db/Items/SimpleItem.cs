using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Db.Items.Requirements;

namespace Albion.Db.Items
{
    public class SimpleItem : BaseItem
    {
        public SimpleItem(string id, IPlayerContext context) : base(id)
        {
            CostContainer = new CostContainer(context, this);

            FastBuyRequirement = new FastBuyRequirement(CostContainer);
            LongBuyRequirement = new LongBuyRequirement(CostContainer);
        }

        #region FromConfig
        public int Tier { get; set; }
        public float Weight { get; set; }
        public string Uisprite => Id.Substring(3);
        public CraftingRequirement[] CraftingRequirements { get; set; }
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

        public long Cost => Requirements.Min(r => r.Cost);//{ get; set; }
        public DateTime Time => Requirements.Min(r=>r.Time);//{ get; set; }
    }
}