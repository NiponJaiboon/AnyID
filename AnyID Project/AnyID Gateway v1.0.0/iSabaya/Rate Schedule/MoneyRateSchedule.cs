using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class MoneyRateSchedule : MultiBracketRateSchedule<Money, SingleMoneyRate> //: RateSchedule<Money>
    {
        public MoneyRateSchedule()
            : base()
        {
        }
        
        public MoneyRateSchedule(MoneyRateSchedule original)
            : base(original)
        {
            BracketedMoneyRate newRate;
            foreach (BracketedMoneyRate br in original.Brackets)
            {
                this.Brackets.Add(newRate = new BracketedMoneyRate(br));
                newRate.Schedule = this;
            }

        }

        private new IList<BracketedMoneyRate> brackets;
        public new virtual IList<BracketedMoneyRate> Brackets
        {
            get
            {
                if (this.brackets == null)
                    this.brackets = new List<BracketedMoneyRate>();
                return (IList<BracketedMoneyRate>)this.brackets;
            }
            set
            {
                this.brackets = value;
            }
        }

        public new virtual BracketedMoneyRate GetBracket(Money amount)
        {
            if (this.LowerBoundIsInclusive)
            {
                foreach (BracketedMoneyRate step in Brackets)
                {
                    if (step.LowerBound <= amount && amount < step.UpperBound)
                        return step;
                }
            }
            else
            {
                foreach (BracketedMoneyRate step in Brackets)
                {
                    if (step.LowerBound < amount && amount <= step.UpperBound)
                        return step;
                }
            }
            return null;
        }

        //public override void Persist(Context context)
        //{
        //    if (null != base.Title) 
        //        base.Title.Persist(context);
            
        //    context.PersistenceSession.SaveOrUpdate(this);
        //    foreach (BracketedMoneyRate sr in this.Brackets)
        //    {
        //        sr.Schedule = this;
        //        context.PersistenceSession.SaveOrUpdate(sr);
        //    }
        //}

        public virtual Money ApplyRate(Money amount)
        {
            return ApplyRate(amount, 1d);
        }

        public virtual Money ApplyRate(Money amount, double percentageRateDivisor)
        {
            BracketedMoneyRate bracket;
            return ApplyRate(amount, percentageRateDivisor, out bracket);
        }

        public virtual Money ApplyRate(Money amount, out BracketedMoneyRate bracket)
        {
            return ApplyRate(amount, 1d, out bracket);
        }

        public virtual Money ApplyRate(Money amount, double percentageRateDivisor,
                                        out BracketedMoneyRate bracket)
        {
            //bracket = (BracketedMoneyRate)base.GetBracket(amount);
            bracket = this.GetBracket(amount);
            if (null == bracket) return new Money(0m, amount.Currency);
            Money result;
            switch (this.RateType)
            {
                case RateType.FixedAndPercentageRates:
                    if (base.ApplyRateToAmountOverBracketLowerBound)
                        result = bracket.Rate.FixedAmount + (amount - bracket.LowerBound) * (bracket.Rate.PercentageRate / (100d * percentageRateDivisor));
                    else
                        result = bracket.Rate.FixedAmount + amount * (bracket.Rate.PercentageRate / (100d * percentageRateDivisor));
                    break;

                case RateType.PercentageRateOnly:
                    if (base.ApplyRateToAmountOverBracketLowerBound)
                        result = (amount - bracket.LowerBound) * (bracket.Rate.PercentageRate / (100d * percentageRateDivisor));
                    else
                        result = amount * (bracket.Rate.PercentageRate / (100d * percentageRateDivisor));
                    break;

                default: // iSabaya.RateType.FixedRateOnly:
                    result = bracket.Rate.FixedAmount;
                    break;
            }

            return result;
        }

        //public override void ApplyStepRateBreakdown(Money amount, double percentageRateDivisor,
        //                                            ref Money total,
        //                                            StepEventHandler stepFinishedEventHandler)
        //{
        //    Money stepAmount;
        //    Money stepRateAmount;
        //    double divisor = 100d * percentageRateDivisor;
        //    if (this.LowerBoundIsInclusive)
        //    {
        //        foreach (BracketedMoneyRate step in Brackets)
        //        {
        //            if (step.LowerBound <= amount)
        //            {
        //                stepAmount = (amount < step.UpperBound ? amount : step.UpperBound) - step.LowerBound;
        //                stepRateAmount = stepAmount * (step.PercentageRate / divisor);
        //                total = total.Add(stepRateAmount);
        //                if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (BracketedMoneyRate step in Brackets)
        //        {
        //            if (step.LowerBound < amount)
        //            {
        //                stepAmount = (amount <= step.UpperBound ? amount : step.UpperBound)
        //                                - step.LowerBound;
        //                stepRateAmount = stepAmount * (step.PercentageRate / divisor);
        //                total = total.Add(stepRateAmount);
        //                if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
        //            }
        //        }
        //    }
        //}

        public static MoneyRateSchedule Find(Context context, String taxCode)
        {
            return Find(context, taxCode, DateTime.Now);
        }

        public static MoneyRateSchedule Find(Context context, String taxCode, DateTime when)
        {
            return context.PersistenceSession.CreateCriteria(typeof(MoneyRateSchedule))
                            .Add(Expression.Eq("Code", taxCode))
                            .Add(Expression.Le("EffectivePeriod.From", when))
                            .Add(Expression.Ge("EffectivePeriod.To", when))
                            .UniqueResult<MoneyRateSchedule>();
        }

        public static MoneyRateSchedule Find(Context context, int id)
        {
            return context.PersistenceSession.Get<MoneyRateSchedule>(id);
        }

        public static IList<MoneyRateSchedule> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria(typeof(MoneyRateSchedule))
                            .List<MoneyRateSchedule>();
        }
    }
}