using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albion.Model.Data;

namespace Albion.Model.Managers
{
    public interface IMarketDataManager
    {
        ItemMarket GetData(string itemId);
    }
}
