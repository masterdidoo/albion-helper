using Albion.Model.Items.Requirements;

namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseMarketRequirement
    {
//        public FastSellProfit(CommonItem item) : base(item)
//        {
//            item.ItemMarket.UpdateSellFastPrice += OnUpdateCostOrPrice;
//            item.UpdateCost += OnUpdateCostOrPrice;
//            OnUpdateCostOrPrice();
//        }
//
//        private void OnUpdateCostOrPrice()
//        {
//            Silver = Item.ItemMarket.SellFastPrice;
//            if (Item.Cost > 0)
//                Profit = (Silver - Item.Cost) * 100 / Item.Cost;
//            else
//                Profit = -100;
//        }
        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateSellFastPrice += OnUpdatePrice;
            OnUpdatePrice();
        }

        private void OnUpdatePrice()
        {
            Silver = Item.ItemMarket.SellFastPrice;
        }

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver / (100 / 2);
        }
    }
}