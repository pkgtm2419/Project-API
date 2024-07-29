using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class CompanyModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("companyID")]
        public string CompanyID { get; set; }

        [BsonElement("companyName")]
        public string CompanyName { get; set; }

        [BsonElement("address")]
        public UserAddress Address { get; set; }

        [BsonElement("gstNo")]
        public string GstNo { get; set; }

        [BsonElement("DOI")]
        public DateTime DOI { get; set; }

        [BsonElement("contactNo")]
        public string ContactNo { get; set; }

        [BsonElement("emailID")]
        public string EmailID { get; set; }

        [BsonElement("companyType")]
        public string CompanyType { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }

        [BsonElement("__v")]
        public int __v { get; set; }
    }

    public class UserAddress
    {
        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("lane")]
        public string Lane { get; set; }

        [BsonElement("pinno")]
        public string Pinno { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }
    }

    public class ResCompany
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<CompanyModel> data { get; set; }
    }
}
