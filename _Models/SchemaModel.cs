namespace WinDLMSClientApp._Models
{
    public class ResStatus
    {
        public int status { get; set; }
        public string message { get; set; }
    }

    public class MongoDBSettingsModel
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
        public string counter { get; set; }
        public string mst_meter { get; set; }
        public string dlsmData { get; set; }
        public string mst_customer { get; set; }
        public string mst_company { get; set; }
        public string mst_user { get; set; }
        public string mst_role { get; set; }
        public string meter_data { get; set; }
        public string mst_appliances { get; set; }
        public string items { get; set; }
        public string trn_billing { get; set; }
        public string mst_bill_calculation { get; set; }
        public string mst_obis { get; set; }
        public string trn_meter_operations { get; set; }
    }
}
