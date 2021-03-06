using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class GeographicAddress
    {
        public GeographicAddress()
        {
        }

        #region persistent

        public virtual long ID { get; set; }
        public virtual MultilingualString AddressNo { get; set; }
        public virtual MultilingualString Street1 { get; set; }
        public virtual MultilingualString Street2 { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string MobilePhones { get; set; }
        public virtual string Phones { get; set; }
        public virtual string Faxes { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }
        public virtual TreeListNode Category { get; set; }

        //Static
        protected static TreeListNode categoryRoot;
        public static TreeListNode CategoryRoot { get; set; }
        public virtual Country Country { get; set; }
        public virtual string FormattedAddress { get; set; }

        private MultilingualString regionLevel1Name;
        public virtual MultilingualString RegionLevel1Name
        {
            get
            {
                if (null == RegionLevel1)
                    return regionLevel1Name;
                else
                    return RegionLevel1.Name;
            }
            set
            {
                regionLevel1Name = value;
            }
        }

        private MultilingualString regionLevel2Name;
        public virtual MultilingualString RegionLevel2Name
        {
            get
            {
                if (null == RegionLevel2)
                    return regionLevel2Name;
                else
                    return RegionLevel2.Name;
            }
            set
            {
                regionLevel2Name = value;
            }
        }

        private MultilingualString regionLevel3Name;
        public virtual MultilingualString RegionLevel3Name
        {
            get
            {
                if (null == RegionLevel3)
                    return regionLevel3Name;
                else
                    return RegionLevel3.Name;
            }
            set
            {
                regionLevel3Name = value;
            }
        }

        public virtual Party Party { get; set; }
        public virtual String Reference { get; set; }
        public virtual String Remark { get; set; }

        public virtual GeographicRegion RegionLevel3 { get; set; }
        public virtual GeographicRegion RegionLevel2 { get; set; }
        public virtual GeographicRegion RegionLevel1 { get; set; }

        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        public virtual User UpdatedBy { get; set; }

        #endregion persistent

        public virtual void Persist(Context context)
        {
            if (AddressNo != null)
                AddressNo.Persist(context);
            if (Building != null)
                Building.Persist(context);
            if (Street1 != null)
                Street1.Persist(context);
            if (Street2 != null)
                Street2.Persist(context);

            if (regionLevel1Name != null)
                regionLevel1Name.Persist(context);
            if (regionLevel2Name != null)
                regionLevel2Name.Persist(context);
            if (regionLevel3Name != null)
                regionLevel3Name.Persist(context);

            context.PersistenceSession.SaveOrUpdate(this);
        }

        public static GeographicAddress Find(Context context, int id)
        {
            return (GeographicAddress)context.PersistenceSession.Get(typeof(GeographicAddress), id);
        }

        //public virtual void Update(Context context)
        //{
        //    if (street1 != null)
        //    {
        //        street1.Update(context);
        //    }
        //    if (street2 != null)
        //    {
        //        street2.Update(context);
        //    }
        //    if (addressNo != null)
        //    {
        //        addressNo.Update(context);
        //    }
        //    context.PersistenceSession.Update(this);
        //}

        public static IList<GeographicAddress> FindByPerson(Context context, Person person)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(GeographicAddress));
            crit.Add(Expression.Eq("Party", person));
            return crit.List<GeographicAddress>();
        }

        protected MultilingualString building;
        public virtual MultilingualString Building
        {
            get { return building; }
            set { building = value; }
        }

        protected String floor;
        public virtual String Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        protected string roomNo;
        public virtual string RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        public virtual string ToLog()
        {
            StringBuilder builder = new StringBuilder();

            return builder.ToString();
        }

        public virtual String ToString(String languageCode)
        {
            StringBuilder sb = new StringBuilder();
            if (null != this.AddressNo) sb.Append(this.AddressNo.ToString(languageCode));
            if (this.Street1 != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.Street1.ToString(languageCode));
            }
            if (this.Street2 != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.Street2.ToString(languageCode));
            }
            if (this.RegionLevel3Name != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.RegionLevel3Name.ToString(languageCode));
            }
            if (this.RegionLevel2Name != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.RegionLevel2Name.ToString(languageCode));
            }
            if (this.RegionLevel1Name != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.RegionLevel1Name.ToString(languageCode));
            }
            if (this.Country != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.Country.ToString(languageCode));
            }
            if (this.PostalCode != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.PostalCode);
            }
            return sb.ToString();
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (null != this.AddressNo) sb.Append(this.AddressNo.ToString());
            if (this.Street1 != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.Street1.ToString());
            }
            if (this.Street2 != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.Street2.ToString());
            }
            if (this.RegionLevel3Name != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.RegionLevel3Name.ToString());
            }
            if (this.RegionLevel2Name != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.RegionLevel2Name.ToString());
            }
            if (this.RegionLevel1Name != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.RegionLevel1Name.ToString());
            }
            if (this.Country != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.Country.ToString());
            }
            if (this.PostalCode != null)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(this.PostalCode);
            }
            return sb.ToString();
        }
    }
} // iSabaya
