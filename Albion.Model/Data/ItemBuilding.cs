using System;

namespace Albion.Model.Data
{
    public class ItemBuilding
    {
        private int _tax;

        /// <summary>
        ///     tax %
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

        public event Action UpdateTax;
    }
}