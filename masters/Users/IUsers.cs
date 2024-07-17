using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.Users
{
    public interface IUsers
    {
        Task<ResUser> GetUserAsync();
    }
}
