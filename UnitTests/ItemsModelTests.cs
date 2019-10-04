using System;
using System.Diagnostics;
using System.Linq;
using Albion.Db.Xml;
using Albion.Db.Xml.Enums;
using Albion.Model.Data;
using Albion.Model.Items;
using Albion.Model.Items.Categories;
using Albion.Model.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class ItemsModelTests
    {
        [TestMethod]
        public void TestUpdatePrice()
        {
            var mmdm = new Mock<IMarketDataManager>();
            mmdm.Setup(x => x.GetData(It.IsAny<string>())).Returns(() => new ItemMarket());
            var bdm = Mock.Of<IBuildingDataManager>(x=>x.GetData(It.IsAny<string>()) == new ItemBuilding());
           
            var loader = new XmlLoader(mmdm.Object, bdm);
            var model = loader.LoadModel();

            var all = loader.Items;

            int fired = 0;
            all["T4_OFF_SHIELD"].UpdateCost += () =>
            {
                Assert.AreEqual(40000, all["T4_OFF_SHIELD"].Cost);
                fired++;
            };

            Assert.AreEqual(0, all["T4_OFF_SHIELD"].Cost);

            all["T4_PLANKS"].ItemMarket.SellPrice = 10000;
            Assert.AreEqual(1, fired);
            Assert.AreEqual(40000, all["T4_OFF_SHIELD"].Cost);
        }

        [TestMethod]
        public void TestMethodModel()
        {
            var mdm = Mock.Of<IMarketDataManager>(x => x.GetData(It.IsAny<string>()) == new ItemMarket());
            var bdm = Mock.Of<IBuildingDataManager>(x => x.GetData(It.IsAny<string>()) == new ItemBuilding());

            var loader = new XmlLoader(mdm, bdm);
            var model = loader.LoadModel();

            Assert.IsNotNull(model);

            
            var list = loader.Items.Values;

            Assert.AreEqual(6282, list.Count);

            Assert.AreEqual(405, list.Count(x => x.ShopCategory == ShopCategory.Artefacts));
            Assert.AreEqual(252, list.Count(x => x.ShopCategory == ShopCategory.Offhand));
            Assert.AreEqual(15, list.Count(x => x.ShopSubCategory == ShopSubCategory.Seed));
            Assert.AreEqual(72, list.Count(x => x.ShopSubCategory == ShopSubCategory.Animals));
            Assert.AreEqual(6, list.Count(x => x.ShopSubCategory == ShopSubCategory.Event));
        }


        [TestMethod]
        public void TestMethodXml()
        {
            var db = XmlLoader.LoadItemsXml();
            Assert.IsNotNull(db);
            Assert.AreEqual(405, db.Items.Cast<IItem>().Count(x => x.shopcategory == shopCategory.artefacts));
            Assert.AreEqual(72, db.Items.Cast<IItem>().Count(x => x.shopcategory == shopCategory.offhand));
            Assert.AreEqual(15, db.Items.Cast<IItem>().Count(x => x.shopsubcategory1 == shopSubCategory.seed));
            Assert.AreEqual(72, db.Items.Cast<IItem>().Count(x => x.shopsubcategory1 == shopSubCategory.animals));
            Assert.AreEqual(6, db.Items.Cast<IItem>().Count(x => x.shopsubcategory1 == shopSubCategory.@event));

            var items = db.Items.Where(x => !(x is IItem)).ToArray();

            Assert.IsNotNull(items);
            Assert.AreEqual(0, items.Length);

            Assert.AreEqual(3097, db.Items.Length);



//            Assert.IsTrue(db.Items.Cast<IItem>().Where(x=>x.craftingcategory!= "farmabal??").All(x=>x.craftingrequirements.Length > 0));

            var enums = db.Items.OfType<IItemCraftingcategory>()
                //.Where(x => x.shopcategory==ShopCategory.melee)
                .Where(x => x.tier.ToString()!=x.uniquename.Substring(1,1))
                .Select(x => Tuple.Create(x.shopcategory, x.shopsubcategory1, x.craftingcategory, x.uniquename, x.craftingrequirements?.Length))
                .Distinct()
                .OrderBy(x => x.Item1)
                .ThenBy(x=>x.Item2)
                .ThenBy(x=>x.Item3);

            foreach (var value in enums) Debug.WriteLine($"{value},");
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