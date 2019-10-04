using Albion.Common;

namespace Albion.DataStore.DataModel
{
    public class MarketData
    {
        public MarketData()
        {
        }

        public MarketData(string id)
        {
            Id = id;

            const int n = (int) Location.None + 1;

            SellPriceDatas = new PriceData[n];
            BuyPriceDatas = new PriceData[n];

            for (var i = 0; i < n; i++)
            {
                SellPriceDatas[i] = new PriceData();
                BuyPriceDatas[i] = new PriceData();
            }
        }

        public string Id { get; set; }
        public PriceData[] SellPriceDatas { get; set; }
        public PriceData[] BuyPriceDatas { get; set; }
    }
}