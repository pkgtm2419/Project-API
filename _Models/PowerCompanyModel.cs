using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class PowerCompanyModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("countryCode")]
        public string CountryCode { get; set; }

        [BsonElement("stateCode")]
        public string StateCode { get; set; }

        [BsonElement("districtCode")]
        public List<string> DistrictCode { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("pinCode")]
        public int PinCode { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

}
