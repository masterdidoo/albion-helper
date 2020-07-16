namespace Albion.Model.Items
{
    public class Journal
    {
        public CommonItem EmptyItem { get; }
        public CommonItem FullItem { get; set; }
        public int MaxFame { get; set; }

        public Journal(CommonItem emptyItem)
        {
            EmptyItem = emptyItem;
        }
    }
}