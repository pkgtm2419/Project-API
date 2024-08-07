using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WinDLMSClientApp._Helpers.Hashing;
using WinDLMSClientApp._Helpers.JWT;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Users
{
    public class UsersServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings, IHashing IHashing) : IUsers
    {
        private readonly IMongoCollection<UsersModel> _Users = database.GetCollection<UsersModel>(settings.Value.mst_user);

        public async Task<ResUser> AddUserAsync(UsersModel body)
        {
            ResUser res = new ResUser();
            try
            {
                body.Password = IHashing.HashValue(body.Password);
                await _Users.InsertOneAsync(body);
                res.status = 200;
                res.data = new List<UsersModel> { body };
                res.message = "success";
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = ex.Message;
            }
            return res;
        }

        public async Task<ResUser> GetUserAsync()
        {
            ResUser res = new ResUser();
            try
            {
                FilterDefinition<UsersModel> filter = Builders<UsersModel>.Filter.Empty;
                List<UsersModel> data = await _Users.Find(filter).ToListAsync();
                if (data.Count > 0)
                {
                    res.status = 200;
                    res.data = data;
                    res.message = "success";
                }
                else
                {
                    res.status = 404;
                    res.message = "no data found";
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
