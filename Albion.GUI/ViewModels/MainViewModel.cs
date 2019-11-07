using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;
using System.Xml.Linq;
using Albion.Common;
using Albion.DataStore.Db;
using Albion.DataStore.Managers;
using Albion.Db.Xml;
using Albion.GUI.Libs;
using Albion.Model.Data;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Model.Managers;
using Albion.Network;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PcapDotNet.Base;

namespace Albion.GUI.ViewModels
{
    public partial class MainViewModel : ViewModelBase, IDisposable
    {
        private static readonly HashSet<ShopCategory> _simpleItems = new HashSet<ShopCategory>
        {
            Model.Items.Categories.ShopCategory.Armor,
            Model.Items.Categories.ShopCategory.Melee,
            Model.Items.Categories.ShopCategory.Ranged,
            Model.Items.Categories.ShopCategory.Magic
        };

        private readonly AlbionParser _albionParser;
        private readonly DebounceDispatcher _debounceDispatcher;
        private readonly BuildingDataManager bdm;
        private readonly MarketDataManager mdm;
        private int _bluePlayers;
        private int? _enchant;
        private string _filterTest;
        private bool _isProfitOrder;
        private bool _isProfitPercentOrder;
        private bool _isProfitSumOrder;
        private int _redPlayers;
        private ShopCategory? _shopCategory;
        private ShopSubCategory? _shopSubCategory;
        private int? _tir;
        private int _gridWidth = 300;
        private int? _Quality;
        private bool _isCountOrder;

        public MainViewModel()
        {
            RefreshCommand = new RelayCommand(() => RaisePropertyChanged(nameof(CommonItems)));
            ClearBmCommand = new RelayCommand(ClearBm);
            ClearItemBmCommand = new RelayCommand<CommonItem>(ClearItemBm);
            ClearItemCommand = new RelayCommand<CommonItem>(ClearItem);

            Tirs = Enumerable.Repeat(new Tuple<string, int?>("-", null), 1)
                .Concat(Enumerable.Range(1, 8).Select(x => Tuple.Create(x.ToString(), (int?) x)));
            Enchants = Enumerable.Repeat(new Tuple<string, int?>("-", null), 1)
                .Concat(Enumerable.Range(0, 4).Select(x => Tuple.Create(x.ToString(), (int?) x)));
            Qualities = Enumerable.Repeat(new Tuple<string, int?>("-", null), 1)
                .Concat(Enumerable.Range(1, 5).Select(x => Tuple.Create(x.ToString(), (int?) x)));

            ShopCategories = Enumerable.Repeat(new Tuple<string, ShopCategory?>("-", null), 1).Concat(Enum
                .GetValues(typeof(ShopCategory)).Cast<ShopCategory?>()
                .Select(x => Tuple.Create(x.Value.ToString(), x)));
            ShopSubCategories = Enumerable.Repeat(new Tuple<string, ShopSubCategory?>("-", null), 1)
                .Concat(Enum.GetValues(typeof(ShopSubCategory)).Cast<ShopSubCategory?>()
                    .Select(x => Tuple.Create(x.Value.ToString(), x)));

            BuyTownManager = new TownManager();
            SellTownManager = new TownManager();
            CraftTownManager = new TownManager();
            AuctionTownManager = new TownManager();

            mdm = new MarketDataManager();
            bdm = new BuildingDataManager(CraftTownManager);

            var loader = new XmlLoader(bdm, CraftTownManager, BuyTownManager, SellTownManager);
            loader.LoadModel();

            Items = loader.Items.Values.Where(x=>x.ShopSubCategory != Model.Items.Categories.ShopSubCategory.Event).ToDictionary(k=>k.Id + (k.QualityLevel > 1 ? $"_{k.QualityLevel}" : ""));

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

            CostCalcOptions.Instance.Changed += RefreshTree;
        }

        public ICommand ClearItemBmCommand { get; set; }

        public ICommand ClearItemCommand { get; set; }

        public TownManager AuctionTownManager { get; }

        public TownManager SellTownManager { get; }

        public TownManager BuyTownManager { get; }

        public TownManager CraftTownManager { get; }

        public ArtefactStat[] Artefacts { get; set; }

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
                if (Quality >= 0) items = items.Where(x => x.QualityLevel == Quality);
                if (ShopCategory != null)
                    switch (ShopCategory)
                    {
                        case Model.Items.Categories.ShopCategory.SimpleItems:
                            items = items.Where(x => _simpleItems.Contains(x.ShopCategory)).Where(x => !x.IsArtefacted);
                            break;
                        case Model.Items.Categories.ShopCategory.ArtefactsItems:
                            items = items.Where(x => _simpleItems.Contains(x.ShopCategory)).Where(x => x.IsArtefacted);
                            break;
                        default:
                            items = items.Where(x => x.ShopCategory == ShopCategory);
                            break;
                    }
                if (ShopSubCategory != null) items = items.Where(x => x.ShopSubCategory == ShopSubCategory);
                if (!_filterTest.IsNullOrEmpty())
                {
                    var filterTest = _filterTest.ToUpper();
                    items = items.Where(x => x.Name.ToUpper().Contains(filterTest));
                }

                var orderedItems =
                    IsProfitOrder
                        ? items.OrderByDescending(x => x.Profitt?.Profit)
                        : IsProfitPercentOrder
                            ? items.OrderByDescending(x => x.Profitt?.ProfitPercent)
                            : IsProfitSumOrder
                                ? items.OrderByDescending(x => x.Profitt?.ProfitSum)
                            : IsCountOrder
                                ? items.OrderByDescending(x => x.Profitt?.Count)
                                : items.OrderBy(x => !x.TreeProps.IsSelected);

//                var tmp = items.OrderByDescending(x => x.Pos).ThenBy(x => x.FullName).ToArray();
//                return tmp;
                return orderedItems.ThenByDescending(x => x.Pos).ThenBy(x => x.FullName);
            }
        }


        public bool IsCountOrder
        {
            get => _isCountOrder;
            set
            {
                if (!Set(ref _isCountOrder, value)) return;
                RefreshTree();
            }
        }

        public bool IsProfitPercentOrder
        {
            get => _isProfitPercentOrder;
            set
            {
                if (!Set(ref _isProfitPercentOrder, value)) return;
                RefreshTree();
            }
        }

        public bool IsProfitSumOrder
        {
            get => _isProfitSumOrder;
            set
            {
                if (!Set(ref _isProfitSumOrder, value)) return;
                RefreshTree();
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

        public int? Quality
        {
            get => _Quality;
            set
            {
                if (!Set(ref _Quality, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public IEnumerable<Tuple<string, int?>> Enchants { get; }

        public IEnumerable<Tuple<string, int?>> Qualities { get; }

        public ICommand RefreshCommand { get; }
        public ICommand ClearBmCommand { get; }

        public CostCalcOptions CostCalcOptions => CostCalcOptions.Instance;

        public void Dispose()
        {
            SaveOptions();
            DataBase.Close();
            _albionParser.Dispose();
        }

        private void SaveOptions()
        {
            mdm.SetSelectedItems(Items.Values.Where(x=>x.TreeProps.IsSelected).Select(x=>x.Id));
        }

        private void ClearBm()
        {
            mdm.DeleteOrders((int) Location.BlackMarket, false);
            foreach (var item in Items.Values)
                item.ItemMarket.ToMarketItems[(int) Location.BlackMarket].ClearOrders();
        }

        private void ClearItemBm(CommonItem item)
        {
            mdm.DeleteOrders(item.Id, (int) Location.BlackMarket, false);
            item.ItemMarket.ToMarketItems[(int) Location.BlackMarket].ClearOrders();

            mdm.DeleteOrders(item.Id, (int) Location.BlackMarket, true);
            item.ItemMarket.FromMarketItems[(int) Location.BlackMarket].ClearOrders();
        }

        private void ClearItem(CommonItem item)
        {
            mdm.DeleteOrders(item.Id, SellTownManager.TownId, false);
            item.ItemMarket.ToMarketItems[SellTownManager.TownId].ClearOrders();

            mdm.DeleteOrders(item.Id, SellTownManager.TownId, true);
            item.ItemMarket.FromMarketItems[SellTownManager.TownId].ClearOrders();
        }

        private void LoadData()
        {
            foreach (var ordersData in mdm.GetOrders())
            {
                if (!Items.TryGetValue(ordersData.ItemId, out var item)) continue;

                var itemMarket = item.ItemMarket;
                var ordersItem = !ordersData.IsFrom
                    ? (ItemMarketData) itemMarket.ToMarketItems[ordersData.TownId]
                    : itemMarket.FromMarketItems[ordersData.TownId];

                ordersItem.SetOrders(ordersData.Orders, ordersData.UpdateTime);

                if (item.Pos < ordersItem.UpdateTime)
                    item.Pos = ordersItem.UpdateTime;
            }

            foreach (var id in mdm.GetSelectedItems())
            {
                if (!Items.TryGetValue(id, out var item)) continue;

                item.TreeProps.IsSelected = true;
            }
        }

        private void RefreshTree()
        {
            _debounceDispatcher.Debounce(200, RaiseRefreshTree);
        }

        private void RaiseRefreshTree(object obj)
        {
            RaisePropertyChanged(nameof(CommonItems));
        }
    }
}