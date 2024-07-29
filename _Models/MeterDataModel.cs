using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class MeterDataModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("meterFormateddata")]
        public List<MeterFormattedData> MeterFormattedData { get; set; }

        [BsonElement("BillingData")]
        public List<object> BillingData { get; set; }

        [BsonElement("meterID")]
        public string MeterID { get; set; }

        [BsonElement("meterPublishTime")]
        public string MeterPublishTime { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("deviceID")]
        public string DeviceID { get; set; }
        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("YOM")]
        public string YOM { get; set; }

        [BsonElement("Association")]
        public string Association { get; set; }

        [BsonElement("companyID")]
        public string CompanyID { get; set; }

        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }
    }

    public class MeterFormattedData
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("OBISCode")]
        public string OBISCode { get; set; }

        [BsonElement("paramValue")]
        public Dictionary<string, string> ParamValue { get; set; }
    }

    public class ResMeterData
    {
        public int status { get; set; }
        public List<MeterDataModel> data { get; set; }
        public string message { get; set; }
    }
}
