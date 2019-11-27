using System;
using System.Collections.Generic;
using Albion.Common;
using Albion.Network;

namespace Albion.Event
{
    public class NewCharacterEvent : LeaveEvent
    {
        public override void Init(Dictionary<byte, object> parameters)
        {
            ///{"0":3145,
            /// "1":"1KKK","2":18,"3":23,"5":[0,0,1,3,2],"6":[0,4,0,0,0],"7":[240,60,189,230,185,186,16,67,165,64,186,234,212,219,210,14],
            /// "8":"Black Forge Orcs",
            /// "9":[64,12,112,161,84,103,18,67,163,43,72,247,129,84,130,27],"10":"","11":"",
            /// "12":[217.729126,-173.90184],
            /// "13":[218.245,-169.278839],
            /// "14":23745508,
            /// "15":7.293147,
            /// "16":12.375,
            /// "18":2627,
            /// "19":2627,
            /// "20":76.46912,"21":23745573,"22":348,"23":348,"24":4.52120638,"25":23745416,"26":676,"27":676,"28":6.76,"29":23745507,
            /// "30":26396.668,"31":636963951305034355,"32":0,
            /// "33":[5562,0,3308,2178,2802,1783,1580,1922,0,0],
            /// "35":[1573,1580,1609,1709,1752,1802,2166,2063],"37":39,"38":2,"39":1,"40":15775037,"41":0.7,"42":0.1,
            /// "43":"ARCH","44":[194,168,26,133,91,47,14,79,168,227,132,116,110,201,136,83],"45":0,"252":24}
            ///

            Name = parameters.StringOrNull(1);
            GuildName = parameters.StringOrNull(8);
            AllianceName = parameters.StringOrNull(43);
            var a13 = (Single[])parameters[13];
            Pos = new Position(a13[0], a13[1]);
        }

        public Position Pos { get; private set; }

        public string AllianceName { get; private set; }

        public string GuildName { get; private set; }

        public string Name { get; private set; }

        public override EventCodes Code => EventCodes.NewCharacter;
    }
}