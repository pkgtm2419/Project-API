using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Roles
{
    public interface IRoles
    {
        Task<ResRoleMenu> GetRole(string companyID);
        Task<ResRoleMenu> GetById(string id);
        Task<ResRoleMenu> GetLogInUserRole(string useType, string code);
    }
}
