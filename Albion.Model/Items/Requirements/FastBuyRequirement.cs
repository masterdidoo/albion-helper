using Albion.Model.Data;

namespace Albion.Model.Items.Requirements
{
    public class FastBuyRequirement : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.FastBuyItem;

        protected override void OnUpdateSilver()
        {
            Cost = Silver;
        }
    }
}