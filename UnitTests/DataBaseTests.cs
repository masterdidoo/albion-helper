using System.Linq;
using Albion.DataStore.Db;
using Albion.DataStore.Managers;
using Albion.Db.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DataBaseTests
    {
        [TestMethod]
        public void TestUpdatePrice()
        {
            {
                DataBase.Drop();
                var mdm = new MarketDataManager();
                var bdm = new BuildingDataManager();

                var loader = new XmlLoader(mdm, bdm);
                var model = loader.LoadModel();

                var all = model.ToDictionary(k => k.Id);

                var fired = 0;
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
            {
                var mdm = new MarketDataManager();
                var bdm = new BuildingDataManager();

                var loader = new XmlLoader(mdm, bdm);
                var model = loader.LoadModel();

                var all = model.ToDictionary(k => k.Id);

                Assert.AreEqual(40000, all["T4_OFF_SHIELD"].Cost);
            }
        }
    }
}