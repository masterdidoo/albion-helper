using System.Linq;
using Albion.Model.Items.Requirements;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Profits
{
    public class SalvageProfit : BaseRequirement
    {
        private long _profit;

        public long Profit
        {
            get => _profit;
            protected set
            {
                if (_profit == value) return;
                _profit = value;
                OnPropertyChanged();
            }
        }

        public CraftingResource[] Resources => Item.CraftingRequirements[0].Resources;

        protected override void OnSetItem()
        {
            //TODO сделать
            foreach (var resource in Resources) resource.Item.LongSellProfit.UpdateCost += ResOnUpdateSale;

            ResOnUpdateSale();
        }

        private void ResOnUpdateSale()
        {
            if (Resources.Any(s => s.Cost == 0))
            {
                Cost = 0;
                Profit = -100;
                return;
            }

            Cost = Resources.Sum(r => r.Item.LongSellProfit.Cost * r.Count / 4);
            Profit = Item.Cost > 0 && Cost > 0 ? (Cost - Item.Cost) * 100 / Item.Cost - 100 : -100;
        }
    }
}