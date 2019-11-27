using System;
using System.Collections.Generic;
using Albion.Common;
using Albion.Network;

namespace Albion.Event
{
    public class LeaveEvent : BaseEvent
    {
        public override void Init(Dictionary<byte, object> parameters)
        {
            Id = Convert.ToInt32(parameters[0]);
        }

        public int Id { get; private set; }

        public override EventCodes Code => EventCodes.Leave;
    }
}