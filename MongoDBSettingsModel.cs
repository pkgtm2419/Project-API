namespace ProjectAPI.SchemaModel
{
    public class MongoDBSettingsModel
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
        public string counter { get; set; }
        public string mst_meter { get; set; }
        public string items { get; set; }
        public string trn_billing { get; set; }
        public string mst_bill_calculation { get; set; }
        public string mst_obis { get; set; }
        public string trn_meter_operations { get; set; }
    }
}
