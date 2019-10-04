using System;

namespace Albion.Model.Data
{
    public class ItemBuilding
    {
        private int _tax;
        public event Action UpdateTax;

        /// <summary>
        /// tax %
        /// </summary>
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