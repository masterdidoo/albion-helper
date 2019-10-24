﻿using Albion.DataStore.DataModel;
using Albion.DataStore.Managers;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.DataStore.Model
{
    public class ProxyBuildingData : ItemBuilding
    {
        private readonly BuildingDataManager _manager;
        private readonly ITownManager _crafTownManager;
        private readonly BuildingData _buildingData;

        public ProxyBuildingData(string id, BuildingDataManager manager, ITownManager crafTownManager)
        {
            _manager = manager;
            _crafTownManager = crafTownManager;
            _buildingData = manager.Rep.FindById(id) ?? new BuildingData(id);
            _crafTownManager.TownChanged += ManagerOnTownChanged;
            UpdateTax += OnUpdateTax;
            ManagerOnTownChanged(crafTownManager);
        }

        private void ManagerOnTownChanged(ITownManager townManager)
        {
            UpdateTax -= OnUpdateTax;
            Tax = _buildingData.TaxDatas[_crafTownManager.TownId];
            UpdateTax += OnUpdateTax;
        }

        private void OnUpdateTax()
        {
            _buildingData.TaxDatas[_crafTownManager.TownId] = Tax;

            _manager.Rep.Upsert(_buildingData);
        }
    }
}