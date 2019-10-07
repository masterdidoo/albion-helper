using Albion.Model.Items.Requirements;

namespace Albion.Model.Items.Profits
{
    public class LongSellProfit : BaseMarketRequirement
    {
//        public LongSellProfit(CommonItem item) : base(item)
//        {
//            item.ItemMarket.UpdateSellLongPrice += OnUpdateCostOrPrice;
//            item.UpdateCost += OnUpdateCostOrPrice;
//            OnUpdateCostOrPrice();
//        }
//
//        private void OnUpdateCostOrPrice()
//        {
//            Silver = Item.ItemMarket.SellLongPrice;
//            if (Item.Cost > 0)
//                Profit = (Silver - Item.Cost) * 100 / Item.Cost;
//            else
//                Profit = -100;
//        }

        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateSellLongPrice += OnUpdatePrice;
            OnUpdatePrice();
        }

        private void OnUpdatePrice()
        {
            Silver = Item.ItemMarket.SellLongPrice;
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.SellLongPrice = Silver;
            Cost = Silver - Silver * 3 / 100;
        }
    }
}