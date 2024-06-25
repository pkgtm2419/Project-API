using System;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectAPI.SchemaModel
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

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("companyID")]
        public string CompanyID { get; set; }

        [BsonElement("initialization")]
        public Initialization Initialization { get; set; }

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

    public class Initialization
    {
        [BsonElement("resTimeOut")]
        public uint ResTimeOut { get; set; }

        [BsonElement("resInterFrameTimeOut")]
        public ushort ResInterFrameTimeOut { get; set; }

        [BsonElement("MaxLinkLayerBuffer")]
        public ushort MaxLinkLayerBuffer { get; set; }

        [BsonElement("MaxAppLayerBuffer")]
        public uint MaxAppLayerBuffer { get; set; }

        [BsonElement("cipheringSupport")]
        public byte CipheringSupport { get; set; }

        [BsonElement("ChannelNo")]
        public ushort ChannelNo { get; set; }

        [BsonElement("baudRate")]
        public int BaudRate { get; set; }

        [BsonElement("client_ipAddr")]
        public string ClientIpAddr { get; set; }

        [BsonElement("server_ipAddr")]
        public string ServerIpAddr { get; set; }

        [BsonElement("serverPort")]
        public int ServerPort { get; set; }

        [BsonElement("wPort_Client")]
        public int WPortClient { get; set; }

        [BsonElement("wPort_Server")]
        public int WPortServer { get; set; }

        [BsonElement("logicalAddr")]
        public int LogicalAddr { get; set; }

        [BsonElement("physicalAddr")]
        public int PhysicalAddr { get; set; }

        [BsonElement("negoParams")]
        public int NegoParams { get; set; }

        [BsonElement("windowTx")]
        public int WindowTx { get; set; }

        [BsonElement("windowRx")]
        public int WindowRx { get; set; }

        [BsonElement("InfoLenTx")]
        public int InfoLenTx { get; set; }

        [BsonElement("InfoLenRx")]
        public int InfoLenRx { get; set; }

        [BsonElement("appContext")]
        public int AppContext { get; set; }

        [BsonElement("passwd")]
        public string Passwd { get; set; }

        [BsonElement("HLSKeyPassword")]
        public string HLSKeyPassword { get; set; }

        [BsonElement("clientChallengeLen")]
        public int ClientChallengeLen { get; set; }

        [BsonElement("clientChallengeKey")]
        public string ClientChallengeKey { get; set; }

        [BsonElement("clientSystemTitle")]
        public string ClientSystemTitle { get; set; }

        [BsonElement("AuthenticationKey")]
        public string AuthenticationKey { get; set; }

        [BsonElement("EncryptionKey")]
        public string EncryptionKey { get; set; }

        [BsonElement("SecurityObjectVer")]
        public int SecurityObjectVer { get; set; }

        [BsonElement("secPolicy")]
        public int SecPolicy { get; set; }

        [BsonElement("AARQSecurityControl")]
        public int AARQSecurityControl { get; set; }

        [BsonElement("secSuite")]
        public int SecSuite { get; set; }

        [BsonElement("UserID")]
        public int UserID { get; set; }

        [BsonElement("userFramectr")]
        public int UserFramectr { get; set; }

        [BsonElement("secPolicyMenu")]
        public SecPolicyMenu SecPolicyMenu { get; set; }
    }

    public class SecPolicyMenu
    {
        [BsonElement("SelectMenu")]
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
}