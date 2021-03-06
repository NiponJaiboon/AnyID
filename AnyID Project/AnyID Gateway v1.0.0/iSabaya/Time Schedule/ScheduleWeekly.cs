using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{


    public class ScheduleWeekly : ScheduleDayOfWeek
    {
        public ScheduleWeekly()
        {
        }

        public ScheduleWeekly(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval, 
                                TreeListNode timeCategory, DayOfWeek dayOfWeek)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory, dayOfWeek)
        {
        }

        #region ScheduleDetail implementaion

        public override TimeInterval GetScheduledHoursOn(DateTime timestamp)
        {
            if (timestamp.DayOfWeek == base.DayOfWeek)
                return new TimeInterval(timestamp, base.HourInterval);
            return null;
        }

        public override bool IsScheduledDate(DateTime date)
        {
            return date.DayOfWeek == base.DayOfWeek;
        }

        //public override bool IsScheduledOrRescheduledDay(DateTime givenDate, TimeSchedule workCalendar, TimeSchedule nonworkSchedule,
        //                                                out TimeInterval scheduledHours)
        //{
        //    int scheduledDayOfWeek = base.dayOfWeek;
        //    int givenDayOfWeek = (int)givenDate.DayOfWeek;

        //    //Check if the given date is a scheduled day
        //    if (scheduledDayOfWeek == givenDayOfWeek) // && this.hourInterval.Includes(date))
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
        //    int dayDiff;
        //    DateTime scheduledDate;
        //    switch (this.rescheduleIfHoliday)
        //    {
        //        case RescheduleOption.ScheduledDayAfter:
        //            dayDiff = scheduledDayOfWeek - givenDayOfWeek;
        //            if (dayDiff > 0) dayDiff -= 7;

        //            scheduledDate = givenDate.AddDays(dayDiff);
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
        //            dayDiff = scheduledDayOfWeek - givenDayOfWeek;
        //            if (dayDiff < 0) dayDiff += 7;

        //            scheduledDate = givenDate.AddDays(dayDiff);
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
            return "Every " + DayOfWeek.ToString() + ", " + base.HourInterval.From.ToShortTimeString()
                + " - " + base.HourInterval.To.ToShortTimeString() + GetRescheduleOptionText(base.RescheduleIfHoliday);
        }

        #endregion ScheduleDetail implementaion

        public override string ToString()
        {
            return "Every " + DayOfWeek.ToString();
        }
    }
}
