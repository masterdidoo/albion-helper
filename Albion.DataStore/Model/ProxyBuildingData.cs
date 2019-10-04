using Albion.DataStore.DataModel;
using Albion.DataStore.Managers;
using Albion.Model.Data;

namespace Albion.DataStore.Model
{
    public class ProxyBuildingData : ItemBuilding
    {
        private readonly BuildingDataManager _manager;
        private readonly BuildingData _buildingData;

        public ProxyBuildingData(string id, BuildingDataManager manager)
        {
            _manager = manager;
            _buildingData = manager.Rep.FindById(id) ?? new BuildingData(id);
            manager.TownChanged += ManagerOnTownChanged;
            UpdateTax += OnUpdateTax;
            ManagerOnTownChanged();
        }

        private void ManagerOnTownChanged()
        {
            UpdateTax -= OnUpdateTax;
            Tax = _buildingData.TaxDatas[_manager.Town].Tax;
            UpdateTax += OnUpdateTax;
        }

        private void OnUpdateTax()
        {
            _buildingData.TaxDatas[_manager.Town].Tax = Tax;

            _manager.Rep.Upsert(_buildingData);
        }
    }
}