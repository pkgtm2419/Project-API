using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.item
{
    public interface IItem
    {
        Task<ResItems> GetItemsAsync();
    }
}
