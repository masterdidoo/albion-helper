using System.Linq;

namespace Albion.Model.Data
{
    public class MaxItemMarketData : ItemMarketData
    {
        protected override long GetBestPrice()
        {
            return Orders.Max(x => x.UnitPriceSilver);
        }
    }
}