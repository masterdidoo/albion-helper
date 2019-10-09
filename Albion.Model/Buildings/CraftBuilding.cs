using System.ComponentModel;
using System.Runtime.CompilerServices;
using Albion.Common;
using Albion.Model.Data;

namespace Albion.Model.Buildings
{
    public class CraftBuilding : INotifyPropertyChanged
    {
        public CraftBuilding(ItemBuilding itemBuilding)
        {
            ItemBuilding = itemBuilding;
            ItemBuilding.UpdateTax += ItemBuildingOnUpdateTax;
        }

        public int Tax
        {
            get => ItemBuilding.Tax;
            set => ItemBuilding.Tax = value;
        }

        #region From Config

        public string Id { get; set; }

        #endregion

        public ItemBuilding ItemBuilding { get; }

        public Location Town { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ItemBuildingOnUpdateTax()
        {
            OnPropertyChanged(nameof(Tax));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}