﻿using System;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseMarketRequirement : BaseRequirement
    {
        private readonly ITownManager _townManager;
        private int _townId;

        protected BaseMarketRequirement(ITownManager townManager)
        {
            _townManager = townManager;
        }

        protected override void OnSetItem()
        {
            _townManager.TownChanged += TownManagerOnTownChanged;
            _townId = _townManager.TownId;
            var md = GetMarketData();
            md.OrdersUpdated += OrdersUpdated;
            OrdersUpdated(md);
        }

        protected int TownId
        {
            get => _townId;
            private set
            {
                if (_townId == value) return;
                GetMarketData().OrdersUpdated -= OrdersUpdated;
                _townId = value;
                GetMarketData().OrdersUpdated += OrdersUpdated;
            }
        }

        private void TownManagerOnTownChanged(ITownManager tm)
        {
            TownId = tm.TownId;
        }

        protected abstract void OrdersUpdated(ItemMarketData imd);

        protected abstract ItemMarketData GetMarketData();
    }
}