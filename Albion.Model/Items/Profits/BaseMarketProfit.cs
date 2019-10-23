using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public abstract class BaseMarketProfit : BaseProfit
    {
        private int _townId;

        protected BaseMarketProfit(CommonItem item, ITownManager townManager) : base(item)
        {
            townManager.TownChanged += TownManagerOnTownChanged;
            GetMarketData().OrdersUpdated += OrdersUpdated;

            TownManagerOnTownChanged(townManager);
            OrdersUpdated(GetMarketData());
        }

        protected int TownId
        {
            get => _townId;
            private set
            {
                if (_townId == value) return;
                GetMarketData().OrdersUpdated -= OrdersUpdated;
                _townId = value;
                GetMarketData().OrdersUpdated += OrdersUpdated;
            }
        }

        private void TownManagerOnTownChanged(ITownManager tm)
        {
            TownId = tm.TownId;
        }

        protected abstract void OrdersUpdated(ItemMarketData imd);

        protected abstract ItemMarketData GetMarketData();
    }
}