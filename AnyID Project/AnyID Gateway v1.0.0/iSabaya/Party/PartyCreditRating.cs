using iSabaya;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public class PartyCreditRating
    {
        public PartyCreditRating()
        {
        }

        public PartyCreditRating(Party party, Organization ratingAgency, String rating, DateTime ratedDate)
        {
            this.party = party;
            this.ratingAgency = ratingAgency;
            this.rating = rating;
            this.effectivePeriod = new TimeInterval(ratedDate);
        }

        #region persistent

        private int partyCreditRatingID;
        public virtual int PartyCreditRatingID
        {
            get { return this.partyCreditRatingID; }
            set { this.partyCreditRatingID = value; }
        }

        private Party party;
        public virtual Party Party
        {
            get { return party; }
            set { party = value; }
        }

        protected Organization ratingAgency;
        public virtual Organization RatingAgency
        {
            get { return this.ratingAgency; }
            set { this.ratingAgency = value; }
        }

        protected String rating;
        public virtual String Rating
        {
            get { return this.rating; }
            set { this.rating = value; }
        }

        protected String reference;
        public virtual String Reference
        {
            get { return reference; }
            set { this.reference = value; }
        }

        protected String remark;
        public virtual String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        #endregion persistent

        public override string ToString()
        {
            return this.Rating + " (" + this.RatingAgency.ToString() + ")";
        }

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }

        public static PartyCreditRating Find(Context context, int ID)
        {
            return (PartyCreditRating)context.PersistenceSession.Get<PartyCreditRating>(ID);
        }
    }
}