using System;
using System.Linq;

namespace Albion.Db.Items
{
    public abstract class BaseRequirement
    {
        public abstract DateTime Time { get; }
        public long Silver { get; set; }
        public abstract long Cost { get; }
    }

    public class CraftingRequirement : BaseRequirement
    {
        public CraftResource[] CraftResources { get; set; }
        public override DateTime Time => CraftResources.Min(x => x.Item.Time);
        public override long Cost => Silver + CraftResources.Sum(c => c.Cost);

        public override string ToString()
        {
            if (CraftResources.Length == 0) return String.Empty;
            return string.Join(", ", CraftResources.Select(x => x.ToString()));
        }
    }

    public class MarketRequirement : BaseRequirement
    {
        public bool IsBuy { get; set; }

        public override long Cost => Silver + (IsBuy ? 0 : CostContainer.OrderTax(Silver));

        public override string ToString()
        {
            var buy = IsBuy ? "fast" : "long";
            return $"Buy {buy} {Silver}";
        }
    }
}