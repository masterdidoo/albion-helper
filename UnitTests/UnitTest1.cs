using System;
using System.Linq;
using Albion.Db.Items;
using Albion.Db.JsonLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = JsonDb.Load();

            Assert.IsNotNull(db);

            var artefacts =  db.Items.Simpleitem.Where(x => x.Shopcategory == ShopCategory.Artefacts);

            Assert.AreEqual(405, artefacts.Count());

            var all = new All(db);

            Assert.AreEqual(79, all.FarmableItem.Length);
            Assert.AreEqual(405, all.Artefacts.Length);
        }
    }
}
