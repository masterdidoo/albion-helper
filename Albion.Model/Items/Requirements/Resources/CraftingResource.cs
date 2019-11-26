namespace Albion.Model.Items.Requirements.Resources
{
    public class CraftingResource : NotifyEntity
    {
        public CraftingResource(CommonItem item, int count, bool isReturnable)
        {
            TreeProps = new TreeProps {IsExpanded = false};
            Item = item;
            Count = count;
            IsReturnable = isReturnable;
            Item.CostUpdate += ItemOnCostUpdate;
        }

        private void ItemOnCostUpdate()
        {
            RaisePropertyChanged(nameof(Cost));
        }

        public CommonItem Item { get; }
        public int Count { get; }
        public bool IsReturnable { get; }
        public long Cost => Item.Cost * Count;

        public TreeProps TreeProps { get; }

        public override string ToString() => $"{Item}[{Count}]";
    }
}