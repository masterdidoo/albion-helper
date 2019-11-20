using System.Linq;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public class TransmutRequirement : CraftingRequirement
    {
        public TransmutRequirement(CraftingResource[] resources) : base(resources)
        {
        }

        protected override void ResourcesOnCostUpdate()
        {
            Tax = 10000 / 100 * Item.CraftingBuilding.Tax * Item.ItemValue * 5 + Silver;

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