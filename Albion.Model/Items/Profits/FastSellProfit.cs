using Albion.Model.Items.Requirements;

namespace Albion.Model.Items.Profits
{
    public class FastSellProfit : BaseMarketRequirement
    {
        protected override void OnSetItem()
        {
            Item.ItemMarket.UpdateSellFastPrice += OnUpdatePrice;
            OnUpdatePrice();
        }

        private void OnUpdatePrice()
        {
            Silver = Item.ItemMarket.SellFastPrice;
            Pos = Item.ItemMarket.SellFastPos;
        }

        protected override void OnUpdateSilver()
        {
            Item.ItemMarket.SellFastPrice = Silver;
            Cost = Silver - Silver * 3 /100;//-3%
        }
    }
}