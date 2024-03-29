﻿using System.Linq;
using Albion.Common;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Requirements.Resources;

namespace Albion.Model.Items.Requirements
{
    public class CraftingRequirement : BaseResorcedRequirement
    {
        public static int ReturnRefine35 => ((CostCalcOptions.Instance.IsRefineFocus ? 53 : 35)); //Refining Royal City With Bonus
        public static int Return25 => ((CostCalcOptions.Instance.IsFocus ? 48 : 25)); //Crafting Royal City With Bonus, Black Zone Territory
        public static int ReturnRefine20 => ((CostCalcOptions.Instance.IsRefineFocus ? 46 : 20)); //Refining Black Zone
        public static int Return15 => ((CostCalcOptions.Instance.IsFocus ? 44 : 15)); //Royal City
        public static int ReturnRefine15 => ((CostCalcOptions.Instance.IsRefineFocus ? 44 : 15)); //Royal City

        private int _returnProc;

        public CraftingRequirement(CraftingResource[] resources) : base(resources)
        {
            //ItemValue = resources.Sum(r => r.Item.ItemValue * r.Count);
        }

        public Location CraftTown => Item.CraftingBuilding.Town;

        public override int ReturnProc => _returnProc;

        protected override void ResourcesOnCostUpdate()
        {
            Tax = (int)(Item.CraftingBuilding.Tax * Item.ItemValue * BaseResorcedRequirement.ItemValueToNutrition / 100) + Silver;

            if (Resources.Any(x => x.Item.Cost == 0))
            {
                SetCost(0, 1);
                return;
            }

            _returnProc = GetReturnCoeff();
            var returnableCost = Resources.Where(r => r.IsReturnable).Sum(x => x.Cost) * (100 - _returnProc) / 100;
            var summ = Resources.Where(r => !r.IsReturnable).Sum(x => x.Cost) + returnableCost;
//            var summ = Resources.Sum(x => x.Cost) * 1000 / GetReturnCoeff();

            //TODO сделать красиво
            var artefacts = Item.ShopCategory == ShopCategory.Artefacts ? 9 : 1;

            var cost = (summ + Tax) / AmountCrafted * artefacts;

            SetCost(cost, 1);
        }

        public double JournalsCount { get; private set; }

        private int GetReturnCoeff()
        {
            switch (Item.ShopCategory)
            {
                case ShopCategory.Offhand:
                    if (CraftTown == Location.Martlock) return Return25;
                    break;
            }

            switch (Item.ShopSubCategory)
            {
                case ShopSubCategory.Planks:
                    if (CraftTown == Location.FortSterling) return ReturnRefine35;
                    if (CraftTown == Location.BlackZone) return ReturnRefine20;
                    return ReturnRefine15;
                case ShopSubCategory.Stoneblock:
                    if (CraftTown == Location.Bridgewatch) return ReturnRefine35;
                    if (CraftTown == Location.BlackZone) return ReturnRefine20;
                    return ReturnRefine15;
                case ShopSubCategory.Metalbar:
                    if (CraftTown == Location.Thetford) return ReturnRefine35;
                    if (CraftTown == Location.BlackZone) return ReturnRefine20;
                    return ReturnRefine15;
                case ShopSubCategory.Leather:
                    if (CraftTown == Location.Martlock) return ReturnRefine35;
                    if (CraftTown == Location.BlackZone) return ReturnRefine20;
                    return ReturnRefine15;
                case ShopSubCategory.Cloth:
                    if (CraftTown == Location.Lymhurst) return ReturnRefine35;
                    if (CraftTown == Location.BlackZone) return ReturnRefine20;
                    return ReturnRefine15;

                case ShopSubCategory.Froststaff:
                case ShopSubCategory.Quarterstaff:
                case ShopSubCategory.Axe:
                case ShopSubCategory.PlateShoes:
                    if (CraftTown == Location.Martlock) return Return25;
                    break;
                case ShopSubCategory.Cursestaff:
                case ShopSubCategory.Dagger:
                case ShopSubCategory.Crossbow:
                case ShopSubCategory.PlateArmor:
                case ShopSubCategory.ClothShoes:
                    if (CraftTown == Location.Bridgewatch) return Return25;
                    break;
                case ShopSubCategory.Arcanestaff:
                case ShopSubCategory.Bow:
                case ShopSubCategory.Sword:
                case ShopSubCategory.LeatherHelmet:
                case ShopSubCategory.LeatherShoes:
                    if (CraftTown == Location.Lymhurst) return Return25;
                    break;
                case ShopSubCategory.Hammer:
                case ShopSubCategory.Spear:
                case ShopSubCategory.Holystaff:
                case ShopSubCategory.ClothArmor:
                case ShopSubCategory.PlateHelmet:
                    if (CraftTown == Location.FortSterling) return Return25;
                    break;
                case ShopSubCategory.Mace:
                case ShopSubCategory.Naturestaff:
                case ShopSubCategory.Firestaff:
                case ShopSubCategory.LeatherArmor:
                case ShopSubCategory.ClothHelmet:
                    if (CraftTown == Location.Thetford) return Return25;
                    break;
                case ShopSubCategory.Cooked:
                case ShopSubCategory.Potion:
                    if (CraftTown == Location.Caerleon) return Return25;
                    break;
            }

            if (CraftTown == Location.BlackZone) return Return25;
            if (CraftTown < Location.BlackMarket) return Return15;

            return 0;
        }

        public override string Type => "CR";

        protected override void OnSetItem()
        {
            if (Journal!=null)
                JournalsCount = Item.ItemFame / Journal.MaxFame;
            Item.CraftingBuilding.UpdateTax += ResourcesOnCostUpdate;
            CostCalcOptions.Instance.IsFocusChanged += ResourcesOnCostUpdate;
            ResourcesOnCostUpdate();
            base.OnSetItem();
        }

        /// <summary>
        ///     tax * 10000
        /// </summary>

        #region Tax

        private long _tax;


        public long Tax
        {
            get => _tax;
            protected set
            {
                if (_tax == value) return;
                _tax = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Config

        /// <summary>
        ///     silver * 10000
        /// </summary>
        public long Silver { get; set; }

        public int AmountCrafted { get; set; }
        public Journal Journal { get; set; }

        #endregion
    }
}