using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.Role
{
    public class RoleServices : IRole
    {
        private readonly IMongoCollection<UserRoleModel> _roles;
        public RoleServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
        {
            _roles = database.GetCollection<UserRoleModel>(settings.Value.mst_role);
        }

        public async Task<ResRoleMenu> GetRole(string companyID)
        {
            ResRoleMenu res = new ResRoleMenu();
            try
            {
                FilterDefinition<UserRoleModel> filter = Builders<UserRoleModel>.Filter.Eq("companyID", companyID);
                List<UserRoleModel> data = await _roles.Find(filter).ToListAsync();
                if (data.Count > 0)
                {
                    res.Status = 200;
                    res.Data = data;
                    res.Message = "success";
                }
                else
                {
                    res.Status = 404;
                    res.Message = "no data found";
                }
            }
            catch (Exception ex)
            {
                res.Status = 500;
                res.Message = $"something went wrong: {ex.Message}";
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        public async Task<ResRoleMenu> GetById(string id)
        {
            ResRoleMenu res = new ResRoleMenu();
            try
            {
                FilterDefinition<UserRoleModel> filter = Builders<UserRoleModel>.Filter.Eq("id", id);
                List<UserRoleModel> data = await _roles.Find(filter).ToListAsync();
                if (data.Count > 0)
                {
                    res.Status = 200;
                    res.Data = data;
                    res.Message = "success";
                }
                else
                {
                    res.Status = 404;
                    res.Message = "no data found";
                }
            }
            catch (Exception ex)
            {
                res.Status = 500;
                res.Message = $"something went wrong: {ex.Message}";
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        public Task<ResRoleMenu> CreateRole(UserRoleModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResRoleMenu> DeleteRole(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResRoleMenu> UpdateRole(string id, UserRoleModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResRoleMenu> GetLogInUserRole(string useType, string code)
        {
            ResRoleMenu res = new ResRoleMenu();
            try
            {
                FilterDefinition<UserRoleModel> filter = Builders<UserRoleModel>.Filter.Eq("useType", useType) & Builders<UserRoleModel>.Filter.Eq("code", code);
                List<UserRoleModel> data = await _roles.Find(filter).ToListAsync();
                if (data.Count > 0)
                {
                    res.Status = 200;
                    res.Data = data;
                    res.Message = "success";
                }
                else
                {
                    res.Status = 404;
                    res.Message = "no data found";
                }
            }
            catch (Exception ex)
            {
                res.Status = 500;
                res.Message = $"something went wrong: {ex.Message}";
                Console.WriteLine(ex.Message);
            }
            return res;
        }
    }
}
