using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ProjectAPI.SchemaModel
{
    public class CustomerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("salutation")]
        public string Salutation { get; set; }

        [BsonElement("fName")]
        public string FirstName { get; set; }

        [BsonElement("lName")]
        public string LastName { get; set; }

        [BsonElement("contactNo")]
        public string ContactNo { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("stateName")]
        public string StateName { get; set; }

        [BsonElement("districtName")]
        public string DistrictName { get; set; }

        [BsonElement("ecbName")]
        public string EcbName { get; set; }

        [BsonElement("circle")]
        public string Circle { get; set; }

        [BsonElement("whatsappNo")]
        public string WhatsappNo { get; set; }

        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("stage")]
        public Double? Stage { get; set; }

        [BsonElement("emailID")]
        public string EmailID { get; set; }

        [BsonElement("profilePicture")]
        public string? ProfilePicture { get; set; }

        [BsonElement("area")]
        public string? Area { get; set; }

        [BsonElement("service")]
        public string? Service { get; set; }

        [BsonElement("securityDeposit")]
        public int? SecurityDeposit { get; set; }

        [BsonElement("userValidation")]
        public string UserValidation { get; set; }

        [BsonElement("approvals")]
        public string Approvals { get; set; }

        [BsonElement("meter")]
        public string Meter { get; set; }

        [BsonElement("fatherName")]
        public string FatherName { get; set; }

        [BsonElement("DOB")]
        public string DateOfBirth { get; set; }

        [BsonElement("address1")]
        public string Address1 { get; set; }

        [BsonElement("address2")]
        public string Address2 { get; set; }

        [BsonElement("address")]
        public CustomerAddress Address { get; set; }

        [BsonElement("bankDetails")]
        public BankDetails BankDetails { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("countryCode")]
        public string CountryCode { get; set; }

        [BsonElement("stateCode")]
        public string StateCode { get; set; }

        [BsonElement("districtCode")]
        public string DistrictCode { get; set; }

        [BsonElement("ecbCode")]
        public string EcbCode { get; set; }

        [BsonElement("circleCode")]
        public string CircleCode { get; set; }

        [BsonElement("connectionType")]
        public string ConnectionType { get; set; }

        [BsonElement("loadSanction")]
        public string LoadSanction { get; set; }

        [BsonElement("phase")]
        public string Phase { get; set; }

        [BsonElement("pinCode")]
        public string PinCode { get; set; }

        [BsonElement("variant")]
        public string Variant { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("meterInstallation")]
        public string MeterInstallation { get; set; }

        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public string UpdatedAt { get; set; }

        [BsonElement("__v")]
        public int Version { get; set; }

        [BsonElement("addressNo")]
        public string AddressNo { get; set; }

        [BsonElement("addressType")]
        public string AddressType { get; set; }

        [BsonElement("bankType")]
        public string BankType { get; set; }

        [BsonElement("idNo")]
        public string IdNo { get; set; }

        [BsonElement("idType")]
        public string IdType { get; set; }

        [BsonElement("remarks")]
        public string Remarks { get; set; }

        [BsonElement("validated")]
        public bool Validated { get; set; }

        [BsonElement("validatedAt")]
        public string ValidatedAt { get; set; }

        [BsonElement("validatedBy")]
        public string ValidatedBy { get; set; }

        [BsonElement("payment")]
        public Payment Payment { get; set; }

        [BsonElement("documents")]
        public List<Document> Documents { get; set; }
    }

    public class CustomerAddress
    {
        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("district")]
        public string District { get; set; }

        [BsonElement("circle")]
        public string Circle { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("pincode")]
        public string Pincode { get; set; }

        [BsonElement("address1")]
        public string Address1 { get; set; }

        [BsonElement("address2")]
        public string Address2 { get; set; }
    }

    public class BankDetails
    {
        [BsonElement("bankName")]
        public string BankName { get; set; }

        [BsonElement("accountType")]
        public string AccountType { get; set; }

        [BsonElement("IFSC")]
        public string IFSC { get; set; }

        [BsonElement("accountNo")]
        public string AccountNo { get; set; }

        [BsonElement("branch")]
        public string Branch { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("pincode")]
        public string Pincode { get; set; }
    }

    public class Payment
    {
        [BsonElement("paymentDue")]
        public PaymentDue PaymentDue { get; set; }

        [BsonElement("paymentReceived")]
        public PaymentReceived PaymentReceived { get; set; }
    }

    public class PaymentReceived
    {
        [BsonElement("validated")]
        public bool Validated { get; set; }

        [BsonElement("validatedBy")]
        public string ValidatedBy { get; set; }

        [BsonElement("validatedAt")]
        public string ValidatedAt { get; set; }

        [BsonElement("amount")]
        public double? Amount { get; set; }

        [BsonElement("mode")]
        public string Mode { get; set; }

        [BsonElement("instrumentNo")]
        public string InstrumentNo { get; set; }

        [BsonElement("bankBranch")]
        public string BankBranch { get; set; }

        [BsonElement("bankName")]
        public string BankName { get; set; }

        [BsonElement("paymentDate")]
        public string PaymentDate { get; set; }

        [BsonElement("remarks")]
        public string Remarks { get; set; }
    }

    public class PaymentDue
    {
        [BsonElement("validated")]
        public bool Validated { get; set; }

        [BsonElement("validatedBy")]
        public string ValidatedBy { get; set; }

        [BsonElement("validatedAt")]
        public string ValidatedAt { get; set; }

        [BsonElement("energyLoad")]
        public int? EnergyLoad { get; set; }

        [BsonElement("meterType")]
        public string MeterType { get; set; }

        [BsonElement("securityAmount")]
        public int? SecurityAmount { get; set; }

        [BsonElement("meterAmount")]
        public int? MeterAmount { get; set; }

        [BsonElement("installationPrice")]
        public int? InstallationPrice { get; set; }

        [BsonElement("otherAmount")]
        public int? OtherAmount { get; set; }

        [BsonElement("totalAmount")]
        public int? TotalAmount { get; set; }

        [BsonElement("remarks")]
        public string Remarks { get; set; }
    }

    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("docType")]
        public string DocType { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("docNo")]
        public string DocNo { get; set; }

        [BsonElement("link")]
        public string Link { get; set; }

        [BsonElement("uploadedAt")]
        public string? UploadedAt { get; set; }

        [BsonElement("validated")]
        public bool Validated { get; set; }

        [BsonElement("validatedBy")]
        public string ValidatedBy { get; set; }

        [BsonElement("validatedAt")]
        public string? ValidatedAt { get; set; }

        [BsonElement("remarks")]
        public string? Remarks { get; set; }
    }

    public class ResCustomer
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<CustomerModel> data { get; set; }
    }
}
