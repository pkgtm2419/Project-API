using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ProjectAPI.SchemaModel
{
    public class ItemsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("deviceID")]
        public string DeviceID { get; set; }

        [BsonElement("meterID")]
        public string MeterID { get; set; }

        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("districtName")]
        public string DistrictName { get; set; }

        [BsonElement("variant")]
        public string Variant { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("loginName")]
        public string LoginName { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("circle")]
        public string Circle { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("ecb")]
        public string Ecb { get; set; }

        [BsonElement("loadSantion")]
        public string LoadSantion { get; set; }

        [BsonElement("billDetails")]
        public BillDetails BillDetails { get; set; }

        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }
        
        [BsonElement("active")]
        public string Active { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public class PaymentDetails
    {
        [BsonElement("paymentAmount")]
        public decimal PaymentAmount { get; set; }

        [BsonElement("pendingAmount")]
        public decimal PendingAmount { get; set; }

        [BsonElement("paymentDate")]
        public string PaymentDate { get; set; }

        [BsonElement("intrNo")]
        public string IntrNo { get; set; }

        [BsonElement("paymentMode")]
        public string PaymentMode { get; set; }

        [BsonElement("bankName")]
        public string BankName { get; set; }
    }

    public class BillDetails
    {
        [BsonElement("billingMonth")]
        public string BillingMonth { get; set; }

        [BsonElement("cumulativeEnergy")]
        public double CumulativeEnergy { get; set; }

        [BsonElement("monthBillingUnit")]
        public double MonthBillingUnit { get; set; }

        [BsonElement("billFrequency")]
        public string BillFrequency { get; set; }

        [BsonElement("billDate")]
        public string BillDate { get; set; }

        [BsonElement("dueDate")]
        public string DueDate { get; set; }

        [BsonElement("meterPublishTime")]
        public string MeterPublishTime { get; set; }

        [BsonElement("energyCharges")]
        public decimal EnergyCharges { get; set; }

        [BsonElement("fixedCharges")]
        public decimal FixedCharges { get; set; }

        [BsonElement("electricityDuty")]
        public decimal ElectricityDuty { get; set; }

        [BsonElement("greenEC")]
        public decimal GreenEC { get; set; }

        [BsonElement("arrearCharges")]
        public decimal ArrearCharges { get; set; }

        [BsonElement("penaltyCharges")]
        public decimal PenaltyCharges { get; set; }

        [BsonElement("rebate")]
        public decimal Rebate { get; set; }

        [BsonElement("prevOutstandingAmount")]
        public decimal PrevOutstandingAmount { get; set; }

        [BsonElement("monthBillAmount")]
        public decimal MonthBillAmount { get; set; }

        [BsonElement("totalAmount")]
        public decimal TotalAmount { get; set; }

        [BsonElement("isMeterActive")]
        public bool IsMeterActive { get; set; }

        [BsonElement("disconnectDate")]
        public string DisconnectDate { get; set; }

        [BsonElement("reConnectionDate")]
        public string ReConnectionDate { get; set; }

        [BsonElement("remark")]
        public string Remark { get; set; }

        [BsonElement("paymentDetails")]
        public List<PaymentDetails> PaymentDetails { get; set; }
    }

    public class ResItems
    {
        public int status { get; set; }
        public string message { get; set; }
        [BsonElement("items")]
        public List<ItemsModel> data { get; set; }
    }
}
