using Albion.Model.Items.Requirements;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public abstract class BaseMarketProfit : BaseMarketRequirement
    {
        private long _profit;

        protected BaseMarketProfit(ITownManager townManager) : base(townManager)
        {
            CostUpdate += OnCostUpdate;
        }

        protected override void OnSetItem()
        {
            base.OnSetItem();
            Item.CostUpdate += OnCostUpdate;
            OnCostUpdate();
        }

        public long Profit
        {
            get => _profit;
            protected set
            {
                if (_profit == value) return;
                _profit = value;
                RaisePropertyChanged();
            }
        }

        private void OnCostUpdate()
        {
            Profit = Item.Cost > 0 && Cost > 0 ? (Cost - Item.Cost) * 100 / Item.Cost : -100;
        }
    }
}