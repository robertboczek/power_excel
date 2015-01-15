using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GraphCaller
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        FBAdAccount GetAdAccount(string access_token, Int64 account_id);
    }

    [DataContract]
    public class FBAdAccount
    {
        //        [DataMember]
        //        public List<FBAccountGroup> AccountGroups { get; set; }
        [DataMember]
        public Int64 AccountId { get; set; }
        [DataMember]
        public Int32 AccountStatus { get; set; }
        [DataMember]
        public float Age { get; set; }
        [DataMember]
        public FBAgencyClientDeclaration AgencyClientDeclaration { get; set; }
        [DataMember]
        public string AmountSpent { get; set; }
        [DataMember]
        public Int32 Balance { get; set; }
        [DataMember]
        public string BusinessCity { get; set; }
        [DataMember]
        public string BusinessCountryCode { get; set; }
        [DataMember]
        public string BusinessName { get; set; }
        [DataMember]
        public string BusinessState { get; set; }
        [DataMember]
        public string BusinessStreet { get; set; }
        [DataMember]
        public string BusinessStreet2 { get; set; }
        [DataMember]
        public List<string> Capabilities { get; set; }
        [DataMember]
        public DateTime CreatedTime { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public Int32 DailySpendLimit { get; set; }
        [DataMember]
        public Int64 EntAdvertiser { get; set; }
        [DataMember]
        public string FundingSource { get; set; }
        //[DataMember]
        //public List<string> FundingSourceDetails { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public Int32 IsPersonal { get; set; }
        [DataMember]
        public Int64 MediaAgency { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool OffsitePixelsTosAccepted { get; set; }
        [DataMember]
        public Int64 Partner { get; set; }
        [DataMember]
        public Int32 SpendCap { get; set; }
        [DataMember]
        public Int32 TimezoneId { get; set; }
        [DataMember]
        public string TimezoneName { get; set; }
        [DataMember]
        public Int32 TimezoneOffsetHoursUtc { get; set; }
        [DataMember]
        public List<string> TosAccepted { get; set; }
        [DataMember]
        //        public List<FBUser> Users { get; set; }
        //        [DataMember]
        public Int32 TaxIdStatus { get; set; }
    }

    [DataContract]
    public class FBUser
    {
        [DataMember]
        public UInt64 Id { get; set; }
        [DataMember]
        public List<string> permissions { get; set; }
        [DataMember]
        public string Role { get; set; }
    }

    [DataContract]
    public class FBAccountGroup
    {
        [DataMember]
        public string AccountGroupID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Status { get; set; }
    }

    [DataContract]
    public class FBAgencyClientDeclaration
    {
        [DataMember]
        public Int32 AgencyRepresentingClient { get; set; }
        [DataMember]
        public Int32 ClientBasedInFrance { get; set; }
        [DataMember]
        public string ClientCity { get; set; }
        [DataMember]
        public string ClientCountryCode { get; set; }
        [DataMember]
        public string ClientEMailAddress { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string ClientPostalCode { get; set; }
        [DataMember]
        public string ClientProvince { get; set; }
        [DataMember]
        public string ClientStreet { get; set; }
        [DataMember]
        public string ClientStreet2 { get; set; }
        [DataMember]
        public Int32 HasWrittenMandateFromAdvertiser { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "GraphCaller.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
