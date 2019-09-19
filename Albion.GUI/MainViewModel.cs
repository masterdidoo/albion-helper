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

            albionParser.AddRequestHandler<MoveOperation>(OperationCodes.Move, (operation) =>
            {
                Console.WriteLine($"Move request");
            });
            albionParser.AddEventHandler<MoveEvent>(EventCodes.Move, (operation) =>
            {
                Console.WriteLine($"Id: {operation.Id} x: {operation.Position.X} y: {operation.Position.Y}");
            });
            albionParser.AddEventHandler<NewCharacterEvent>(EventCodes.NewCharacter, (operation) =>
            {
                Console.WriteLine($"New ch Id: {operation.Id}");
            });
        }

        public void Start()
        {
            Console.WriteLine("Start");

            var devices = LivePacketDevice.AllLocalMachine;
            foreach (var device in devices)
            {
                new Thread(() =>
                    {
                        Console.WriteLine($"Open... {device.Description}");

                        using (PacketCommunicator communicator = device.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
                        {
                            communicator.ReceivePackets(0, PacketHandler);
                        }
                    })
                    .Start();
            }
        }

        private void PacketHandler(Packet packet)
        {
            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;

            if (udp == null || (udp.SourcePort != 5056 && udp.DestinationPort != 5056))
            {
                return;
            }

            albionParser.ReceivePacket(udp.Payload.ToArray());
        }
    }
}