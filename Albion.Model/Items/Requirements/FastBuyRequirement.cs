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
            UpdateSilver(Item.ItemMarket.FastBuyItem.BestPrice, Item.ItemMarket.FastBuyItem.UpdateTime);
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.FastBuyItem.BestPrice = Silver;
            Cost = Silver;
        }
    }
}