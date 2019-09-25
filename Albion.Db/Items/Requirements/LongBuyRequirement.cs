namespace Albion.Db.Items.Requirements
{
    public class LongBuyRequirement : BaseMarketRequirement
    {
        public LongBuyRequirement(CostContainer costContainer) : base(costContainer)
        {
        }

        public override long Cost => Silver + Tax + 10000;
        public override long Tax => Silver / 1000;

        public override string ToString()
        {
            return $"Long Buy {Silver}";
        }

        protected override void Update()
        {
            Silver = CostContainer.BuyPrice;
            _time = CostContainer.BuyTime;
        }
    }
}