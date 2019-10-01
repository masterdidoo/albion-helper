using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Albion.ItemsDb
{
    public class XmlLoader
    {
        public static items Load()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Albion.ItemsDb.items.xml");
            if (stream == null) return null;
            using (TextReader tr = new StreamReader(stream))
            {
                var xml = new XmlSerializer(typeof(items));
                var items = (items) xml.Deserialize(tr);

                return items;
            }
        }
    }
}