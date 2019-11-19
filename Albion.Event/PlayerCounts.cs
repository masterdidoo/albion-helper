using System;
using System.Collections.Generic;
using Albion.Common;
using Albion.Network;

namespace Albion.Event
{
    public class PlayerCounts : BaseEvent
    {
        public int Blue { get; private set; }
        public int Red { get; private set; }
        public override EventCodes Code => EventCodes.PlayerCounts;

        public override void Init(Dictionary<byte, object> parameters)
        {
            Blue = Convert.ToInt32(parameters[0]);
            if (parameters.TryGetValue(1, out var p2))
                Red = Convert.ToInt32(p2);
        }

        public override string ToString()
        {
            return $"{Code} {Blue} {Red}";
        }
    }
}