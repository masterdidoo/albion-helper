using System.Linq;
using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public class CraftingRequirement : BaseCostableEntity
    {
        public CraftingRequirement(CraftingResource[] resources)
        {
            Resources = resources;
            foreach (var cr in Resources) cr.Item.UpdateCost += CrOnUpdateCost;
        }

        private void CrOnUpdateCost()
        {
            Cost = (Resources.Sum(x => x.Count * x.Item.Cost) + Silver) / AmountCrafted;
        }

        public long Silver { get; set; }
        public int AmountCrafted { get; set; }
        public CraftingResource[] Resources { get; }
    }
}