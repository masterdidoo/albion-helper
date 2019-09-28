using System;
using Albion.Common;
using LiteDB;

namespace Albion.Db.Items
{
    public class PlayerContext : IPlayerContext
    {
        private LiteDatabase _ldb;
        private LiteCollection<PricesContainer> _rep;
        private Location _town = Location.None;

        public PlayerContext()
        {
            _ldb = new LiteDatabase("main.db");
            _rep = _ldb.GetCollection<PricesContainer>();
        }

        public int TownIndex => (int) Town;

        public Location Town
        {
            get => _town;
            set
            {
                if (_town == value) return;
                _town = value;
                TownIndexChanged?.Invoke();
            }
        }

        public long GetCraftTax(ShopCategory shopCategory)
        {
            return 10;
        }

        public event Action TownIndexChanged;

        public void SavePricesContainer(string id, PricesContainer pricesContainer)
        {
            _rep.Upsert(id, pricesContainer);
        }

        public PricesContainer LoadPricesContainer(string id)
        {
            return _rep.FindById(id);
        }

        public long GetReturn(Craftingcategory category)
        {
            switch (category)
            {
                case Craftingcategory.Fiber:
                    if (Town == Location.Lymhurst) return 153;
                    if (Town <= Location.Caerleon) return 117;
                    break;
                case Craftingcategory.Hide:
                    if (Town == Location.Martlock) return 153;
                    if (Town <= Location.Caerleon) return 117;
                    break;
                case Craftingcategory.Ore:
                    if (Town == Location.Thetford) return 153;
                    if (Town <= Location.Caerleon) return 117;
                    break;
                case Craftingcategory.Rock:
                    if (Town == Location.Bridgewatch) return 153;
                    if (Town <= Location.Caerleon) return 117;
                    break;
                case Craftingcategory.Wood:
                    if (Town == Location.FortSterling) return 153;
                    if (Town <= Location.Caerleon) return 117;
                    break;
                default:
                    return 100;
            }

            return 100;
        }
    }
}