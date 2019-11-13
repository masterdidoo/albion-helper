using Albion.Model.Items;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private int _count;

        public ItemViewModel(CommonItem item)
        {
            Item = item;
        }

        public CommonItem Item { get; }

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }
    }
}