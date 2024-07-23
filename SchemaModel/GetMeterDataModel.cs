using DLMS_CLIENT.DLMSStruct;

namespace ProjectAPI.SchemaModel
{
    public class GetMeterDataModel
    {
    }

    public class ReqGetMeterData
    {
        public int meterID { get; set; }
        public int? association { get; set; }
        public int? IC { get; set; }
        public OBISCODE? OBISCode { get; set; }
    }
}
