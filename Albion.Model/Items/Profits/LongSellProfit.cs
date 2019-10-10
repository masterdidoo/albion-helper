using Albion.Model.Items.Requirements;

namespace Albion.Model.Items.Profits
{
    public class LongSellProfit : BaseMarketRequirement
    {
        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateSellLongPrice += OnUpdatePrice;
            OnUpdatePrice();
        }

        private void OnUpdatePrice()
        {
            Silver = Item.ItemMarket.SellLongPrice;
            Pos = Item.ItemMarket.SellLongPos;
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.SellLongPrice = Silver;
            Cost = Silver - Silver * 45 / 1000; //-1.5% and -3%
        }
    }
}