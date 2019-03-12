namespace Albion.Db.Items
{
    public class CraftResource
    {
        public SimpleItem Item { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Item} {Count}";
        }
    }
}