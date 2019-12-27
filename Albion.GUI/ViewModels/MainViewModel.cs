using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Input;
using Albion.Common;
using Albion.DataStore.DataModel;
using Albion.DataStore.Db;
using Albion.DataStore.Managers;
using Albion.Db.Xml;
using Albion.GUI.Libs;
using Albion.GUI.Views;
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

        private readonly AlbionParser _albionParser;
        private readonly DebounceDispatcher _debounceDispatcher;
        private readonly BuildingDataManager _bdm;
        private readonly MarketDataManager _mdm;
        private int _bluePlayers;
        private int? _enchant;
        private string _filterTest;
        private bool _isCostOrder;
        private bool _isCountOrder;
        private bool _isProfitOrder;
        private bool _isProfitPercentOrder;
        private bool _isProfitSumOrder;
        private bool _isSameTir;
        private int? _quality;
        private int _redPlayers;
        private ShopCategory? _shopCategory;
        private ShopSubCategory? _shopSubCategory;
        private int? _tir;
        private bool _isIpCostOrder;

        public MainViewModel()
        {
            RefreshCommand = new RelayCommand(() => RaisePropertyChanged(nameof(CommonItems)));
            ClearBmCommand = new RelayCommand(ClearBm);
            ClearItemBmCommand = new RelayCommand<CommonItem>(ClearItemBm);
            ClearItemCommand = new RelayCommand<CommonItem>(ClearItem);
            OpenItemCommand = new RelayCommand<CommonItem>(OpenItem);

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

            _mdm = new MarketDataManager();
            _bdm = new BuildingDataManager(CraftTownManager);

            var loader = new XmlLoader(_bdm, CraftTownManager, BuyTownManager, SellTownManager);
            loader.LoadModel();

            Items = loader.Items.Values.Where(x => x.ShopSubCategory != Model.Items.Categories.ShopSubCategory.Event)
                .ToDictionary(k => k.Id + (k.QualityLevel > 1 ? $"_{k.QualityLevel}" : ""));

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

            AuctionTownManager.TownChanged += p =>
            {
                if (BuyTownManager.Town == Location.None) BuyTownManager.Town = p.Town;
                if (SellTownManager.Town == Location.None) SellTownManager.Town = p.Town;
                if (CraftTownManager.Town == Location.None) CraftTownManager.Town = p.Town;
            };

            InitAlbionParser();

            CostCalcOptions.Instance.ProfitsChanged += RefreshTree;
            CostCalcOptions.Instance.Changed += RefreshTree;
        }

        public ICommand ClearItemBmCommand { get; set; }

        public ICommand ClearItemCommand { get; set; }

        public ICommand OpenItemCommand { get; set; }

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
            set
            {
                var old = _redPlayers;
                if (Set(ref _redPlayers, value) && old < _redPlayers) BeepRed();
            }
        }

        public int BluePlayers
        {
            get => _bluePlayers;
            set => Set(ref _bluePlayers, value);
        }

        public IEnumerable<Location> Towns => TownsAndBz.Where(x => x != Location.BlackZone);

        public IEnumerable<Location> TownsAndBz => typeof(Location).GetEnumValues().Cast<Location>();

        public IEnumerable<CommonItem> CommonItems
        {
            get
            {
                IEnumerable<CommonItem> items = Items.Values;
                if (Tir >= 0 && Enchant >= 0 && IsSameTir)
                {
                    items = items.Where(x => IsSameFor(x, Tir.Value, Enchant.Value));
                }
                else
                {
                    if (Tir >= 0) items = items.Where(x => x.Tir == Tir);
                    if (Enchant >= 0) items = items.Where(x => x.Enchant == Enchant);
                }

                if (Quality >= 0) items = items.Where(x => x.QualityLevel == Quality);
                if (ShopCategory != null)
                    switch (ShopCategory)
                    {
                        case Model.Items.Categories.ShopCategory.SimpleItems:
                            items = items.Where(x => CommonItem.SimpleItems.Contains(x.ShopCategory)).Where(x => !x.IsArtefacted);
                            break;
                        case Model.Items.Categories.ShopCategory.ArtefactsItems:
                            items = items.Where(x => CommonItem.SimpleItems.Contains(x.ShopCategory)).Where(x => x.IsArtefacted);
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
                    IsCostOrder
                        ? items.OrderBy(x => x.Requirement?.Cost)
                        : IsProfitOrder
                            ? items.OrderByDescending(x => x.Profitt?.Profit)
                            : IsProfitPercentOrder
                                ? items.OrderByDescending(x => x.Profitt?.ProfitPercent)
                                : IsProfitSumOrder
                                    ? items.OrderByDescending(x => x.Profitt?.ProfitSum)
                                    : IsCountOrder
                                        ? items.OrderByDescending(x => x.Profitt?.Count)
                                    : IsIpCostOrder
                                        ? items.Where(x=> x.ItemPower > 0 && x.Requirement?.Cost > 0).OrderBy(x => ((double)x.Requirement?.Cost) / x.ItemPower)
                                        : items.OrderBy(x => !x.TreeProps.IsSelected);

//                var tmp = items.OrderByDescending(x => x.Pos).ThenBy(x => x.FullName).ToArray();
//                return tmp;
                return orderedItems.ThenByDescending(x => x.Pos).ThenBy(x => x.FullName);
            }
        }


        public bool IsIpCostOrder
        {
            get => _isIpCostOrder;
            set
            {
                if (!Set(ref _isIpCostOrder, value)) return;
                RefreshTree();
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

        public bool IsCostOrder
        {
            get => _isCostOrder;
            set
            {
                if (!Set(ref _isCostOrder, value)) return;
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

        public bool IsSameTir
        {
            get => _isSameTir;
            set
            {
                if (!Set(ref _isSameTir, value)) return;
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
            get => _quality;
            set
            {
                if (!Set(ref _quality, value)) return;
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

        private void OpenItem(CommonItem item)
        {
            var vm = new ItemViewModel(item, 1);
            var window = new ItemWindow() {DataContext = vm};
            window.Show();
        }

        private void BeepRed()
        {
            SystemSounds.Beep.Play();
        }

        private bool IsSameFor(CommonItem item, int tir, int enchant)
        {
            tir = tir + enchant;
            for (var i = 0; i <= 3; i++)
                if (item.Tir == tir - i && item.Enchant == i)
                    return true;
            return false;
        }

        private void SaveOptions()
        {
            _mdm.SetSelectedItems(Items.Values.Where(x => x.TreeProps.IsSelected).Select(x => x.Id));
        }

        private void ClearBm()
        {
            _mdm.DeleteOrders((int) Location.BlackMarket, false);
            foreach (var item in Items.Values)
                item.ItemMarket.ToMarketItems[(int) Location.BlackMarket].ClearOrders();
        }

        private void ClearItemBm(CommonItem item)
        {
            _mdm.DeleteOrders(item.Id, (int) Location.BlackMarket, false);
            item.ItemMarket.ToMarketItems[(int) Location.BlackMarket].ClearOrders();

            _mdm.DeleteOrders(item.Id, (int) Location.BlackMarket, true);
            item.ItemMarket.FromMarketItems[(int) Location.BlackMarket].ClearOrders();
        }

        private void ClearItem(CommonItem item)
        {
            _mdm.DeleteOrders(item.Id, SellTownManager.TownId, false);
            item.ItemMarket.ToMarketItems[SellTownManager.TownId].ClearOrders();

            _mdm.DeleteOrders(item.Id, SellTownManager.TownId, true);
            item.ItemMarket.FromMarketItems[SellTownManager.TownId].ClearOrders();
        }

        private void LoadData()
        {
            foreach (var ordersData in _mdm.GetOrders())
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

            foreach (var id in _mdm.GetSelectedItems())
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