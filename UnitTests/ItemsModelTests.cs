﻿using System.Diagnostics;
using System.Linq;
using Albion.Db.Xml;
using Albion.Db.Xml.Entity.Item;
using Albion.Db.Xml.Enums;
using Albion.Model.Data;
using Albion.Model.Items.Categories;
using Albion.Model.Items.Requirements;
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
            var bdm = Mock.Of<IBuildingDataManager>(x => x.GetData(It.IsAny<string>()) == new ItemBuilding());
            var tm = Mock.Of<ITownManager>();

            var loader = new XmlLoader(bdm, tm, tm, tm);
            var model = loader.LoadModel();

            var all = loader.Items;

            var fired = 0;
            all["T4_OFF_SHIELD"].CostUpdate += () =>
            {
                Assert.AreEqual(80000, all["T4_OFF_SHIELD"].Cost);
                fired++;
            };

            Assert.AreEqual(0, all["T4_OFF_SHIELD"].Cost);

            all["T4_PLANKS"].CraftingBuilding.Tax = 0;
            Assert.AreEqual(1, fired);
            Assert.AreEqual(80000, all["T4_OFF_SHIELD"].Cost);
        }

        [TestMethod]
        public void TestModel()
        {
            var bdm = Mock.Of<IBuildingDataManager>(x => x.GetData(It.IsAny<string>()) == new ItemBuilding());
            var tm = Mock.Of<ITownManager>();

            var loader = new XmlLoader(bdm, tm, tm, tm);
            var model = loader.LoadModel();

            Assert.IsNotNull(model);


            var list = loader.Items.Values;

            //            foreach (var n in list.Where(x => x.IsCraftable))
            //                Debug.WriteLine("\"{0}\" {1}, {2}", n.Id,
            //                    (n.CraftingRequirements.FirstOrDefault() as CraftingRequirement)?.Silver,
            //                    n.CraftingRequirements.FirstOrDefault()?.Resources.Length);

            foreach (var item in list
                .Where(x =>
                    x.ShopCategory == ShopCategory.Artefacts
                )
            )
            foreach (var requirement in item.Components.OfType<CraftingRequirement>())
            foreach (var cr in requirement.Resources)
            {
                Debug.WriteLine($"{item} {item.FullName} {item.ItemValue} <- {cr.Item} x {cr.Count} {cr.Item.ShopCategory} {cr.Item.ItemValue}");
                //Assert.Fail($"{item} {item.FullName} <- {cr.Item} {cr.Item.ShopCategory} {cr.Item.ShopSubCategory}");
            }

            Assert.AreEqual(6286, list.Count);

            Assert.AreEqual(405, list.Count(x => x.ShopCategory == ShopCategory.Artefacts));
            Assert.AreEqual(252, list.Count(x => x.ShopCategory == ShopCategory.Offhand));
            Assert.AreEqual(15, list.Count(x => x.ShopSubCategory == ShopSubCategory.Seed));
            Assert.AreEqual(72, list.Count(x => x.ShopSubCategory == ShopSubCategory.Animals));
            Assert.AreEqual(6, list.Count(x => x.ShopSubCategory == ShopSubCategory.Event));

            Assert.IsTrue(list.All(x => x.Enchant > 0 && x.Id.EndsWith($"@{x.Enchant}") || x.Enchant == 0));


//            foreach (var item in list
//                .Where(x => x.CraftingRequirements.Length>0 && x.CraftingRequirements[0].Resources.Length>0  && x.ItemValue != x.CraftingRequirements[0].Resources.Sum(r=>r.Item.ItemValue * r.Count)).GroupBy(i => i.ShopSubCategory)
//            )
//            {
//                Debug.WriteLine($"{item.Key} {item.Count()}");
//            }
//
//            foreach (var item in list
//                .Where(x => x.ShopSubCategory == ShopSubCategory.Royalsigils)
//            )
//            {
//                var iv = item.CraftingRequirements.Length>0 ? item.CraftingRequirements[0].Resources.Sum(r => r.Item.ItemValue * r.Count) : -1;
//                Debug.WriteLine($"{item}\t{item.FullName}\t{item.ItemValue} != {iv}");
//            }

//            foreach (var item in list) Debug.WriteLine($"{item}\t{item.FullName}\t{item.ItemValue}");

            //            Assert.IsTrue(list
            //                .Where(x=>
            //                    x.ShopCategory==ShopCategory.Armor
            //                          || x.ShopCategory == ShopCategory.Magic
            //                          || x.ShopCategory == ShopCategory.Melee
            //                          || x.ShopCategory == ShopCategory.Ranged
            //                    )
            //                .All(x=>x.Enchant > 0 && x.CraftingRequirements.All(c=>c.Resources.All(cr=>cr.Item.Enchant==x.Enchant))));
        }


        [TestMethod]
        public void TestReadXml()
        {
            var db = XmlLoader.LoadItemsXml();
            Assert.IsNotNull(db);
            Assert.AreEqual(405, db.Items.Cast<IItem>().Count(x => x.shopcategory == shopCategory.artefacts));
            Assert.AreEqual(72, db.Items.Cast<IItem>().Count(x => x.shopcategory == shopCategory.offhand));
            Assert.AreEqual(15, db.Items.Cast<IItem>().Count(x => x.shopsubcategory1 == shopSubCategory.seed));
            Assert.AreEqual(72, db.Items.Cast<IItem>().Count(x => x.shopsubcategory1 == shopSubCategory.animals));
            //Assert.AreEqual(6, db.Items.Cast<IItem>().Count(x => x.shopsubcategory1 == shopSubCategory.@event));

            var items = db.Items.Where(x => !(x is IItem)).ToArray();

            Assert.IsNotNull(items);
            Assert.AreEqual(0, items.Length);

            Assert.AreEqual(3106, db.Items.Length);

            //            Assert.IsTrue(db.Items.Cast<IItem>().Where(x=>x.craftingcategory!= "farmabal??").All(x=>x.craftingrequirements.Length > 0));

            var enums = db.Items.OfType<IItemCraftingcategory>()
                //.Where(x => x.shopcategory==ShopCategory.melee)
                .Where(x => x.shopcategory == shopCategory.resources)
                .OfType<SimpleItem>();
//                .Select(x => Tuple.Create(x.shopcategory, x.shopsubcategory1, x.craftingcategory, x.uniquename))
//                .Distinct()
//                .OrderBy(x => x.Item1)
//                .ThenBy(x=>x.Item2)
//                .ThenBy(x=>x.Item3);
//
            foreach (var value in enums) Debug.WriteLine($"{value.uniquename},");
        }
    }
}