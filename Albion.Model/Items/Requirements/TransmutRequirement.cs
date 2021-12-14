using System.Linq;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public class TransmutRequirement : CraftingRequirement
    {
        public TransmutRequirement(CraftingResource[] resources) : base(resources)
        {
        }

        public override int ReturnProc => 0;

        protected override void ResourcesOnCostUpdate()
        {
            Tax = (int)(Item.CraftingBuilding.Tax * Item.ItemValue * BaseResorcedRequirement.ItemValueToNutrition / 100) + Silver;

            if (Resources.Any(x => x.Item.Cost == 0))
            {
                SetCost(0, 1);
                return;
            }

            var summ = Resources.Any(x => x.Cost == 0) ? 0 : Resources.Sum(x => x.Count * x.Item.Cost);

            var cost = (summ + Tax) / AmountCrafted;
            SetCost(cost, 1);
        }

        public override string Type => "TR";
    }
}