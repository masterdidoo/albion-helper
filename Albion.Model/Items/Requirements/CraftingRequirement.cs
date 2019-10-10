using System;
using System.Linq;
using Albion.Common;
using Albion.Model.Data;
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

            var resourceCost = Resources.Where(r=>r.Item.IsResource).Sum(x => x.Cost) * 1000 / GetReturnCoeff();
            var summ = Resources.Where(r => !r.Item.IsResource).Sum(x => x.Cost) + resourceCost;

            //TODO сделать красиво
            var artefacts = Item.ShopCategory == ShopCategory.Artefacts ? 9 : 1;

            if (Resources.Length > 0)
            {
                var pos = Resources.Max(x => x.Item.Pos);
                Pos = (pos.Ticks > 1) ? pos.AddTicks(-1) : pos;
            }

            Cost = (summ + Tax) / AmountCrafted * artefacts;
        }

        private long GetReturnCoeff()
        {
            switch (Item.ShopSubCategory)
            {
                case ShopSubCategory.Planks:
                    if (CostCalcOptions.Instance.CraftTown == Location.FortSterling) return Return35;
                    break;
                case ShopSubCategory.Stoneblock:
                    if (CostCalcOptions.Instance.CraftTown == Location.Bridgewatch) return Return35;
                    break;
                case ShopSubCategory.Metalbar:
                    if (CostCalcOptions.Instance.CraftTown == Location.Thetford) return Return35;
                    break;
                case ShopSubCategory.Leather:
                    if (CostCalcOptions.Instance.CraftTown == Location.Martlock) return Return35;
                    break;
                case ShopSubCategory.Cloth:
                    if (CostCalcOptions.Instance.CraftTown == Location.Lymhurst) return Return35;
                    break;
            }
            return Return15;
        }

        private const long Return35 = 1533;
        private const long Return25 = 1330;
        private const long Return15 = 1175;

        protected override void OnSetItem()
        {
            base.OnSetItem();
            if (Silver > 0)
            {
                Tax = Silver;
                return;
            }
            Item.ItemBuilding.UpdateTax += BuildingDataOnUpdateTax;
            BuildingDataOnUpdateTax();
        }

        private void BuildingDataOnUpdateTax()
        {
            Tax = 10000 / 100 * Item.ItemBuilding.Tax * Item.ItemValue * 5;
        }
    }
}