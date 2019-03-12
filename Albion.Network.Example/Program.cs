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
            var db = new All(JsonDb.Load());

            albionParser = new AlbionParser();

            albionParser.AddEventHandler<PlayerCounts>(p =>
            {
                Console.WriteLine($"Players: {p.Blue} / {p.Red}");
            });

            albionParser.AddOperationHandler<ConsloeCommand>(p =>
            {
                Console.WriteLine($"Loc: {p.Location}");
            });

            albionParser.AddOperationHandler<AuctionBuyOffer>(p =>
            {
                if (p.Items.Length==0) return;
                var items = p.Items.GroupBy(x=>x.ItemTypeId);
                foreach (var item in items)
                {
                    var max = item.Max(x => x.UnitPriceSilver) / 10000;
                    Console.WriteLine($"Bye: {item.Key} / {item.First().ItemGroupTypeId} {max}");
                    db.GetItem(item.Key).PriceToBye = max;
                }
            });

            albionParser.AddOperationHandler<AuctionGetRequests>(p =>
            {
                if (p.Items.Length == 0) return;
                var items = p.Items.GroupBy(x => x.ItemTypeId);
                foreach (var item in items)
                {
                    var min = item.Min(x => x.UnitPriceSilver) / 10000;
                    Console.WriteLine($"Sell: {item.Key} / {item.First().ItemGroupTypeId} {min}");
                    db.GetItem(item.Key).PriceToSell = min;
                }
            });

            Console.WriteLine("Start");

            albionParser.Start();

            Console.Read();
        }

    }
}