using System;
using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public class FastBuyRequirement : BaseRequirement
    {
        protected override void OnSetParent(CommonItem item)
        {
            item.MarketData.UpdateSellPrice += OnUpdateSellPrice;
        }

        private void OnUpdateSellPrice(long price)
        {
            Cost = price;
        }
    }
}