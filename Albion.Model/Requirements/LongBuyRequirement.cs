using System;
using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public class LongBuyRequirement : BaseRequirement
    {
        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateBuyPrice += OnUpdateBuyPrice;
            OnUpdateBuyPrice();
        }

        private void OnUpdateBuyPrice()
        {
            var price = Item.ItemMarket.BuyPrice;
            if (price == 0)
            {
                Cost = 0;
                return;
            }

            Cost = (price + 10000) + (price + 10000) / 100;
            OnPropertyChanged(nameof(Silver));
        }

        public long Silver
        {
            get => Item.ItemMarket.BuyPrice;
            set => Item.ItemMarket.BuyPrice = value;
        }
    }
}