using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ProjectAPI.SchemaModel
{
    public class BillingTransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("deviceID")]
        public string DeviceID { get; set; }

        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("devicePublishTime")]
        public DateTime DevicePublishTime { get; set; }

        [BsonElement("billDate")]
        public DateTime BillDate { get; set; }

        [BsonElement("cumulativeEnergy")]
        public double CumulativeEnergy { get; set; }

        [BsonElement("billingUnit")]
        public double BillingUnit { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("billAmount")]
        public double BillAmount { get; set; }

        [BsonElement("billingMonth")]
        public string BillingMonth { get; set; }

        [BsonElement("amountPaid")]
        public double AmountPaid { get; set; }

        [BsonElement("pendingAmount")]
        public double PendingAmount { get; set; }

        [BsonElement("isMeterActive")]
        public bool IsMeterActive { get; set; }

        [BsonElement("dueDate")]
        public DateTime DueDate { get; set; }

        [BsonElement("disconnectDate")]
        public DateTime DisconnectDate { get; set; }

        [BsonElement("reConnectionDate")]
        public string ReConnectionDate { get; set; } // Could be DateTime? if you expect nullable date

        [BsonElement("remark")]
        public string Remark { get; set; }

        [BsonElement("customerCategory")]
        public string CustomerCategory { get; set; }

        [BsonElement("billBifurcation")]
        public BillBifurcation BillBifurcation { get; set; }

        [BsonElement("paymentDetails")]
        public List<PaymentDetail> PaymentDetails { get; set; }
    }

    public class BillBifurcation
    {
        [BsonElement("energyCharges")]
        public double EnergyCharges { get; set; }

        [BsonElement("fixedCharges")]
        public double FixedCharges { get; set; }

        [BsonElement("electricityDuty")]
        public double ElectricityDuty { get; set; }

        [BsonElement("greenEC")]
        public double GreenEC { get; set; }

        [BsonElement("arrearCharges")]
        public double ArrearCharges { get; set; }

        [BsonElement("penaltyCharges")]
        public double PenaltyCharges { get; set; }

        [BsonElement("rebate")]
        public double Rebate { get; set; }

        [BsonElement("prevOutstandingAmount")]
        public double PrevOutstandingAmount { get; set; }
    }

    public class PaymentDetail
    {
        [BsonElement("paymentAmount")]
        public double PaymentAmount { get; set; }

        [BsonElement("pendingAmount")]
        public double PendingAmount { get; set; }

        [BsonElement("paymentDate")]
        public DateTime PaymentDate { get; set; }

        [BsonElement("intrNo")]
        public string IntrNo { get; set; }

        [BsonElement("paymentMode")]
        public string PaymentMode { get; set; }

        [BsonElement("bankName")]
        public string BankName { get; set; }
    }
}