using System;
using System.Threading;
using Albion.Common;
using Albion.Event;
using Albion.Network;
using Albion.Operation;
using PcapDotNet.Core;

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
    }
}