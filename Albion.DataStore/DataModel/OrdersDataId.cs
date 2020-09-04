namespace Albion.DataStore.DataModel
{
    public struct OrdersDataId
    {
        public OrdersDataId(string itemId, int townId, bool isFrom) : this()
        {
            ItemId = itemId;
            TownId = townId;
            IsFrom = isFrom;
        }

        public string ItemId { get; set; }
        public int TownId { get; set; }
        public bool IsFrom { get; set; }
    }
}