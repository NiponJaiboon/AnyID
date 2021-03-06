using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public enum RateType
    {
        FixedRateOnly,
        PercentageRateOnly,
        FixedAndPercentageRates,
        //PercentagePerAnnum_365Days,
        //PercentagePerAnnum_ActualDays,
    }


    public abstract class MultiBracketRateSchedule<TBracketBound, TRate> : PersistentTemporalEntity
        where TBracketBound : IComparable<TBracketBound> //, ISimpleMath<TBracketQuantity>
        //where TValue : ISimpleMath<TValue>
    {
        public delegate void StepEventHandler(BracketedRate<TBracketBound, TRate> step, TRate stepRateAmount);

        public MultiBracketRateSchedule()
        {
        }

        public MultiBracketRateSchedule(MultiBracketRateSchedule<TBracketBound, TRate> original)
        {
            this.Code = original.Code;
            this.Title = original.Title;
            this.Description = original.Description;
            this.Reference = original.Reference;
            this.Remark = original.Remark;
            this.EffectivePeriod = new TimeInterval(DateTime.Now);
            this.ApplyRateToAmountOverBracketLowerBound = original.ApplyRateToAmountOverBracketLowerBound;
            this.LowerBoundIsInclusive = original.LowerBoundIsInclusive;
        }

        public MultiBracketRateSchedule(String code, MultilingualString title, String description,
                            bool lowerBoundIsInclusive, bool applyRateToAmountOverBracketLowerBound,
                            String reference, String remark, DateTime effectiveDate, User updatedBy)
        {
            this.Code = code;
            this.Title = title;
            this.Description = description;
            this.Reference = reference;
            this.Remark = remark;
            this.EffectivePeriod = new TimeInterval(effectiveDate);
            this.ApplyRateToAmountOverBracketLowerBound = applyRateToAmountOverBracketLowerBound;
            this.LowerBoundIsInclusive = lowerBoundIsInclusive;
        }

        #region persistent

        public virtual MultilingualString Title { get; set; }
        public virtual String Description { get; set; }
        public virtual RateType RateType { get; set; }
        public virtual DateTime UpdatedTS { get; set; }
        /// <summary>
        /// Default is true.
        /// </summary>
        public virtual bool ApplyRateToAmountOverBracketLowerBound { get; set; }
        /// <summary>
        /// If true, the bracket will satisfy condition: lower bound &lt;= amount &lt; upper bound.
        /// Otherwise the satisfing condition is: lower bound &lt; amount &lt;= upper bound.
        /// Default is false.
        /// </summary>
        public virtual bool LowerBoundIsInclusive { get; set; }

        protected IList<BracketedRate<TBracketBound, TRate>> brackets;
        public virtual IList<BracketedRate<TBracketBound, TRate>> Brackets
        {
            get
            {
                if (brackets == null)
                    brackets = new List<BracketedRate<TBracketBound, TRate>>();
                return brackets;
            }
            set { brackets = value; }
        }

        #endregion persistent

        public virtual BracketedRate<TBracketBound, TRate>
            GetBracket(TBracketBound stepQuantity)
        {
            if (this.LowerBoundIsInclusive)
            {
                foreach (BracketedRate<TBracketBound, TRate> step in Brackets)
                {
                    if (0 <= stepQuantity.CompareTo(step.LowerBound)
                        && 0 > stepQuantity.CompareTo(step.UpperBound))
                        return step;
                }
            }
            else
            {
                foreach (BracketedRate<TBracketBound, TRate> step in Brackets)
                {
                    if (0 < stepQuantity.CompareTo(step.LowerBound)
                        && 0 >= stepQuantity.CompareTo(step.UpperBound))
                        return step;
                }
            }
            throw new iSabayaException(Messages.NoQualifiedBracket(stepQuantity.ToString()));
        }

        //public virtual void ApplyStepRateBreakdown(TValue amount, double percentageRateDivisor, ref TValue total,
        //                                            StepEventHandler stepFinishedEventHandler)
        //{
        //    T stepAmount;
        //    T stepRateAmount;
        //    double divisor = 100d * percentageRateDivisor;
        //    if (this.isLowerBoundInclusive)
        //    {
        //        foreach (Bracket<TBracketQuantity, TValue> step in Steps)
        //        {
        //            if (0 >= step.FromAmount.CompareTo(amount))
        //            {
        //                stepAmount = (0 > amount.CompareTo(step.ToAmount) ? amount : step.ToAmount)
        //                                .Subtract(step.FromAmount);
        //                stepRateAmount = stepAmount.Multiply(step.PercentageRate / divisor);
        //                total = total.Add(stepRateAmount);
        //                if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (Bracket<TBracketQuantity, TValue> step in Steps)
        //        {
        //            if (0 > step.FromAmount.CompareTo(amount))
        //            {
        //                stepAmount = (0 >= amount.CompareTo(step.ToAmount) ? amount : step.ToAmount)
        //                                .Subtract(step.FromAmount);
        //                stepRateAmount = stepAmount.Multiply(step.PercentageRate / divisor);
        //                total = total.Add(stepRateAmount);
        //                if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
        //            }
        //        }
        //    }
        //}

        //public virtual void Persist(Context context)
        //{
        //    //context.PersistenceSession.SaveOrUpdate(this);
        //    //foreach (SingleStepRate sr in this.Steps)
        //    //{
        //    //    sr.Persist(context);
        //    //}
        //}

        //public static MultiStepRate<T> Find(Context context, int id)
        //{
        //    return (MultiStepRate<T>)context.PersistenceSession.Get(typeof(MultiStepRate<T>), id);
        //}

        //public static IList<MultiStepRate<T>> List(Context context)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(MultiStepRate<T>));
        //    return crit.List<MultiStepRate<T>>();
        //}


        public virtual void Validate()
        {
            foreach (BracketedRate<TBracketBound, TRate> e in this.Brackets)
            {
                if (((IComparable<TBracketBound>)e.LowerBound).CompareTo(e.UpperBound) > 0)
                    throw new Exception("Bracket lower bound is greater than upper bound.");
            }
        }

        public override void Persist(Context context)
        {
            Validate();
            
            if (null != this.Title)
                this.Title.Persist(context);

            context.PersistenceSession.SaveOrUpdate(this);
            int seqNo = -1;
            foreach (BracketedRate<TBracketBound, TRate> e in this.Brackets)
            {
                e.SeqNo = ++seqNo;
                e.Schedule = this;
                context.PersistenceSession.SaveOrUpdate(e);
            }
        }
    }
}