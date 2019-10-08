using System.Collections.Generic;
using System.Linq;
using Albion.DataStore.Managers;
using Albion.GUI.ViewModels;
using Albion.Model.Buildings;
using GalaSoft.MvvmLight;

namespace Albion.GUI
{
    public class BuildingsViewModel : ObservableObject
    {
        private readonly Dictionary<string, CraftBuilding> _loaderCraftBuildings;
        private readonly MainViewModel _main;

        public BuildingsViewModel(MainViewModel main, Dictionary<string, CraftBuilding> loaderCraftBuildings,
            BuildingDataManager bdm)
        {
            _main = main;
            _loaderCraftBuildings = loaderCraftBuildings;
            bdm.TownChanged += BdmOnTownChanged;
        }

        private void BdmOnTownChanged()
        {
            RaisePropertyChanged(nameof(Buildings));
        }

        public IEnumerable<CraftBuilding> Buildings => _loaderCraftBuildings.Values.OrderBy(x=>x.Id);
    }
}