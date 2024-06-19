using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectAPI.SchemaModel
{
    public class OBISCodeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string obisCode { get; set; }
        public string? name { get; set; }
        public string? displayName { get; set; }
        public string? unit { get; set; }
        public int? interfaceClass { get; set; }
        public int? ICVersion { get; set; }
        public int? MethodID { get; set; }
    }
    public class OBISListModel
    {
        public string? obisCode { get; set; }
    }

    public class ResOBISCodeList
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<OBISCodeModel> data { get; set; }
    }
}
