using System.Runtime.Serialization;
using iSabaya;

namespace AnyIDModel
{
    public class AnyID : PersistentEntity
    {
        public AnyID()
        {
        }

        public AnyID(string idType, string anyIDValue)
        {
            this.IDType = idType == AnyIDType.MSISDN.ToString() ? AnyIDType.MSISDN : AnyIDType.NATID;
            this.DisplayIDNo = anyIDValue;
        }

        //[DataMember(Name = "idNo")]
        public virtual string IDNo { get; set; }

        //[DataMember(Name = "idType")]
        public virtual AnyIDType IDType { get; set; }

        //[DataMember(Name = "status")]
        public virtual AnyIDStatus Status { get; set; } //Subscribed, Unsubscribed

        private string displayIDNo;
        public virtual string DisplayIDNo
        {
            get
            {
                return this.displayIDNo;
            }
            set
            {
                if (IDType == AnyIDType.MSISDN)
                    this.IDNo = Configuration.NormalizeMobilePhoneNo(value);
                else
                    this.IDNo = value;
                displayIDNo = value;
            }
        }

        public virtual AnyID FindOneOrDefault(Context context)
        {
            return context.PersistenceSession.QueryOver<AnyID>()
                .Where(e => e.IDNo == this.IDNo && e.IDType == this.IDType)
                .SingleOrDefault();
        }

        public override string ToString()
        {
            return "{" + this.IDType.ToString() + ", " + this.IDNo + ", " + this.Status.ToString() + "}";
        }
    }
}
