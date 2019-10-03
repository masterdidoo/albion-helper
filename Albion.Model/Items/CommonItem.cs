using System.Linq;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Requirements;

namespace Albion.Model.Items
{
    public class CommonItem : BaseCostableEntity
    {
        public CommonItem(CraftingRequirement[] craftingRequirements)
        {
            CraftingRequirements = craftingRequirements;
            foreach (var cr in CraftingRequirements) cr.UpdateCost += CrOnUpdateCost;
        }

        #region From Config

        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        public CraftingRequirement[] CraftingRequirements { get; }

        #endregion


        public MarketData MarketData { get; set; }

        private void CrOnUpdateCost()
        {
            Cost = CraftingRequirements.Min(x => x.Cost);
        }

        public override string ToString()
        {
            return Id;
        }
    }
}