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

namespace Albion.GUI
{
    public class MainViewModel : ViewModelBase, IDisposable
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
        private Location _town = Location.None;
        private Location _townSell = Location.None;

        public MainViewModel()
        {
            ShopCategories = Enum.GetValues(typeof(ShopCategory)).Cast<ShopCategory?>();
            ShopSubCategories = Enum.GetValues(typeof(ShopSubCategory)).Cast<ShopSubCategory?>();

            mdm = new MarketDataManager();
            bdm = new BuildingDataManager();

            var loader = new XmlLoader(mdm, bdm);
            loader.LoadModel();

            Items = loader.Items;

            CraftBuildings = loader.CraftBuildings;

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
                if (p.Items.Length == 0) return;
                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
                foreach (var item in items)
                    if (items.Length > 1)
                    {
                        var bdprice = mdm.GetData(item.Key);
                            var max = item.Max(x => x.UnitPriceSilver);
                        if (bdprice.BuyPrice < max)
                            bdprice.BuyPrice = max;
                    }
                    else
                        mdm.GetData(item.Key).BuyPrice = item.Max(x => x.UnitPriceSilver);
            });

            _albionParser.AddOperationHandler<AuctionGetRequests>(p =>
            {
                if (p.Items.Length == 0) return;
                var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();
                foreach (var item in items)
                    if (items.Length > 1)
                    {
                        var bdprice = mdm.GetData(item.Key);
                        var min = item.Min(x => x.UnitPriceSilver);
                        if (bdprice.SellPrice > min || bdprice.SellPrice == 0 && min > 0)
                            bdprice.SellPrice = min;
                    }
                    else
                        mdm.GetData(item.Key).SellPrice = item.Min(x => x.UnitPriceSilver);
            });

            _albionParser.Start();
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

        public Location TownSell
        {
            get => _townSell;
            set
            {
                if (!Set(ref _townSell, value)) return;
//                mdm.SelectTown((int)_townSell);
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

                return items;
            }
        }

        public IEnumerable<ShopCategory?> ShopCategories { get; }

        public ShopCategory? ShopCategory
        {
            get => _shopCategory;
            set
            {
                if (!Set(ref _shopCategory, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public IEnumerable<ShopSubCategory?> ShopSubCategories { get; }

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

        public int?[] Tirs { get; } = {-1, 1, 2, 3, 4, 5, 6, 7, 8};

        public int? Enchant
        {
            get => _enchant;
            set
            {
                if (!Set(ref _enchant, value)) return;
                RaisePropertyChanged(nameof(CommonItems));
            }
        }

        public int?[] Enchants { get; } = {-1, 0, 1, 2, 3};

        public void Dispose()
        {
            _albionParser.Dispose();
        }
    }
}