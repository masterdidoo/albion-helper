using System;
using System.Collections.Generic;
using Albion.Common;
using Albion.Network;

namespace Albion.Operation
{
    public class Join : BaseOperation
    {
        private Location _town = Location.None;

        public Dictionary<string, Location> Locations = new Dictionary<string, Location>
        {
            {"0004", Location.SwampCross},
            {"0007", Location.Thetford},
            {"1002", Location.Lymhurst},
            {"1006", Location.ForestCross},
            {"2002", Location.SteppeCross},
            {"2004", Location.Bridgewatch},
            {"3002", Location.HighlandCross},
            {"3003", Location.BlackMarket},
            {"3005", Location.Caerleon},
            {"3013", Location.Caerleon},
            {"3008", Location.Martlock},
            {"4002", Location.FortSterling},
            {"4006", Location.MountainCross}
        };

        public Location Town => _town;

        public string Name { get; private set; }
        public string LocId { get; private set; }

        public override OperationCodes Code => OperationCodes.Join;

        public override void Init(Dictionary<byte, object> parameters)
        {
            Name = Convert.ToString(parameters[2]);
            LocId = Convert.ToString(parameters[8]);
            if (!Locations.TryGetValue(LocId, out _town)) _town = Location.None;
        }
    }    }