using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ProjectAPI.SchemaModel;
using ProjectAPI._Helpers.Hashing;
using ProjectAPI._Helpers.JWT;
using Microsoft.AspNetCore.Hosting;
using ProjectAPI.masters.Role;

namespace ProjectAPI.UserAuthentication
{
    public class AuthenticationServices(
        IMongoDatabase database, 
        IOptions<MongoDBSettingsModel> settings, 
        IHashing IHashing, 
        IJwt jwt, 
        IWebHostEnvironment _webHostEnvironment,
        IRole _Role
    ) : IAuthentication
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
                        JWTModel jwtModel = new JWTModel()
                        {
                            LogInName = data.LoginName,
                            Email = data.Email,
                            Role = data.Role,
                            CompanyID = data.CompanyID
                        };
                        var roleData = await _Role.GetLogInUserRole(data.UseType, data.Role);
                        if(roleData.Status == 200)
                        {
                            data.RoleMenus = roleData.Data;
                        } 
                        else
                        {
                            throw new Exception(roleData.Message);
                        }
                        res.token = jwt.GenerateToken(jwtModel);
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
                if (body.ProfilePicture == null || !body.ProfilePicture.ContentType.StartsWith("image/"))
                {
                    res.status = 400;
                    res.message = "Invalid profile picture format. Please upload an image file.";
                    return res;
                }
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(body.ProfilePicture.FileName);
                string uploadPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadFiles", fileName);
                body.Password = IHashing.HashValue(body.Password);
                await using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await body.ProfilePicture.CopyToAsync(stream);
                }

                await _users.InsertOneAsync(body);
                res.status = 200;
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
