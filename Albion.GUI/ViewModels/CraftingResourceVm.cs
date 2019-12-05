using Albion.Model.Items;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class CraftingResourceVm : ObservableObject
    {
        private readonly int _returnProc;
        private int _count;

        private long _sum;

        public CraftingResourceVm(CommonItem item, int batchCount, int baseCount, int returnProc)
        {
            Item = item;
            BatchCount = batchCount;
            _returnProc = returnProc;
            BaseCount = baseCount;
            UpdateCount(1);
        }

        public int BaseCount { get; }
        public int BatchCount { get; }

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public CommonItem Item { get; }

        public long Sum
        {
            get => _sum;
            set => Set(ref _sum, value);
        }

        public void UpdateCount(int count)
        {
            var tmpSumCount = BaseCount * count * BatchCount;
//            var ret = tmpSumCount * _returnProc / 100;

            Count = tmpSumCount;

            Sum = Item.Requirement.Cost * Count;
        }
    }
}