﻿using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseResorcedRequirement : BaseRequirement
    {
        public const int ItemValueToNutrition = 1125;
        protected BaseResorcedRequirement(CraftingResource[] resources)
        {
            Resources = resources;
        }

//        protected override void SetSelected(bool value)
//        {
//            base.SetSelected(value);
//            foreach (var resource in Resources)
//            {
//                resource.IsSelected = value;
//            }
//        }

        public CraftingResource[] Resources { get; }
        public abstract int ReturnProc { get; }

        protected abstract void ResourcesOnCostUpdate();

        protected override void OnSetItem()
        {
            foreach (var resource in Resources) resource.Item.CostUpdate += ResourcesOnCostUpdate;
            ResourcesOnCostUpdate();
        }
    }
}