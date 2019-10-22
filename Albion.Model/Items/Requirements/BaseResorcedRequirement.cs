using System.Security.Cryptography.X509Certificates;
using Albion.Model.Items.Requirements.Resources;
using DynamicData;
using ReactiveUI;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseResorcedRequirement : BaseRequirement
    {
        protected BaseResorcedRequirement(CraftingResource[] resources)
        {
            Resources = resources;
            foreach (var resource in Resources)
            {
                //resource.WhenAnyValue(x => x.Item.Cost).Subscribe(_ => ResourcesOnUpdateCost());
            }
        }

        protected override void SetSelected(bool value)
        {
            base.SetSelected(value);
            foreach (var resource in Resources)
            {
                resource.IsSelected = value;
            }
        }

        public CraftingResource[] Resources { get; }
        protected abstract void ResourcesOnUpdateCost();

        protected override void OnSetItem()
        {
            ResourcesOnUpdateCost();
        }
    }
}