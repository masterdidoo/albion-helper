using System.Collections.Generic;
using Albion.DataStore.DataModel;
using Albion.DataStore.Model;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.DataStore.Managers
{
    public class BuildingDataManager : BaseDataManager<BuildingData, ItemBuilding>, IBuildingDataManager
    {
        protected override ItemBuilding CreateData(string id)
        {
            return new ProxyBuildingData(id, this);
        }

        public void UpdateTax(string id, int tax)
        {
            _data[id].Tax = tax;
        }
    }
}