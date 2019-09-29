using System;
using System.Linq;
using System.Threading;
using Albion.Db.Items;
using Albion.Db.JsonLoader;
using Albion.Event;
using Albion.Operation;
using PcapDotNet.Core;
using PcapDotNet.Packets;

namespace Albion.Network.Example
{
    internal class Program
    {
        private static AlbionParser albionParser;

        private static void Main(string[] args)
        {
            var db = new All(JsonDb.Load(), JsonNames.LoadNames());

            albionParser = new AlbionParser();

            albionParser.AddEventHandler<PlayerCounts>(p =>
            {
                Console.WriteLine($"Players: {p.Blue} / {p.Red}");
            });

            albionParser.AddOperationHandler<ConsloeCommand>(p =>
            {
                Console.WriteLine($"LocId: {p.LocId} {p.Town}");
            });

//            albionParser.AddOperationHandler<AuctionBuyOffer>(p =>
//            {
//                if (p.Items.Length==0) return;
//                var items = p.Items.GroupBy(x=>x.ItemTypeId).ToArray();
//                foreach (var item in items)
//                {
//                    var max = item.Max(x => x.UnitPriceSilver) / 10000;
//
//                    var ph = db.GetItem(item.Key).PriceHolder;
//
//                    ph.UpdateBye(max, items.Length == 1);
//                }
//            });
//
//            albionParser.AddOperationHandler<AuctionGetRequests>(p =>
//            {
//                if (p.Items.Length == 0) return;
//                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
//                foreach (var item in items)
//                {
//                    var min = item.Min(x => x.UnitPriceSilver) / 10000;
//
//                    var ph = db.GetItem(item.Key).PriceHolder;
//
//                    ph.UpdateSell(min, items.Length == 1);
//                }
//            });

            Console.WriteLine("Start");

            albionParser.Start();

            Console.Read();
        }

    }
}