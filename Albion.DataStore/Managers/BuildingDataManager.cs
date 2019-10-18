using System.Collections.Generic;
using Albion.DataStore.DataModel;
using Albion.DataStore.Model;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.DataStore.Managers
{
    public class BuildingDataManager : BaseDataManager<BuildingData, ItemBuilding>, IBuildingDataManager
    {
        private readonly ITownManager _townManager;

        public BuildingDataManager(ITownManager townManager)
        {
            _townManager = townManager;
        }

        protected override ItemBuilding CreateData(string id)
        {
            return new ProxyBuildingData(id, this, _townManager);
        }

        public void UpdateTax(string id, int tax)
        {
            Data[id].Tax = tax;
        }
    }
}