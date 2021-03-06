using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class DurationRateSchedule //: PersistentTemporalEntity
    {
        public DurationRateSchedule()
            : base()
        {
        }


        #region persistent

        public virtual int ID { get; set; }

        protected String code = "";
        public virtual String Code { get; set; }
        public virtual String Description { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }        /// <summary>
        /// Default is false.
        /// </summary>
        public virtual bool LowerBoundIsInclusive { get; set; }
        public virtual String Reference { get; set; }
        public virtual String Remark { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual DateTime UpdatedTS { get; set; }

        protected IList<BracketedDurationRate> brackets;
        public virtual IList<BracketedDurationRate> Brackets
        {
            get
            {
                if (brackets == null)
                    brackets = new List<BracketedDurationRate>();
                return brackets;
            }
            set { brackets = value; }
        }

        #endregion persistent

        public virtual BracketedDurationRate GetBracket(TimeDuration duration)
        {
            if (this.LowerBoundIsInclusive)
            {
                foreach (BracketedDurationRate step in Brackets)
                {
                    if (step.LowerBound <= duration && duration < step.UpperBound)
                        return step;
                }
            }
            else
            {
                foreach (BracketedDurationRate step in Brackets)
                {
                    if (step.LowerBound < duration && duration <= step.UpperBound)
                        return step;
                }
            }
            return null;
        }

        //public virtual void Persist(Context context)
        //{
        //    context.PersistenceSession.SaveOrUpdate(this);
        //    foreach (BracketedDurationRate sr in this.Brackets)
        //    {
        //        sr.Schedule = this;
        //        context.PersistenceSession.SaveOrUpdate(sr);
        //    }
        //}

        /// <summary>
        /// Return (bracket.FixedAmountRate + (amount * (bracket.PercentageRate / (100 * divisor)))
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="percentageRateDivisor"></param>
        /// <returns></returns>
        public virtual Money ApplyRate(TimeDuration duration, Money amount,
                                        double percentageRateDivisor,
                                        out BracketedMoneyRate moneyBracket)
        {
            BracketedDurationRate bracket = this.GetBracket(duration);
            MoneyRateSchedule moneyRateSchdule = bracket.MoneyRateSchedule;
            Money rate;
            if (null == bracket)
            {
                moneyBracket = null;
                rate = new Money(0m, amount.Currency);
            }
            else
                rate = moneyRateSchdule.ApplyRate(amount, percentageRateDivisor, out moneyBracket);
            return rate;
        }

        public static DurationRateSchedule Find(Context context, String taxCode)
        {
            return Find(context, taxCode, DateTime.Now);
        }

        public static DurationRateSchedule Find(Context context, String taxCode, DateTime when)
        {
            return context.PersistenceSession.CreateCriteria(typeof(DurationRateSchedule))
                            .Add(Expression.Eq("Code", taxCode))
                            .Add(Expression.Le("EffectivePeriod.From", when))
                            .Add(Expression.Ge("EffectivePeriod.To", when))
                            .UniqueResult<DurationRateSchedule>();
        }

        public static DurationRateSchedule Find(Context context, int id)
        {
            return context.PersistenceSession.Get<DurationRateSchedule>(id);
        }

        public static IList<DurationRateSchedule> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria(typeof(DurationRateSchedule))
                            .List<DurationRateSchedule>();
        }
    }
}