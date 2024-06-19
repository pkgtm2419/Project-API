using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.obis
{
    public interface IOBISCode
    {
        Task<ResOBISCodeList> GetOBISCodeAsync();
    }
}