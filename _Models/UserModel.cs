using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class UsersModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("loginName")]
        public string LoginName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("mobile")]
        public string Mobile { get; set; }

        [BsonElement("status")]
        public int? status { get; set; }

        [BsonElement("message")]
        public string? message { get; set; }

        [BsonElement("token")]
        public string? token { get; set; }

        [BsonElement("userAddress")]
        public UsersAddress UserAddress { get; set; }

        [BsonElement("companyID")]
        public string? CompanyID { get; set; }

        [BsonElement("ecbCode")]
        public string? EcbCode { get; set; }

        [BsonElement("stateCode")]
        public string StateCode { get; set; }

        [BsonElement("roleIDs")]
        public List<string> RoleIDs { get; set; }

        [BsonElement("useType")]
        public string UseType { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonElement("doj")]
        public string DateOfJoining { get; set; }

        [BsonElement("profilePicture")]
        public IFormFile? ProfilePicture { get; set; }

        [BsonElement("alerts")]
        public Alerts Alerts { get; set; }

        [BsonElement("isActive")]
        public bool? IsActive { get; set; } = true;

        [BsonElement("roleMenus")]
        public Dictionary<string, RolesMenuModel>? RoleMenus { get; set; }

        [BsonElement("oldPasswords")]
        public List<string>? OldPasswords { get; set; }

        [BsonElement("createdDate")]
        public string? createdDate { get; set; }

        [BsonElement("createdBy")]
        public string? CreatedBy { get; set; }

        [BsonElement("updatedAt")]
        public string? UpdatedAt { get; set; }

        [BsonElement("updatedBy")]
        public string? UpdatedBy { get; set; }
    }

    public class UsersAddress
    {
        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("zone")]
        public string Zone { get; set; }

        [BsonElement("pinCode")]
        public int PinCode { get; set; }

        [BsonElement("lane")]
        public string Lane { get; set; }

        [BsonElement("state")]
        public string State { get; set; }
    }

    public class Alerts
    {
        [BsonElement("SMS")]
        public bool SMS { get; set; }

        [BsonElement("MAIL")]
        public bool MAIL { get; set; }

        [BsonElement("notification")]
        public bool Notification { get; set; }
    }

    public class ReqAuthentication
    {
        public string loginName { get; set; }
        public string password { get; set; }
    }

    public class JWTModel
    {
        public int? status { get; set; }
        public string? message { get; set; }
        public string LogInName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string CompanyID { get; set; }
    }

    public class ResUser
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<UsersModel> data { get; set; }
    }
}
