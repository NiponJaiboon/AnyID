using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace iSabaya
{

    public class ScheduleMonthlyRelativeToEOM : ScheduleDetail
    {
        public ScheduleMonthlyRelativeToEOM()
        {
        }

        public ScheduleMonthlyRelativeToEOM(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval, 
                                            TreeListNode timeCategory, int leadDays)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory)
        {
            //dayNo = 31 => end-of-month
            this.LeadDays = leadDays;
        }

        protected int leadDays;
        /// <summary>
        /// DayNo = 0..6 for weekly schedule where 0 is Sunday
        /// DayNo = 0..31 for monthly schedule where DayNo > end-of-month day implies the end-of-month
        /// </summary>
        public virtual int LeadDays
        {
            get { return this.leadDays; }
            set
            {
                if (value < 0 || 28 < value)
                    throw new iSabayaException("The value of lead days is not between 0 and 28.");
                this.leadDays = value;
            }
        }

        public virtual DateTime GetScheduledDate(int year, int month)
        {
            if (month == 12)
                return new DateTime(year, 12, 31);
            else
                return new DateTime(year, month + 1, 1).AddDays(-(1 - this.LeadDays));
        }

        #region ScheduleDetail implementaion

        public override TimeInterval GetScheduledHoursOn(DateTime timestamp)
        {
            DateTime scheduledDate = this.GetScheduledDate(timestamp.Year, timestamp.Month);
            if (timestamp.Date == scheduledDate.Date)
                return new TimeInterval(timestamp, base.HourInterval);
            return null;
        }

        public override bool IsScheduledDate(DateTime date)
        {
            //if a month does not have day 31 then the last day of the month is considered the scheduled day.
            return date.Date == this.GetScheduledDate(date.Year, date.Month).Date;
        }

        //public override bool IsScheduledOrRescheduledDay(DateTime givenDate, TimeSchedule workCalendar, TimeSchedule nonworkSchedule,
        //                                                out TimeInterval scheduledHours)
        //{
        //    DateTime scheduledDate;

        //    //Check if the given date is a scheduled day
        //    scheduledDate = GetScheduledDate(givenDate.Year, givenDate.Month);
        //    scheduledHours = null;

        //    if (scheduledDate.Day == givenDate.Day) // && this.hourInterval.Includes(date))
        //    {
        //        if (null != nonworkSchedule && null == nonworkSchedule.GetScheduledHoursOn(givenDate))
        //            return false;
        //        scheduledHours = this.hourInterval.Clone();
        //        return true;
        //    }

        //    if (null == workCalendar || null == nonworkSchedule)
        //    {
        //        scheduledHours = null;
        //        return false;
        //    }

        //    //The given date is not in the schedule; 
        //    //check if it coincides with a rescheduled date of one of the surrounding scheduled dates
        //    switch (this.RescheduleIfHoliday)
        //    {
        //        case RescheduleOption.ScheduledDayBefore:
        //            if (givenDate > scheduledDate)
        //            {
        //                //Get the scheduled date in the next month 
        //                DateTime nextMonth = givenDate.AddMonths(1);
        //                scheduledDate = GetScheduledDate(nextMonth.Year, nextMonth.Month);
        //            }
        //            if (null !=nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //                return false;
        //            scheduledHours = workCalendar.FindWorkDayBefore(scheduledDate, nonworkSchedule);
        //            scheduledDate = scheduledHours.From.Date;
        //            return givenDate == scheduledDate;

        //        case RescheduleOption.ScheduledDayAfter:
        //            if (givenDate < scheduledDate)
        //            {
        //                //Get the scheduled date in the preceeding month 
        //                DateTime previousMonth = givenDate.AddMonths(-1);
        //                scheduledDate = GetScheduledDate(previousMonth.Year, previousMonth.Month);
        //            }

        //            if (null !=nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //                return false;
        //            scheduledHours = workCalendar.FindWorkDayAfter(scheduledDate, nonworkSchedule);
        //            scheduledDate = scheduledHours.From.Date;
        //            return givenDate == scheduledDate;
        //    }
        //    scheduledHours = null;
        //    return false;
        //}

        public override string ToLongString()
        {
            return String.Format((this.LeadDays == 0 ? "monthly on the end of month"
                                        : "monthly, " + this.LeadDays + " days before EOM")
                                    + base.HourInterval.ToString()
                                    + GetRescheduleOptionText(base.RescheduleIfHoliday));
        }

        #endregion ScheduleDetail implementaion

        public override string ToLog()
        {
            return base.ToLog("Monthly:"
                + (this.LeadDays == 0 ? "EOM" : this.LeadDays + " days before EOM"));
        }

        public override string ToString()
        {
            return (this.LeadDays == 0 ? "Monthly on the end of month"
                                        : "Monthly, " + this.LeadDays + " days before EOM");
        }
    }
}