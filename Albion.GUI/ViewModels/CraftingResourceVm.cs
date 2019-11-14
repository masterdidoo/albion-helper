using Albion.Model.Items;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class CraftingResourceVm : ObservableObject
    {
        private int _count;

        public CraftingResourceVm(CommonItem item, int count)
        {
            Item = item;
            _count = count;
            BaseCount = count;
        }

        public int BaseCount { get; }

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public CommonItem Item { get; }


        public override string ToString()
        {
            return $"{Item.FullName} {Count}";
        }
    }
}