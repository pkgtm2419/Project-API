using ProjectAPI.SchemaModel;
using System.ComponentModel.Design;

namespace ProjectAPI.masters.Role
{
    public interface IRole
    {
        Task<ResRoleMenu> GetRole(string companyID);
        Task<ResRoleMenu> GetLogInUserRole(string useType, string code);
        Task<ResRoleMenu> GetById(string id);
        Task<ResRoleMenu> CreateRole(UserRoleModel model);
        Task<ResRoleMenu> UpdateRole(string id, UserRoleModel model);
        Task<ResRoleMenu> DeleteRole(string id);
    }
}
