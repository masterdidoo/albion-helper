using System;
using System.Linq;
using Albion.ItemsDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodXml()
        {
            var db = XmlLoader.Load();
            Assert.IsNotNull(db);
            Assert.AreEqual(405, db.Items.OfType<itemsSimpleitem>().Count(x => x.shopcategory== "artefacts"));

            var items = db.Items.Where(x=>!(x is IItem)).ToArray();
            //var items = db.Items.OfType<IItem>().Select(x=>x.craftingcategory).Distinct().ToList();

            Assert.IsNotNull(items);
            Assert.AreEqual(0, items.Length);
        }


//        [TestMethod]
//        public void TestMethod1()
//        {
//            var db = JsonDb.Load();
//            var dbnames = JsonNames.LoadNames();
//
//            Assert.IsNotNull(db);
//
//            var artefacts =  db.Items.Simpleitem.Where(x => x.Shopcategory == ShopCategory.Artefacts);
//
//            Assert.AreEqual(405, artefacts.Count());
//
////            var all = new All(db, dbnames);
////
////            Assert.AreEqual(79, all.FarmableItem.Length);
////            Assert.AreEqual(405, all.Artefacts.Length);
//        }
    }
}
