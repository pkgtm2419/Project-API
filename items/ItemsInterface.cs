using ProjectAPI.SchemaModel;

namespace ProjectAPI.items
{
    public interface ItemsInterface
    {
        Task<ResItems> GetItems();
    }
}
