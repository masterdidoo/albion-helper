using System;

namespace Albion.Db.Items.Requirements
{
    public class FastBuyRequirement : BaseMarketRequirement
    {
        public FastBuyRequirement(CostContainer costContainer) : base(costContainer)
        {
        }

        protected override DateTime? InitTime => CostContainer.SellTime;
        protected override long? InitSilver
        {
            get => CostContainer.SellPrice;
            set => CostContainer.SellPrice=value;
        }

        protected override long? InitCost => Silver;
    }
}