using System.Linq;
using Albion.Db.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LocalizationTests
    {
        [TestMethod]
        public void TestXmlLoad()
        {
            var tu = XmlLoader.LoadLocalizationXml();

            Assert.AreEqual(6671, tu.Count());
        }
    }
}