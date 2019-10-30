using System.Linq;
using Albion.Model.Data;
using Albion.Model.Managers;

namespace Albion.Model.Items.Profits
{
    public class BmFastSellProfit : FastSellProfit
    {
        public override string Type => "BF";

        public BmFastSellProfit(CommonItem item) : base(item, BlackMarketTownManager.Instance)
        {
        }
    }
}