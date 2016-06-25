using System;

namespace iSabaya
{
    public class TimeInterval
    {
        private static TimeSpan Zero = new TimeSpan(0);

        public TimeInterval(DateTime effectiveFrom)
        {
            this.EffectiveDate = effectiveFrom;
            this.ExpiryDate = DateTime.MaxValue;
        }

        public TimeInterval(DateTime effectiveFrom, DateTime effectiveTo)
        {
            this.EffectiveDate = effectiveFrom;
            this.ExpiryDate = effectiveTo.TimeOfDay == Zero ? effectiveTo.AddDays(1) : effectiveTo.AddMilliseconds(1);
        }

        public static DateTime MaxDate = new DateTime(2800, 1, 1);

        public static DateTime MinDate = new DateTime(1700, 1, 1);
        public virtual DateTime EffectiveDate { get; set; }
        public virtual DateTime ExpiryDate { get; set; }

        public virtual bool IsEffective
        {
            get { return this.EffectiveDate <= DateTime.Now && DateTime.Now < this.ExpiryDate; }
        }
    }
}
