namespace Albion.Model.Items.Requirements.Resources
{
    public class CraftingResource
    {
        public CommonItem Item { get; set; }
        public int Count { get; set; }
        public long Cost => Item.Cost * Count;

        public override string ToString() => $"{Item}[{Count}]";
    }
}