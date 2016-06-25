using System;
using System.Runtime.Serialization;

namespace AnyIDModel
{
    //[DataContract(Namespace = "http://schemas.datacontract.org/2004/07/AnyIDModel")]
    public class Organization : Customer
    {
        //[DataMember]
        public virtual string NameThai { get; set; }
        //[DataMember]
        public virtual string NameEnglish { get; set; }
        //[DataMember]
        public virtual DateTime RegisteredDate { get; set; }
        public override string FullNameThai => this.NameThai;
        public override string FullNameEnglish => NameEnglish;

        public override Customer ShallowCopy()
        {
            return (Organization)this.MemberwiseClone();
        }

        public override void ReplaceMyProperties(Customer c)
        {
            base.ReplaceProperties(c);

            var p = (AnyIDModel.Organization)c;
            this.NameThai = p.NameThai;
            this.NameEnglish = p.NameEnglish;
            this.RegisteredDate = p.RegisteredDate;
        }

        public override string ToString()
        {
            return "{" + this.FullNameThai + ", " + this.FullNameEnglish + "}";
        }
    }
}
