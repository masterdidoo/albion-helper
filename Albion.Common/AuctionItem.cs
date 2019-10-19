using System;

namespace Albion.Common
{
    public class AuctionItem
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public long TotalPriceSilver { get; set; }
        public long UnitPriceSilver { get; set; }
        public AuctionType AuctionType { get; set; }
        public Guid? BuyerCharacterId { get; set; }
        public string BuyerName { get; set; }
        public int EnchantmentLevel { get; set; }
        public string Expires { get; set; }
        public bool HasBuyerFetched { get; set; }
        public bool HasSellerFetched { get; set; }
        public bool IsFinished { get; set; }
        public string ItemGroupTypeId { get; set; }
        public string ItemTypeId { get; set; }
        public int QualityLevel { get; set; }
        public Guid? SellerCharacterId { get; set; }
        public string SellerName { get; set; }
        public int Tier { get; set; }
    }
}