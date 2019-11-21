using System.Collections.ObjectModel;
using Albion.Model.Items;
using Albion.Model.Items.Requirements;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private int _count = 1;

        public ItemViewModel(CommonItem item, int returnProc)
        {
            Item = item;
            Items = new ObservableCollection<CraftingResourceVm>();
            AddRequirement(item, 1, returnProc);
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
            //TODO возвраты
            foreach (var item in Items) item.UpdateCount(count);
        }

        private void AddRequirement(CommonItem item, int count, int returnProc)
        {
            switch (item.Requirement)
            {
                case BaseResorcedRequirement craftingRequirement:
                    //TODO возвраты
                    AddCraftingRequirement(craftingRequirement, count);
                    return;
            }

            Items.Add(new CraftingResourceVm(item, count, returnProc));
        }

        private void AddCraftingRequirement(BaseResorcedRequirement requirement, int count)
        {
            foreach (var requirementResource in requirement.Resources)
                AddRequirement(requirementResource.Item, count * requirementResource.Count, requirement.ReturnProc);
        }
    }
}