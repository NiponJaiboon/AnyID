using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public class SingleMoneyRate
    {
        #region persistent

        public virtual Money FixedAmount { get; set; }
        public virtual Money MaxFixedAmount { get; set; }
        public virtual Money MinFixedAmount { get; set; }

        /// <summary>
        /// Variable rate
        /// </summary>
        public virtual double PercentageRate { get; set; }
        public virtual double MaxPercentageRate { get; set; }
        public virtual double MinPercentageRate { get; set; }

        public virtual Money MinAmount { get; set; }
        public virtual Money MaxAmount { get; set; }

        #endregion persistent

        private string ToString(string label, Money amount, string suffix)
        {
            if (amount.IsNullOrZero())
                return "";
            else
                return label + amount.ToString() + suffix;
        }

        private string ToString(string label, double amount, string suffix)
        {
            if (amount == 0d)
                return "";
            else
                return label + amount.ToString() + suffix;
        }

        public override string ToString()
        {
            return this.ToString("fixed amount = ", this.FixedAmount, " ") +
                this.ToString("percentage rate = ", this.PercentageRate, "% ")
                ;
        }

        public virtual string ToString(RateType rateType)
        {
            string message;

            switch (rateType)
            {
                case RateType.FixedRateOnly:
                    message = this.ToString("fixed amount = ", this.FixedAmount, " ");
                    break;

                case RateType.PercentageRateOnly:
                    message = this.ToString("percentage rate = ", this.PercentageRate, "% ");
                    break;

                default:
                    message = this.ToString("fixed amount = ", this.FixedAmount, " ") +
                        this.ToString("+ variable rate = ", this.PercentageRate, "% ");
                    break;

            }
            return message;
        }

        public static SingleMoneyRate Clone(SingleMoneyRate original)
        {
            if (null == original)
                return null;
            else
                return new SingleMoneyRate
                {
                    MaxFixedAmount = original.MaxFixedAmount,
                    MinFixedAmount = original.MinFixedAmount,
                    FixedAmount = original.FixedAmount,

                    PercentageRate = original.PercentageRate,
                    MaxPercentageRate = original.MaxPercentageRate,
                    MinPercentageRate = original.MinPercentageRate,

                    MaxAmount = original.MaxAmount,
                    MinAmount = original.MinAmount,
                };
        }
    }
}