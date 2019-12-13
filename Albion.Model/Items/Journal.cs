namespace Albion.Model.Items
{
    public class Journal
    {
        public CommonItem Item { get; }
        public int MaxFame { get; set; }

        public Journal(CommonItem item)
        {
            Item = item;
        }
    }
}