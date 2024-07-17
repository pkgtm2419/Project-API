using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ProjectAPI.SchemaModel;
using ProjectAPI._Helpers.Hashing;

namespace ProjectAPI.UserAuthentication
{
    public class AuthenticationServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings, IHashing IHashing) : IAuthentication
    {
        private readonly IMongoCollection<UsersModel> _users = database.GetCollection<UsersModel>(settings.Value.mst_user);

        public async Task<ResUser> GetAuthentication(string username, string password, string companyID)
        {
            ResUser res = new ResUser();
            try
            {
                FilterDefinition<UsersModel> filter = Builders<UsersModel>.Filter.Where(x => x.LoginName == username && x.IsActive == true && x.CompanyID == companyID);
                UsersModel data = await _users.Find(filter).FirstOrDefaultAsync();
                bool verify = IHashing.VerifyHash(data.Password, password);
                if (data != null)
                {
                    if(verify)
                    {
                        res.status = 200;
                        res.data = [data];
                        res.message = "success";
                    }
                    else
                    {
                        res.status = 404;
                        res.message = "Invalid username or password";
                    }
                }
                else
                {
                    res.status = 404;
                    res.message = "User not found";
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = $"something went wrong: {ex.Message}";
                Console.WriteLine($"Error: {ex.Message}");
            }
            return res;
        }

        public async Task<ResUser> CreateUser(UsersModel body)
        {
            ResUser res = new ResUser();
            try
            {
                body.Password = IHashing.HashValue(body.Password);
                await _users.InsertOneAsync(body);
                res.status = 200;
                res.data = new List<UsersModel> { body };
                res.message = "success";
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = $"something went wrong: {ex.Message}";
                Console.WriteLine($"Error: {ex.Message}");
            }
            return res;
        }
    }
}
