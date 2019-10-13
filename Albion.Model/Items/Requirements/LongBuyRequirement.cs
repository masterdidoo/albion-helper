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
            UpdateSilver(Item.ItemMarket.LongBuyItem.BestPrice, Item.ItemMarket.LongBuyItem.UpdateTime);
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.LongBuyItem.BestPrice = Silver;
            Cost = Silver == 0 ? 0 : (Silver + 10000) + (Silver + 10000) * 15 / 1000; //+1 silver and +1,5%
        }
    }
}