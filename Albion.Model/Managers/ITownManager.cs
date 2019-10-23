using System;
using Albion.Common;

namespace Albion.Model.Managers
{
    public interface ITownManager
    {
        Location Town { get; }
        int TownId { get; }
        event Action<ITownManager> TownChanged;
    }

    public class TownManager : NotifyEntity, ITownManager
    {
        private Location _town;

        public Location Town
        {
            get => _town;
            set
            {
                if (_town == value) return;
                _town = value;
                TownChanged?.Invoke(this);
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(TownId));
            }
        }

        public int TownId => (int) _town;

        public event Action<ITownManager> TownChanged;
    }
}