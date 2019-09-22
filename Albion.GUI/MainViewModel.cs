using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Albion.Common;
using Albion.Db.Items;
using Albion.Db.JsonLoader;
using Albion.Event;
using Albion.Network;
using Albion.Operation;
using GalaSoft.MvvmLight;

namespace Albion.GUI
{
    public class MainViewModel : ViewModelBase
    {
        private readonly AlbionParser _albionParser;
        private int _bluePlayers;
        private int _redPlayers;
        private Location _town = Location.None;
        private readonly All _db;

        public MainViewModel()
        {
            _db = new All(JsonDb.Load());

            _albionParser = new AlbionParser();

            _albionParser.AddEventHandler<PlayerCounts>(p =>
            {
                BluePlayers = p.Blue > 0 ? p.Blue : 0;
                RedPlayers = p.Red > 0 ? p.Red : 0;
            });

            _albionParser.AddOperationHandler<ConsloeCommand>(p =>
            {
                Town = p.Town;
            });

            _albionParser.AddOperationHandler<AuctionBuyOffer>(p =>
            {
                if (p.Items.Length == 0) return;
                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
                foreach (var item in items)
                {
                    var max = item.Max(x => x.UnitPriceSilver) / 10000;
                    var ph = _db.GetItem(item.Key).PriceHolder;

                    ph.UpdateBye(max, items.Length == 1);
                }
            });

            _albionParser.AddOperationHandler<AuctionGetRequests>(p =>
            {
                if (p.Items.Length == 0) return;
                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
                foreach (var item in items)
                {
                    var max = item.Max(x => x.UnitPriceSilver) / 10000;
                    var ph = _db.GetItem(item.Key).PriceHolder;

                    ph.UpdateSell(max, items.Length == 1);
                }
            });

            _albionParser.Start();


            view = (CollectionView)CollectionViewSource.GetDefaultView(SimpleItems);
            view.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
        }

        public CollectionView view { get; }

        public IEnumerable<SimpleItem> SimpleItems => _db.ItemsDb.Values;

        public Location Town
        {
            get => _town;
            set
            {
                if (Set(ref _town, value))
                    _db.Town = value;
            }
        }

        public int RedPlayers
        {
            get => _redPlayers;
            set => Set(ref _redPlayers, value);
        }

        public int BluePlayers
        {
            get => _bluePlayers;
            set => Set(ref _bluePlayers, value);
        }
    }
}