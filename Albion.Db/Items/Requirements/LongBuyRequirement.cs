using System;

namespace Albion.Db.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        public LongBuyRequirement(CostContainer costContainer) : base(costContainer)
        {
        }

        protected override DateTime? InitTime => CostContainer.BuyTime;
        protected override long? InitSilver
        {
            get => CostContainer.BuyPrice;
            set => CostContainer.BuyPrice = value;
        }

        protected override long? InitCost => Silver + Silver / 100 + 10000;
    }
}