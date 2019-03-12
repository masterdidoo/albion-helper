using System;
using System.Collections.Generic;
using Albion.Common;
using Albion.Network;

namespace Albion.Operation
{
    public class ConsloeCommand : BaseOperation {
        public override void Init(Dictionary<byte, object> parameters)
        {
            Location = (Location) Convert.ToInt32(parameters[0]);
        }

        public Location Location { get; private set; }

        public override OperationCodes Code => OperationCodes.ConsoleCommand;
    }
}