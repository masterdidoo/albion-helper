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
            Cost = (Resources.Sum(x => x.Count * x.Item.Cost) + Silver + Tax) / AmountCrafted;
        }

        protected override void OnSetParent(CommonItem item)
        {
            item.BuildingData.UpdateTax += BuildingDataOnUpdateTax;
        }

        private void BuildingDataOnUpdateTax()
        {
            Tax = Item.ItemPower * 5 * Item.BuildingData.Tax / 100;
        }
    }
}