using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// Duration in years and months only.
    /// </summary>
    [Serializable]
    public class YearMonthDuration : IComparable<YearMonthDuration>//, ISimpleMath<YearMonthDuration>
    {
        public static int DetermineYears(DateTime from, DateTime to)
        {
            int years = to.Year - from.Year;
            if (from.Month > to.Month || (from.Month == to.Month && from.Day > to.Day))
                --years;
            return years;
        }
        //public delegate void TimeDurationEvent(object sender, DateTime previousDate);
        //public event TimeDurationEvent FromDateChange;
        //public static readonly int[] daysPerMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public YearMonthDuration()
        {
        }

        public YearMonthDuration(YearMonthDuration original)
        {
            this.Years = original.Years;
            this.Months = original.Months;
        }

        public YearMonthDuration(int years, int months)
        {
            SetValues(years, months);
        }

        public YearMonthDuration(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
                throw new Exception("fromDate is greater than toDate");

            Years = toDate.Year - fromDate.Year;
            Months = toDate.Month - fromDate.Month;
            if (Months < 0)
            {
                --Years;
                Months += 12;
            }

            int fromDay = fromDate.Day;
            int toDay = toDate.Day;
            int endOfToMonth = toDate.LastDayOfMonth();

            if (fromDay == 1)
            {
                if (toDay == endOfToMonth)
                {
                    ++Months;
                }
            }
            else if (fromDay > toDay + 1 && toDay < endOfToMonth)
            {
                --Months;
            }

            if (Months >= 12)
            {
                Months -= 12;
                ++Years;
            }
        }

        public YearMonthDuration(int totalMonths)
        {
            if (totalMonths < 0)
                throw new ArgumentException("totalMonths is negative.");
            this.TotalMonths = totalMonths;
        }


        /// <summary>
        /// Warning : This operation is not idempotent.
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static DateTime operator +(DateTime fromDate, YearMonthDuration duration)
        {
            DateTime toDate = new DateTime(fromDate.Year + duration.Years, fromDate.Month, 1);

            if (duration.Months > 0)
                toDate = toDate.AddMonths(duration.Months);

            int lastDayOfToMonth = toDate.LastDayOfMonth();
            int toDay = fromDate.Day;
            if (toDay > lastDayOfToMonth)
                toDay = lastDayOfToMonth;
            toDate = new DateTime(toDate.Year, toDate.Month, toDay);

            return toDate;
        }

        #region persistent

        public virtual int TotalMonths
        {
            get { return this.Years * 12 + this.Months; }
            set
            {
                this.Years = value / 12;
                this.Months = value % 12;
            }
        }
        #endregion persistent

        public virtual int Years { get; set; }
        public virtual int Months { get; set; }

        public virtual void SetValues(int years, int months)
        {
            if (months > 12)
                throw new ArgumentException("months must be between 0 and 12.");
            this.Years = years;
            this.Months = months;
        }

        #region IComparable<YearMonthDuration> Members

        public int CompareTo(YearMonthDuration other)
        {
            if (object.ReferenceEquals(other, null))
                throw new Exception("YearMonthDuration.operator < : one of the operand is null.");

            int otherYears = other.Years;
            if (this.Years < otherYears) return -1;
            if (this.Years > otherYears) return 1;

            if (this.Months < other.Months) return -1;
            if (this.Months > other.Months) return 1;
            return 0;
        }

        #endregion

        public static bool operator <(YearMonthDuration left, YearMonthDuration right)
        {
            if (object.ReferenceEquals(left, right)) return false;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("YearMonthDuration.operator < : one of the operand is null.");
            return left.TotalMonths < right.TotalMonths;
        }

        public static bool operator <=(YearMonthDuration left, YearMonthDuration right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("YearMonthDuration.operator < : one of the operand is null.");
            return left.TotalMonths <= right.TotalMonths;
        }

        public static bool operator ==(YearMonthDuration left, YearMonthDuration right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null)) return false;
            return left.TotalMonths == right.TotalMonths;
        }

        public static bool operator !=(YearMonthDuration left, YearMonthDuration right)
        {
            return !(left == right);
        }

        public static bool operator >(YearMonthDuration left, YearMonthDuration right)
        {
            if (object.ReferenceEquals(left, right)) return false;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("YearMonthDuration.operator < : one of the operand is null.");
            return left.TotalMonths > right.TotalMonths;
        }

        public static bool operator >=(YearMonthDuration left, YearMonthDuration right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("YearMonthDuration.operator < : one of the operand is null.");
            return left.TotalMonths >= right.TotalMonths;
        }

        public static YearMonthDuration operator +(YearMonthDuration a, YearMonthDuration b)
        {
            return new YearMonthDuration(a.TotalMonths + b.TotalMonths);
        }

        public static YearMonthDuration operator -(YearMonthDuration a, YearMonthDuration b)
        {
            return new YearMonthDuration(a.TotalMonths - b.TotalMonths);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            YearMonthDuration theOther = obj as YearMonthDuration;
            return this.TotalMonths == theOther.TotalMonths;
        }

        public override int GetHashCode()
        {
            return this.TotalMonths.GetHashCode();
        }

        public override string ToString()
        {
            return this.Years.ToString("D") + "," + this.Months.ToString("D");
        }

        public static bool IsNullOrZero(YearMonthDuration duration)
        {
            return duration == null || duration.TotalMonths == 0;
        }
    }
}
