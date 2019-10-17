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

            _albionParser.AddOperationHandler<ConsloeCommand>(p =>
            {
                if (p.Town != Location.None)
                {
                    Town = p.Town;
                    SellTown = p.Town;
                }
            });

            _albionParser.AddOperationHandler<AuctionBuyOffer>(AuctionBuyOfferHandler);

            _albionParser.AddOperationHandler<AuctionGetRequests>(AuctionGetRequestsHandler);

            try
            {
                _albionParser.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Net Init", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AuctionGetRequestsHandler(AuctionGetRequests p)
        {
            if (p.Items.Length == 0) return;
            var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();

            if (items.Length == 1)
                MdmGetData(items[0].Key).FromMarketItems[(int)Town].SetOrders(items[0], DateTime.Now);
            else
            {
                foreach (var item in items)
                {
                    MdmGetData(item.Key).FromMarketItems[(int)Town].AppendOrders(item);
                }
            }

            foreach (var item in items)
            {
                Items[item.Key].Pos = DateTime.Now;
            }
            RefreshTree();
        }

        private void AuctionBuyOfferHandler(AuctionBuyOffer p)
        {
            if (p.Items.Length == 0) return;
            var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();

            if (items.Length == 1)
                MdmGetData(items[0].Key).ToMarketItems[(int) Town].SetOrders(items[0], DateTime.Now);
            else
            {
                foreach (var item in items)
                {
                    MdmGetData(item.Key).ToMarketItems[(int)Town].AppendOrders(item);
                }
            }

            foreach (var item in items) { 
                Items[item.Key].Pos = DateTime.Now;
            }

            RefreshTree();
        }

        private ItemMarket MdmGetData(string id)
        {
//            if (id[id.Length - 2] == '@' && id.Length - Level.Length - 3 > 0 &&
//                id.Substring(id.Length - Level.Length - 3, Level.Length) == Level)
//                id = id.Substring(0, id.Length - 2);
            return mdm.GetData(id);
        }
    }
}