using System;

namespace Albion.Db.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        public LongBuyRequirement(CostContainer costContainer) : base(costContainer)
        {
            costContainer.Updated += Update;
            Update();
        }

        public override long Cost => _time == DateTime.MinValue ? MaxNullPrice : (Silver + Tax + 10000);
        public override long Tax => Silver / 1000;

        public override string ToString()
        {
            return $"Long Buy {Silver}";
        }

        protected void Update()
        {
            Silver = CostContainer.BuyPrice;
            _time = CostContainer.BuyTime;
            RaisePropertyChanged(nameof(Cost));
        }
    }
}