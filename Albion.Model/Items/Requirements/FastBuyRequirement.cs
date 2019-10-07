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
            Pos = Item.ItemMarket.SellPos;
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.SellPrice = Silver;
            Cost = Silver;
        }
    }
}