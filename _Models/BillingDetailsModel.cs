using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinDLMSClientApp._Models
{
    public class BillingDetailsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("businessType")]
        public string BusinessType { get; set; }

        [BsonElement("areaType")]
        public string AreaType { get; set; }

        [BsonElement("billType")]
        public string BillType { get; set; }

        [BsonElement("customerCategory")]
        public string CustomerCategory { get; set; }

        [BsonElement("connectionType")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ConnectionType { get; set; }

        [BsonElement("effectiveFrom")]
        public DateTime EffectiveFrom { get; set; }

        [BsonElement("billDetails")]
        public BillCalculationDetails BillDetails { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("__v")]
        public int Version { get; set; }
    }

    public class BillCalculationDetails
    {
        [BsonElement("energyCharges")]
        public EnergyCharges EnergyCharges { get; set; }

        [BsonElement("loadCharges")]
        public List<LoadCharges> LoadCharges { get; set; }

        [BsonElement("rentalCharge")]
        public double RentalCharge { get; set; }

        [BsonElement("surcharge")]
        public double Surcharge { get; set; }

        [BsonElement("greenCharge")]
        public double GreenCharge { get; set; }

        [BsonElement("onDemandCharge")]
        public double OnDemandCharge { get; set; }

        [BsonElement("miscellaneousCharge")]
        public double MiscellaneousCharge { get; set; }

        [BsonElement("otherCharge")]
        public double OtherCharge { get; set; }
    }

    public class EnergyCharges
    {
        [BsonElement("freeZone")]
        public double FreeZone { get; set; }

        [BsonElement("tariff")]
        public List<Tariff> Tariff { get; set; }
    }

    public class Tariff
    {
        [BsonElement("fromUnit")]
        public string FromUnit { get; set; }

        [BsonElement("toUnit")]
        public string ToUnit { get; set; }

        [BsonElement("unitRate")]
        public double UnitRate { get; set; }
    }

    public class LoadCharges
    {
        [BsonElement("load")]
        public string Load { get; set; }

        [BsonElement("charge")]
        public double Charge { get; set; }
    }

}
