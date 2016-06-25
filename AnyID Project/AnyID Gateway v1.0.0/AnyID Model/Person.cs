using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSabaya;
using System.Runtime.Serialization;

namespace AnyIDModel
{
    public class Person : Customer
    {
        public virtual DateTime BirthDate { get; set; }
        public virtual string Gender { get; set; }
        public virtual string HomePhoneNo { get; set; }
        public virtual string MobilePhoneNo { get; set; }

        //[DataMember(Name = "FirstNameThai")]
        public virtual string FirstName { get; set; }

        //[DataMember]
        public virtual string FirstNameEnglish { get; set; }

        //[DataMember(Name = "LastNameThai")]
        public virtual string LastName { get; set; }

        //[DataMember]
        public virtual string LastNameEnglish { get; set; }

        public virtual string MaritalStatus { get; set; }
        public override string FullNameThai => FirstName + " " + LastName;
        public override string FullNameEnglish => FirstNameEnglish + " " + LastNameEnglish;

        public override Customer ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public override void ReplaceMyProperties(Customer c)
        {
            base.ReplaceProperties(c);

            var p = ((AnyIDModel.Person)c);
            this.BirthDate = p.BirthDate;
            this.Gender = p.Gender;
            this.HomePhoneNo = p.HomePhoneNo;
            this.MaritalStatus = p.MaritalStatus;
            this.MobilePhoneNo = p.MobilePhoneNo;
            this.FirstName = p.FirstName;
            this.LastName = p.LastName;
            this.FirstNameEnglish = p.FirstNameEnglish;
            this.LastNameEnglish = p.LastNameEnglish;
        }

        public override string ToString()
        {
            return "{" + this.FullNameThai + ", " + this.FullNameEnglish + "}";
        }
    }
}
