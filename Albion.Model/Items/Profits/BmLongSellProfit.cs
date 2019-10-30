using Albion.Common;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class BmLongSellProfit : LongSellProfit
    {
        public override string Type => "BL";

        public BmLongSellProfit(CommonItem item) : base(item, BlackMarketTownManager.Instance)
        {
        }
    }
}