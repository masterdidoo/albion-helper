using System;
using System.ComponentModel;

namespace Albion.Model
{
    public class BaseCostableEntity : NotifyEntity
    {
        private long _cost;
        private DateTime _pos;

        public event Action CostUpdate;

        public DateTime Pos
        {
            get => _pos;
            set
            {
                if (Equals(_pos, value)) return;
                _pos = value;
                RaisePropertyChanged();
            }
        }

        public long Cost
        {
            get => _cost;
            protected set
            {
                if (_cost == value) return;
                _cost = value;
                //Pos = _cost == 0 ? DateTime.MinValue : DateTime.Now;
                CostUpdate?.Invoke();
                RaisePropertyChanged();
            }
        }
    }
}