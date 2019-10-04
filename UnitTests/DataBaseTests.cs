using System.Linq;
using Albion.DataStore.Db;
using Albion.DataStore.Managers;
using Albion.Db.Xml;
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
                var mdm = new MarketDataManager();
                var bdm = new BuildingDataManager();

                var loader = new XmlLoader(mdm, bdm);
                loader.LoadModel();

                var buildings = loader.CraftBuildings;
                var all = loader.Items;

                _exp = 40000;
                var fired = 0;
                all["T4_OFF_SHIELD"].UpdateCost += () =>
                {
                    Assert.AreEqual(_exp, all["T4_OFF_SHIELD"].Cost);
                    fired++;
                };

                Assert.AreEqual(0, all["T4_OFF_SHIELD"].Cost);

                all["T4_PLANKS"].ItemMarket.SellPrice = 10000;
                Assert.AreEqual(1, fired);
                Assert.AreEqual(40000, all["T4_OFF_SHIELD"].Cost);

                _exp = 3540000;

                buildings["T8_FORGE"].ItemBuilding.Tax = 10;

//                all["T4_OFF_SHIELD"].Building.Tax= 10;
                Assert.AreEqual(2, fired);
                Assert.AreEqual(3540000, all["T4_OFF_SHIELD"].Cost);
            }
            {
                var mdm = new MarketDataManager();
                var bdm = new BuildingDataManager();

                var loader = new XmlLoader(mdm, bdm);
                var model = loader.LoadModel();

                var all = loader.Items;

                Assert.AreEqual(40000, all["T4_OFF_SHIELD"].Cost);
            }
        }
    }
}