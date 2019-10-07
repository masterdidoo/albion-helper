using System;
using System.Collections.Generic;
using System.Linq;
using Albion.Common;
using Albion.DataStore.Managers;
using Albion.Db.Xml;
using Albion.Event;
using Albion.Model.Buildings;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Network;
using Albion.Operation;
using GalaSoft.MvvmLight;
using PcapDotNet.Base;

namespace Albion.GUI.ViewModels
{
    public partial class MainViewModel : ViewModelBase, IDisposable
    {
        private readonly AlbionParser _albionParser;
        private readonly BuildingDataManager bdm;
        private readonly MarketDataManager mdm;
        private int _bluePlayers;
        private int? _enchant;
        private string _filterTest;
        private int _redPlayers;
        private ShopCategory? _shopCategory;
        private ShopSubCategory? _shopSubCategory;
        private int? _tir;
        private Location _town;
        private Location _sellTown;

        public MainViewModel()
        {
            Tirs = Enumerable.Repeat(new Tuple<string,int?>("-",null),1).Concat(Enumerable.Range(1,8).Select(x=>Tuple.Create(x.ToString(),(int?) x)));
            Enchants = Enumerable.Repeat(new Tuple<string,int?>("-",null),1).Concat(Enumerable.Range(0,4).Select(x=>Tuple.Create(x.ToString(),(int?) x)));

            ShopCategories = Enumerable.Repeat(new Tuple<string, ShopCategory?>("-", null), 1).Concat(Enum.GetValues(typeof(ShopCategory)).Cast<ShopCategory?>().Select(x=> Tuple.Create(x.Value.ToString(), x)));
            ShopSubCategories = Enumerable.Repeat(new Tuple<string, ShopSubCategory?>("-", null), 1).Concat(Enum.GetValues(typeof(ShopSubCategory)).Cast<ShopSubCategory?>().Select(x => Tuple.Create(x.Value.ToString(), x)));

            mdm = new MarketDataManager();
            bdm = new BuildingDataManager();

            var loader = new XmlLoader(mdm, bdm);
            loader.LoadModel();

            Items = loader.Items;

            foreach (var item in Items.Values)
            {
                item.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName=="Pos")
                        RaisePropertyChanged(nameof(CommonItems));
                };
            }

            CraftBuildings = loader.CraftBuildings;

            _albionParser = new AlbionParser();

            Town = Location.None;
            SellTown = Location.None;

            InitAlbionParser();
        }

        public Dictionary<string, CraftBuilding> CraftBuildings { get; }

        public Dictionary<string, CommonItem> Items { get; }

        public Location Town
        {
            get => _town;
            set
            {
                if (!Set(ref _town, value)) return;
                mdm.SelectTown((int) _town);
                bdm.SelectTown((int) _town);
            }
        }

        public Location SellTown
        {
            get => _sellTown;
            set
            {
                if (!Set(ref _sellTown, value)) return;
                mdm.SelectSellTown((int)_sellTown);
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

        public IEnumerable<CommonItem> CommonItems
        {
            get
            {
                IEnumerable<CommonItem> items = Items.Values;
                if (Tir >= 0) items = items.Where(x => x.Tir == Tir);
                if (Enchant >= 0) items = items.Where(x => x.Enchant == Enchant);
                if (ShopCategory != null) items = items.Where(x => x.ShopCategory == ShopCategory);
                if (ShopSubCategory != null) items = items.Where(x => x.ShopSubCategory == ShopSubCategory);
                if (!_filterTest.IsNullOrEmpty())
                {
                    var filterTest = _filterTest.ToUpper();
                    items = items.Where(x => x.Name.ToUpper().Contains(filterTest));
                }
                items = items.OrderByDescending(x=>x.Pos).ThenBy(x=>x.FullName);

                return items;
            }
        }

        public IEnumerable<Tuple<string, ShopCategory?>> ShopCategories { get; }

        public ShopCategory? ShopCategory
        {
            get => _shopCategory;
            set
            {
                if (!Set(ref _shopCategory, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public IEnumerable<Tuple<string, ShopSubCategory?>> ShopSubCategories { get; }

        public ShopSubCategory? ShopSubCategory
        {
            get => _shopSubCategory;
            set
            {
                if (!Set(ref _shopSubCategory, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public string FilterTest
        {
            get => _filterTest;
            set
            {
                if (!Set(ref _filterTest, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public int? Tir
        {
            get => _tir;
            set
            {
                if (!Set(ref _tir, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public IEnumerable<Tuple<string, int?>> Tirs { get; }

        public int? Enchant
        {
            get => _enchant;
            set
            {
                if (!Set(ref _enchant, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public IEnumerable<Tuple<string, int?>> Enchants { get; }

        public void Dispose()
        {
            _albionParser.Dispose();
        }
    }


}