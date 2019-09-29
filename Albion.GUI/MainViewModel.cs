using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Albion.Common;
using Albion.Db.Items;
using Albion.Db.Items.ViewModels;
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
        private readonly All _db;
        private Location _townSell = Location.None;

        public MainViewModel()
        {
            _db = new All(JsonDb.Load(), JsonNames.LoadNames());

            _db.Context.TownIndexChanged += ContextOnTownIndexChanged;

            //SimpleItems = new ObservableCollection<SimpleItem>(_db.ItemsDb.Values.OrderBy(x => x.Id));

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
                RaisePropertyChanged(nameof(SimpleItems));
            });

            _albionParser.AddOperationHandler<AuctionBuyOffer>(p =>
            {
                if (p.Items.Length == 0) return;
                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
                foreach (var item in items)
                {
                    var ph = _db.GetItem(item.Key).CostContainer;
                    ph.UpdateBye(item, items.Length == 1);
                }
                RaisePropertyChanged(nameof(SimpleItems));
            });

            _albionParser.AddOperationHandler<AuctionGetRequests>(p =>
            {
                if (p.Items.Length == 0) return;
                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
                foreach (var item in items)
                {
                    var ph = _db.GetItem(item.Key).CostContainer;
                    ph.UpdateSell(item, items.Length == 1);
                }
                RaisePropertyChanged(nameof(SimpleItems));
            });

            _albionParser.Start();
        }

        private void ContextOnTownIndexChanged()
        {
            RaisePropertyChanged(nameof(SimpleItems));
        }

        public IEnumerable<SimpleItem> SimpleItems => _db.ItemsDb.Values.OrderByDescending(x => x.Time).ThenByDescending(x=>x.Profit);

        public Location Town
        {
            get => _town;
            set
            {
                if (Set(ref _town, value))
                    _db.Context.Town = value;
            }
        }

        public Location TownSell
        {
            get => _townSell;
            set
            {
                if (Set(ref _townSell, value))
                    _db.Context.TownSell = value;
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

        public IEnumerable<ArtefactVm> Artefacts => _db.Artefacts;

        public void Dispose()
        {
            _albionParser.Dispose();
            _db.Context.Dispose();
        }
    }
}