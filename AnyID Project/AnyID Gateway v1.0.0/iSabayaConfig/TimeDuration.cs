using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// Duration in years and months only.
    /// </summary>
    [Serializable]
    public class TimeDuration : IComparable<TimeDuration>//, ISimpleMath<TimeDuration>
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

        public TimeDuration()
        {
        }

        public TimeDuration(int days, int seconds)
        {
            this.TotalMonths = days;
            this.TotalSeconds = seconds;
        }

        public TimeDuration(TimeDuration original)
        {
            this.TotalMonths = original.TotalMonths;
            this.TotalSeconds = original.TotalSeconds;
        }

        public TimeDuration(int years, int months, int days)
        {
            SetDays(years, months, days);
        }

        public TimeDuration(int years, int months, int days, int hours, int minutes, int seconds)
        {
            SetDuration(years, months, days, hours, minutes, seconds);
        }

        public TimeDuration(DateTime fromDate, DateTime toDate)
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
                    Days = 0;
                }
                else
                    Days = toDay;
            }
            else if (toDay == endOfToMonth)
                Days = fromDate.LastDayOfMonth() - fromDay + 1; //the remaining days of the month of fromDate 
            else if (fromDay - 1 <= toDay)
                Days = toDay - fromDay + 1;
            else
            {
                Days = (fromDate.LastDayOfMonth() - fromDay + 1) + toDay;
                --Months;
            }

            if (Months >= 12)
            {
                Months -= 12;
                ++Years;
            }
        }

        /// <summary>
        /// Warning : This operation is not idempotent.
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static DateTime operator +(DateTime fromDate, TimeDuration duration)
        {
            DateTime toDate = new DateTime(fromDate.Year + duration.Years, fromDate.Month, 1);

            if (duration.Months > 0)
                toDate = toDate.AddMonths(duration.Months);

            int daysTillEndOfMonth = fromDate.LastDayOfMonth() - fromDate.Day + 1;
            int fromDay = fromDate.Day;
            if (fromDay == 1)
            {
                if (duration.Days == 0)
                {
                    toDate = toDate.AddMonths(-1);
                    toDate = new DateTime(toDate.Year, toDate.Month, toDate.LastDayOfMonth());
                }
                else
                    toDate = toDate.AddDays(duration.Days - 1);
            }
            else if (duration.Days == fromDate.LastDayOfMonth() - fromDay + 1)
            {
                toDate = new DateTime(toDate.Year, toDate.Month, toDate.LastDayOfMonth());
            }
            else if (duration.Days > daysTillEndOfMonth)
            {
                //TestTimeDuration(new DateTime(2010, 9, 30), new DateTime(2010, 10, 31), 0, 1, 1);
                //9-30 10-28  0 29
                toDate = toDate.AddMonths(1);
                toDate = toDate.AddDays(duration.Days - daysTillEndOfMonth - 1);
            }
            else //if (duration.Days <= daysTillEndOfMonth)
            {
                //TestTimeDuration(new DateTime(2009, 9, 30), new DateTime(2010, 10, 29), 1, 1, 0);
                toDate = toDate.AddDays(duration.Days + fromDay - 2);
            }
            //else
            //{
            //    int lastDayOfToDateMonth = toDate.LastDayOfMonth();
            //    if (lastDayOfToDateMonth >= fromDate.Day)
            //    {
            //        toDate = new DateTime(toDate.Year, toDate.Month, fromDate.Day);
            //        toDate = toDate.AddDays(duration.Days - 1);
            //    }
            //    else
            //    {
            //        toDate = new DateTime(toDate.Year, toDate.Month, lastDayOfToDateMonth);
            //        toDate = toDate.AddDays(fromDate.Day - lastDayOfToDateMonth + duration.Days - 1);
            //    }
            //}

            return toDate;
        }

        //public TimeDuration(DateTime fromDate, DateTime toDate)
        //{
        //    if (fromDate > toDate)
        //        throw new Exception("fromDate is greater than toDate");

        //    Years = toDate.Year - fromDate.Year;
        //    Months = toDate.Month - fromDate.Month;
        //    int fromDay = fromDate.Day;
        //    int toDay = toDate.Day;
        //    if (fromDay == 1 && toDate.IsLastDayOfMonth())
        //    {
        //        Days = 0;
        //        ++Months;
        //    }
        //    else if (fromDay <= toDay)
        //        Days = toDay - fromDay + 1;
        //    else if (fromDay == toDay + 1)
        //        Days = 0;
        //    else
        //    {
        //        Days = (fromDate.LastDayOfMonth() - fromDay + 1) + toDay;
        //        --Months;
        //    }

        //    if (Months >= 12)
        //    {
        //        Months -= 12;
        //        ++Years;
        //    }
        //}

        #region persistent

        public virtual int TotalMonths
        {
            get { return (this.Years * 12 + this.Months) * 30 + this.Days; }
            set
            {
                this.Years = value / (12 * 30);
                this.Months = (value / 30) % 12;
                this.Days = value % 30;
            }
        }

        public virtual int TotalSeconds
        {
            get { return (this.Hours * 60 + this.Minutes) * 60 + this.Seconds; }
            set
            {
                this.Years = value / (60 * 60);
                this.Months = (value / 60) % 60;
                this.Days = value % 60;
            }
        }

        #endregion persistent

        public virtual int Years { get; set; }
        public virtual int Months { get; set; }//{ get { return (int)((this.TotalDays % 10000) / 100); } }
        public virtual int Days { get; set; }//{ get { return (int)(this.TotalDays % 100); } }
        public virtual int Hours { get; set; }//{ get { return (int)(this.TotalSeconds / 10000);} }
        //{
        //    get
        //    {
        //        int fractionOfDay = (this.TotalSeconds % SecondsPerDay);
        //        return (int)((this.TotalSeconds % SecondsPerDay) / SecondsPerHour);
        //    }
        //    protected set
        //    {
        //        if (Math.Abs(value) > HoursPerDay)
        //            throw new ArgumentException();

        //        long fractionOfHourInSeconds = this.TotalSeconds % SecondsPerHour;
        //        this.TotalSeconds = RoundDown(SecondsPerDay) + value * SecondsPerHour + fractionOfHourInSeconds;
        //    }
        //}
        public virtual int Minutes { get; set; }//{ get { return (int)((this.TotalSeconds % 10000) / 100); } }
        //{
        //    get { return (int)((this.TotalSeconds % SecondsPerHour) / SecondsPerMinute); }
        //    protected set
        //    {
        //        if (Math.Abs(value) > MinutesPerHour)
        //            throw new ArgumentException();

        //        long fractionOfMinutesInSeconds = this.TotalSeconds % SecondsPerMinute;
        //        this.TotalSeconds = RoundDown(SecondsPerHour) + value * SecondsPerMinute + fractionOfMinutesInSeconds;
        //    }
        //}
        public virtual int Seconds { get; set; }//{ get { return (int)(this.TotalSeconds % 10000); } }
        //{
        //    get { return (int)(this.TotalSeconds % SecondsPerMinute); }
        //    protected set
        //    {
        //        if (Math.Abs(value) > SecondsPerMinute)
        //            throw new ArgumentException();
        //        this.TotalSeconds = RoundDown(SecondsPerMinute) + value;
        //    }
        //}


        //private long RoundDown(long roundTo)
        //{
        //    return (long)(this.TotalSeconds / roundTo) * roundTo;
        //}

        public virtual void SetDays(int years, int months, int days)
        {
            if (months > 12)
                throw new ArgumentException("months must be between 0 and 12.");
            if (days > 30)
                throw new ArgumentException("days must be between 0 and 30.");
            this.Years = years;
            this.Months = months;
            this.Days = days;
        }

        public virtual void SetSeconds(int hours, int minutes, int seconds)
        {
            if (hours >= 24)
                throw new ArgumentException("hours exceeds 23.");
            if (minutes >= 60)
                throw new ArgumentException("minutes exceeds 59.");
            if (seconds >= 60)
                throw new ArgumentException("seconds exceeds 59.");
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public virtual void SetDuration(int years, int months, int days, int hours, int minutes, int seconds)
        {
            SetDays(years, months, days);
            SetSeconds(hours, minutes, seconds);
        }

        //public virtual DateTime DurationEndDate(DateTime fromDate)
        //{
        //    DateTime endDate = fromDate;
        //    if (this.TotalSeconds != 0)
        //        endDate = endDate.AddSeconds(this.TotalSeconds);
        //    return endDate;
        //}

        #region IComparable<TimeDuration> Members

        public int CompareTo(TimeDuration other)
        {
            if (object.ReferenceEquals(other, null))
                throw new Exception("TimeDuration.operator < : one of the operand is null.");

            int days = this.TotalMonths;
            int ottherDays = other.TotalMonths;
            if (days < ottherDays) return -1;
            if (days > ottherDays) return 1;

            int seconds = this.TotalSeconds;
            int otherSeconds = other.TotalSeconds;
            if (seconds < otherSeconds) return -1;
            if (seconds > otherSeconds) return 1;
            return 0;
        }

        #endregion

        //#region ISimpleMath<TimeDuration> Members

        //public virtual DateTime Add(DateTime startDate)
        //{
        //    return startDate.Add(new TimeSpan(this.TotalDays, this.Hours, this.Minutes, this.Seconds));
        //}

        //public virtual TimeDuration Add(TimeDuration b)
        //{
        //    return this + b;
        //}

        //public virtual TimeDuration Subtract(TimeDuration b)
        //{
        //    return this - b;
        //}

        //public virtual TimeDuration Multiply(double rate)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion ISimpleMath

        //public static int DaysPerMonth(int gregorianYear, int month)
        //{
        //    int dpm = daysPerMonth[month - 1];
        //    if (month == 2 && (gregorianYear % 400 == 0 || gregorianYear % 4 == 0 && gregorianYear % 100 != 0))
        //        ++dpm;
        //    return dpm;
        //}

        public static bool operator <(TimeDuration left, TimeDuration right)
        {
            if (object.ReferenceEquals(left, right)) return false;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("TimeDuration.operator < : one of the operand is null.");
            int leftDays = left.TotalMonths;
            int rightDays = right.TotalMonths;
            return leftDays < rightDays || (leftDays == rightDays && left.TotalSeconds < right.TotalSeconds);
        }

        public static bool operator <=(TimeDuration left, TimeDuration right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("TimeDuration.operator < : one of the operand is null.");
            int leftDays = left.TotalMonths;
            int rightDays = right.TotalMonths;
            return leftDays < rightDays || (leftDays == rightDays && left.TotalSeconds <= right.TotalSeconds);
        }

        public static bool operator ==(TimeDuration left, TimeDuration right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null)) return false;
            int leftDays = left.TotalMonths;
            int rightDays = right.TotalMonths;
            return leftDays == rightDays && left.TotalSeconds == right.TotalSeconds;
        }

        public static bool operator !=(TimeDuration left, TimeDuration right)
        {
            return !(left == right);
        }

        public static bool operator >(TimeDuration left, TimeDuration right)
        {
            if (object.ReferenceEquals(left, right)) return false;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("TimeDuration.operator < : one of the operand is null.");
            int leftDays = left.TotalMonths;
            int rightDays = right.TotalMonths;
            return leftDays > rightDays || (leftDays == rightDays && left.TotalSeconds > right.TotalSeconds);
        }

        public static bool operator >=(TimeDuration left, TimeDuration right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                throw new Exception("TimeDuration.operator < : one of the operand is null.");
            int leftDays = left.TotalMonths;
            int rightDays = right.TotalMonths;
            return leftDays > rightDays || (leftDays == rightDays && left.TotalSeconds >= right.TotalSeconds);
        }

        public static TimeDuration operator +(TimeDuration a, TimeDuration b)
        {
            return new TimeDuration(a.TotalMonths + b.TotalMonths, a.TotalSeconds + b.TotalSeconds);
        }

        public static TimeDuration operator -(TimeDuration a, TimeDuration b)
        {
            return new TimeDuration(a.TotalMonths - b.TotalMonths, a.TotalSeconds - b.TotalSeconds);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            TimeDuration theOther = obj as TimeDuration;
            return this.TotalMonths == theOther.TotalMonths && this.TotalSeconds == theOther.TotalSeconds;
        }

        public override int GetHashCode()
        {
            return (this.TotalMonths.GetHashCode() ^ this.TotalSeconds.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return this.Years.ToString("D") + "," + this.Months.ToString("D") + "," + this.Days.ToString("D");
        }

        public virtual string ToString(String yearSuffix, String daySuffix)
        {
            return this.Years.ToString("D") + yearSuffix + this.Days.ToString("F02") + daySuffix;
        }

        public virtual string ToString(String yearSuffix, String monthSuffix, String daySuffix)
        {
            return this.Years.ToString("D") + yearSuffix + monthSuffix + this.Days.ToString("F02") + daySuffix;
        }

        public static bool IsNullOrZero(TimeDuration timeDuration)
        {
            return timeDuration == null || timeDuration.TotalSeconds == 0;
        }
    }
}
