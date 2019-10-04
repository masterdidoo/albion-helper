using System;
using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public class FastBuyRequirement : BaseRequirement
    {
        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateSellPrice += OnUpdateSellPrice;
            OnUpdateSellPrice();
        }

        private void OnUpdateSellPrice()
        {
            Cost = Item.ItemMarket.SellPrice;
        }
    }
}