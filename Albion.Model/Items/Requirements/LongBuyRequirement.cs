using Albion.Model.Data;

namespace Albion.Model.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.LongBuyItem;

        protected override void OnUpdateSilver()
        {
            Cost = Silver == 0 ? 0 : (Silver + 10000) + (Silver + 10000) * 15 / 1000; //+1 silver and +1,5%
        }
    }
}