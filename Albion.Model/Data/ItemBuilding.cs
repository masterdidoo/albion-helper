using System;

namespace Albion.Model.Data
{
    public class ItemBuilding
    {
        private int _tax;
        public event Action UpdateTax;

        public int Tax
        {
            get => _tax;
            set
            {
                if (_tax == value) return;
                _tax = value;
                UpdateTax?.Invoke();
            }
        }
    }
}