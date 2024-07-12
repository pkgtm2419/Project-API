using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ProjectAPI.SchemaModel
{
    public class RoleMenusModel
    {
        public LinkMenu Dashboard { get; set; }
        public LinkMenu Masters { get; set; }
        public LinkMenu Hes { get; set; }
        public LinkMenu Mdm { get; set; }
        public LinkMenu CustomerRegistration { get; set; }
        public LinkMenu CustomerSection { get; set; }
        public LinkMenu Transactions { get; set; }
        public LinkMenu Reports { get; set; }
        public LinkMenu UserMnt { get; set; }
        public FullAccessMenu Company { get; set; }
        public FullAccessMenu State { get; set; }
        public FullAccessMenu Ecb { get; set; }
        public FullAccessMenu District { get; set; }
        public PartialAccessMenu Division { get; set; }
        public PartialAccessMenu Business { get; set; }
        public PartialAccessMenu ConnectionType { get; set; }
        public PartialAccessMenu BillPackage { get; set; }
        public ReadOnlyMenu MeterPricing { get; set; }
        public ReadOnlyMenu Customer { get; set; }
        public ReadOnlyMenu Warehouse { get; set; }
        public ReadOnlyMenu Installer { get; set; }
        public ReadOnlyMenu Credentials { get; set; }
        public ReadOnlyMenu ObisCode { get; set; }
        public ReadOnlyMenu Faq { get; set; }
        public LinkMenu MeterData { get; set; }
        public LinkMenu MeterDataRaw { get; set; }
        public LinkMenu Alert { get; set; }
        public LinkMenu BillDataConfig { get; set; }
        public LinkMenu FirmwareUpgrade { get; set; }
        public LinkMenu MeterTempering { get; set; }
        public LinkMenu ConnectMeter { get; set; }
        public LinkMenu DisconnectMeter { get; set; }
        public LinkMenu Notification { get; set; }
        public LinkMenu RevenueCollection { get; set; }
        public LinkMenu RevenueOutstanding { get; set; }
        public LinkMenu CustomerBill { get; set; }
        public LinkMenu CustomerDataUsage { get; set; }
        public LinkMenu Tickets { get; set; }
        public LinkMenu Registration { get; set; }
        public LinkMenu Approval { get; set; }
        public LinkMenu Payment { get; set; }
        public LinkMenu AssignMeter { get; set; }
        public LinkMenu CDataUsage { get; set; }
        public LinkMenu CBillingData { get; set; }
        public LinkMenu AccountInfo { get; set; }
        public LinkMenu ConsumptionCal { get; set; }
        public LinkMenu CustomerFaq { get; set; }
        public LinkMenu LinkMeterCust { get; set; }
        public LinkMenu Inventory { get; set; }
        public LinkMenu MeterQc { get; set; }
        public LinkMenu Event { get; set; }
        public LinkMenu PerformanceReport { get; set; }
        public LinkMenu User { get; set; }
        public LinkMenu UserLogs { get; set; }
        public LinkMenu UserRoles { get; set; }
    }

    public class LinkMenu
    {
        public bool Link { get; set; }
        public string Level { get; set; }
        public string LinkPath { get; set; }
    }

    public class FullAccessMenu : LinkMenu
    {
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }

    public class PartialAccessMenu : LinkMenu
    {
        public bool Add { get; set; }
        public bool Edit { get; set; }
    }

    public class ReadOnlyMenu : LinkMenu
    {
        public bool Add { get; set; }
    }

    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("useType")]
        public string UseType { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("companyID")]
        public string CompanyID { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("roleMenus")]
        public RoleMenusModel RoleMenus { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
