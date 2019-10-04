using System.IO;
using LiteDB;

namespace Albion.DataStore.Db
{
    public class DataBase
    {
        private DataBase()
        {
            LiteDatabase = new LiteDB.LiteDatabase("main.db");
        }

        internal readonly LiteDatabase LiteDatabase;
        public static DataBase Instance { get; } = new DataBase();

        public LiteCollection<T> GetCollection<T>()
        {
            return LiteDatabase.GetCollection<T>();
        }

        public static void Drop()
        {
            File.Delete("main.db");
        }
    }
}