using System.Linq;
using Albion.Common;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public class CraftingRequirement : BaseResorcedRequirement
    {
        private const long Return35 = 1533;
        private const long Return25 = 1330;
        private const long Return15 = 1175;

        public CraftingRequirement(CraftingResource[] resources) : base(resources)
        {
            //ItemValue = resources.Sum(r => r.Item.ItemValue * r.Count);
        }

        public Location CraftTown => Item.CraftingBuilding.Town;

        protected override void ResourcesOnCostUpdate()
        {
            Tax = 10000 / 100 * Item.CraftingBuilding.Tax * Item.ItemValue * 5 + Silver;

            if (Resources.Any(x => x.Item.Cost == 0))
            {
                SetCost(0, 1);
                return;
            }

            var resourceCost = Resources.Where(r => r.Item.IsResource).Sum(x => x.Cost) * 1000 / GetReturnCoeff();
            var summ = Resources.Where(r => !r.Item.IsResource).Sum(x => x.Cost) + resourceCost;

            //TODO сделать красиво
            var artefacts = Item.ShopCategory == ShopCategory.Artefacts ? 9 : 1;

            var cost = (summ + Tax) / AmountCrafted * artefacts;

            SetCost(cost, 1);
        }

        private long GetReturnCoeff()
        {
            switch (Item.ShopSubCategory)
            {
                case ShopSubCategory.Planks:
                    if (CraftTown == Location.FortSterling) return Return35;
                    break;
                case ShopSubCategory.Stoneblock:
                    if (CraftTown == Location.Bridgewatch) return Return35;
                    break;
                case ShopSubCategory.Metalbar:
                    if (CraftTown == Location.Thetford) return Return35;
                    break;
                case ShopSubCategory.Leather:
                    if (CraftTown == Location.Martlock) return Return35;
                    break;
                case ShopSubCategory.Cloth:
                    if (CraftTown == Location.Lymhurst) return Return35;
                    break;
            }

            switch (Item.ShopCategory)
            {
                case ShopCategory.Offhand:
                    if (CraftTown == Location.Martlock) return Return25;
                    break;
            }

            if (CraftTown < Location.BlackMarket) return Return15;

            return 1000;
        }

        protected override void OnSetItem()
        {
            Item.CraftingBuilding.UpdateTax += ResourcesOnCostUpdate;
            ResourcesOnCostUpdate();
            base.OnSetItem();
        }

        /// <summary>
        ///     tax * 10000
        /// </summary>

        #region Tax

        private long _tax;

        public long Tax
        {
            get => _tax;
            private set
            {
                if (_tax == value) return;
                _tax = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Config

        /// <summary>
        ///     silver * 10000
        /// </summary>
        public long Silver { get; set; }

        public int AmountCrafted { get; set; }

        #endregion
    }
}