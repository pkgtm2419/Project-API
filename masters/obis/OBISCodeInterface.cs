using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.obis
{
    public interface OBISCodeInterface
    {
        Task<ResOBISCodeList> GetOBISCodeAsync();
    }
}