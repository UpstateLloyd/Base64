using System;
using System.Collections.Generic;
using System.Text;

namespace B64.Models
{
    internal class Quotes
    {
        public List<Value> value { get; set; }
    }

    public class Value
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? FirstOrderDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? PriceLockExpiration { get; set; }
        public bool IsOwner { get; set; }
        public string PONumber { get; set; }
        public string ProjectName { get; set; }
        public string QuoteName { get; set; }
        public string QuoteNumber { get; set; }
        public int QuoteNumberPrimaryInt { get; set; }
        public int QuoteNumberSecondaryInt { get; set; }
        public string QuoteStatus { get; set; }
        public string QuoteWaitingOn { get; set; }
        public string QuoteType { get; set; }
        public string QuoteUserName { get; set; }
        public string PricingType { get; set; }
        public double TotalDealerPrice { get; set; }
        public double TotalCustomerPrice { get; set; }
        public double TotalTwoStepPrice { get; set; }
        public string QuoteIntegrationID { get; set; }
        public string ClientIntegrationID { get; set; }
        public DateTime? LastServerUpdate { get; set; }
        public string SalesRepCode { get; set; }
        public string SalesRep { get; set; }
        public string ManufacturingStatus { get; set; }
        public int Manufacturer { get; set; }
        public string ManufacturerToUserType { get; set; }
        public bool WasCertified { get; set; }
        public int CustomerId { get; set; }
        public string CustomerIntegrationId { get; set; }
        public bool Inspire { get; set; }
        public bool View { get; set; }
        public bool Vendo { get; set; }
        public string ParentQuoteId { get; set; }
        public bool IsOption { get; set; }
        public int AttachmentsCount { get; set; }
        public string BusinessSegment { get; set; }
        public string OrderType { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public int LinesCount { get; set; }
        public string QuoteTemplateID { get; set; }
        public string CreatedByUserEmailAddress { get; set; }
        public bool InWorkflowQueue { get; set; }
        public bool IsTwoStep { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyIntegrationId { get; set; }
        public string ShippingMethodName { get; set; }
        public string ShippingMethodId { get; set; }
        public bool HasError { get; set; }
        public bool CanceledFlag { get; set; }
        public bool HasClientNotes { get; set; }
        public string TaskName { get; set; }
        public bool IsAlternateQuote { get; set; }
        public int RelativesCount { get; set; }
        public string OrderByUserId { get; set; }
        public string OrderByUserName { get; set; }
        public DateTime? FirstSentToEngineeringDate { get; set; }
        public string EstimateId { get; set; }
        public string PricingProfileId { get; set; }
        public string PricingProfileName { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime? WorkflowStartDate { get; set; }
        public List<string> NoteInformation { get; set; }
    }

}
