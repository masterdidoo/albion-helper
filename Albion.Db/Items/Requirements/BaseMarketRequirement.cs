using System;

namespace Albion.Db.Items.Requirements
{
    public abstract class BaseMarketRequirement : BaseRequirement
    {

        protected DateTime? _time;
        public override DateTime? Time => _time;

        protected BaseMarketRequirement(CostContainer costContainer)
        {
            Silver = MaxNullPrice;
            CostContainer = costContainer;
        }

        public CostContainer CostContainer { get; }
    }
}