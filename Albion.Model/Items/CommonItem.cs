using System.Collections.Generic;
using System.Linq;
using Albion.Model.Buildings;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Profits;
using Albion.Model.Items.Requirements;
using Albion.Model.Managers;

namespace Albion.Model.Items
{
    public class CommonItem : BaseCostableEntity
    {
        private readonly FastBuyRequirement _fastBuyRequirement;

        private readonly LongBuyRequirement _longBuyRequirement;
        private long _profit = -100;
        private BaseRequirement _requirement;

        public CommonItem(BaseResorcedRequirement[] craftingRequirements,
            ItemMarket itemMarket,
            CraftBuilding craftingBuilding,
            ITownManager buyTownManager,
            ITownManager sellTownManager
        )
        {
            CraftingRequirements = craftingRequirements;
            CraftingBuilding = craftingBuilding;
            ItemMarket = itemMarket;

            _longBuyRequirement = new LongBuyRequirement(buyTownManager);
            _fastBuyRequirement = new FastBuyRequirement(buyTownManager);

            LongSellProfit = new LongSellProfit(sellTownManager);
            FastSellProfit = new FastSellProfit(sellTownManager);
            BmFastSellProfit = new BmFastSellProfit(sellTownManager);

            if (CraftingRequirements.Length > 0 && CraftingRequirements[0].Resources.Length > 0)
                SalvageProfit = new SalvageProfit();

            CostCalcOptions.Instance.Changed += RequirementOnCostUpdate;
        }

        public FastSellProfit FastSellProfit { get; }
        public BmFastSellProfit BmFastSellProfit { get; }
        public SalvageProfit SalvageProfit { get; }
        public LongSellProfit LongSellProfit { get; }

        public long Profit
        {
            get => _profit;
            protected set
            {
                if (_profit == value) return;
                _profit = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<BaseRequirement> Components => ProfitsAll.Concat(RequirementsAll);

        private IEnumerable<BaseRequirement> RequirementsAll
        {
            get
            {
                yield return _fastBuyRequirement;
                yield return _longBuyRequirement;
                foreach (var cr in CraftingRequirements) yield return cr;
            }
        }

        private IEnumerable<BaseRequirement> ProfitsAll
        {
            get
            {
                if (SalvageProfit != null) yield return SalvageProfit;
                yield return BmFastSellProfit;
                yield return FastSellProfit;
                yield return LongSellProfit;
            }
        }

        private IEnumerable<BaseRequirement> RequirementsAutoMin
        {
            get
            {
                yield return _fastBuyRequirement;
                if (!CostCalcOptions.Instance.IsLongBuyDisabled || CostCalcOptions.Instance.IsArtefactsLongBuyEnabled &&
                    ShopCategory == ShopCategory.Artefacts)
                    yield return _longBuyRequirement;
                foreach (var cr in CraftingRequirements) yield return cr;
            }
        }

        public int MemId { get; set; }

        public ItemMarket ItemMarket { get; }

        #region For UI

        public bool IsExpanded { get; set; } = false;

        #endregion

        public BaseRequirement Requirement
        {
            get => _requirement;
            set
            {
                if (_requirement == value) return;
                _requirement = value;
                RaisePropertyChanged();
            }
        }

        public BaseProfit Profitt { get; set; }

        public void Init()
        {
            foreach (var cr in ProfitsAll)
            {
                cr.SetItem(this);
                cr.CostUpdate += ProfitOnCostUpdate;
                cr.Selected += OnProfitSelect;
            }

            foreach (var cr in RequirementsAll)
            {
                cr.SetItem(this);
                cr.CostUpdate += RequirementOnCostUpdate;
                cr.Selected += OnRequirementSelect;
            }

            RequirementOnCostUpdate();
        }

        private void ProfitOnCostUpdate()
        {
//            throw new System.NotImplementedException();
        }

        private void OnProfitSelect(BaseRequirement profit)
        {
            foreach (var item in ProfitsAll)
                if (item != profit)
                    item.IsSelected = false;
            Cost = profit.Cost;
//            Profitt = profit;
        }

        public void OnRequirementSelect(BaseRequirement requirement)
        {
            foreach (var item in RequirementsAll)
                if (item != requirement)
                    item.IsSelected = false;
            Cost = requirement.Cost;
            Requirement = requirement;
        }

        private void RequirementOnCostUpdate()
        {
            var min = long.MaxValue;
            BaseRequirement minItem = null;

            foreach (var item in RequirementsAutoMin)
            {
                item.IsSelected = false;
                item.IsExpanded = false;
                if (min > item.Cost && item.Cost > 0)
                {
                    min = item.Cost;
                    minItem = item;
                }
            }

//            var pos = Components.Max(x => x.Pos);
//            Pos = (pos.Ticks > 1) ? pos.AddTicks(-1) : pos;

            if (minItem != null)
            {
                minItem.IsSelected = true;
                minItem.IsExpanded = true;
                //Cost = minItem.Cost; set from UpdateMinCost
            }
            else
            {
                Cost = 0;
            }

            //Cost = Requirements.Select(x => x.Cost).Where(x => x > 0).DefaultIfEmpty(0).Min();
        }

        #region From Config

        public string Id { get; set; }
        public ShopCategory ShopCategory { get; set; }
        public ShopSubCategory ShopSubCategory { get; set; }
        public CraftBuilding CraftingBuilding { get; }
        public int ItemPower { get; set; }

        public int Tir { get; set; }
        public int Enchant { get; set; }

        public string Name { get; set; }

        public string FullName => $"{Tir}.{Enchant} {Name}";

        public BaseResorcedRequirement[] CraftingRequirements { get; }
        public int ItemValue { get; set; }
        public bool IsResource => ShopCategory == ShopCategory.Resources;
#if DEBUG
        public object Debug { get; set; }
#endif
        public override string ToString()
        {
            return Id;
        }

        #endregion

        public IEnumerable<BaseProfit> Profits { get; }

    }
}