using System;

namespace Albion.Model.Items.Requirements
{
    public abstract class BaseMarketRequirement : BaseRequirement
    {
        private long _silver;

        public long Silver
        {
            get => _silver;
            set => UpdateSilver(value, DateTime.Now);
        }

        protected void UpdateSilver(long silver, DateTime pos)
        {
            if (_silver == silver) return;
            _silver = silver;
            Pos = pos;
            OnUpdateSilver();
            OnPropertyChanged(nameof(Silver));
        }

        protected abstract void OnUpdateSilver();
    }
}