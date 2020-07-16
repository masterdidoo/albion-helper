using System;
using System.Collections.Generic;
using Albion.Model.Items;
using Albion.Model.Items.Requirements;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly Dictionary<CommonItem, CraftingResourceVm> _items;
        private int _count;

        private double? _jornalsCount;

        private long _profit;

        private long _silver;

        private long _sum;

        private long _tax;
        private long _baseTax;
        private long _baseSilver;

        public ItemViewModel(CommonItem item, int returnProc)
        {
            Item = item;
            _items = new Dictionary<CommonItem, CraftingResourceVm>();
            AddRequirement(item, 1, 1, returnProc);
            Count = 1;
        }

        public IEnumerable<CraftingResourceVm> Items => _items.Values;

        public CommonItem Item { get; }

        public bool IsTaxSilver => Tax > 0 || Silver > 0;

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
        public Journal Jornal { get; private set; }

        public long Profit

        {
            get => _profit;
            set => Set(ref _profit, value);
        }

        public long Silver
        {
            get => _silver;
            set => Set(ref _silver, value);
        }

        public long Tax
        {
            get => _tax;
            set => Set(ref _tax, value);
        }

        private void UpdateCount(int count)
        {
            long sum = 0;
            foreach (var item in Items)
            {
                item.UpdateCount(count);
                sum += item.Sum;
            }

            Tax = _baseTax * count;
            Silver = _baseSilver * count;

            Sum = sum + Tax + Silver;
            Profit = (Item.Profitt?.Income ?? 0) * count - Sum;

            JornalsCount = (Item.Requirement as CraftingRequirement)?.JournalsCount * count;
            Jornal = (Item.Requirement as CraftingRequirement)?.Journal;
            if (JornalsCount == null || JornalsCount == 0)
            {
                JornalsCount = null;
            }
            else
            {
                //Profit += (long) ((Jornal.FullItem.Profitt?.Income ?? 0) * JornalsCount.Value);
            }
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

            if (requirement is CraftingRequirement craftingRequirement)
            {
                _baseTax += craftingRequirement.Tax;
                _baseSilver += craftingRequirement.Silver;
                if (craftingRequirement.Journal != null)
                    AddRequirement(craftingRequirement.Journal.EmptyItem, itemsCount, craftingRequirement.JournalsCount,
                        0);
            }
        }
    }
}