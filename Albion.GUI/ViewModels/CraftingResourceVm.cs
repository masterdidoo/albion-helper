using System;
using Albion.Model.Items;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class CraftingResourceVm : ObservableObject
    {
        private readonly int _returnProc;
        private int _count;

        private long _sum;

        public CraftingResourceVm(CommonItem item, double baseCount, int returnProc)
        {
            Item = item;
            _returnProc = returnProc;
            _baseCount = baseCount;
            UpdateCount(1);
        }

        private double _baseCount;

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
            var tmpSumCount = _baseCount * count;
//            var ret = tmpSumCount * _returnProc / 100;

            Count = (int)Math.Ceiling(tmpSumCount);

            Sum = (Item?.Requirement?.Cost ?? 0) * Count;
        }

        public void Add(double count)
        {
            _baseCount += count;
        }
    }
}