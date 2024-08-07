using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WinDLMSClientApp._Helpers.Hashing;
using WinDLMSClientApp._Helpers.JWT;
using WinDLMSClientApp._Models;
using WinDLMSClientApp.Masters.Roles;

namespace WinDLMSClientApp.Users
{
    public class AuthenticationServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings, IHashing IHashing, IJWT jwt, IRoles _Roles) : IAuthentication
    {
        private readonly IMongoCollection<UsersModel> _users = database.GetCollection<UsersModel>(settings.Value.mst_user);

        public async Task<UsersModel> GetAuthentication(string username, string password, string companyID)
        {
            UsersModel res = new UsersModel();
            try
            {
                FilterDefinition<UsersModel> filter = Builders<UsersModel>.Filter.Where(x => x.LoginName == username && x.IsActive == true && x.CompanyID == companyID);
                UsersModel data = await _users.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                {
                    bool verify = IHashing.VerifyHash(data.Password, password);
                    if (verify)
                    {
                        JWTModel jwtModel = new JWTModel()
                        {
                            LogInName = data.LoginName,
                            Email = data.Email,
                            Role = data.Role,
                            CompanyID = data.CompanyID
                        };
                        res = data;
                        var roleData = await _Roles.GetLogInUserRole(data.UseType, data.Role);
                        if (roleData.Status == 200)
                        {
                            data.RoleMenus = roleData.Data[0].RoleMenus;
                        }
                        else
                        {
                            res.status = 404;
                            res.message = "User Role is not defined";
                            return res;
                        }
                        res.token = jwt.GenerateToken(jwtModel);
                        res.status = 200;
                        res.message = "success";
                        res.Password = null;
                        return res;
                    }
                    else
                    {
                        res.status = 404;
                        res.message = "Invalid username or password";
                        return res;
                    }
                }
                else
                {
                    res.status = 404;
                    res.message = "User not found";
                    return res;
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = $"something went wrong: {ex.Message}";
                Console.WriteLine(ex);
                return res;
            }
        }
    }
}
