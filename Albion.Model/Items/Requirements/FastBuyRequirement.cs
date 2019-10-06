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
            Silver = Item.ItemMarket.SellPrice;
        }

        protected override void OnUpdateSilver()
        {
            Cost = Silver;
        }
    }
}