using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{
    [Serializable]
    public class RateSchedule<T> : MultiBracketRate<T, T>
        where T : IComparable<T> //, ISimpleMath<T>
    {
        public RateSchedule()
            : base()
        {
        }
       
        public RateSchedule(RateSchedule<T> original)
            : base(original)
        {
        }

        #region persistent

        #endregion persistent

        /// <summary>
        /// Return (bracket.FixedAmountRate + (amount * (bracket.PercentageRate / 100)))
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="percentageRateDivisor"></param>
        /// <returns></returns>
        public virtual T ApplyRate(T amount, out BracketedRate<T, T> bracket)
        {
            return ApplyRate(amount, 1d, out bracket);
        }

        /// <summary>
        /// Return (bracket.FixedAmountRate + (amount * (bracket.PercentageRate / (100 * divisor)))
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="percentageRateDivisor"></param>
        /// <returns></returns>
        public virtual T ApplyRate(T amount, double percentageRateDivisor,
                                                    out BracketedRate<T, T> bracket)
        {
            bracket = base.GetBracket(amount);

            return bracket.ApplyRate(this.ApplyRateToAmountOverBracketLowerBound, this.RateType, 
                                    amount, percentageRateDivisor);
        }

        ///// <summary>
        ///// Return (bracket.FixedAmountRate + (amount * (bracket.PercentageRate / 100)))
        ///// </summary>
        ///// <param name="amount"></param>
        ///// <param name="percentageRateDivisor"></param>
        ///// <returns></returns>
        //public virtual T ApplyRate(T amount)
        //{
        //    return ApplyRate(amount, 1d);
        //}

        ///// <summary>
        ///// Return (bracket.FixedAmountRate + (amount * (bracket.PercentageRate / (100 * divisor)))
        ///// </summary>
        ///// <param name="amount"></param>
        ///// <param name="percentageRateDivisor"></param>
        ///// <returns></returns>
        //public virtual T ApplyRate(T amount, double percentageRateDivisor)
        //{
        //    BracketedRate<T, T> bracket = base.GetBracket(amount);
        //    return bracket.ApplyRate(amount, percentageRateDivisor);

        //}

        //public virtual void ApplyStepRateBreakdown(T amount, double percentageRateDivisor,
        //                                            ref T total,
        //                                            StepEventHandler stepFinishedEventHandler)
        //{
        //    T stepAmount;
        //    T stepRateAmount;
        //    double divisor = 100d * percentageRateDivisor;
        //    if (this.LowerBoundIsInclusive)
        //    {
        //        foreach (BracketedRate<T, T> step in Brackets)
        //        {
        //            if (0 >= step.LowerBound.CompareTo(amount))
        //            {
        //                stepAmount = (0 > amount.CompareTo(step.UpperBound) ? amount : step.UpperBound)
        //                                .Subtract(step.LowerBound);
        //                stepRateAmount = stepAmount.Multiply(step.PercentageRate / divisor);
        //                total = total.Add(stepRateAmount);
        //                if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (BracketedRate<T, T> step in Brackets)
        //        {
        //            if (0 > step.LowerBound.CompareTo(amount))
        //            {
        //                stepAmount = (0 >= amount.CompareTo(step.UpperBound) ? amount : step.UpperBound)
        //                                .Subtract(step.LowerBound);
        //                stepRateAmount = stepAmount.Multiply(step.PercentageRate / divisor);
        //                total = total.Add(stepRateAmount);
        //                if (null != stepFinishedEventHandler) stepFinishedEventHandler(step, stepRateAmount);
        //            }
        //        }
        //    }
        //}
    }
}