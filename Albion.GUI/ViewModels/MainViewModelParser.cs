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
                MdmGetData(items[0].Key).LongSaleItem.SetOrders(items[0]);
            else
            {
                foreach (var item in items)
                {
                    MdmGetData(item.Key).LongSaleItem.AppendOrders(item);
                }
            }

            foreach (var item in items)
            {
                if (items.Length > 1)
                {
                    var bdprice = MdmGetData(item.Key);
                    var min = item.Where(x=>x.QualityLevel <= 1).Select(x => x.UnitPriceSilver).DefaultIfEmpty(0).Min();
                    if (bdprice.LongSaleItem.BestPrice > min || bdprice.FastSaleItem.BestPrice == 0 && min > 0)
                        bdprice.LongSaleItem.BestPrice = min;
                }
                else
                {
                    var mm = MdmGetData(item.Key);
                    mm.SellLongPos = DateTime.Now;
                    MdmGetData(item.Key).LongSaleItem.BestPrice = item.Min(x => x.UnitPriceSilver);
                }
                Items[item.Key].Pos = DateTime.Now;
            }
            RefreshTree();
        }

        private void AuctionBuyOfferHandler(AuctionBuyOffer p)
        {
            if (p.Items.Length == 0) return;
            var items = p.Items.GroupBy(x => x.ItemTypeId).ToArray();

            if (items.Length == 1)
                MdmGetData(items[0].Key).FastSaleItem.SetOrders(items[0]);
            else
            {
                foreach (var item in items)
                {
                    MdmGetData(item.Key).FastSaleItem.AppendOrders(item);
                }
            }

            foreach (var item in items) { 
                if (items.Length > 1)
                {
                    var bdprice = MdmGetData(item.Key);
                    var max = item.Where(x => x.QualityLevel <= 1).Select(x => x.UnitPriceSilver).DefaultIfEmpty(0)
                        .Max();
                    if (bdprice.FastSaleItem.BestPrice < max)
                        bdprice.FastSaleItem.BestPrice = max;
                }
                else
                {
                    var mm = MdmGetData(item.Key);
                    mm.FastSaleItem.BestPrice = item.Max(x => x.UnitPriceSilver);
                }
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