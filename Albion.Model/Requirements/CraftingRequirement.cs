using System.Linq;
using Albion.Model.Items;
using Albion.Model.Requirements.Resources;

namespace Albion.Model.Requirements
{
    public class CraftingRequirement : BaseResorcedRequirement
    {
        private long _tax;

        public CraftingRequirement(CraftingResource[] resources) : base(resources)
        {
        }

        public long Silver { get; set; }

        public int AmountCrafted { get; set; }

        public long Tax
        {
            get => _tax;
            private set
            {
                if (_tax == value) return;
                _tax = value;
                OnPropertyChanged();
                ResourcesOnUpdateCost();
            }
        }

        protected override void ResourcesOnUpdateCost()
        {
            var summ = Resources.Sum(x => x.Count * x.Item.Cost);

            if (summ == 0)
            {
                Cost = 0;
                return;
            }

            Cost = (summ + Silver + Tax) / AmountCrafted;
        }

        protected override void OnSetItem()
        {
            base.OnSetItem();
            Item.ItemBuilding.UpdateTax += BuildingDataOnUpdateTax;
            BuildingDataOnUpdateTax();
        }

        private void BuildingDataOnUpdateTax()
        {
            Tax = Item.ItemPower * 5 * Item.ItemBuilding.Tax / 100;
        }
    }
}