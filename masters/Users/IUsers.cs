using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Users
{
    public interface IUsers
    {
        Task<ResUser> GetUserAsync();
        Task<ResUser> AddUserAsync(UsersModel body);
    }
}
