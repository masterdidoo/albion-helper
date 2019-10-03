using System;

namespace Albion.Model
{
    public class BaseCostableEntity
    {
        private long _cost;
        public event Action UpdateCost;

        public long Cost
        {
            get => _cost;
            set
            {
                if (_cost == value) return;
                _cost = value;
                UpdateCost?.Invoke();
            }
        }
    }
}