namespace Albion.Db.Items
{
    public class PlayerContext : IPlayerContext
    {
        private int _townIndex;

        public int TownIndex
        {
            get => _townIndex;
            set => _townIndex = value;
        }
    }
}