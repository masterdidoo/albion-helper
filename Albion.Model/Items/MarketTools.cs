namespace Albion.Model.Items
{
    public static class MarketTools
    {
        public static long FastSell(this long price) => price - price * 3 / 100; // -3%
        public static long LongSell(this long price) => price - price * 45 / 1000; //-1.5% and -3% = -4.5%
    }
}