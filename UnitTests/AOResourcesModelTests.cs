using System.Linq;
using Albion.Db.Xml;
using Albion.Db.Xml.Entity.Building;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class AoResourcesModelTests
    {
        [TestMethod]
        public void TestXmlLoad()
        {
            var db = XmlLoader.LoadResourcesXml();
            Assert.IsNotNull(db);
            Assert.AreEqual(35, db.Length);

//            var res = db.First();
//            Assert.AreEqual(135, res.Resource);

//            var buildings = res.Where(x=>x.tier==8 && x.favoritedish!=null && x.craftingitemlist != null && x.craftingitemlist[0].craftitem != null).ToArray();
//            Assert.AreEqual(13, buildings.Length);

//            Assert.AreEqual(8, craft.Select(x=>x.tier).Distinct().Count());
        }
    }
}