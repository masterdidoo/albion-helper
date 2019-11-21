using System.Data;
using Albion.Model.Items;
using GalaSoft.MvvmLight;

namespace Albion.GUI.ViewModels
{
    public class CraftingResourceVm : ObservableObject
    {
        private int _count;
        private readonly int _returnProc;

        public CraftingResourceVm(CommonItem item, int baseCount, int returnProc)
        {
            Item = item;
            _returnProc = returnProc;
            BaseCount = baseCount;
            UpdateCount(1);
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

        public void UpdateCount(int count)
        {
            var tmpCount = BaseCount * count;
            var ret = tmpCount * _returnProc / 100;
            if (tmpCount - ret > BaseCount)
            {
                int chekCount;
                ret++;
                do
                {
                    ret--;
                    var newRet = ret;
                    chekCount = tmpCount - newRet;
                    newRet = tmpCount - newRet;
                    while (newRet > 0)
                    {
                        newRet = newRet * _returnProc / 100;
                        chekCount += newRet;
                    }
                } while (chekCount < tmpCount);
                tmpCount -= ret;
            }
            Count = tmpCount;
        }
    }
}