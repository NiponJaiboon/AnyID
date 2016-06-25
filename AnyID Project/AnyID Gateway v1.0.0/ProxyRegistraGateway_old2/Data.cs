using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProxyGateway
{
    [DataContract]
    public class Response
    {
        [DataMember]
        string Code { get; set; }
        string Description { get; set; }
    }


    [DataContract]
    public class AnyID
    {
        /// <summary>
        /// Mobile phone no. or Thai Citizen ID no.
        /// </summary>
        [DataMember]
        public virtual string IDNo { get; set; }

        /// <summary>
        /// MSISDN or NATID
        /// </summary>
        [DataMember]
        public virtual string IDType { get; set; }

        /// <summary>
        /// Either Subscribed or Unsubscribed
        /// </summary>
        [DataMember]
        public string Status { get; set; }
    }

    /// <summary>
    /// Always DUMMY account
    /// </summary>
    [DataContract]
    public class BankAccount
    {
        [DataMember]
        public virtual string DummyAccountNo { get; set; }
        [DataMember]
        public virtual string DisplayName { get; set; }
        [DataMember]
        public virtual string AccountName { get; set; }
        [DataMember]
        public virtual Party AccountOwner { get; set; }
    }

    [DataContract]
    [KnownType(typeof(Person))]
    [KnownType(typeof(Organization))]
    public class Party
    {
        [DataMember]
        string CISID { get; set; }
    }

    [DataContract]
    public class Person : Party
    {
        [DataMember]
        string FirstName { get; set; }

        [DataMember]
        string MiddleName { get; set; }

        [DataMember]
        string LastName { get; set; }
    }

    [DataContract]
    public class Organization : Party
    {
        [DataMember]
        string Name { get; set; }

        [DataMember]
        DateTime RegisteredDate { get; set; }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class AccountProxy
    {
        [DataMember]
        public AnyID AnyID { get; set; }

        [DataMember]
        public BankAccount BankAccount { get; set; }

        [DataMember]
        public string RegistrationID { get; set; }

        [DataMember]
        public DateTime RegistrationTimestamp { get; set; }

        [DataMember]
        /// <summary>
        /// Either Active or Inactive
        /// </summary>
        public string Status { get; set; }
    }
}
