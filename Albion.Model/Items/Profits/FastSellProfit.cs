namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseProfit
    {
        public FastSellProfit(CommonItem item) : base(item)
        {
            item.ItemMarket.UpdateSellFastPrice += OnUpdateCostOrPrice;
            item.UpdateCost += OnUpdateCostOrPrice;
            OnUpdateCostOrPrice();
        }

        private void OnUpdateCostOrPrice()
        {
            Silver = Item.ItemMarket.SellFastPrice;
            if (Item.Cost > 0)
                Profit = (Silver - Item.Cost) * 100 / Item.Cost;
            else
                Profit = -100;
        }
    }
}