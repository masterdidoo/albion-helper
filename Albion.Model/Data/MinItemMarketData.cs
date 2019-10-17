using System.Linq;

namespace Albion.Model.Data
{
    public class MinItemMarketData : ItemMarketData
    {
        protected override long GetBestPrice()
        {
            return Orders.Min(x => x.UnitPriceSilver);
        }
    }
}