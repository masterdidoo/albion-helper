using System;
using System.Collections.Generic;

namespace Albion.Network.Handlers
{
    internal abstract class BaseHandler
    {
        public abstract void Run(Dictionary<byte, object> parameters);
    }

    internal class BaseHandler<T> : BaseHandler where T : BaseBase, new()
    {
        public event Action<T> Action;

        public override void Run(Dictionary<byte, object> parameters)
        {
            var obj = new T();
            obj.Init(parameters);
            Action(obj);
        }
    }
}