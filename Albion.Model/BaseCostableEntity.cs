using System;
using System.ComponentModel;
using ReactiveUI;

namespace Albion.Model
{
    public class BaseCostableEntity : NotifyEntity
    {
        private long _cost;
        private DateTime _pos;

        public DateTime Pos
        {
            get => _pos;
            set => this.RaiseAndSetIfChanged(ref _pos, value);
        }

        public long Cost
        {
            get => _cost;
            protected set =>this.RaiseAndSetIfChanged(ref _cost, value);
        }
    }
}