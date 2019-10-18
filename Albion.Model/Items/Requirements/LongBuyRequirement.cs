using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[TownId];

        protected override void OnUpdateSilver()
        {
            Cost = Silver == 0 ? 0 : (Silver + 10000) + (Silver + 10000) * 15 / 1000; //+1 silver and +1,5%
        }

        public LongBuyRequirement(ITownManager townManager) : base(townManager)
        {
        }
    }
}