using Albion.Model.Items.Requirements;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public abstract class BaseMarketProfit : BaseMarketRequirement
    {
        private long _profit;

        protected BaseMarketProfit(ITownManager townManager) : base(townManager)
        {
            UpdateCost += OnUpdateCost;
        }

        protected override void OnSetItem()
        {
            base.OnSetItem();
            Item.UpdateCost += OnUpdateCost;
            OnUpdateCost();
        }

        public long Profit
        {
            get => _profit;
            protected set
            {
                if (_profit == value) return;
                _profit = value;
                OnPropertyChanged();
            }
        }

        private void OnUpdateCost()
        {
            Profit = Item.Cost > 0 && Cost > 0 ? (Cost - Item.Cost) * 100 / Item.Cost : -100;
        }
    }
}