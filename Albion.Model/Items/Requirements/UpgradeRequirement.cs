using System.Linq;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public class UpgradeRequirement : BaseResorcedRequirement
    {
        public UpgradeRequirement(CraftingResource[] resources) : base(resources)
        {
        }

        protected override void ResourcesOnCostUpdate()
        {
            var cost = Resources.Any(x => x.Cost == 0) ? 0 : Resources.Sum(x => x.Count * x.Item.Cost);
            SetCost(cost, 1);
        }
    }
}