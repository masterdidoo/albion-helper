using System.Collections.Generic;
using System.Linq;
using Albion.Model.Buildings;
using Albion.Model.Managers;
using GalaSoft.MvvmLight;

namespace Albion.GUI
{
    public class BuildingsViewModel : ObservableObject
    {
        private readonly Dictionary<string, CraftBuilding> _loaderCraftBuildings;

        public BuildingsViewModel(Dictionary<string, CraftBuilding> loaderCraftBuildings, ITownManager townManager)
        {
            _loaderCraftBuildings = loaderCraftBuildings;
            townManager.TownChanged += BdmOnTownChanged;
        }

        private void BdmOnTownChanged(ITownManager tm)
        {
            RaisePropertyChanged(nameof(Buildings));
        }

        public IEnumerable<CraftBuilding> Buildings => _loaderCraftBuildings.Values.OrderBy(x=>x.Name);
    }
}