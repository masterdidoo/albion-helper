namespace Albion.Model.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateBuyPrice += OnUpdateBuyPrice;
            OnUpdateBuyPrice();
        }

        private void OnUpdateBuyPrice()
        {
            Silver = Item.ItemMarket.BuyPrice;
            Pos = Item.ItemMarket.BuyPos;
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.BuyPrice = Silver;
            Cost = Silver == 0 ? 0 : (Silver + 10000) + (Silver + 10000) / 100;
        }
    }
}