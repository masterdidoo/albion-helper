using GalaSoft.MvvmLight;

namespace Albion.Db.Items
{
    public class BaseItem : ObservableObject
    {
        public BaseItem(string id)
        {
            Id = id;
        }

        public string Id { get; }

        protected bool Equals(SimpleItem other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SimpleItem) (object) (SimpleItem) obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Id;
        }
    }
}