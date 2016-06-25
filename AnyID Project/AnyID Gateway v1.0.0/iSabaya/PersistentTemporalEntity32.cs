using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public abstract class PersistentTemporalEntity32 : PersistentEntity32, ITemporal
    {
        public PersistentTemporalEntity32()
        {
        }

        public PersistentTemporalEntity32(DateTime effectiveDate)
        {
            this.EffectivePeriod = new TimeInterval(effectiveDate);
        }

        public PersistentTemporalEntity32(DateTime effectiveDate, string reference, string remark)
        {
            this.EffectivePeriod = new TimeInterval(effectiveDate);
            this.Reference = reference;
            this.Remark = remark;
        }

        public PersistentTemporalEntity32(DateTime effectiveFrom, DateTime effectiveTo, string reference, string remark)
        {
            this.EffectivePeriod = new TimeInterval(effectiveFrom, effectiveTo);
            this.Reference = reference;
            this.Remark = remark;
        }

        public PersistentTemporalEntity32(TimeInterval effectivePeriod)
        {
            this.EffectivePeriod = effectivePeriod;
        }

        #region persistent

        public virtual TimeInterval EffectivePeriod { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Remark { get; set; }

        #endregion
        
        public virtual object PreviousInstance { get; set; }

        protected bool isDeleted = false;
        public virtual bool ToBeDeleted { get; set; }

        public virtual void ExpirePreviousEffectiveInstanceIfNecessary(Context context)
        {
        }

        public virtual void Initiate(Context context, TimeInterval effectivePeriod, UserAction approvedAction)
        {
            base.Initiate(context, approvedAction);
            if (TimeInterval.IsNullOrEmpty(effectivePeriod))
                throw new Exception(Messages.Genaral.InitiateEntityWithNullOrEmptyEffectivePeriod.Format(context.CurrentLanguage.Code, this.ToString(context.CurrentLanguage.Code)));
            this.EffectivePeriod = effectivePeriod;
        }

        public virtual void Terminate(DateTime expiryTS)
        {
            if (this.EffectivePeriod.From > expiryTS)
                throw new Exception(Messages.Genaral.TerminateEntityWithNullOrEmptyEffectivePeriod.Format(Configuration.CurrentConfiguration.DefaultLanguage.Code, this.ToString(Configuration.CurrentConfiguration.DefaultLanguage.Code)));
            this.EffectivePeriod.ExpiryDate = expiryTS;
            this.IsNotFinalized = false;
        }

        public virtual void Terminate(Context context, DateTime expiryTS)
        {
            if (this.EffectivePeriod.From > expiryTS)
                throw new Exception(Messages.Genaral.TerminateEntityWithNullOrEmptyEffectivePeriod.Format(context.CurrentLanguage.Code, this.ToString(context.CurrentLanguage.Code)));
            this.EffectivePeriod.ExpiryDate = expiryTS;
            this.IsNotFinalized = false;
        }

        public virtual bool IsEffectiveOn(DateTime date)
        {
            return (null == this.EffectivePeriod || this.EffectivePeriod.Includes(date));
        }

        public virtual bool IsEffective
        {
            get { return (null == this.EffectivePeriod || this.EffectivePeriod.Includes(DateTime.Now)); }
        }

        public override void Persist(Context context)
        {
            //if (null != this.EffectivePeriod && this.EffectivePeriod == TimeInterval.EmptyInterval)
            //    context.PersistenceSession.Delete(this);
            //else
            //    context.Persist(this);
            context.Persist(this);
        }
    }
}
