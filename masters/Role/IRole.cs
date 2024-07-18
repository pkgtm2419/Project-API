using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.Role
{
    public interface IRole
    {
        Task<ResRoleMenu> GetRole();
        Task<ResRoleMenu> GetLogInUserRole(string useType, string code);
        Task<ResRoleMenu> GetById(string id);
        Task<ResRoleMenu> CreateRole(UserRoleModel model);
        Task<ResRoleMenu> UpdateRole(string id, UserRoleModel model);
        Task<ResRoleMenu> DeleteRole(string id);
    }
}
