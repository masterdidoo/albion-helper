namespace Albion.Model.Items.Profits
{
    public class LongSellProfit : BaseProfit
    {
        public LongSellProfit(CommonItem item) : base(item)
        {
            item.ItemMarket.UpdateSellLongPrice += OnUpdateCostOrPrice;
            item.UpdateCost += OnUpdateCostOrPrice;
            OnUpdateCostOrPrice();
        }

        private void OnUpdateCostOrPrice()
        {
            Silver = Item.ItemMarket.SellLongPrice;
            if (Item.Cost > 0)
                Profit = (Silver - Item.Cost) * 100 / Item.Cost;
            else
                Profit = -100;
        }
    }
}