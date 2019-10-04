using System.Linq;
using Albion.Db.Xml;
using Albion.Db.Xml.Entity.Building;
using Albion.Db.Xml.Enums;
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
            Assert.AreEqual(348, db.Items.Count());

            var craft = db.Items.OfType<CraftBuilding>();
            Assert.AreEqual(135, craft.Count());
        }
    }
}