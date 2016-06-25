using System.Runtime.Serialization;

namespace ProxyRegistraGateway
{
    [DataContract]
    public class Header
    {
        [DataMember]
        public virtual string referenceNo { get; set; }

        [DataMember]
        public virtual string transactionDateTime { get; set; }

        [DataMember]
        public virtual string serviceName { get; set; }

        [DataMember]
        public virtual string systemCode { get; set; }

        [DataMember]
        public virtual string channelId { get; set; }

        public virtual string LogTitle
        {
            get { return systemCode + "." + channelId; }
        }
    }

    [DataContract]
    public class AnyID
    {
        [DataMember]
        public virtual string IDNo { get; set; }

        [DataMember]
        public virtual string IDType { get; set; }

        public override string ToString()
        {
            return IDType + " " + IDNo;
        }
    }

    [DataContract]
    public class BankAccount
    {
        [DataMember]
        public virtual string AccountNo { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        [DataMember]
        public virtual string AccountName { get; set; }
    }

    [DataContract]
    [KnownType(typeof(Person))]
    [KnownType(typeof(Organization))]
    public class Customer
    {
        [DataMember]
        public string CISID { get; set; }
    }

    [DataContract]
    public class Person : Customer
    {
        [DataMember]
        public string FirstName { get; set; }

        //[DataMember]
        //public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }

    [DataContract]
    public class Organization : Customer
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string RegisteredDate { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class AccountProxy
    {
        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public AnyID AnyID { get; set; }

        [DataMember]
        public BankAccount BankAccount { get; set; }

        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public virtual string DummyAccountNo { get; set; }

        [DataMember]
        public string RegistrationID { get; set; }

        [DataMember]
        public string RegistrationTimestamp { get; set; }

        [DataMember]
        /// <summary>
        /// Either Active or Inactive
        /// </summary>
        public string Status { get; set; }
    }
}