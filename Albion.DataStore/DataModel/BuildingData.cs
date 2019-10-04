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

            TaxDatas = new TaxData[n];

            for (var i = 0; i < n; i++) TaxDatas[i] = new TaxData();
        }

        public string Id { get; set; }
        public TaxData[] TaxDatas { get; set; }
    }
}