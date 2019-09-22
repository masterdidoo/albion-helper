using System;
using GalaSoft.MvvmLight;

namespace Albion.Db.Items
{
    public class PriceItem : ObservableObject
    {
        private long _price;
        private DateTime _time = DateTime.MinValue;

        public DateTime Time
        {
            get => _time;
            set => Set(ref _time, value);
        }

        public long Price
        {
            get => _price;
            set => Set(ref _price, value);
        }
    }
}