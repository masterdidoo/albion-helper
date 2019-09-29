using System;
using Albion.Db.Items.Requirements.Resources;
using GalaSoft.MvvmLight;

namespace Albion.Db.Items.ViewModels
{
    public class ArtefactVm : ObservableObject
    {
        private long? _fastCost;
        private long? _fastProfit;
        private long? _longCost;
        private long? _longProfit;
        private long? _longAllCost;
        private long? _fastAllCost;
        private long? _fastLongProfit;
        private DateTime? _time;
        private CraftResource cr;

        public ArtefactVm(SimpleItem item)
        {
            Item = item;
            cr = Item.CraftingRequirements[0].CraftResources[0];
            item.FastBuyRequirement.Updated += ItemOnUpdated;
            item.LongBuyRequirement.Updated += ItemOnUpdated;
            cr.Item.FastBuyRequirement.Updated += ItemOnUpdated;
            cr.Item.LongBuyRequirement.Updated += ItemOnUpdated;
//            item.PropertyChanged += (sender, args) => { ItemOnUpdated(); };
            ItemOnUpdated();
        }

        public SimpleItem Item { get; }

        public long? LongProfit
        {
            get => _longProfit;
            set => Set(ref _longProfit, value);
        }

        public long? FastProfit
        {
            get => _fastProfit;
            set => Set(ref _fastProfit, value);
        }

        public long? LongCost
        {
            get => _longCost / 10000;
            set => Set(ref _longCost, value);
        }

        public long? FastCost
        {
            get => _fastCost / 10000;
            set => Set(ref _fastCost, value);
        }

        private void ItemOnUpdated()
        {

            FastAllCost = cr.Item.FastSellPrice * (cr.Count / 4);
            LongAllCost = cr.Item.LongSellPrice * (cr.Count / 4);

            FastCost = Item.FastBuyRequirement.Cost / (cr.Count / 4);
            LongCost = Item.LongBuyRequirement.Cost / (cr.Count / 4);

            FastProfit = cr.Item.FastSellPrice * 100 / _fastCost - 100;
            LongProfit = cr.Item.LongSellPrice * 100 / _longCost - 100;
            FastLongProfit = cr.Item.LongSellPrice * 100 / _fastCost - 100;

            Time = (Item.CostContainer.BuyTime ?? DateTime.MinValue) > (Item.CostContainer.SellTime ?? DateTime.MinValue) ? Item.CostContainer.BuyTime : Item.CostContainer.SellTime;
        }

        public DateTime? Time
        {
            get => _time;
            set => Set(ref _time , value);
        }

        public long? FastLongProfit
        {
            get => _fastLongProfit;
            set => Set(ref _fastLongProfit, value);
        }

        public long? LongAllCost
        {
            get => _longAllCost / 10000;
            set => Set(ref _longAllCost , value);
        }

        public long? FastAllCost
        {
            get => _fastAllCost / 10000;
            set => Set(ref _fastAllCost , value);
        }
    }
}