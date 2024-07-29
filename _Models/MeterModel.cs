using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.InteropServices;

namespace WinDLMSClientApp._Models
{
    public class MeterModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("meterID")]
        public string MeterID { get; set; }

        [BsonElement("deviceID")]
        public string DeviceID { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("meterCategory")]
        public string MeterCategory { get; set; }

        [BsonElement("lotNo")]
        public string LotNo { get; set; }

        [BsonElement("billType")]
        public string BillType { get; set; }

        [BsonElement("warehouseCode")]
        public string WarehouseCode { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("companyID")]
        public string CompanyID { get; set; }

        [BsonElement("initialization")]
        public Initialization Initialization { get; set; }

        [BsonElement("billingDateConfiguration")]
        public BillingDateDetails BillingDateConfiguration { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("mfgDate")]
        public string MfgDate { get; set; }

        [BsonElement("IPAddress")]
        public string IPAddress { get; set; }

        [BsonElement("IMEINo")]
        public string IMEINo { get; set; }

        [BsonElement("rating")]
        public string Rating { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("firmwareVer")]
        public string FirmwareVer { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("assigned")]
        public bool Assigned { get; set; }

        [BsonElement("isMeterInstalled")]
        public bool IsMeterInstalled { get; set; }

        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public class BillingDateDetails
    {
        [BsonElement("accessSelector")]
        public byte AccessSelector { get; set; }

        [BsonElement("rangeData")]
        public RangeData RangeData { get; set; }

        [BsonElement("entryData")]
        public EntryData EntryData { get; set; }
    }

    public class RangeData
    {
        [BsonElement("fromDate")]
        public string FromDate { get; set; }

        [BsonElement("toDate")]
        public string ToDate { get; set; }
    }

    public class EntryData
    {

    }

    public class Initialization
    {
        [BsonElement("OBISData")]
        public OBISCodeModel? OBISData { get; set; }

        [BsonElement("resTimeOut")]
        public uint ResTimeOut { get; set; }

        [BsonElement("resInterFrameTimeOut")]
        public ushort ResInterFrameTimeOut { get; set; }

        [BsonElement("maxLinkLayerBuffer")]
        public ushort MaxLinkLayerBuffer { get; set; }

        [BsonElement("maxAppLayerBuffer")]
        public uint MaxAppLayerBuffer { get; set; }

        [BsonElement("cipheringSupport")]
        public byte CipheringSupport { get; set; }

        [BsonElement("channelNo")]
        public ushort ChannelNo { get; set; }

        [BsonElement("baudRate")]
        public uint BaudRate { get; set; }

        [BsonElement("service")]
        public byte Service { get; set; }

        [BsonElement("useWithList")]
        public byte UseWithList { get; set; }

        [BsonElement("serviceClass")]
        public byte ServiceClass { get; set; }

        [BsonElement("securityKeys")]
        public SecurityKeys SecurityKeys { get; set; }

        [BsonElement("PC")]
        public Associasion PC { get; set; }

        [BsonElement("MR")]
        public Associasion MR { get; set; }

        [BsonElement("US")]
        public Associasion US { get; set; }

        [BsonElement("PUSH")]
        public Associasion PUSH { get; set; }

        [BsonElement("FW")]
        public Associasion FW { get; set; }

        [BsonElement("clientIpAddr")]
        public string ClientIpAddr { get; set; }

        [BsonElement("serverIpAddr")]
        public string ServerIpAddr { get; set; }

        [BsonElement("serverPort")]
        public int ServerPort { get; set; }

        [BsonElement("wPortClient")]
        public int WPortClient { get; set; }

        [BsonElement("wPortServer")]
        public int WPortServer { get; set; }

        [BsonElement("logicalAddress")]
        public ushort LogicalAddress { get; set; }

        [BsonElement("serverPhysicalDeviceID")]
        public ushort ServerPhysicalDeviceID { get; set; }

        [BsonElement("physicalAddress")]
        public int PhysicalAddress { get; set; }

        [BsonElement("clientID")]
        public byte ClientID { get; set; }

        [BsonElement("authMech")]
        public byte AuthenticationMechanism { get; set; }

        [BsonElement("authTagLen")]
        public byte AuthTagLen { get; set; }

        [BsonElement("associationType")]
        public byte AssociationType { get; set; }

        [BsonElement("negoParams")]
        public byte NegoParams { get; set; }

        [BsonElement("windowTx")]
        public byte WindowTx { get; set; }

        [BsonElement("windowRx")]
        public byte WindowRx { get; set; }

        [BsonElement("infoLenTx")]
        public byte InfoLenTx { get; set; }

        [BsonElement("infoLenRx")]
        public byte InfoLenRx { get; set; }

        [BsonElement("appContext")]
        public byte AppContext { get; set; }

        [BsonElement("securityObjectVer")]
        public int SecurityObjectVer { get; set; }

        [BsonElement("securityPolicyVersion")]
        public byte SecurityPolicyVersion { get; set; }

        [BsonElement("securityPolicy")]
        public byte SecurityPolicy { get; set; }

        [BsonElement("serverAddressLength")]
        public byte ServerAddressLength { get; set; }

        [BsonElement("AARQSecurityControl")]
        public byte AARQSecurityControl { get; set; }

        [BsonElement("secSuite")]
        public byte SecSuite { get; set; }

        [BsonElement("maximumAPDU")]
        public ushort MaximumAPDU { get; set; }

        [BsonElement("userID")]
        public byte UserID { get; set; }

        [BsonElement("userFramectr")]
        public uint UserFramectr { get; set; }

        [BsonElement("secPolicyMenu")]
        public SecPolicyMenu SecPolicyMenu { get; set; }
    }

    public class SecurityKeys
    {
        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("HLSKeyPassword")]
        public string HLSKeyPassword { get; set; }

        [BsonElement("clientChallengeLen")]
        public uint ClientChallengeLen { get; set; }

        [BsonElement("dedicatedKey")]
        public string DedicatedKey { get; set; }

        [BsonElement("clientChallengeKey")]
        public string ClientChallengeKey { get; set; }

        [BsonElement("clientSystemTitle")]
        public string ClientSystemTitle { get; set; }

        [BsonElement("serverSystemTitle")]
        public string ServerSystemTitle { get; set; }

        [BsonElement("authenticationKey")]
        public string AuthenticationKey { get; set; }

        [BsonElement("encryptionKey")]
        public string EncryptionKey { get; set; }

        [BsonElement("globalKey")]
        public string GlobalKey { get; set; }
    }

    public class Associasion
    {
        [BsonElement("secSuite")]
        public byte SecSuite { get; set; }

        [BsonElement("appContext")]
        public byte AppContext { get; set; }

        [BsonElement("securityPolicy")]
        public byte SecurityPolicy { get; set; }

        [BsonElement("AARQSecurityControl")]
        public byte AARQSecurityControl { get; set; }

        [BsonElement("authenticationMechanism")]
        public byte AuthenticationMechanism { get; set; }
    }

    public class SecPolicyMenu
    {
        [BsonElement("selectMenu")]
        public int SelectMenu { get; set; }

        [BsonElement("moreSecurityChoices")]
        public string MoreSecurityChoices { get; set; }
    }

    public class MeterRes
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<MeterModel>? data { get; set; }
    }

    struct TCPUDP
    {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 40)]
        public byte[] client_ipAddr;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 40)]
        public byte[] server_ipAddr;
        public ushort serverPort;
        public ushort wPort_Client;
        public ushort wPort_Server;
    }

    struct SEROPT
    {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 10)]
        public byte[] name;
        public uint baud;
        public byte parity;
    }

    public enum DATA_TYPE
    {
        DT_NULL_DATA = 0,
        DT_ARRAY,
        DT_STRUCTURE,
        DT_BOOLEAN,
        DT_BIT_STRING,
        DT_DOUBLE_LONG = 5,
        DT_DOUBLE_LONG_UNSIGNED,
        DT_FLOATING_POINT,
        DT_OCTET_STRING = 9,
        DT_VISIBLE_STRING,
        DT_TIME,
        DT_BCD = 13,
        DT_INTEGER = 15,
        DT_LONG,
        DT_UNSIGNED,
        DT_LONG_UNSIGNED,
        DT_LONG64 = 20,
        DT_UNSIGNED_LONG64,
        DT_ENUM,
        DT_REAL32,
        DT_REAL64,
        DT_DATETIME,
        DT_DATE,
        DT_TIME1,
    }
}
