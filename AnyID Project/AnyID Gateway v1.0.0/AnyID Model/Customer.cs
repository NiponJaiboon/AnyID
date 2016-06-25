using System.Collections.Generic;
using iSabaya;
using System.Runtime.Serialization;

namespace AnyIDModel
{
    public enum DocumentType
    {
        Undefined,
        ใบสมัคร,
        ใบคำขอแก้ไขข้อมูล,
        บัตรประชาชน,
    }

    public enum IDType
    {
        U, //Undefined,
        C, //Corporate_Registration,
        I, //ID_Card,
        P, //Passport,
        R, //Bureaucracy_ID,
        O, //Other_Juristic_ID,
        F, //Financial_Institution,
        T, //Tax_ID,
        G, //Government_ID,
    }
    
    //[DataContract(Namespace = "http://schemas.datacontract.org/2004/07/AnyIDModel")]
    //[KnownType(typeof(Person))]
    //[KnownType(typeof(Organization))]
    public abstract partial class Customer : PersistentEntity, ICustomer
    {
        #region persistent
        public virtual string CISID { get; set; }
        public virtual string CurrentAddress { get; set; }
        /// <summary>
        /// member of Configuration.CustomerTypes
        /// </summary>
        public virtual string CustomerType { get; set; }
        public virtual string CustomerRM { get; set; }
        public virtual string CustomerSegment { get; set; }
        public virtual string FATCA { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string HomeBranchCode { get; set; }
        public virtual string IDNo { get; set; }
        public virtual IDType IDType { get; set; }
        public virtual string KYCLevel { get; set; }
        public virtual string Sanction { get; set; }
        public virtual string OfficePhoneNo { get; set; }
        public virtual string MailingAddress { get; set; }
        public virtual string OfficeAddress { get; set; }
        public virtual string RegisteredAddress { get; set; }

        #endregion

        public virtual IList<BankAccount> Accounts { get; set; }
        public abstract string FullNameThai { get; }
        public abstract string FullNameEnglish { get; }
        public abstract Customer ShallowCopy();

        public abstract void ReplaceMyProperties(Customer c);
        protected void ReplaceProperties(Customer c)
        {
            this.HomeBranchCode = c.HomeBranchCode;
            this.CurrentAddress = c.CurrentAddress;
            this.CustomerRM = c.CustomerRM;
            this.CustomerSegment = c.CustomerSegment;
            this.CustomerType = c.CustomerType;
            this.EmailAddress = c.EmailAddress;
            this.FATCA = c.FATCA;
            //this.IDNo = c.IDNo;
            //this.IDType = c.IDType;
            this.KYCLevel = c.KYCLevel;
            this.MailingAddress = c.MailingAddress;
            this.OfficeAddress = c.OfficeAddress;
            this.OfficePhoneNo = c.OfficePhoneNo;
            this.RegisteredAddress = c.RegisteredAddress;
            this.Sanction = c.Sanction;
        }
    }
}
