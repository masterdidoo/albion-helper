using System.Collections.Generic;
using System.Linq;
using Albion.Common;
using Albion.Network;
using Newtonsoft.Json;

namespace Albion.Operation
{
    public abstract class AuctionBase : BaseOperation
    {
        public AuctionItem[] Items { get; private set; }

        public override void Init(Dictionary<byte, object> parameters)
        {
            var rows = parameters[0] as string[];
            Items = rows?.Select(JsonConvert.DeserializeObject<AuctionItem>).ToArray() ?? new AuctionItem[0];
        }
    }
}