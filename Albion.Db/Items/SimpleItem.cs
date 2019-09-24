using System;
using System.Linq;
using GalaSoft.MvvmLight;

namespace Albion.Db.Items
{
    public class SimpleItem : BaseItem
    {
        public SimpleItem(string id, IPlayerContext context) : base(id)
        {
            CostContainer = new CostContainer(context, this);
        }

        public int Tier { get; set; }
        public float Weight { get; set; }
        public string Uisprite => Id.Substring(3);
        public CraftingRequirement[] CraftingRequirements { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public long ItemValue { get; set; }

        public MarketRequirement CraftingRequirements { get; set; }

        public CostContainer CostContainer { get; }
        public DateTime Time { get; set; }
    }

    public class CostContainer : ObservableObject
    {
        public CostContainer(IPlayerContext context, SimpleItem item)
        {
            Context = context;
            Item = item;
        }

        public void UpdateCosts()
        {
            var minPrice = PriceBuy;
            var price = PriceBuy.Price + OrderTax(PriceBuy.Price);
            if (price > PriceSell.Price)
            {
                price = PriceSell.Price;
                minPrice = PriceSell;
            }

            if (price > PriceCraft.Price)
            {
                price = PriceCraft.Price;
                minPrice = PriceCraft;
            }

            minPrice.IsMin = true;
            Cost = price;
        }

        public long Cost { get; set; }

        public static long OrderTax(long price)
        {
            return price / 1000;
        }

        public static long SellTax(long price)
        {
            return price / 500;
        }

        public PriceHolder PriceHolder { get; }
        public PriceItem PriceBuy;
        public PriceItem PriceSell;
        public PriceItem Price;
        public PriceItem PriceCraft => Item.CraftingRequirements.Min(x => x.Cost);
        public long MinCost => Math.Min(Cost, Price);

        public IPlayerContext Context { get; }
        public SimpleItem Item { get; }
    }
}