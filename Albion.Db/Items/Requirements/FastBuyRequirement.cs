using System;

namespace Albion.Db.Items.Requirements
{
    public class FastBuyRequirement : BaseMarketRequirement
    {
        public FastBuyRequirement(CostContainer costContainer) : base(costContainer)
        {
        }

        public override long Cost => Silver;
        public override long Tax => 0;

        public override string ToString()
        {
            return $"Fast Buy {Silver}";
        }

        protected override void Update()
        {
            Silver = CostContainer.SellPrice;
            _time = CostContainer.SellTime;
        }
    }
}