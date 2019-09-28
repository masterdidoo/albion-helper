using System;

namespace Albion.Db.Items.Requirements
{
    public abstract class BaseMarketRequirement : BaseRequirement
    {
        private long? _silver;

        protected DateTime? _time;

        protected BaseMarketRequirement(CostContainer costContainer)
        {
            CostContainer = costContainer;
            costContainer.Updated += Update;
            _silver = InitSilver;
            _time = InitTime;
            Cost = InitCost;
        }

        protected abstract DateTime? InitTime { get; }

        protected abstract long? InitSilver { get; set; }

        protected abstract long? InitCost { get; }

        public override DateTime? Time => _time;

        public long? Silver
        {
            get => _silver;
            set
            {
                if (Set(ref _silver, value))
                {
                    Cost = InitCost;
                    InitSilver = value;
                    CostContainer.Save();
                }
            }
        }

        public CostContainer CostContainer { get; }

        private void Update()
        {
            _time = InitTime;
            Silver = InitSilver;
        }
    }
}