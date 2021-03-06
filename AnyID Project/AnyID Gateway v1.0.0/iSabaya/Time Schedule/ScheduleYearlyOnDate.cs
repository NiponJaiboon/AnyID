using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class ScheduleYearlyOnDate : ScheduleDetail
    {
        public ScheduleYearlyOnDate()
        {
        }

        public ScheduleYearlyOnDate(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval, 
                                    TreeListNode timeCategory, DateTime date)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory)
        {
            this.date = date;
        }

        protected DateTime date;
        public virtual DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        
        #region ScheduleDetail implementaion

        public override TimeInterval GetScheduledHoursOn(DateTime timestamp)
        {
            if (timestamp.Day == date.Day && timestamp.Month == date.Month)
                return new TimeInterval(timestamp, base.HourInterval);
            return null;
        }

        public override bool IsScheduledDate(DateTime date)
        {
            return date.Day == date.Day && date.Month == date.Month;
        }

        //public override bool IsScheduledOrRescheduledDay(DateTime givenDate, TimeSchedule workCalendar, TimeSchedule nonworkSchedule,
        //                                                out TimeInterval scheduledHours)
        //{
        //    //Check if the given date is a scheduled day
        //    if (this.date.Date == givenDate.Date) // && this.hourInterval.Includes(date))
        //    {
        //        if (null != nonworkSchedule)
        //            if (null == nonworkSchedule.GetScheduledHoursOn(givenDate))
        //            {
        //                scheduledHours = null;
        //                return false;
        //            }
        //            else
        //            {
        //                scheduledHours = this.hourInterval.Clone();
        //                return true;
        //            }
        //    }

        //    if (null != workCalendar || null != nonworkSchedule)
        //    {
        //        //The given date is not in schedule; 
        //        //check if is coincided with a rescheduled date of one of the surrounding scheduled dates
        //        DateTime scheduledDate = this.date;
        //        switch (this.rescheduleIfHoliday)
        //        {
        //            case RescheduleOption.ScheduledDayAfter:
        //                if (givenDate < scheduledDate) scheduledDate = scheduledDate.AddYears(-1);
        //                while (null == nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //                {
        //                    scheduledHours = workCalendar.FindWorkDayAfter(scheduledDate, nonworkSchedule);
        //                    scheduledDate = scheduledHours.From.Date;
        //                }
        //                if (scheduledDate.Date == givenDate.Date)
        //                {
        //                    scheduledHours = this.hourInterval.Clone();
        //                    return true;
        //                }
        //                break;

        //            case RescheduleOption.ScheduledDayBefore:
        //                if (givenDate > scheduledDate) scheduledDate = scheduledDate.AddYears(1);
        //                while (null == nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //                {
        //                    scheduledHours = workCalendar.FindWorkDayBefore(scheduledDate, nonworkSchedule);
        //                    scheduledDate = scheduledHours.From.Date;
        //                }
        //                if (scheduledDate.Date == givenDate.Date)
        //                {
        //                    scheduledHours = this.hourInterval.Clone();
        //                    return true;
        //                }
        //                break;
        //        }
        //    }
        //    scheduledHours = null;
        //    return false;
        //}

        public override string ToLongString()
        {
            return string.Format("Yearly on {0:m}, {1} - {2}",
                    date, base.HourInterval.From.ToShortTimeString(),
                    base.HourInterval.To.ToShortTimeString() + GetRescheduleOptionText(base.RescheduleIfHoliday));
        }
        
        #endregion ScheduleDetail implementaion

        public override string ToLog()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");


            return builder.ToString();
        }

        public override string ToString()
        {
            return string.Format("Once a year on {0:m}", date);
        }
    }
}
