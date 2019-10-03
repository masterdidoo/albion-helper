using System.Linq;
using Albion.Model.Items;
using Albion.Model.Requirements.Resources;

namespace Albion.Model.Requirements
{
    public class UpgradeRequirement : BaseResorcedRequirement
    {
        public UpgradeRequirement(CraftingResource[] resources) : base(resources)
        {
        }

        protected override void ResourcesOnUpdateCost()
        {
            Cost = Resources.Sum(x => x.Count * x.Item.Cost);
        }

        protected override void OnSetParent(CommonItem item)
        {
        }
    }
}