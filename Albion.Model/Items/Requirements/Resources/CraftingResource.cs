namespace Albion.Model.Items.Requirements.Resources
{
    public class CraftingResource : NotifyEntity
    {
        private bool _isSelected;
        public bool IsExpanded { get; set; } = true;

        public CommonItem Item { get; set; }
        public int Count { get; set; }
        public long Cost => Item.Cost * Count;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public override string ToString() => $"{Item}[{Count}]";
    }
}