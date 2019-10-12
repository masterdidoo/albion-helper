using System.Linq;
using Albion.Model.Items.Requirements;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Profits
{
    public class SalvageProfit : BaseRequirement
    {
        protected override void OnSetItem()
        {
            foreach (var resource in Resources)
            {
                resource.Item.UpdateSale += ResOnUpdateSale;
            }

            ResOnUpdateSale();
        }

        private void ResOnUpdateSale()
        {
            if (Resources.Any(s => s.Cost == 0))
            {
                Cost = 0;
                return;
            }

            Cost = Resources.Sum(r => r.Item.LongSellProfit.Cost*r.Count/4);
        }

        public CraftingResource[] Resources => Item.CraftingRequirements[0].Resources;
    }
}