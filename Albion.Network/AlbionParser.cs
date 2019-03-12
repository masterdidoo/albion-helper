// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Albion.Common;
using Albion.Network.Handlers;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PhotonPackageParser;

namespace Albion.Network
{
    public sealed class AlbionParser : PhotonParser
    {
        private readonly Dictionary<EventCodes, BaseHandler> _eventHandlers = new Dictionary<EventCodes, BaseHandler>();

        private readonly Dictionary<OperationCodes, BaseHandler> _operationHandlers =
            new Dictionary<OperationCodes, BaseHandler>();

        protected override void OnEvent(byte code, Dictionary<byte, object> parameters)
        {
            if (code == 2) parameters.Add(252, (short) EventCodes.Move);

            var eventCode = ParseEventCode(parameters);

            switch (eventCode)
            {
                case EventCodes.ReputationUpdate:
                case EventCodes.UpdateFame:
                case EventCodes.AchievementProgressInfo:
                case EventCodes.UpdateMoney:
                case EventCodes.RepairBuildingInfo:
                case EventCodes.NewBuilding:
                case EventCodes.ActionOnBuildingFinished:
                case EventCodes.ActionOnBuildingStart:
                case EventCodes.MountCancel:
                case EventCodes.EnteringArenaStart:
                case EventCodes.CastStart:
                case EventCodes.EnergyUpdate:
                case EventCodes.CastFinished:
                case EventCodes.ForcedMovement:
                case EventCodes.EnteringArenaCancel:
                case EventCodes.EnteringArenaLockStart:
                case EventCodes.OverChargeEnd:
                case EventCodes.EnteringArenaLockCancel:
                case EventCodes.NewExit:
                case EventCodes.NewEquipmentItem:
                case EventCodes.RegenerationCraftingChanged:
                case EventCodes.RegenerationMountHealthChanged:
                case EventCodes.ChatSay:
                case EventCodes.RegenerationEnergyChanged:
                case EventCodes.RegenerationHealthChanged:
                case EventCodes.RegenerationPlayerComboChanged:
                case EventCodes.CharacterEquipmentChanged:
                case EventCodes.CastHits:
                case EventCodes.TimeSync:
                case EventCodes.NewCharacter:
                case EventCodes.Mounted:
                case EventCodes.NewMountObject:
                case EventCodes.ActiveSpellEffectsUpdate:
                case EventCodes.Leave:
                case EventCodes.CastHit:
                case EventCodes.CastSpell:
                case EventCodes.TakeSilver:
                case EventCodes.Move:
                case EventCodes.PlayerCounts:
                case EventCodes.NewSimpleItem:
                case EventCodes.NewFloatObject:
                case EventCodes.FishingStart:
                    break;
                case EventCodes.HarvestFinished:
                case EventCodes.HarvestStart:
                    Debug.WriteLine($"{eventCode.ToString()}: {parameters[0]}");
                    break;
                default:
                    Debug.WriteLine($"case EventCodes.{eventCode.ToString()}:");
                    break;
            }

            if (_eventHandlers.TryGetValue(eventCode, out var handler))
                handler.Run(parameters);
        }

        protected override void OnRequest(byte code, Dictionary<byte, object> parameters)
        {
            //HandleOperation(code, parameters);
        }

        private void HandleOperation(byte code, Dictionary<byte, object> parameters)
        {
            var operationCode = ParseOperationCode(parameters);

            switch (operationCode)
            {
                case OperationCodes.Move:
                    break;
                case OperationCodes.ConsoleCommand:
                    Console.WriteLine($"ConsoleCommand {parameters[0]}");
                    break;
                default:
                    Debug.WriteLine($"case OperationCodes.{operationCode.ToString()}:");
                    break;
            }

            if (_operationHandlers.TryGetValue(operationCode, out var handler))
                handler.Run(parameters);
        }

        protected override void OnResponse(byte code, short returnCode, string debugMessage,
            Dictionary<byte, object> parameters)
        {
            HandleOperation(code, parameters);
        }

        private OperationCodes ParseOperationCode(Dictionary<byte, object> parameters)
        {
            if (!parameters.TryGetValue(253, out var value)) throw new AlbionException();

            return (OperationCodes) value;
        }

        private EventCodes ParseEventCode(Dictionary<byte, object> parameters)
        {
            if (!parameters.TryGetValue(252, out var value)) throw new AlbionException();

            return (EventCodes) value;
        }

        public void AddOperationHandler<T>(Action<T> action) where T : BaseOperation, new()
        {
            var obj = new T();
            var handler = new BaseHandler<T> {Action = action};
            _operationHandlers.Add(obj.Code, handler);
        }

        public void AddEventHandler<T>(Action<T> action) where T : BaseEvent, new()
        {
            var obj = new T();
            var handler = new BaseHandler<T> {Action = action};
            _eventHandlers.Add(obj.Code, handler);
        }

        public void Start()
        {
            var devices = LivePacketDevice.AllLocalMachine;
            foreach (var device in devices)
                new Thread(() =>
                    {
                        Console.WriteLine($"Open... {device.Description}");

                        using (var communicator = device.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
                        {
                            communicator.ReceivePackets(0, PacketHandler);
                        }
                    })
                    .Start();
        }

        private void PacketHandler(Packet packet)
        {
            var ip = packet.Ethernet.IpV4;
            var udp = ip.Udp;

            if (udp == null || udp.SourcePort != 5056 && udp.DestinationPort != 5056) return;

            ReceivePacket(udp.Payload.ToArray());
        }
    }
}