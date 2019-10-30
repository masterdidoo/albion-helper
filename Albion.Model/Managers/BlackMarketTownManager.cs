using System;
using Albion.Common;

namespace Albion.Model.Managers
{
    internal class BlackMarketTownManager : ITownManager
    {
        public static BlackMarketTownManager Instance = new BlackMarketTownManager();

        private BlackMarketTownManager()
        {
        }

        public Location Town => Location.BlackMarket;
        public int TownId => (int) Location.BlackMarket;
        public event Action<ITownManager> TownChanged
        {
            add {} 
            remove {}
        }
    }
}