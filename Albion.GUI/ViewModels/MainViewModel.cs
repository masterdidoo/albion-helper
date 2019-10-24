using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Albion.Common;
using Albion.DataStore.Db;
using Albion.DataStore.Managers;
using Albion.Db.Xml;
using Albion.Event;
using Albion.GUI.Libs;
using Albion.Model.Buildings;
using Albion.Model.Data;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Model.Managers;
using Albion.Network;
using Albion.Operation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
        private readonly DebounceDispatcher _debounceDispatcher;
        private bool _isProfitOrder;

        public MainViewModel()
        {
            RefreshCommand = new RelayCommand(() => RaisePropertyChanged(nameof(CommonItems)));

            Tirs = Enumerable.Repeat(new Tuple<string,int?>("-",null),1).Concat(Enumerable.Range(1,8).Select(x=>Tuple.Create(x.ToString(),(int?) x)));
            Enchants = Enumerable.Repeat(new Tuple<string,int?>("-",null),1).Concat(Enumerable.Range(0,4).Select(x=>Tuple.Create(x.ToString(),(int?) x)));

            ShopCategories = Enumerable.Repeat(new Tuple<string, ShopCategory?>("-", null), 1).Concat(Enum.GetValues(typeof(ShopCategory)).Cast<ShopCategory?>().Select(x=> Tuple.Create(x.Value.ToString(), x)));
            ShopSubCategories = Enumerable.Repeat(new Tuple<string, ShopSubCategory?>("-", null), 1).Concat(Enum.GetValues(typeof(ShopSubCategory)).Cast<ShopSubCategory?>().Select(x => Tuple.Create(x.Value.ToString(), x)));

            BuyTownManager = new TownManager();
            SellTownManager = new TownManager();
            CraftTownManager = new TownManager();
            AuctionTownManager = new TownManager();

            mdm = new MarketDataManager();
            bdm = new BuildingDataManager(CraftTownManager);

            var loader = new XmlLoader(bdm, CraftTownManager , BuyTownManager, SellTownManager);
            loader.LoadModel();

            Items = loader.Items;

            LoadData();

            Artefacts = loader.Artefacts;

            _debounceDispatcher = new DebounceDispatcher();
//            foreach (var item in Items.Values)
//            {
//                item.PropertyChanged += (sender, args) =>
//                {
//                     //if (args.PropertyName == "Pos")
//                     RefreshTree();
//                };
//            }

            BuildingsViewModel = new BuildingsViewModel(loader.CraftBuildings, CraftTownManager);

            _albionParser = new AlbionParser();

            BuyTownManager.Town = Location.None;
            SellTownManager.Town = Location.None;
            CraftTownManager.Town = Location.None;
            AuctionTownManager.Town = Location.None;

            InitAlbionParser();
        }

        private void LoadData()
        {
            foreach (var ordersData in mdm.GetOrders())
            {
                if (!Items.TryGetValue(ordersData.ItemId, out var item)) continue;

                var itemMarket = item.ItemMarket;
                var ordersItem = ordersData.IsFrom ? (ItemMarketData) itemMarket.ToMarketItems[ordersData.TownId] : itemMarket.FromMarketItems[ordersData.TownId];

                ordersItem.SetOrders(ordersData.Orders, ordersData.UpdateTime, true);
                ordersItem.SetBestPrice(ordersItem.BestPrice);

                if (item.Pos < ordersItem.UpdateTime)
                    item.Pos = ordersItem.UpdateTime;
            }
        }

        public TownManager AuctionTownManager { get; }

        public TownManager SellTownManager { get; }

        public TownManager BuyTownManager { get;  }

        public TownManager CraftTownManager { get; }

        public ArtefactStat[] Artefacts { get; set; }

        private void RefreshTree()
        {
            _debounceDispatcher.Debounce(200, RaiseRefreshTree);
        }

        private void RaiseRefreshTree(object obj)
        {
            RaisePropertyChanged(nameof(CommonItems));
        }

        public Dictionary<string, CommonItem> Items { get; }
        public BuildingsViewModel BuildingsViewModel { get; }

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

                var orderedItems = IsProfitOrder 
                    ? items.OrderByDescending(x=>x.BmFastSellProfit.ProfitSum).ThenBy(x => !x.TtreeProps.IsExpanded) 
                    : items.OrderBy(x=>!x.TtreeProps.IsExpanded);

//                var tmp = items.OrderByDescending(x => x.Pos).ThenBy(x => x.FullName).ToArray();
//                return tmp;
                return orderedItems.ThenByDescending(x => x.Pos).ThenBy(x => x.FullName);
            }
        }

        public bool IsProfitOrder
        {
            get => _isProfitOrder;
            set
            {
                if (!Set(ref _isProfitOrder, value)) return;
                RefreshTree();
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

        public ICommand RefreshCommand { get; }

        public CostCalcOptions CostCalcOptions => CostCalcOptions.Instance;

        public void Dispose()
        {
            _albionParser.Dispose();
            DataBase.Close();
        }
    }
}