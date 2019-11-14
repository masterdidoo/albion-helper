using System.Collections.ObjectModel;
using Albion.Model.Items;
using Albion.Model.Items.Requirements;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private int _count = 1;

        public ItemViewModel(CommonItem item)
        {
            Item = item;
            Items = new ObservableCollection<CraftingResourceVm>();
            AddRequirement(item, 1);
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

        private void UpdateCount(int count)
        {
            foreach (var item in Items) item.Count = item.BaseCount * count;
        }

        private void AddRequirement(CommonItem item, int count)
        {
            switch (item.Requirement)
            {
                case BaseResorcedRequirement craftingRequirement:
                    AddCraftingRequirement(craftingRequirement, count);
                    return;
            }

            Items.Add(new CraftingResourceVm(item, count));
        }

        private void AddCraftingRequirement(BaseResorcedRequirement requirement, int count)
        {
            foreach (var requirementResource in requirement.Resources)
                AddRequirement(requirementResource.Item, requirementResource.Count * count);
        }
    }
}