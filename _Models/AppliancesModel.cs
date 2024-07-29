using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinDLMSClientApp._Models
{
    public class AppliancesModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("capacity")]
        public int Capacity { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }
    }

    public class ResAppliances
    {
        public int status { get; set; }
        public List<AppliancesModel> data { get; set; }
        public string message { get; set; }
    }
}
