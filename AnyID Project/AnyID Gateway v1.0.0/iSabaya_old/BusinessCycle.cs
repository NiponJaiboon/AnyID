using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// Cycle length of one year starting on the 1st day of StartMonthOfCycle.
    /// </summary>
    public class BusinessCycle
    {
        #region persistent
        /// <summary>
        /// Otherwise, the cycle year is one more than the calendar year of the start month.
        /// </summary>
        public virtual bool CycleYearCoincideWithCalendarYearOfTheStartMonth { get; set; }
        /// <summary>
        /// Value 1 - 12 representing January to December.
        /// </summary>
        public virtual int StartMonthOfCycle { get; set; }

        #endregion

        public virtual int DetermineYearOf(DateTime date)
        {
            int month = date.Month;
            if (month >= this.StartMonthOfCycle)
                if (this.CycleYearCoincideWithCalendarYearOfTheStartMonth)
                    return date.Year;
                else
                    return date.Year + 1;
            else
                return date.Year - 1;
        }

        public virtual int DetermineYearOf(TimeInterval period)
        {
            int fromYear = this.DetermineYearOf(period.From);
            int toYear = this.DetermineYearOf(period.To);
            if (fromYear != toYear)
                throw new Exception("The period is not within a single year.");
            return fromYear;
        }

        public virtual TimeInterval AnnualInterval(int year)
        {
            DateTime firstDayOfYear = this.FirstDateOfYear(year);

            return new TimeInterval(firstDayOfYear, firstDayOfYear.AddYears(1).AddDays(-1));
        }

        public virtual DateTime FirstDateOfYear(int year)
        {
            return this.CycleYearCoincideWithCalendarYearOfTheStartMonth
                        ? new DateTime(year, this.StartMonthOfCycle, 1)
                        : new DateTime(year - 1, this.StartMonthOfCycle, 1);
        }

        public virtual DateTime LastDateOfYear(int year)
        {
            return this.FirstDateOfYear(year + 1).AddDays(-1);
        }
    }
}
