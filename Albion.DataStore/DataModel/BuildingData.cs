using Albion.Common;

namespace Albion.DataStore.DataModel
{
    public class BuildingData
    {
        public BuildingData()
        {
        }

        public BuildingData(string id)
        {
            Id = id;

            const int n = (int) Location.None + 1;

            TaxDatas = new int[n];
        }

        public string Id { get; set; }
        public int[] TaxDatas { get; set; }
    }
}