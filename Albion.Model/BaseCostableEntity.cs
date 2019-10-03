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
        public event Action UpdateCost;

        public long Cost
        {
            get => _cost;
            protected set
            {
                if (_cost == value) return;
                _cost = value;
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