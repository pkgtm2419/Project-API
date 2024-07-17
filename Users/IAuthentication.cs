using ProjectAPI.SchemaModel;

namespace ProjectAPI.UserAuthentication
{
    public interface IAuthentication
    {
        Task<ResUser> GetAuthentication(string username, string password);
    }
}
