using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ProjectAPI.SchemaModel
{
    public class UsersModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("isActive")]
        public string IsActive { get; set; }

        [BsonElement("loginName")]
        public string LoginName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("companyID")]
        public string CompanyID { get; set; }

        [BsonElement("roleIDs")]
        public List<string> RoleIDs { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("useType")]
        public string UseType { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonElement("alerts")]
        public Alerts Alerts { get; set; }

        [BsonElement("mobile")]
        public string Mobile { get; set; }

        [BsonElement("updatedBy")]
        public string UpdatedBy { get; set; }
    }

    public class UsersAddress
    {
        [BsonElement("address")]
        public string Addr { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("zone")]
        public string Zone { get; set; }

        [BsonElement("subzone")]
        public string Subzone { get; set; }

        [BsonElement("pinCode")]
        public string PinCode { get; set; }

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
}
