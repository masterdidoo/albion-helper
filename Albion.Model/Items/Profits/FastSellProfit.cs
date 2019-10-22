using System;
using System.Linq;
using Albion.Common;
using Albion.Model.Data;
using Albion.Model.Managers;
using ReactiveUI;

namespace Albion.Model.Items.Profits
{
    public class BmFastSellProfit : FastSellProfit
    {
        private int _count;
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[(int)Location.BlackMarket];

        public int Count
        {
            get => _count;
            set
            {
                if (_count == value) return;
                _count = value;
                OnPropertyChanged();
            }
        }

        readonly ObservableAsPropertyHelper<long> _profitSum;
        public long ProfitSum => _profitSum.Value;

        private void OnUpdateCosts()
        {
            Count = ItemMarketData.Orders.OrderByDescending(x=>x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
        }

        public BmFastSellProfit(ITownManager townManager) : base(townManager)
        {
            _profitSum = this.WhenAnyValue(
                x => x.Item.Cost, 
                x => x.Cost, 
                x => x.Count, 
                (ic, cost, count) => (cost - ic) * count)
                .ToProperty(this, x=>x.ProfitSum);
        }

        protected override void OnSetItem()
        {
            base.OnSetItem();
            ItemMarketData.UpdateOrders += OnUpdateCosts;

            OnUpdateCosts();
        }
    }

    public class FastSellProfit : BaseMarketProfit
    {
        public FastSellProfit(ITownManager townManager) : base(townManager)
        {
        }

        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[TownId];

        protected override void OnUpdateSilver()
        {
            Cost = Silver - Silver * 3 / 100; //-3%
        }
    }
}