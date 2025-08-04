namespace B64
{
    
    class ClientsTaxCodes
    {
        public Vendor Vendor { get; set; }
        public string ID { get; set; }
        public string IntegrationId { get; set; }
        public string VendorID { get; set; }
        public string Vendor_IntegrationID { get; set; }
        public string Name { get; set; }
        public string CityRate { get; set; }
        public string CountyRate { get; set; }
        public string StateRate { get; set; }
        public bool GroupTwoMultiplicative { get; set; }
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
        public bool Delete { get; set; }
    }
}
