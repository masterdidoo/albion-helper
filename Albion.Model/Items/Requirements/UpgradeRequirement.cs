using System.Linq;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public class UpgradeRequirement : BaseResorcedRequirement
    {
        public UpgradeRequirement(CraftingResource[] resources) : base(resources)
        {
            Resources.Last().Item.RequirementUpdated += ItemOnCostUpdate;
        }

        private void ItemOnCostUpdate()
        {
            RaisePropertyChanged(nameof(Type));
        }

        protected override void ResourcesOnCostUpdate()
        {
            var cost = Resources.Any(x => x.Cost == 0) ? 0 : Resources.Sum(x => x.Count * x.Item.Cost);
            SetCost(cost, 1);
        }

        public override string Type => "U"+ Resources.Last().Item.Requirement?.Type;
    }
}