namespace Albion.Db.Items
{
    public class SimpleItem : BaseItem
    {
        public SimpleItem(string id, All all) : base(id)
        {
            PriceHolder = new PriceHolder();
        }

        public int Tier { get; set; }
        public float Weight { get; set; }
        public string Uisprite => Id.Substring(3);
        public CraftingRequirement[] CraftingRequirements { get; set; }
        public ShopCategory ShopCategory { get; set; }

        public PriceHolder PriceHolder { get; }
    }
}