using Albion.Model.Items;

namespace Albion.Model.Requirements
{
    public class CraftingResource
    {
        public CommonItem Item { get; set; }
        public int Count { get; set; }

        public override string ToString() => $"{Item}[{Count}]";
    }
}