using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Albion.Common;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Buildings
{
    public class CraftBuilding : NotifyEntity
    {
        private readonly ItemBuilding _itemBuilding;

        public CraftBuilding(ItemBuilding itemBuilding, ITownManager craftTownManager)
        {
            _itemBuilding = itemBuilding;
            _itemBuilding.UpdateTax += ItemBuildingOnUpdateTax;
            craftTownManager.TownChanged += CraftTownManagerOnTownChanged;
        }

        private void CraftTownManagerOnTownChanged(ITownManager ctm)
        {
            Town = ctm.Town;
            ItemBuildingOnUpdateTax();
        }

        public int Tax
        {
            get => _itemBuilding.Tax;
            set => _itemBuilding.Tax = value;
        }

        #region From Config

        public string Id { get; set; }
        public string Name { get; set; }

        #endregion

        public Location Town { get; set; }

        public event Action UpdateTax;

        private void ItemBuildingOnUpdateTax()
        {
            RaisePropertyChanged(nameof(Tax));
            UpdateTax?.Invoke();
        }
    }
}