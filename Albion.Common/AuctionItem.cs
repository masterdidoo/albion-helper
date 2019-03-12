using System;

namespace Albion.Common
{
    public class AuctionItem
    {
        public long Id;
        public int Amount;
        public long TotalPriceSilver;
        public long UnitPriceSilver;
        public AuctionType AuctionType;
        public Guid? BuyerCharacterId;
        public string BuyerName;
        public int EnchantmentLevel;
        public string Expires;
        public bool HasBuyerFetched;
        public bool HasSellerFetched;
        public bool IsFinished;
        public string ItemGroupTypeId;
        public string ItemTypeId;
        public int QualityLevel;
        public Guid? SellerCharacterId;
        public string SellerName;
        public int Tier;

    }
}