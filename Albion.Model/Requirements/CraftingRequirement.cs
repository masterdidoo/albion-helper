using System.Linq;
using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public class CraftingRequirement : BaseRequirement
    {
        public CraftingRequirement(CraftingResource[] resources)
        {
            Resources = resources;
            foreach (var cr in Resources) cr.Item.UpdateCost += CrOnUpdateCost;
        }

        public long Silver { get; set; }

        public int AmountCrafted { get; set; }

        public CraftingResource[] Resources { get; }

        private void CrOnUpdateCost()
        {
            Tax = Item.ItemPower * 5 * Item.Building.Tax / 100;
            Cost = (Resources.Sum(x => x.Count * x.Item.Cost) + Silver + Tax) / AmountCrafted;
        }

        protected override void OnSetParent(CommonItem item)
        {
            item.Building.UpdateTax += CrOnUpdateCost;
        }

        public long Tax { get; private set; }
    }
}