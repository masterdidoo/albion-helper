using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseResorcedRequirement : BaseRequirement
    {
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

        protected abstract void ResourcesOnCostUpdate();

        protected override void OnSetItem()
        {
            foreach (var resource in Resources) resource.Item.CostUpdate += ResourcesOnCostUpdate;
            ResourcesOnCostUpdate();
        }
    }
}