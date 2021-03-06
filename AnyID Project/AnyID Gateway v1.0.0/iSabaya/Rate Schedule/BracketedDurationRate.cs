using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public class BracketedDurationRate //: BracketedRate<TimeDuration, MoneyRateSchedule>
    {
        public BracketedDurationRate()
        {
            //this.LowerBoundIsInclusive = false;
        }

        #region persistent

        public virtual int ID { get; set; }
        public virtual TimeDuration LowerBound { get; set; }
        public virtual MoneyRateSchedule MoneyRateSchedule { get; set; }
        /// <summary>
        /// Owner of this instance
        /// </summary>
        public virtual DurationRateSchedule Schedule { get; set; }
        public virtual int SeqNo { get; set; }
        public virtual TimeDuration UpperBound { get; set; }
        /// <summary>
        /// Default is false.
        /// </summary>
        //public virtual bool LowerBoundIsInclusive { get; set; }

        #endregion persistent

        public virtual MoneyRateSchedule ApplyRate(bool applyRateToAmountOverBracketLowerBound, RateType rateType, MoneyRateSchedule amount, double percentageRateDivisor)
        {
            throw new NotImplementedException();
        }
    }
}