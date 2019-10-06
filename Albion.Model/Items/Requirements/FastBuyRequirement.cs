namespace Albion.Model.Items.Requirements
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
            OnPropertyChanged(nameof(Silver));
        }

        public long Silver
        {
            get => Item.ItemMarket.SellPrice;
            set => Item.ItemMarket.SellPrice = value;
        }
    }
}