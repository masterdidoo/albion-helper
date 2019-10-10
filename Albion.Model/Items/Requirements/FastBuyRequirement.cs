namespace Albion.Model.Items.Requirements
{
    public class FastBuyRequirement : BaseMarketRequirement
    {
        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateSellPrice += OnUpdateSellPrice;
            OnUpdateSellPrice();
        }

        private void OnUpdateSellPrice()
        {
            UpdateSilver(Item.ItemMarket.SellPrice, Item.ItemMarket.SellPos);
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.SellPrice = Silver;
            Cost = Silver;
        }
    }
}