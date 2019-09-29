using System.IO;
using Newtonsoft.Json;

namespace Albion.Db.JsonLoader
{
    public class JsonNames
    {
        public static JsonNames[] LoadNames()
        {
            using (StreamReader file = File.OpenText(@"items_names.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                using (JsonReader reader = new JsonTextReader(file))
                {
                    JsonNames[] jsonDb = serializer.Deserialize<JsonNames[]>(reader);
                    return jsonDb;
                }
            }
        }

        public string UniqueName { get; set; }

        public LocalizedNames LocalizedNames { get; set; }
    }

    public class LocalizedNames
    {
        [JsonProperty("RU-RU")]
        public string RU { get; set; }
    }
}