using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.UserAuthentication
{
    public class AuthenticationServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : IAuthentication
    {
        private readonly IMongoCollection<UsersModel> _users = database.GetCollection<UsersModel>(settings.Value.mst_user);

        public async Task<ResUser> GetAuthentication(string username, string password)
        {
            ResUser res = new ResUser();
            try
            {
                FilterDefinition<UsersModel> filter = Builders<UsersModel>.Filter.Where(x => x.LoginName == username && x.Password == password && x.IsActive == true); //"$2a$10$8Dgt6I7KkB3MoIeLwcyPcuJuUeJkPhSnVKbpXpi3Bhyo.PnsOBQD6",
                //FilterDefinition<UsersModel> filter = Builders<UsersModel>.Filter.Where(x => x.LoginName == username && x.IsActive == true);
                var projection = Builders<UsersModel>.Projection.Exclude(u => u.Password);
                UsersModel data = await _users.Find(filter).Project<UsersModel>(projection).FirstOrDefaultAsync();

                if (data != null)
                {
                    res.status = 200;
                    res.data = new List<UsersModel> { data };
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
                res.message = $"something went wrong: {ex.Message}";
                Console.WriteLine($"Error: {ex.Message}");
            }
            return res;
        }
    }
}
