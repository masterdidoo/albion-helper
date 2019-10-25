using System.Linq;
using Albion.Model.Items.Requirements;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Profits
{
    public class SalvageProfit : BaseProfit
    {
        public override string Type => "SL";

        public CraftingResource[] Resources => Item.CraftingRequirements[0].Resources;

        private void ResOnCostUpdateSale()
        {
            if (Resources.Any(s => s.Cost == 0))
            {
                SetIncome(0,1);
                return;
            }

            var income = Resources.Sum(r => r.Item.LongSellProfit.Income * r.Count / 4);
            SetIncome(income, 1);
        }

        public SalvageProfit(CommonItem item) : base(item)
        {
            //TODO сделать
            foreach (var resource in Resources) resource.Item.LongSellProfit.Updated += ResOnCostUpdateSale;

            ResOnCostUpdateSale();
        }
    }
}