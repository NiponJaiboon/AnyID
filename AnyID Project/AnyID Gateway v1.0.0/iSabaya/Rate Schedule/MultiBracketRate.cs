using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{
    [Serializable]
    public class MultiStepRate<TBracketQuantity, TAmount> 
        where TBracketQuantity : IComparable<TBracketQuantity>, 
                                ISimpleMath<TBracketQuantity>
        where TAmount : ISimpleMath<TAmount>
    {
        public delegate void StepEventHandler(Bracket<TBracketQuantity, TAmount> step, TAmount stepRateAmount);

        public MultiStepRate()
        {
        }

        public MultiStepRate(String code, MultilingualString title, MultilingualString description,
                            bool isLowerBoundInclusive, bool applyRateToTheEntireAmount,
                            String reference, String remark, DateTime effectiveDate, Person updatedBy)
        {
            this.code = code;
            this.title = title;
            this.description = description;
            this.reference = reference;
            this.remark = remark;
            this.effectivePeriod = new TimeInterval(effectiveDate);
            this.applyRateToTheEntireAmount = applyRateToTheEntireAmount;
            this.isLowerBoundInclusive = isLowerBoundInclusive;
        }

        #region persistent

        protected String code = "";
        public virtual String Code
        {
            get { return code; }
            set { code = value; }
        }

        protected MultilingualString title;
        public virtual MultilingualString Title
        {
            get { return title; }
            set { title = value; }
        }

        protected MultilingualString description;
        public virtual MultilingualString Description
        {
            get { return description; }
            set { description = value; }
        }

        protected String reference;
        public virtual String Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        protected String remark;
        public virtual String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        protected Person updatedBy;
        public virtual Person UpdatedBy
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

        protected bool applyRateToTheEntireAmount = true;
        public virtual bool ApplyRateToTheEntireAmount
        {
            get { return applyRateToTheEntireAmount; }
            set { applyRateToTheEntireAmount = value; }
        }

        protected bool isLowerBoundInclusive;
        public virtual bool IsLowerBoundInclusive
        {
            get { return isLowerBoundInclusive; }
            set { isLowerBoundInclusive = value; }
        }

        private IList<Bracket<TBracketQuantity, TAmount>> steps;
        public virtual IList<Bracket<TBracketQuantity, TAmount>> Steps
        {
            get
            {
                if (steps == null)
                {
                    steps = new List<Bracket<TBracketQuantity, TAmount>>();
                }
                return steps;
            }
            set { steps = value; }
        }

        #endregion persistent

        public virtual double GetRate(TBracketQuantity stepQuantity)
        {
            if (this.isLowerBoundInclusive)
            {
                foreach (Bracket<TBracketQuantity, TAmount> step in Steps)
                {
                    if (0 <= stepQuantity.CompareTo(step.FromAmount) 
                        && 0 > stepQuantity.CompareTo(step.ToAmount))
                        return step.PercentageRate;
                }
            }
            else
            {
                foreach (Bracket<TBracketQuantity, TAmount> step in Steps)
                {
                    if (0 < stepQuantity.CompareTo(step.FromAmount) 
                        && 0 >= stepQuantity.CompareTo(step.ToAmount))
                        return step.PercentageRate;
                }
            }
            throw new Exception("Can't find rate.");
        }

        public virtual void ApplyStepRateBreakdown(TAmount amount, double percentageRateDivisor, ref TAmount total,
                                                    StepEventHandler stepFinishedEventHandler)
        {
            T stepAmount;
            T stepRateAmount;
            double divisor = 100d * percentageRateDivisor;
            if (this.isLowerBoundInclusive)
            {
                foreach (Bracket<TBracketQuantity, TAmount> step in Steps)
                {
                    if (0 >= step.FromAmount.CompareTo(amount))
                    {
                        stepAmount = (0 > amount.CompareTo(step.ToAmount) ? amount : step.ToAmount)
                                        .Subtract(step.FromAmount);
                        stepRateAmount = stepAmount.Multiply(step.PercentageRate / divisor);
                        total = total.Add(stepRateAmount);
                        if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
                    }
                }
            }
            else
            {
                foreach (Bracket<TBracketQuantity, TAmount> step in Steps)
                {
                    if (0 > step.FromAmount.CompareTo(amount))
                    {
                        stepAmount = (0 >= amount.CompareTo(step.ToAmount) ? amount : step.ToAmount)
                                        .Subtract(step.FromAmount);
                        stepRateAmount = stepAmount.Multiply(step.PercentageRate / divisor);
                        total = total.Add(stepRateAmount);
                        if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
                    }
                }
            }
        }

        //public virtual void Save(iSabayaContext context)
        //{
        //    //context.PersistencySession.SaveOrUpdate(this);
        //    //foreach (SingleStepRate sr in this.Steps)
        //    //{
        //    //    sr.Save(context);
        //    //}
        //}

        //public static MultiStepRate<T> Find(iSabayaContext context, int id)
        //{
        //    return (MultiStepRate<T>)context.PersistencySession.Get(typeof(MultiStepRate<T>), id);
        //}

        //public static IList<MultiStepRate<T>> List(iSabayaContext context)
        //{
        //    ICriteria crit = context.PersistencySession.CreateCriteria(typeof(MultiStepRate<T>));
        //    return crit.List<MultiStepRate<T>>();
        //}
    }
}