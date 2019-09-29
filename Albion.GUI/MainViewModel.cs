using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Albion.Common;
using Albion.Db.JsonLoader;
using Albion.Event;
using Albion.Network;
using Albion.Operation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;

namespace Albion.GUI
{
    public class MainViewModel : ViewModelBase, IDisposable
    {
        private readonly AlbionParser _albionParser;
        private int _bluePlayers;
        private int _redPlayers;
        private Location _town = Location.None;
        private Location _townSell = Location.None;

        public MainViewModel()
        {
            _albionParser = new AlbionParser();

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
                    TownSell = p.Town;
                }
            });

            _albionParser.AddOperationHandler<AuctionBuyOffer>(p =>
            {
//                if (p.Items.Length == 0) return;
//                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
//                foreach (var item in items)
//                {
//                    var ph = _db.GetItem(item.Key).CostContainer;
//                    ph.UpdateBye(item, items.Length == 1);
//                }
//                RaisePropertyChanged(nameof(SimpleItems));
            });

            _albionParser.AddOperationHandler<AuctionGetRequests>(p =>
            {
//                if (p.Items.Length == 0) return;
//                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
//                foreach (var item in items)
//                {
//                    var ph = _db.GetItem(item.Key).CostContainer;
//                    ph.UpdateSell(item, items.Length == 1);
//                }
//                RaisePropertyChanged(nameof(SimpleItems));
            });

            _albionParser.Start();
        }

        public Location Town
        {
            get => _town;
            set { Set(ref _town, value); }
        }

        public Location TownSell
        {
            get => _townSell;
            set
            {
                Set(ref _townSell, value);
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

        public IEnumerable<Location> Towns => typeof(Location).GetEnumValues().Cast<Location>();

        public void Dispose()
        {
            _albionParser.Dispose();
        }
    }
}