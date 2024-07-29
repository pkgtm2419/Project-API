using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class NotificationsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("deviceID")]
        public string DeviceID { get; set; }

        [BsonElement("custID")]
        public string CustID { get; set; }

        [BsonElement("loginName")]
        public string LoginName { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("circle")]
        public string Circle { get; set; }

        [BsonElement("ecb")]
        public string Ecb { get; set; }

        [BsonElement("source")]
        public string Source { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("message")]
        public string Message { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
