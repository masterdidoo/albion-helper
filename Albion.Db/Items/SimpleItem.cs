namespace Albion.Db.Items
{
    public class SimpleItem : BaseItem
    {
        public SimpleItem(string id) : base(id)
        {
        }

        public int Tier { get; set; }
        public float Weight { get; set; }
        public string Uisprite => Id.Substring(3);
        public CraftingRequirement[] CraftingRequirements { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public long PriceToBye { get; set; } = -1;
        public long PriceToSell { get; set; } = -1;
    }
}