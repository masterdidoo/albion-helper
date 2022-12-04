using Albion.Common;

namespace Albion.Operation
{
    public class AuctionSell : AuctionBase
    {
        public override OperationCodes Code => OperationCodes.AuctionGetOffers;
    }
}