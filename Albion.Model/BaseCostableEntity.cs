using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Albion.Model.Items;
using Albion.Model.Requirements;

namespace Albion.Model
{
    public class BaseCostableEntity : INotifyPropertyChanged
    {
        private long _cost;
        private DateTime _pos;

        public event Action UpdateCost;

        public DateTime Pos
        {
            get => _pos;
            protected set
            {
                if (_pos == value) return;
                _pos = value;
                OnPropertyChanged();
            }
        }

        public long Cost
        {
            get => _cost;
            protected set
            {
                if (_cost == value) return;
                _cost = value;
                Pos = _cost == 0 ? DateTime.MinValue : DateTime.Now;
                UpdateCost?.Invoke();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}