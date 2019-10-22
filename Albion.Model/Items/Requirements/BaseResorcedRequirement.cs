using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseResorcedRequirement : BaseRequirement
    {
        protected BaseResorcedRequirement(CraftingResource[] resources)
        {
            Resources = resources;
            foreach (var resource in Resources)
            {
                resource.Item.CostChanged += ResourcesOnUpdateCost;
                //resource.Master = this; 
            }
        }

        protected override void OnSelected()
        {
            base.OnSelected();
            foreach (var resource in Resources)
            {
                resource.IsSelected = IsSelected;
            }
        }

        public CraftingResource[] Resources { get; }
        protected abstract void ResourcesOnUpdateCost();
    }
}