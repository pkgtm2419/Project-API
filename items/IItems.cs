using ProjectAPI.SchemaModel;

namespace ProjectAPI.items
{
    public interface IItems
    {
        Task<ResItems> GetItems();
    }
}
