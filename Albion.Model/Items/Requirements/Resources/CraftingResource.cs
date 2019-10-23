namespace Albion.Model.Items.Requirements.Resources
{
    public class CraftingResource : NotifyEntity
    {
        protected CraftingResource()
        {
            TreeProps = new TreeProps {IsExpanded = true};
        }

        public CommonItem Item { get; set; }
        public int Count { get; set; }
        public long Cost => Item.Cost * Count;

        public TreeProps TreeProps { get; }

        public override string ToString() => $"{Item}[{Count}]";
    }
}