using System;
using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public class LongBuyRequirement : BaseRequirement
    {
        protected override void OnSetParent(CommonItem item)
        {
            item.MarketData.UpdateBuyPrice += OnUpdateBuyPrice;
        }

        private void OnUpdateBuyPrice(long price)
        {
            Cost = (price + 10000) + (price + 10000) / 100;
        }
    }
}