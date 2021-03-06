using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace iSabaya
{

    public class ScheduleMonthlyOnDay : ScheduleDetail
    {
        public ScheduleMonthlyOnDay()
        {
        }

        public ScheduleMonthlyOnDay(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval, 
                                    TreeListNode timeCategory, int dayOfMonth)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory)
        {
            //dayNo = 31 => end-of-month
            this.DayOfMonth = dayOfMonth;
        }

        protected int dayOfMonth;
        /// <summary>
        /// DayNo = 0..31 for monthly schedule where DayNo > end-of-month day implies the end-of-month
        /// </summary>
        public virtual int DayOfMonth
        {
            get { return dayOfMonth; }
            set
            {
                //Schedule.EOM signifies the end-of-month day, 
                if (1 <= value && value <= TimeSchedule.EOM)
                    dayOfMonth = value;
                else
                    throw new iSabayaException("DayNo for ScheduleMonthlyOnDay is not in the range (1=31)");
            }
        }

        #region ScheduleDetail implementaion

        public override TimeInterval GetScheduledHoursOn(DateTime timestamp)
        {
            //if a month does not have day 31 then the last day of the month is considered the scheduled day.
            if (timestamp.Day == dayOfMonth
                || (dayOfMonth == TimeSchedule.EOM 
                    && timestamp.Day == DateTime.DaysInMonth(timestamp.Year, timestamp.Month)))
                return new TimeInterval(timestamp, base.HourInterval);
            return null;
        }

        public override bool IsScheduledDate(DateTime date)
        {
            //if a month does not have day 31 then the last day of the month is considered the scheduled day.
            int day = date.Day;
            return (day == dayOfMonth
                    || (dayOfMonth == TimeSchedule.EOM
                        && day == DateTime.DaysInMonth(date.Year, date.Month)));
        }

        //public override bool IsScheduledOrRescheduledDay(DateTime givenDate, TimeSchedule workCalendar, TimeSchedule nonworkSchedule,
        //                                                out TimeInterval scheduledHours)
        //{
        //    //Check if the given date is a scheduled day
        //    if (this.dayOfMonth == givenDate.Day) // && this.hourInterval.Includes(date))
        //    {
        //        if (null != nonworkSchedule && null == nonworkSchedule.GetScheduledHoursOn(givenDate))
        //        {
        //            scheduledHours = null;
        //            return false;
        //        }
        //        else
        //        {
        //            scheduledHours = this.hourInterval.Clone();
        //            return true;
        //        }
        //    }

        //    if (null == workCalendar || null == nonworkSchedule)
        //    {
        //        scheduledHours = null;
        //        return false;
        //    }

        //    //The given date is not in schedule; 
        //    //check if is coincided with a rescheduled date of one of the surrounding scheduled dates
        //    int year = givenDate.Year;
        //    int month = givenDate.Month;
        //    int daysInMonth;
        //    DateTime scheduledDate;
        //    switch (this.rescheduleIfHoliday)
        //    {
        //        case RescheduleOption.ScheduledDayAfter:
        //            //Find the earlier scheduled date
        //            if (this.dayOfMonth > givenDate.Day && --month < 1)
        //            {
        //                --year;
        //                month = 12;
        //            }

        //            daysInMonth = DateTime.DaysInMonth(year, month);
        //            int earlierScheduledDayOfMonth = this.dayOfMonth;
        //            if (earlierScheduledDayOfMonth > daysInMonth) earlierScheduledDayOfMonth = daysInMonth;
        //            scheduledDate = new DateTime(year, month, earlierScheduledDayOfMonth);

        //            //If it is a non work day, get the next work day 
        //            while (null == nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //            {
        //                scheduledHours = workCalendar.FindWorkDayAfter(scheduledDate, nonworkSchedule);
        //                scheduledDate = scheduledHours.From.Date;
        //            }
        //            if (scheduledDate.Date == givenDate.Date)
        //            {
        //                scheduledHours = this.hourInterval.Clone();
        //                return true;
        //            }
        //            break;

        //        case RescheduleOption.ScheduledDayBefore:
        //            //Find the later scheduled date
        //            if (this.dayOfMonth < givenDate.Day && ++month > 12)
        //            {
        //                ++year;
        //                month = 1;
        //            }

        //            daysInMonth = DateTime.DaysInMonth(year, month);
        //            int laterScheduledDayOfMonth = this.dayOfMonth;
        //            if (laterScheduledDayOfMonth > daysInMonth) laterScheduledDayOfMonth = daysInMonth;
        //            scheduledDate = new DateTime(year, month, laterScheduledDayOfMonth);

        //            //If it is a non work day, get the next work day 
        //            while (null != nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //            {
        //                scheduledHours = workCalendar.FindWorkDayBefore(scheduledDate, nonworkSchedule);
        //                scheduledDate = scheduledHours.From.Date;
        //            }
        //            if (scheduledDate.Date == givenDate.Date)
        //            {
        //                scheduledHours = this.hourInterval.Clone();
        //                return true;
        //            }
        //            break;
        //    }
        //    scheduledHours = null;
        //    return false;
        //}

        public override string ToLongString()
        {
            return string.Format("the {0} day of every month, {1} - {2}",
                    iSabayaUtility.ConvertToOrdinalNumberString(this.dayOfMonth), base.HourInterval.From.ToShortTimeString(),
                    base.HourInterval.To.ToShortTimeString() + GetRescheduleOptionText(base.RescheduleIfHoliday));
        }

        #endregion ScheduleDetail implementaion

        public override string ToString()
        {
            return string.Format("The {0} day of every month", iSabayaUtility.ConvertToOrdinalNumberString(this.dayOfMonth));
        }

        public class SortByDayNo : IComparer
        {
            public int Compare(object a, object b)
            {
                ScheduleMonthlyOnDay aa = (ScheduleMonthlyOnDay)a;
                ScheduleMonthlyOnDay bb = (ScheduleMonthlyOnDay)b;
                if (aa.dayOfMonth > bb.dayOfMonth) return 1;
                if (aa.dayOfMonth < bb.dayOfMonth) return -1;
                return 0;
            }
        }

        public override string ToLog()
        {
            return base.ToLog("Monthly:the " + this.DayOfMonth + iSabayaUtility.OrdinalIndicator[this.DayOfMonth]);
        }
    }
}