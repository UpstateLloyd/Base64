using System;
using CsvHelper.Configuration.Attributes;
using B64;

namespace Users
{
    public partial class Users
    {        
        public object BusinessSegmentDefault { get; set; }
        [Ignore]
        public Root ClientDefault { get; set; }
        [Ignore]
        public Group Group { get; set; }
        public object SalesRep { get; set; }
        public string UserId { get; set; }
        public string Id { get; set; }
        public object IntegrationId { get; set; }
        public string UserName { get; set; }
        public string QuoteHeaderConfig { get; set; }
        public Nullable<DateTimeOffset> LastUpdated { get; set; }
        public Nullable<DateTimeOffset> LastServerLogin { get; set; }
        public long BSuperUser { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Manufacturer { get; set; }
        public string SecurityXml { get; set; }
        public string GroupId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public string UserFax { get; set; }
        public string UserAddress1 { get; set; }
        public string UserAddress2 { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public string UserZip { get; set; }
        public string UserProjects { get; set; }
        public long MinMarkupPct { get; set; }
        public long MaxMarkupPct { get; set; }
        public long MinMarkupAmt { get; set; }
        public long MaxMarkupAmt { get; set; }
        public long TwoStepMarkupAmt { get; set; }
        public long TwoStepMarkupPct { get; set; }
        public Nullable<DateTimeOffset> LastMsgOfTheDayUpdated { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyAddress3 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }        
        public string CompanyFax { get; set; }        
        public string CompanyPhone { get; set; }        
        public string CompanyZip { get; set; }        
        public string CompanyEmail { get; set; }        
        public long MarkupDisplayType { get; set; }        
        public object UpdatePermissions { get; set; }      
        public int? Status { get; set; }   
        public object SalesRepId { get; set; }   
        public object WindowStoreDefaultId { get; set; }
        public object BusinessSegmentDefaultId { get; set; }
        public string ClientDefaultId { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public long DealerAdmin { get; set; }
        public long UserNamePrefix { get; set; }
        public object PasswordExpirationDate { get; set; }
        public object CustomDbLastUpdate { get; set; }
        public string ContactId { get; set; }
        public string ContactName { get; set; }
        public bool Engineer { get; set; }
        public string Custom5 { get; set; }
        public object Custom6 { get; set; }
        public object CacheOptionsComp { get; set; }
        public long RemoteSqlServerId { get; set; }
        public object Schedulable { get; set; }
        public Nullable<DateTimeOffset> LastDataModified { get; set; }
        public object ResourceSchedulingContactType { get; set; }
        public long UserContext { get; set; }
        public long TwoStep { get; set; }
        public object LastLoginTerminalServer { get; set; }
        public string CellPhone { get; set; }
        public bool ManufacturerRestrictedClients { get; set; }
        public object CompanyLogo { get; set; }
        public object EulaVersion { get; set; }
        public object PrintHeaderLastUpdated { get; set; }
        public object LastClientGrpChngViewed { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public bool AutoAddNewBrands { get; set; }
        public object Password { get; set; }
        public object GroupIntegrationId { get; set; }
        public object SalesRepIntegrationId { get; set; }
        public string ClientDefaultIntegrationId1 { get; set; }
        public object ClientDefaultIntegrationId2 { get; set; }
        public object ClientDefaultIntegrationId3 { get; set; }
        public object BusinessSegmentDefaultIntegrationId { get; set; }
        public bool Delete { get; set; }
    }

    public partial class Group
    {
        public string GroupId { get; set; }
        public string Id { get; set; }
        public object IntegrationId { get; set; }
        public string GroupName { get; set; }
        public string GroupSecurityXml { get; set; }
        public string GroupDescription { get; set; }
        public long GroupSecurityLevel { get; set; }
        public long GroupCanEditXml { get; set; }
        public long OrderBy { get; set; }
        public object LastUpdate { get; set; }
        public Nullable<DateTimeOffset> WtsLastUpdate { get; set; }
        public bool Delete { get; set; }
    }
}