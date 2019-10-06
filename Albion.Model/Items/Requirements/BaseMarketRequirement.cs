namespace Albion.Model.Items.Requirements
{
    public abstract class BaseMarketRequirement : BaseRequirement
    {
        private long _silver;

        public long Silver
        {
            get => _silver;
            set
            {
                if (_silver == value) return;
                _silver = value;
                OnPropertyChanged();
                OnUpdateSilver();
            }
        }

        protected abstract void OnUpdateSilver();
    }
}