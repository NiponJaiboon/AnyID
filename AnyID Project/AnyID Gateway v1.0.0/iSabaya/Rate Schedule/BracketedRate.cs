using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public abstract class BracketedRate<TBound, TRate>
        where TBound : IComparable<TBound> //, ISimpleMath<TBracketBound>
    //where TRate : ISimpleMath<TAmount>
    {
        public BracketedRate()
        {
        }

        public BracketedRate(BracketedRate<TBound, TRate> original)
        {
            this.LowerBound = original.LowerBound;
            this.UpperBound = original.UpperBound;
            this.Rate = original.Rate;
            //this.fixedRate = original.FixedRate;
            //this.percentageRate = original.PercentageRate;
            //this.maxFixedRate = original.MaxFixedRate;
            //this.maxPercentageRate = original.MaxPercentageRate;
            //this.minFixedRate = original.MinFixedRate;
            //this.minPercentageRate = original.MinPercentageRate;
            this.SeqNo = original.SeqNo;
        }

        public BracketedRate(TBound lowerBound, TBound upperBound, float percentageRate)
        {
            if (lowerBound.CompareTo(upperBound) > 0)
                throw new Exception("Bracket lower bound is greater than upper bound.");

            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        #region persistent

        public virtual int ID { get; set; }
        public virtual TRate Rate { get; set; }
        public virtual TBound LowerBound { get; set; }
        public virtual TBound UpperBound { get; set; }

        //private TRate maxFixedRate;
        //public virtual TRate MaxFixedRate
        //{
        //    get { return maxFixedRate; }
        //    set { maxFixedRate = value; }
        //}

        //private double maxPercentageRate;
        //public virtual double MaxPercentageRate
        //{
        //    get { return maxPercentageRate; }
        //    set { maxPercentageRate = value; }
        //}

        //private TRate minFixedRate;
        //public virtual TRate MinFixedRate
        //{
        //    get { return minFixedRate; }
        //    set { minFixedRate = value; }
        //}

        //private double minPercentageRate;
        //public virtual double MinPercentageRate
        //{
        //    get { return minPercentageRate; }
        //    set { minPercentageRate = value; }
        //}

        //private double percentageRate;
        //public virtual double PercentageRate
        //{
        //    get { return percentageRate; }
        //    set { percentageRate = value; }
        //}

        //public virtual TRate MinAmount { get; set; }
        //public virtual TRate MaxAmount { get; set; }

        public virtual MultiBracketRateSchedule<TBound, TRate> Schedule { get; set; }

        /// <summary>
        /// Default is 0.
        /// </summary>
        public virtual int SeqNo{get;set;}


        #endregion persistent

        public virtual int TempID { get; set; }
        public virtual object Tag { get; set; }
        //public abstract TRate ApplyRate(bool applyRateToAmountOverBracketLowerBound, RateType rateType, 
        //                                TRate amount, double percentageRateDivisor);
        //{

        //    return amount.Multiply(this.PercentageRate / (100d * percentageRateDivisor))
        //                .Add(this.FixedRate);
        //    switch (rateType)
        //    {
        //        case iSabaya.RateType.FixedAndPercentageRates:
        //            if (applyRateToAmountOverBracketLowerBound)
        //                return amount.Subtract(this.LowerBound)
        //                            .Multiply(this.PercentageRate / (100d * percentageRateDivisor))
        //                            .Add(this.FixedRate);
        //            else
        //                return amount.Multiply(this.PercentageRate / (100d * percentageRateDivisor))
        //                            .Add(this.FixedRate);

        //        case iSabaya.RateType.PercentageRateOnly:
        //            if (applyRateToAmountOverBracketLowerBound)
        //                return amount.Subtract(this.LowerBound)
        //                            .Multiply(this.PercentageRate / (100d * percentageRateDivisor));
        //            else
        //                return amount.Multiply(this.PercentageRate / (100d * percentageRateDivisor));

        //        default: // iSabaya.RateType.FixedRateOnly:
        //            return this.FixedRate;
        //    }
        //}

        public override string ToString()
        {
            return this.LowerBound.ToString()
                + "-" + this.UpperBound.ToString()
                + ": " + this.Rate.ToString();
        }
    }
}