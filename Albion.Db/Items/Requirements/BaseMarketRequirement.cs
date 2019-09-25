using System;
using Albion.Common;

namespace Albion.Db.Items.Requirements
{
    public abstract class BaseMarketRequirement : BaseRequirement
    {

        protected DateTime _time;
        public override DateTime Time => _time;

        protected BaseMarketRequirement(CostContainer costContainer)
        {
            CostContainer = costContainer;
            costContainer.Updated += Update;
        }

        protected abstract void Update();

        public CostContainer CostContainer { get; }
    }
}