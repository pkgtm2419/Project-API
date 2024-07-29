using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WinDLMSClientApp._Models
{
    public class OBISCodeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string obisCode { get; set; }
        public OBIS? obisObject { get; set; }
        public string? name { get; set; }
        public string? displayName { get; set; }
        public string? unit { get; set; }
        public ushort interfaceClass { get; set; }
        public byte ICVersion { get; set; }
        public byte MethodID { get; set; }
    }

    public class OBIS
    {
        public byte a { get; set; }
        public byte b { get; set; }
        public byte c { get; set; }
        public byte d { get; set; }
        public byte e { get; set; }
        public byte f { get; set; }
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
