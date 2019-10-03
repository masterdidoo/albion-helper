using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public abstract class BaseRequirement : BaseCostableEntity
    {
        public CommonItem Item { get; private set; }

        public void SetParent(CommonItem item)
        {
            Item = item;
            OnSetParent(item);
        }

        protected abstract void OnSetParent(CommonItem item);
    }
}