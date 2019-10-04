using System.Linq;
using Albion.Db.Xml;
using Albion.Db.Xml.Entity.Building;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BuildingsModelTests
    {
        [TestMethod]
        public void TestXmlLoad()
        {
            var db = XmlLoader.LoadBuildingsXml();
            Assert.IsNotNull(db);
            Assert.AreEqual(348, db.Items.Length);

            var craft = db.Items.OfType<craftBuilding>();
            Assert.AreEqual(135, craft.Count());

            var buildings = craft.Where(x=>x.tier==8 && x.favoritedish!=null && x.craftingitemlist != null && x.craftingitemlist[0].craftitem != null).ToArray();
            Assert.AreEqual(13, buildings.Length);

//            Assert.AreEqual(8, craft.Select(x=>x.tier).Distinct().Count());
        }
    }
}