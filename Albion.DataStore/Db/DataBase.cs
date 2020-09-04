using System.IO;
using System.Linq;
using LiteDB;

namespace Albion.DataStore.Db
{
    public class DataBase
    {
        private DataBase()
        {
            LiteDatabase = new LiteDB.LiteDatabase("main2v.db");
        }

        internal readonly LiteDatabase LiteDatabase;
        public static DataBase Instance { get; } = new DataBase();

        public LiteCollection<T> GetCollection<T>()
        {
            return LiteDatabase.GetCollection<T>();
        }

        public static void Close()
        {
//            var x = Instance.LiteDatabase.GetCollection("OrdersData").Find(Query.EQ("ItemId", "T4_2H_FIRESTAF_HELL@3")).ToArray();
//            var x2 = Instance.LiteDatabase.GetCollection("OrdersData").Delete(Query.EQ("ItemId", "T4_2H_FIRESTAF_HELL@3"));
            Instance.LiteDatabase.Shrink();
            Instance.LiteDatabase.Dispose();
        }

        public static void Drop()
        {
            File.Delete("main2v.db");
        }
    }
}