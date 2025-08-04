using System;

namespace B64
{
    public class Vendor
    {
        public string VendorID { get; set; }
        public string ID { get; set; }
        public string IntegrationID { get; set; }
        public string VendorTermsID { get; set; }
        public string VenderTerms_IntegrationID { get; set; }
        public string CurrencyID { get; set; }
        public string Currency_IntegrationID { get; set; }
        public string AutoPTOPurchaseOrderShippingMethodID { get; set; }
        public string AutoPTOPurchaseOrderFreightOnBoardID { get; set; }
        public string AutoPTOPurchaseOrderReportID { get; set; }
        public string AutoCreatePTOPurchaseOrders { get; set; }
        public string Name { get; set; }
        public string SeparateAutoPTOPurchaseOrdersBySalesOrder { get; set; }
        public string SendAutoPTOPurchaseOrders { get; set; }
        public string APAddress1 { get; set; }
        public string APAddress2 { get; set; }
        public string APCity { get; set; }
        public string APContactName { get; set; }
        public string APCountry { get; set; }
        public string APFax { get; set; }
        public string APName { get; set; }
        public string APPhone { get; set; }
        public string APState { get; set; }
        public string APVendorNumber { get; set; }
        public string APZip { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string VendorNumber { get; set; }
        public string Zip { get; set; }
        public string IntegrationAssembly { get; set; }
        public string IntegrationClass { get; set; }
        public string IntegrationFilePath { get; set; }
        public string IntegrationGroup { get; set; }
        public string IsDeleted { get; set; }
        public string POFaxEmailMethod { get; set; }
        public string MaxTotalPurchaseOrderCost { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime WTSLastUpdate { get; set; }
        public string Delete { get; set; }

    }

    public class ClientTaxCode
    {
        public Vendor Vendor { get; set; }
        public string ID { get; set; }
        public string IntegrationID { get; set; }
        public string VendorID { get; set; }
        public string Vendor_IntegrationID { get; set; }
        public string Name { get; set; }
        public string CityRate { get; set; }
        public string CountyRate { get; set; }
        public string StateRate { get; set; }
        public string GroupTwoMultiplicative { get; set; }
        public string City { get; set; }
        public string CityGroup { get; set; }
        public string County { get; set; }
        public string CountyGroup { get; set; }
        public string GroupOneName { get; set; }
        public string GroupTwoName { get; set; }
        public string HandlingTaxableDefault { get; set; }
        public string MiscTaxableDefault { get; set; }
        public string OtherGroup { get; set; }
        public string OtherRate { get; set; }
        public string ShippingTaxableDefault { get; set; }
        public string State { get; set; }
        public string StateGroup { get; set; }
        public string SurtaxLimit { get; set; }
        public string SurtaxRate { get; set; }
        public string TaxExemptType { get; set; }
        public string Deleted { get; set; }
        public string Delete { get; set; }

    }

    public class DefaultSalesRepstring
    {
        public SalesTerritory SalesTerritory { get; set; }
        public string User { get; set; }
        public string SalesRepID { get; set; }
        public string ID { get; set; }
        public string IntegrationID { get; set; }
        public string SalesRepCode { get; set; }
        public string RepName { get; set; }
        public string Notes { get; set; }
        public string UserID { get; set; }
        public string LastUpdate { get; set; }
        public DateTime WTSLastUpdate { get; set; }
        public string Active { get; set; }
        public string SalesTerritoryID { get; set; }
        public string SalesTerritory_IntegrationID { get; set; }
        public string User_IntegrationID { get; set; }
        public string Delete { get; set; }      

    }

    public class DefaultShippingMethod
    {
        public string ShippingCharge { get; set; }
        public string ShippingMethodID { get; set; }
        public string ID { get; set; }
        public string IntegrationID { get; set; }
        public string ShippingChargeID { get; set; }
        public string ShippingCharge_IntegrationID { get; set; }
        public string AlwaysVisible { get; set; }
        public string NeedTrailer { get; set; }
        public string TruckingMethodType { get; set; }
        public string TrackingNumberType { get; set; }
        public string UseCalender { get; set; }
        public string VisibleToConsumer { get; set; }
        public string DefaultFOB { get; set; }
        public string ExtraData1 { get; set; }
        public string ExtraData2 { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PlaceHolder { get; set; }
        public string LastUpdate { get; set; }
        public string Delete { get; set; }

    }

    public class DefaultShipAddresses
    {
        public ClientTaxCode ClientTaxCode { get; set; }
        public DefaultShippingMethod DefaultShippingMethod { get; set; }
        public string PayTerm { get; set; }
        public string ShippingBranch { get; set; }
        public string ID { get; set; }
        public string IntegrationID { get; set; }
        public string ClientID { get; set; }
        public string Client_IntegrationID1 { get; set; }
        public string Client_IntegrationID2 { get; set; }
        public string Client_IntegrationID3 { get; set; }
        public string ShippingBranchID { get; set; }
        public string ShippingBranch_IntegrationID { get; set; }
        public string DefaultShippingMethodID { get; set; }
        public string DefaultShippingMethod_IntegrationID { get; set; }
        public string ClientTaxCodeID { get; set; }
        public string ClientTaxCode_IntegrationID { get; set; }
        public string PayTermsID { get; set; }
        public string PayTerms_IntegrationID { get; set; }
        public string TerritoryID { get; set; }
        public string Territory_IntegrationID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ExtraData { get; set; }
        public string ExtraField1 { get; set; }
        public string ExtraField2 { get; set; }
        public string ExtraField3 { get; set; }
        public string ExtraField4 { get; set; }
        public string ExtraField5 { get; set; }
        public string ShipMonday { get; set; }
        public string ShipMondayLoadDay { get; set; }
        public string ShipTuesday { get; set; }
        public string ShipTuesdayLoadDay { get; set; }
        public string ShipWenesday { get; set; }
        public string ShipWenesdayLoadDay { get; set; }
        public string ShipThursday { get; set; }
        public string ShipThursdayLoadDay { get; set; }
        public string ShipFriday { get; set; }
        public string ShipFridayLoadDay { get; set; }
        public string ShipSaturday { get; set; }
        public string ShipSaturdayLoadDay { get; set; }
        public string ShipSunday { get; set; }
        public string ShipSundayLoadDay { get; set; }
        public string Comment { get; set; }
        public string ContactName { get; set; }
        public string DefaultShipAddress { get; set; }
        public string DropNumber { get; set; }
        public string FulfillLoc { get; set; }
        public string FulfillmentType { get; set; }
        public string PriceAdjustmentPct { get; set; }
        public string RouteCode { get; set; }
        public string ShipZone { get; set; }
        public string ShipLeadTime { get; set; }
        public string Status { get; set; }
        public string Tax1 { get; set; }
        public string Tax2 { get; set; }
        public string TaxID { get; set; }
        public string TwoStep { get; set; }
        public string Delete { get; set; }

    }

    public class SalesTerritory
    {
        public int ID { get; set; }
        public object IntegrationID { get; set; }
        public string Name { get; set; }
        public object LastUpdate { get; set; }
        public object WTSLastUpdate { get; set; }
        public bool Delete { get; set; }
    }
    public class Root
    {
        public ClientTaxCode ClientTaxCode { get; set; }
        public Vendor Vendor { get; set; }
        public string Currency { get; set; }
        public DefaultSalesRepstring DefaultSalesRepstring { get; set; }
        public DefaultShipAddresses DefaultShipAddress { get; set; }
        public string Distributor { get; set; }
        public SalesTerritory SalesTerritory { get; set; }
        public string ClientID { get; set; }
        public string ID { get; set; }
        public string IntegrationID { get; set; }
        public string IntegrationID2 { get; set; }
        public string IntegrationID3 { get; set; }
        public string DefaultShipAddressID { get; set; }
        public string DefaultShipAddress_IntegrationID { get; set; }
        public string SalesTerritoryID { get; set; }
        public string SalesTerritory_IntegrationID { get; set; }
        public string Currency_IntegrationID { get; set; }
        public string ClientTaxCode_IntegrationID { get; set; }
        public string DistributorID { get; set; }
        public string Distributor_IntegrationID { get; set; }
        public string DefaultSalesRep { get; set; }
        public string DefaultSalesRep_IntegrationID { get; set; }
        public string AutoInvoice { get; set; }
        public string AutoSendInvoice { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillAddress3 { get; set; }
        public string BillCity { get; set; }
        public string BillCountry { get; set; }
        public string BillCounty { get; set; }
        public string BillFax { get; set; }
        public string BillMobilePhone { get; set; }
        public string BillName { get; set; }
        public string BillPhone { get; set; }
        public string BillState { get; set; }
        public string BillTo { get; set; }
        public string BillZip { get; set; }
        public string ExtraField1 { get; set; }
        public string ExtraField2 { get; set; }
        public string ExtraField3 { get; set; }
        public string ExtraField4 { get; set; }
        public string ExtraField5 { get; set; }
        public string ExtraField6 { get; set; }
        public string ExtraField7 { get; set; }
        public string ExtraField8 { get; set; }
        public string ExtraField9 { get; set; }
        public string ExtraField10 { get; set; }
        public string ExtraField11 { get; set; }
        public string ExtraField12 { get; set; }
        public string ExtraField13 { get; set; }
        public string ExtraField14 { get; set; }
        public string ExtraField15 { get; set; }
        public string ExtraField16 { get; set; }
        public string ExtraField17 { get; set; }
        public string ExtraField18 { get; set; }
        public string ExtraField19 { get; set; }
        public string ExtraField20 { get; set; }
        public string ExtraField21 { get; set; }
        public string ExtraField22 { get; set; }
        public string ExtraField23 { get; set; }
        public string ExtraField24 { get; set; }
        public string ExtraField25 { get; set; }
        public string ExtraFieldLarge { get; set; }
        public string MarkupType { get; set; }
        public string MinMarkupPct { get; set; }
        public string MaxMarkupPct { get; set; }
        public string MinMarkupAmt { get; set; }
        public string MaxMarkupAmt { get; set; }
        public string AllowTwoStepCompanyDiscounts { get; set; }
        public string AutomaticOrderHold { get; set; }
        public string AutomaticOrderHoldDuration { get; set; }
        public string ClientName { get; set; }
        public string ClientTaxCodeID { get; set; }
        public string ClientTerms { get; set; }
        public string Comment { get; set; }
        public string ContactName { get; set; }
        public string CreditBalance { get; set; }
        public string CreditHold { get; set; }
        public string CreditLimit { get; set; }
        public string ClientWarranty { get; set; }
        public string ContractAdjustments { get; set; }
        public string ContractTermsConditions { get; set; }
        public string CreditManagerEmail { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyID { get; set; }
        public string CustomUpcharge { get; set; }
        public string DealerClientType { get; set; }
        public string DefaultHeldItemDeliveryMethod { get; set; }
        public string DefaultRetentionPct { get; set; }
        public string DropNumber { get; set; }
        public string EligibleForExtendedWarranty { get; set; }
        public string Email { get; set; }
        public string EnableAutoGenerateSentQuoteXMLFile { get; set; }
        public string ExtraData { get; set; }
        public string Freight { get; set; }
        public string FulfillmentType { get; set; }
        public string HasCreditLimit { get; set; }
        public string Installation { get; set; }
        public string IntegrationGroup { get; set; }
        public string InvoiceEDIAssembly { get; set; }
        public string InvoiceEDIClass { get; set; }
        public string InvoiceEDIPath { get; set; }
        public string InvoiceMethod { get; set; }
        public string ManufacturerWarranty { get; set; }
        public string NeedsAttention { get; set; }
        public string OrderAckEDIAssembly { get; set; }
        public string OrderAckEDIClass { get; set; }
        public string OrderAckEDIDirectory { get; set; }
        public string OrderAckType { get; set; }
        public string OrderIntegrationAssembly { get; set; }
        public string OrderIntegrationCaption { get; set; }
        public string OrderIntegrationClass { get; set; }
        public string PORequired { get; set; }
        public string PrepayStatus { get; set; }
        public string ProductionPriority { get; set; }
        public string ProposalTermsConditions { get; set; }
        public string QuoteClientMarkupSetupChargePct { get; set; }
        public string ReleaseScreensOption { get; set; }
        public string RequireQuoteVerification { get; set; }
        public string RequiresRetention { get; set; }
        public string RetailExtendedWarranty { get; set; }
        public string RetentionBillDateTimespan { get; set; }
        public string RouteCode { get; set; }
        public string ShipZone { get; set; }
        public string Status { get; set; }
        public string Tax1 { get; set; }
        public string Tax2 { get; set; }
        public string TaxExempt { get; set; }
        public string TaxID { get; set; }
        public string TwoStep { get; set; }
        public string UseCustomerListPriceCodes { get; set; }
        public string UsedForTesting { get; set; }
        public string UseShipToFax { get; set; }
        public string Delete { get; set; }

    }

}

