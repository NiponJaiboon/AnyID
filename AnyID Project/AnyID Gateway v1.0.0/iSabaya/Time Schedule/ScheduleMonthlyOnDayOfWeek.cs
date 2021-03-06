using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class ScheduleMonthlyOnDayOfWeek : ScheduleDayOfWeek
    {
        public ScheduleMonthlyOnDayOfWeek()
        {
        }

        public ScheduleMonthlyOnDayOfWeek(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval, 
                                            TreeListNode timeCategory, int weekOfMonth, DayOfWeek dayOfWeek)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory, dayOfWeek)
        {
            this.WeekOfMonth = weekOfMonth;
        }

        //public virtual int WeekNo
        //{
        //    get { return weekNo; }
        //    set { weekNo = value; }
        //}

        protected int weekNo;
        //signifies the nth dayOfWeek in a month
        //e.g., for the 3rd Friday of the month, we need to set
        //this.DayOfWeek = System.DayOfWeek.Friday and this.WeekOfMonth = 3
        //for the 4th Thursday of the month
        //this.DayOfWeek = System.DayOfWeek.Thursday and this.WeekOfMonth = 4
        public virtual int WeekOfMonth
        {
            get { return weekNo; }
            set
            {
                if (1 <= value && value < 5)
                    weekNo = value;
                else
                    throw new iSabayaException("ScheduleMonthlyOnDayOfWeek.WeekOfMonth value is out of range (1-4)");
            }
        }

        #region ScheduleDetail implementaion

        public override TimeInterval GetScheduledHoursOn(DateTime timestamp)
        {
            //if (timestamp.DayOfWeek == this.DayOfWeek && weekNo == GetDayOfWeekOfMonth(timestamp))
            if (timestamp.Date == this.GetScheduledDate(timestamp.Year, timestamp.Month))
                return new TimeInterval(timestamp, base.HourInterval);

            return null;
        }

        public override bool IsScheduledDate(DateTime date)
        {
            return date.Date == this.GetScheduledDate(date.Year, date.Month).Date;
        }

        //public override bool IsScheduledOrRescheduledDay(DateTime givenDate, TimeSchedule workCalendar, TimeSchedule nonworkSchedule, 
        //                                                out TimeInterval scheduledHours)
        //{
        //    //Check if the given date is a scheduled day
        //    scheduledHours = this.GetScheduledHoursOn(givenDate);
        //    if (null != scheduledHours) // && this.hourInterval.Includes(date))
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
        //    DateTime scheduledDate = this.GetScheduledDate(givenDate.Year, givenDate.Month);
        //    int givenWeekNo = GetDayOfWeekOfMonth(givenDate);
        //    int givenDayOfWeek = (int)givenDate.DayOfWeek;
        //    int givenDay = givenDate.Day;
        //    int dayDiff;
        //    switch (this.rescheduleIfHoliday)
        //    {
        //        case RescheduleOption.ScheduledDayAfter:
        //            dayDiff = givenDate.Subtract(scheduledDate).Days;
        //            if (dayDiff < 0) scheduledDate = scheduledDate.AddMonths(-1);
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
        //            dayDiff = givenDate.Subtract(scheduledDate).Days;
        //            if (dayDiff > 0) scheduledDate = scheduledDate.AddMonths(1);
        //            while (null == nonworkSchedule.GetScheduledHoursOn(scheduledDate))
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
            return "the " + ToCommonString() + GetRescheduleOptionText(base.RescheduleIfHoliday);
        }

        #endregion ScheduleDetail implementaion

        public virtual DateTime GetScheduledDate(int year, int month)
        {
            DateTime first = new DateTime(year, month, 1);
            int diff = base.dayOfWeek - (int)first.DayOfWeek;
            if (diff < 0) diff += 7;
            return first.AddDays(diff + (weekNo - 1) * 7);
        }

        /// <summary>
        /// Return n if the date is the nth day-of-week of the month. 
        /// If the date is the 2nd Friday of the month, the return value is 2.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetDayOfWeekOfMonth(DateTime date)
        {
            return (date.Day - 1) / 7 + 1;
        }

        private static string[] weekNoStrings = { "none ", "1st ", "2nd ", "3rd ", "4th " };
        private string ToCommonString()
        {
            return weekNoStrings[weekNo] + DayOfWeek.ToString() + " of every month";
        }

        public override string ToString()
        {
            return "The " + ToCommonString();
        }

        public override string ToLog()
        {
            return base.ToLog("Monthly on:the " + this.WeekOfMonth + iSabayaUtility.OrdinalIndicator[this.WeekOfMonth-1] + this.DayOfWeek);
        }
    }
}
