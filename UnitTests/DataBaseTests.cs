using System.Linq;
using Albion.DataStore.Db;
using Albion.DataStore.Managers;
using Albion.Db.Xml;
using Albion.Model.Managers;
using Castle.DynamicProxy.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DataBaseTests
    {
        private long _exp;

        [TestMethod]
        public void TestUpdatePrice()
        {
            {
                DataBase.Drop();
                var tm = new TownManager();

                var mdm = new MarketDataManager();
                var bdm = new BuildingDataManager(tm);

                var loader = new XmlLoader(mdm, bdm, tm, tm, tm);
                loader.LoadModel();

                var buildings = loader.CraftBuildings;
                var all = loader.Items;

                Assert.AreEqual(10, buildings["T8_FORGE"].Tax);
                buildings["T8_FORGE"].Tax = 0;

                _exp = 80000;
                var fired = 0;
//                all["T4_OFF_SHIELD"].UpdateCost += () =>
//                {
//                    Assert.AreEqual(_exp, all["T4_OFF_SHIELD"].Cost);
//                    fired++;
//                };

                Assert.AreEqual(0, all["T4_OFF_SHIELD"].Cost);

                all["T4_PLANKS"].ItemMarket.FromMarketItems[0].BestPrice = 10000;
                all["T4_METALBAR"].ItemMarket.FromMarketItems[0].BestPrice = 10000;
                Assert.AreEqual(1, fired);
                Assert.AreEqual(80000, all["T4_OFF_SHIELD"].Cost);

                _exp = 3580000;

                buildings["T8_FORGE"].Tax = 10;

//                all["T4_OFF_SHIELD"].Building.Tax= 10;
                Assert.AreEqual(2, fired);
                Assert.AreEqual(3580000, all["T4_OFF_SHIELD"].Cost);
            }
            {
                var tm = new TownManager();

                var mdm = new MarketDataManager();
                var bdm = new BuildingDataManager(tm);

                var loader = new XmlLoader(mdm, bdm, tm, tm, tm);
                var model = loader.LoadModel();

                var all = loader.Items;

                Assert.AreEqual(3580000, all["T4_OFF_SHIELD"].Cost);
            }
        }
    }
}