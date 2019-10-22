using System.Reactive.Linq;
using Albion.Model.Items.Requirements;
using Albion.Model.Managers;
using ReactiveUI;

namespace Albion.Model.Items.Profits
{
    public abstract class BaseMarketProfit : BaseMarketRequirement
    {
        private readonly ObservableAsPropertyHelper<long> _profit;

        protected BaseMarketProfit(ITownManager townManager) : base(townManager)
        {
            _profit = this.WhenAnyValue(
                    x => x.Item.Cost, 
                    x => x.Cost,
                    (ic, cost) => ic > 0 && cost > 0 ? (cost - ic) * 100 / ic : -100)
                .ToProperty(this, x => x.Profit);
            //UpdateCost += OnUpdateCost;
        }

        public long Profit => _profit.Value;
    }
}