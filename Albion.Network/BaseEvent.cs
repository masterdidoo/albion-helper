// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;
using Albion.Common;

namespace Albion.Network
{
    public abstract class BaseEvent : BaseBase
    {
        public abstract EventCodes Code { get; }
    }
}
