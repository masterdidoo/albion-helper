﻿using System;
using System.Linq;
using System.Windows;
using Albion.Common;
using Albion.Event;
using Albion.Model.Data;
using Albion.Operation;

namespace Albion.GUI.ViewModels
{
    public partial class MainViewModel
    {
//        private static readonly string Level = "_LEVEL";

        private void InitAlbionParser()
        {
            _albionParser.AddEventHandler<PlayerCounts>(p =>
            {
                BluePlayers = p.Blue > 0 ? p.Blue : 0;
                RedPlayers = p.Red > 0 ? p.Red : 0;
            });

            _albionParser.AddOperationHandler<Join>(p =>
            {
                //if (p.Town != Location.None)
                {
                    AuctionTownManager.Town = p.Town;
                }
            });

            _albionParser.AddOperationHandler<AuctionGetRequests>(AuctionBuyOfferHandler);

            _albionParser.AddOperationHandler<AuctionGetOffers>(AuctionGetRequestsHandler);

            try
            {
                _albionParser.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Net Init", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AuctionGetRequestsHandler(AuctionGetOffers p)
        {
            if (p.Items.Length == 0) return;
            var ordersGroups = p.Items.GroupBy(x => x.ItemTypeId).ToArray();

            if (ordersGroups.Length == 1)
            {
                var orders = ordersGroups[0];
                var itemMarket = MdmGetData(orders.Key).FromMarketItems[AuctionTownManager.TownId];
                itemMarket.AppendOrSetOrders(orders);
                    //itemMarket.SetOrders(items[0], DateTime.Now);
                _mdm.Save(orders.Key, AuctionTownManager.TownId, true, itemMarket);
            }
            else
            {
                foreach (var orders in ordersGroups)
                {
                    var itemMarket = MdmGetData(orders.Key).FromMarketItems[AuctionTownManager.TownId];
                    itemMarket.AppendOrders(orders);
                    _mdm.Save(orders.Key, AuctionTownManager.TownId, true, itemMarket);
                }
            }

            foreach (var item in ordersGroups)
            {
                Items[item.Key].Pos = DateTime.Now;
                foreach (var ci in Items[item.Key].QualityLevels)
                {
                    ci.Pos = DateTime.Now;
                }
            }
            RefreshTree();
        }

        private void AuctionBuyOfferHandler(AuctionGetRequests p)
        {
            if (p.Items.Length == 0) return;
            var ordersGroups = p.Items.GroupBy(x => x.ItemTypeId).ToArray();

            if (ordersGroups.Length == 1)
            {
                var orders = ordersGroups[0];
                var itemMarket = MdmGetData(orders.Key).ToMarketItems[AuctionTownManager.TownId];
                itemMarket.AppendOrSetOrders(orders);
                //itemMarket.SetOrders(items[0], DateTime.Now);
                _mdm.Save(orders.Key, AuctionTownManager.TownId, false, itemMarket);
            }
            else
            {
                foreach (var orders in ordersGroups)
                {
                    var itemMarket = MdmGetData(orders.Key).ToMarketItems[AuctionTownManager.TownId];
                    itemMarket.AppendOrders(orders);
                    _mdm.Save(orders.Key, AuctionTownManager.TownId, false, itemMarket);
                }
            }

            foreach (var item in ordersGroups)
            {
                Items[item.Key].Pos = DateTime.Now;
                foreach (var ci in Items[item.Key].QualityLevels)
                {
                    ci.Pos = DateTime.Now;
                }
            }

            RefreshTree();
        }

        private ItemMarket MdmGetData(string id)
        {
//            if (id[id.Length - 2] == '@' && id.Length - Level.Length - 3 > 0 &&
//                id.Substring(id.Length - Level.Length - 3, Level.Length) == Level)
//                id = id.Substring(0, id.Length - 2);
            if (Items.TryGetValue(id, out var item)) return item.ItemMarket;
            //TODO обработать ошибку
            return new ItemMarket();
//            return Items[id].ItemMarket;
            //return mdm.GetData(id);
        }
    }
}