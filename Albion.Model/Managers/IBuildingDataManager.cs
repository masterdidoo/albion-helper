using Albion.Model.Data;

namespace Albion.Model.Managers
{
    public interface IBuildingDataManager
    {
        ItemBuilding GetData(string id);
    }
}