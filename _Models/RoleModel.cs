using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class RolesMenuModel
    {
        [BsonElement("link")]
        public bool? Link { get; set; }

        [BsonElement("level")]
        public string? Level { get; set; }

        [BsonElement("linkPath")]
        public string? LinkPath { get; set; }

        [BsonElement("add")]
        public bool? Add { get; set; }

        [BsonElement("edit")]
        public bool? Edit { get; set; }

        [BsonElement("delete")]
        public bool? Delete { get; set; }
    }

    public class UserRoleModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("useType")]
        public string UseType { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("companyID")]
        public string CompanyID { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("roleMenus")]
        public Dictionary<string, RolesMenuModel> RoleMenus { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("createdDate")]
        public string CreatedDate { get; set; }

        [BsonElement("updatedBy")]
        public string? UpdatedBy { get; set; }

        [BsonElement("updatedDate")]
        public string? UpdatedDate { get; set; }
    }

    public class ResRoleMenu
    {
        [BsonElement("status")]
        public int Status { get; set; }

        [BsonElement("data")]
        public List<UserRoleModel>? Data { get; set; }

        [BsonElement("message")]
        public string Message { get; set; }
    }
}
