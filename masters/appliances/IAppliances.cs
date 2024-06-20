using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.appliances
{
    public interface IAppliances
    {
        Task<ResAppliances> GetAppliances();
    }
}
