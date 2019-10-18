using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Albion.Common;
using Albion.Model.Data;

namespace Albion.Model.Buildings
{
    public class CraftBuilding : NotifyEntity
    {
        private readonly ItemBuilding _itemBuilding;

        public CraftBuilding(ItemBuilding itemBuilding)
        {
            _itemBuilding = itemBuilding;
            _itemBuilding.UpdateTax += ItemBuildingOnUpdateTax;
        }

        public int Tax
        {
            get => _itemBuilding.Tax;
            set => _itemBuilding.Tax = value;
        }

        #region From Config

        public string Id { get; set; }

        #endregion

        public Location Town { get; set; }

        public event Action UpdateTax;

        private void ItemBuildingOnUpdateTax()
        {
            OnPropertyChanged(nameof(Tax));
            UpdateTax?.Invoke();
        }
    }
}