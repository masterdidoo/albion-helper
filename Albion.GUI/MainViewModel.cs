using System;
using System.Linq;
using System.Threading;
using Albion.Common;
using Albion.Event;
using Albion.Network;
using Albion.Operation;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;

namespace Albion.GUI
{
    public class MainViewModel
    {
        public readonly AlbionParser albionParser;

        public MainViewModel()
        {
            albionParser = new AlbionParser();
            albionParser.Start();
        }
    }
}