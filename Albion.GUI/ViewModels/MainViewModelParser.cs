using System.Linq;
using Albion.Common;
using Albion.Event;
using Albion.Model.Data;
using Albion.Operation;

namespace Albion.GUI.ViewModels
{
    public partial class MainViewModel
    {
        private static readonly string Level = "_LEVEL";

        private void InitAlbionParser()
        {
            _albionParser.AddEventHandler<PlayerCounts>(p =>
            {
                BluePlayers = p.Blue > 0 ? p.Blue : 0;
                RedPlayers = p.Red > 0 ? p.Red : 0;
            });

            _albionParser.AddOperationHandler<ConsloeCommand>(p =>
            {
                if (p.Town != Location.None)
                {
                    Town = p.Town;
                    SellTown = p.Town;
                }
            });

            _albionParser.AddOperationHandler<AuctionBuyOffer>(AuctionBuyOfferHandler);

            _albionParser.AddOperationHandler<AuctionGetRequests>(AuctionGetRequestsHandler);

            _albionParser.Start();
        }

        private void AuctionGetRequestsHandler(AuctionGetRequests p)
        {
            if (p.Items.Length == 0) return;
            var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
            foreach (var item in items)
                if (items.Length > 1)
                {
                    var bdprice = MdmGetData(item.Key);
                    var min = item.Min(x => x.UnitPriceSilver);
                    if (bdprice.SellLongPrice > min || bdprice.SellFastPrice == 0 && min > 0)
                        bdprice.SellLongPrice = min;
                }
                else
                {
                    MdmGetData(item.Key).SellLongPrice = item.Min(x => x.UnitPriceSilver);
                }
        }

        private void AuctionBuyOfferHandler(AuctionBuyOffer p)
        {
            if (p.Items.Length == 0) return;
            var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
            foreach (var item in items)
                if (items.Length > 1)
                {
                    var bdprice = MdmGetData(item.Key);
                    var max = item.Max(x => x.UnitPriceSilver);
                    if (bdprice.SellFastPrice < max)
                        bdprice.SellFastPrice = max;
                }
                else
                {
                    MdmGetData(item.Key).SellFastPrice = item.Max(x => x.UnitPriceSilver);
                }
        }

        private ItemMarket MdmGetData(string id)
        {
            if (id[id.Length - 2] == '@' && id.Length - Level.Length - 3 > 0 &&
                id.Substring(id.Length - Level.Length - 3, Level.Length) == Level)
                id = id.Substring(0, id.Length - 2);
            return mdm.GetData(id);
        }
    }
}