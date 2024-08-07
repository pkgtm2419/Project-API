using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Users
{
    public interface IAuthentication
    {
        Task<UsersModel> GetAuthentication(string username, string password, string company);
    }
}
