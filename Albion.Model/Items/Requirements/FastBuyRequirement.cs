using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Requirements
{
    public class FastBuyRequirement : BaseMarketRequirement
    {
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.FromMarketItems[TownId];

        protected override void OnUpdateSilver()
        {
            Cost = Silver;
        }

        public FastBuyRequirement(ITownManager townManager) : base(townManager)
        {
        }
    }
}