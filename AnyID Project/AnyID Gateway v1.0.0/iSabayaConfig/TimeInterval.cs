using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace iSabaya
{
    [Serializable]
    public class TimeInterval : IComparable, IComparable<TimeInterval>
    {
        /// <summary>
        /// Safe for persisting to SQL Server database
        /// </summary>
        public static readonly DateTime MaxDate = System.Globalization.CultureInfo.InvariantCulture.Calendar.ToDateTime(2300, 12, 31, 0, 0, 0, 0);
        /// <summary>
        /// Safe for persisting to SQL Server database
        /// </summary>
        public static readonly DateTime MinDate = System.Globalization.CultureInfo.InvariantCulture.Calendar.ToDateTime(1800, 1, 1, 0, 0, 0, 0);
        public static readonly TimeInterval EmptyInterval = new TimeInterval(MaxDate, MinDate);
        public static readonly TimeInterval Eternal = new TimeInterval(MinDate, MaxDate);

        public static TimeInterval EffectiveNow
        {
            get { return new TimeInterval(DateTime.Now); }
        }

        public static bool IsEndOfMonth(DateTime date)
        {
            return date.Day == DateTime.DaysInMonth(date.Year, date.Month);
        }

        #region persistent

        public virtual DateTime From { get; set; }
        public virtual DateTime To { get; set; }

        #endregion persistent

        #region constructors

        public TimeInterval()
        {
            this.From = TimeInterval.MinDate;
            this.To = TimeInterval.MaxDate;
        }

        public TimeInterval(TimeInterval original)
        {
            this.From = original.From;
            this.To = original.To;
        }

        public TimeInterval(DateTime from)
        {
            if (from > TimeInterval.MaxDate)
                throw new Exception("The initial effective date of TimeInterval exceeds max date.");
            this.From = from;
            this.To = TimeInterval.MaxDate;
        }

        public TimeInterval(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }

        public TimeInterval(DateTime date, TimeInterval timeInterval)
        {
            this.From = new DateTime(date.Year, date.Month, date.Day, timeInterval.From.Hour, timeInterval.From.Minute, timeInterval.From.Second);
            this.To = new DateTime(date.Year, date.Month, date.Day, timeInterval.To.Hour, timeInterval.To.Minute, timeInterval.To.Second);
        }

        public TimeInterval(DateTime date, DateTime fromHour, DateTime toHour)
        {
            this.From = new DateTime(date.Year, date.Month, date.Day, fromHour.Hour, fromHour.Minute, fromHour.Second);
            this.To = new DateTime(date.Year, date.Month, date.Day, toHour.Hour, toHour.Minute, toHour.Second);
        }

        #endregion constructors

        public DateTime ExpiryDate
        {
            get { return To.AddMilliseconds(1d); }
            set { this.To = value.AddMilliseconds(-1d); }
        }

        public virtual DateTime EffectiveDate
        {
            get { return From; }
            set { this.From = value; }
        }

        public virtual TimeInterval Intersect(TimeInterval interval)
        {
            DateTime f = (From < interval.From) ? interval.From : From;
            DateTime t = (To < interval.To) ? To : interval.To;

            if (f <= t)
                return new TimeInterval(f, t);
            else
                return EmptyInterval;
        }

        public virtual TimeInterval Intersect(DateTime from, DateTime to)
        {
            DateTime f = (this.From < from) ? From : this.From;
            DateTime t = (this.To < to) ? this.To : to;

            if (f <= t)
                return new TimeInterval(f, t);
            else
                return EmptyInterval;
        }

        public virtual bool IsEmpty
        {
            get { return this.From > this.To; }
        }

        public virtual bool IsEffective
        {
            get
            {
                DateTime now = DateTime.Now;
                return From <= now && now <= To;
            }
        }

        public virtual bool Includes(DateTime dateTime)
        {
            return From <= dateTime && dateTime <= To;
        }

        /// <summary>
        /// Obsolete, please use Includes
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public virtual bool Contains(DateTime dateTime)
        {
            return this.Includes(dateTime);
        }

        public virtual bool Overlaps(TimeInterval interval)
        {
            return !(this.From > interval.To || this.To < interval.From);

            //DateTime f = (from < interval.From) ? interval.From : from;
            //DateTime t = (to < interval.To) ? to : interval.To;

            //return (f <= t);
        }

        public virtual YearMonthDuration YearMonthDuration
        {
            get { return new YearMonthDuration(this.From, this.To); }
        }

        public virtual TimeDuration Duration
        {
            get { return new TimeDuration(this.From, this.To); }
        }

        public virtual int Years
        {
            get { return TimeDuration.DetermineYears(this.From, this.To); }
        }

        public virtual TimeSpan TimeSpan
        {
            get { return this.From <= this.To ? this.To - this.From : new TimeSpan(0); }
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            TimeInterval theOther = obj as TimeInterval;
            if (theOther == null) return false;
            if (this.From == theOther.From && this.To == theOther.To) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() ^ To.GetHashCode();
        }

        public virtual string ToString(String format, String languageCode)
        {
            if (Object.ReferenceEquals(this, EmptyInterval))
                return "[empty]";
            else if (Object.ReferenceEquals(this, Eternal))
                return "[forever]";

            CultureInfo c = CultureInfo.GetCultureInfo(languageCode);
            StringBuilder b = new StringBuilder("[");

            if (this.From == TimeInterval.MinDate)
                b.Append("-");
            else
                b.Append(this.From.ToString(format, c));
            b.Append(", ");
            if (this.To == TimeInterval.MaxDate)
                b.Append("-");
            else
                b.Append(this.To.ToString(format, c));
            b.Append("]");
            return b.ToString();
        }

        public virtual string ToString(String format)
        {
            if (Object.ReferenceEquals(this, EmptyInterval))
                return "[empty]";
            else if (Object.ReferenceEquals(this, Eternal))
                return "[forever]";

            StringBuilder b = new StringBuilder("[");

            if (this.From == TimeInterval.MinDate)
                b.Append("-");
            else
                b.Append(this.From.ToString(format));
            b.Append(", ");
            if (this.To == TimeInterval.MaxDate)
                b.Append("-");
            else
                b.Append(this.To.ToString(format));
            b.Append("]");
            return b.ToString();
        }

        public override string ToString()
        {
            if (Object.ReferenceEquals(this, EmptyInterval))
                return "[empty]";
            else if (Object.ReferenceEquals(this, Eternal))
                return "[forever]";

            StringBuilder b = new StringBuilder("[");

            if (this.From == TimeInterval.MinDate)
                b.Append("-");
            else
                b.Append(this.From.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            b.Append(", ");
            if (this.To == TimeInterval.MaxDate)
                b.Append("-");
            else
                b.Append(this.To.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            b.Append("]");
            return b.ToString();
        }

        public static bool operator ==(TimeInterval left, TimeInterval right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null)) return false;
            if (left.From == right.From && left.To == right.To) return true;
            return false;
        }

        public static bool operator !=(TimeInterval left, TimeInterval right)
        {
            return !(left == right);
        }

        #region IComparable<TimeInterval> Members

        public int CompareTo(TimeInterval other)
        {
            if (Object.ReferenceEquals(null, other))
                return 1;
            if (this.From < other.From)
                return -1;
            else
                if (this.From > other.From)
                    return 1;
                else
                    return 0;
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return CompareTo((TimeInterval)obj);
        }

        #endregion

        public static bool IsNullOrEmpty(TimeInterval timeInterval)
        {
            return null == timeInterval || timeInterval == TimeInterval.EmptyInterval;
        }

        //public static bool IsInvalid(TimeInterval timeInterval)
        //{
        //    return null == timeInterval || timeInterval.From >= timeInterval.To;
        //}
    }
}
