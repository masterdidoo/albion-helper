using System;

namespace Albion.Model.Items
{
    public class Journal : NotifyEntity
    {
        public CommonItem EmptyItem { get; }
        public CommonItem FullItem { get; private set; }
        public long Profit => FullItem.Profitt.Income - EmptyItem.Cost;
        public int MaxFame { get; set; }

        public Journal(CommonItem emptyItem)
        {
            EmptyItem = emptyItem;
            EmptyItem.CostUpdate += OnProfitUpdate;
        }

        public void SetFullItem(CommonItem item)
        {
            FullItem = item;
            FullItem.ProfitUpdated += OnProfitUpdate;
        }

        private void OnProfitUpdate()
        {
            RaisePropertyChanged(nameof(Profit));
        }
    }
}