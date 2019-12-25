﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Albion.Model.Items;
using Albion.Model.Items.Requirements;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private int _count;

        private double? _jornalsCount;

        private long _profit;

        private long _sum;
        private readonly Dictionary<CommonItem, CraftingResourceVm> _items;

        public ItemViewModel(CommonItem item, int returnProc)
        {
            Item = item;
            _items = new Dictionary<CommonItem, CraftingResourceVm>();
            AddRequirement(item, 1, 1, returnProc);
            Count = 1;
        }

        public IEnumerable<CraftingResourceVm> Items => _items.Values;

        public CommonItem Item { get; }

        public int Count
        {
            get => _count;
            set
            {
                if (!Set(ref _count, value)) return;
                UpdateCount(value);
            }
        }

        public long Sum
        {
            get => _sum;
            set => Set(ref _sum, value);
        }

        public double? JornalsCount
        {
            get => _jornalsCount;
            set => Set(ref _jornalsCount, value);
        }

        public long Profit

        {
            get => _profit;
            set => Set(ref _profit, value);
        }

        private void UpdateCount(int count)
        {
            long sum = 0;
            foreach (var item in Items)
            {
                item.UpdateCount(count);
                sum += item.Sum;
            }

            Sum = sum;
            Profit = (Item.Profitt?.Income ?? 0) * count - Sum;

            JornalsCount = (Item.Requirement as CraftingRequirement)?.JournalsCount * count;
            if (JornalsCount == 0) JornalsCount = null;
        }

        private void AddRequirement(CommonItem item, double itemsCount, double ingredientsCount, int returnProc)
        {
            switch (item.Requirement)
            {
                case BaseResorcedRequirement craftingRequirement:
                    if (craftingRequirement.Resources.Length == 0) break;
                    AddCraftingRequirement(craftingRequirement, itemsCount * ingredientsCount);
                    return;
            }

            if (_items.TryGetValue(item, out var itemVm))
                itemVm.Add(itemsCount * ingredientsCount);
            else
                _items.Add(item, new CraftingResourceVm(item, itemsCount * ingredientsCount, returnProc));
        }

        private void AddCraftingRequirement(BaseResorcedRequirement requirement, double itemsCount)
        {
            foreach (var requirementResource in requirement.Resources)
                AddRequirement(requirementResource.Item, itemsCount, requirementResource.Count,
                    requirementResource.IsReturnable ? requirement.ReturnProc : 0);

            if (requirement is CraftingRequirement craftingRequirement && craftingRequirement.Journal != null)
            {
                AddRequirement(craftingRequirement.Journal.EmptyItem, itemsCount, craftingRequirement.JournalsCount, 0);
            }
        }
    }
}