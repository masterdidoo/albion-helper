using System.Collections.ObjectModel;
using Albion.Model.Items;
using Albion.Model.Items.Requirements;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private int _count;

        private long _profit;

        private long _sum;

        public ItemViewModel(CommonItem item, int returnProc)
        {
            Item = item;
            Items = new ObservableCollection<CraftingResourceVm>();
            AddRequirement(item, 1, 1, returnProc);
            Count = 1;
        }

        public ObservableCollection<CraftingResourceVm> Items { get; }

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
        }

        private void AddRequirement(CommonItem item, int itemsCount, int ingredientsCount, int returnProc)
        {
            switch (item.Requirement)
            {
                case BaseResorcedRequirement craftingRequirement:
                    AddCraftingRequirement(craftingRequirement, itemsCount * ingredientsCount);
                    return;
            }

            Items.Add(new CraftingResourceVm(item, itemsCount, ingredientsCount, returnProc));
        }

        private void AddCraftingRequirement(BaseResorcedRequirement requirement, int itemsCount)
        {
            foreach (var requirementResource in requirement.Resources)
                AddRequirement(requirementResource.Item, itemsCount, requirementResource.Count,
                    requirementResource.IsReturnable ? requirement.ReturnProc : 0);
        }
    }
}