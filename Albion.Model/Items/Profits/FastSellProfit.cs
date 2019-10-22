using System;
using System.Linq;
using Albion.Common;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class BmFastSellProfit : FastSellProfit
    {
        private int _count;
        private long _profitSum;
        protected override ItemMarketData ItemMarketData => Item.ItemMarket.ToMarketItems[(int)Location.BlackMarket];

        public int Count
        {
            get => _count;
            set
            {
                if (_count == value) return;
                _count = value;
                RaisePropertyChanged();
            }
        }

        public long ProfitSum
        {
            get => _profitSum;
            set
            {
                if (_profitSum == value) return;
                _profitSum = value;
                RaisePropertyChanged();
            }
        }

        private void OnCostUpdate()
        {
            Count = ItemMarketData.Orders.OrderByDescending(x=>x.UnitPriceSilver).FirstOrDefault()?.Amount ?? 0;
            ProfitSum = (Cost - Item.Cost) * Count;
        }

        public BmFastSellProfit(ITownManager townManager) : base(townManager)
        {
        }

        protected override void OnSetItem()
        {
            base.OnSetItem();
            ItemMarketData.UpdateOrders += OnCostUpdate;
            Item.CostUpdate += OnCostUpdate;
            CostUpdate += OnCostUpdate;

            OnCostUpdate();
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