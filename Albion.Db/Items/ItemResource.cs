namespace Albion.Db.Items
{
    public abstract class BaseResource
    {
        public abstract long Cost { get; }
    }

    public class CraftResource : BaseResource
    {
        public SimpleItem Item { get; set; }
        public int Count { get; set; }
        public override long Cost => Item.CostContainer.Cost * Count;

        public override string ToString()
        {
            return $"{Item} {Count}";
        }
    }

    public class MarketResource : BaseResource
    {
        public bool IsBuy { get; set; }
        public override long Cost => IsBuy ? Price + Price / 1000 : Price;
        public long Price { get; set; }

        public override string ToString()
        {
            return $"{Item} {Count}";
        }
    }
}