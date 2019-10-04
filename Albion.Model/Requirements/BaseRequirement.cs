using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public abstract class BaseRequirement : BaseCostableEntity
    {
        public CommonItem Item { get; private set; }

        internal void SetItem(CommonItem item)
        {
            Item = item;
            OnSetItem();
        }

        protected abstract void OnSetItem();
    }
}