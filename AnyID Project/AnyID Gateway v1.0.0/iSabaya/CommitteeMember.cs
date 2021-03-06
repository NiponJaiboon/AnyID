using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public class CommitteeMember
    {
        #region persistent

        public virtual int CommitteeMemberID 
        {
            get;
            set;
        }

        private Person member;
        public virtual Person Member
        {
            get { return member; }
            set { member = value; }
        }

        private Party committeeOf;
        public virtual Party CommitteeOf
        {
            get { return committeeOf; }
            set { committeeOf = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        private bool isNominatedByEmployer;
        public virtual bool IsNominatedByEmployer
        {
            get { return isNominatedByEmployer; }
            set { isNominatedByEmployer = value; }
        }

        protected TreeListNode role;
        public virtual TreeListNode Role
        {
            get { return role; }
            set { role = value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        #endregion persistent
        
        //public virtual Employer Employer
        //{
        //    get { return (Employer)committeeOf; }
        //    set { committeeOf = value; }
        //}
        
        //public virtual ProvidentFund Fund
        //{
        //    get { return (ProvidentFund)committeeOf; }
        //    set { committeeOf = value; }
        //}

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }
    }
}

