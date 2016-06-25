using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AnyIDModel
{

    [ServiceContract]
    public interface IBankAccount
    {
        [DataMember]
        string AccountNo { get; set; }
        [DataMember]
        string Name { get; set; }
        [DataMember]
        string BankCode { get; set; }
        [DataMember]
        string BranchCode { get; set; }
        [DataMember]
        string Status { get; set; }
    }

    [ServiceContract]
    public interface IPerson : ICustomer
    {
        [DataMember]
        DateTime BirthDate { get; set; }
        [DataMember]
        string Gender { get; set; }
        [DataMember]
        string HomePhoneNo { get; set; }
        [DataMember]
        string MobilePhoneNo { get; set; }
        [DataMember]
        string FirstName { get; set; }
        [DataMember]
        string FirstNameEnglish { get; set; }
        [DataMember]
        string LastName { get; set; }
        [DataMember]
        string LastNameEnglish { get; set; }
        [DataMember]
        string MaritalStatus { get; set; }
    }

    [ServiceContract]
    public interface IOrganization : ICustomer
    {
        [DataMember]
        string NameThai { get; set; }
        [DataMember]
        string NameEnglish { get; set; }
        [DataMember]
        DateTime RegisteredDate { get; set; }

    }

    [ServiceContract]
    [ServiceKnownType(typeof(IPerson))]
    [ServiceKnownType(typeof(IOrganization))]
    public interface ICustomer
    {
        [DataMember]
        string CISID { get; set; }
        [DataMember]
        string CurrentAddress { get; set; }
        [DataMember]
        string CustomerType { get; set; }
        [DataMember]
        string CustomerRM { get; set; }
        [DataMember]
        string CustomerSegment { get; set; }
        [DataMember]
        string FATCA { get; set; }
        [DataMember]
        string EmailAddress { get; set; }
        [DataMember]
        string HomeBranchCode { get; set; }
        [DataMember]
        string IDNo { get; set; }
        [DataMember]
        IDType IDType { get; set; }
        [DataMember]
        string KYCLevel { get; set; }
        [DataMember]
        string Sanction { get; set; }
        [DataMember]
        string OfficePhoneNo { get; set; }
        [DataMember]
        string MailingAddress { get; set; }
        [DataMember]
        string OfficeAddress { get; set; }
        [DataMember]
        string RegisteredAddress { get; set; }
    }
}
