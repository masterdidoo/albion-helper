using System.Linq;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public class CraftingRequirement : BaseResorcedRequirement
    {
        private long _tax;

        public CraftingRequirement(CraftingResource[] resources) : base(resources)
        {
            //ItemValue = resources.Sum(r => r.Item.ItemValue * r.Count);
        }

        /// <summary>
        /// silver * 10000
        /// </summary>
        public long Silver { get; set; }

        public int AmountCrafted { get; set; }

        /// <summary>
        /// tax * 10000
        /// </summary>
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
            if (Resources.Any(x => x.Item.Cost == 0))
            {
                Cost = 0;
                return;
            }

            var summ = Resources.Sum(x => x.Cost);

            //TODO сделать красиво
            var artefacts = Item.ShopCategory == ShopCategory.Artefacts ? 9 : 1;

            Cost = (summ + Silver + Tax) / AmountCrafted * artefacts;
        }

        protected override void OnSetItem()
        {
            base.OnSetItem();
            Item.ItemBuilding.UpdateTax += BuildingDataOnUpdateTax;
            BuildingDataOnUpdateTax();
        }

        private void BuildingDataOnUpdateTax()
        {
            Tax = 10000 / 100 * Item.ItemBuilding.Tax * Item.ItemValue * 5;
        }
    }
}