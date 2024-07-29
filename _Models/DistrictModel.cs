using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class DistrictModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("stateCode")]
        public string StateCode { get; set; }

        [BsonElement("countryID")]
        public string CountryID { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
