namespace Albion.Model.Items
{
    public class BaseItem
    {
        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        public CraftingRequirement[] CraftingRequirements { get; set; }

        public override string ToString() => Id;
    }

    public class CraftingRequirement
    {
        public long Silver { get; set; }
        public int AmountCrafted { get; set; }
        public CraftingResource[] Resources { get; set; }
    }

    public class CraftingResource
    {
        public BaseItem Item { get; set; }
        public int Count { get; set; }

        public override string ToString() => $"{Item}[{Count}]";
    }
}
