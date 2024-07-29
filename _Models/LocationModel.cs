using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class LocationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("division")]
        public string Division { get; set; }

        [BsonElement("subDivision")]
        public string SubDivision { get; set; }

        [BsonElement("districtCode")]
        public string DistrictCode { get; set; }

        [BsonElement("stateCode")]
        public string StateCode { get; set; }

        [BsonElement("countryID")]
        public string CountryID { get; set; }

        [BsonElement("ecbCode")]
        public string EcbCode { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

    public class LocationMasterModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("marketCode")]
        public string MarketCode { get; set; }

        [BsonElement("stateCode")]
        public string StateCode { get; set; }

        [BsonElement("districtCode")]
        public string DistrictCode { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
