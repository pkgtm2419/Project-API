namespace WinDLMSClientApp._Models
{
    public class ReqGetMeterData
    {
        public int meterID { get; set; }
        public int? association { get; set; }
        public byte service { get; set; }
        public string? OBISCode { get; set; }
    }
}
