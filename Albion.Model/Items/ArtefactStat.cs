using System;
using System.Linq;
using Albion.Model.Buildings;
using ReactiveUI;

namespace Albion.Model.Items
{
    public class ArtefactStat : NotifyEntity
    {
        private long _cost;
        private long _fastSale;
        private long _longSale;

        public ArtefactStat(CraftBuilding craftingBuilding, CommonItem material, CommonItem[] artefacts)
        {
            CraftingBuilding = craftingBuilding;
            Material = material;
            Artefacts = artefacts;

            this.WhenAnyValue(x => x.Material.Cost).Subscribe(_ => MaterialOnUpdateCost());
            //            foreach (var item in Artefacts.Select(x => x.CraftingRequirements[0]).Distinct())
            //                item.UpdateCost += MaterialOnUpdateCost;

            foreach (var item in Artefacts)
            {
//                item.FastSellProfit.UpdateCost += FastSellProfitOnUpdateCost;
//                item.LongSellProfit.UpdateCost += LongSellProfitOnUpdateCost;
            }

            FastSellProfitOnUpdateCost();
            LongSellProfitOnUpdateCost();
            MaterialOnUpdateCost();
        }

        public CraftBuilding CraftingBuilding { get; }
        public CommonItem Material { get; }
        public CommonItem[] Artefacts { get; }

        public string Title => $"{Material}";
//        public string Title => $"{Material} {CraftingBuilding.Id}";

        public long Cost
        {
            get => _cost;
            protected set
            {
                if (_cost == value) return;
                _cost = value;
                OnPropertyChanged();
            }
        }

        public long FastSale
        {
            get => _fastSale;
            protected set
            {
                if (_fastSale == value) return;
                _fastSale = value;
                OnPropertyChanged();
            }
        }

        public long LongSale
        {
            get => _longSale;
            protected set
            {
                if (_longSale == value) return;
                _longSale = value;
                OnPropertyChanged();
            }
        }

        private void LongSellProfitOnUpdateCost()
        {
            LongSale = Artefacts.Sum(x => x.LongSellProfit.Cost);
        }

        private void FastSellProfitOnUpdateCost()
        {
            FastSale = Artefacts.Sum(x => x.FastSellProfit.Cost);
        }

        private void MaterialOnUpdateCost()
        {
            //Cost = Artefacts.SelectMany(x=>x.CraftingRequirements[0].Resources).Sum(x => x.Cost);
            Cost = Material.Cost*Artefacts.Length*36;
        }
    }
}