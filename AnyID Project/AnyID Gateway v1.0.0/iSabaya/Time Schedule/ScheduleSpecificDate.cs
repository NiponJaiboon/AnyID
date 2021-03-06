using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace iSabaya
{

    public class ScheduleSpecificDate : ScheduleDetail
    {
        public ScheduleSpecificDate()
        {
        }

        public ScheduleSpecificDate(DateTime date, MultilingualString title)
            : base(title)
        {
            this.date = date;
        }

        public ScheduleSpecificDate(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval, 
                                    TreeListNode timeCategory, DateTime date, MultilingualString title)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory, title)
        {
            this.date = date;
        }

        #region persistent

        protected DateTime date;
        public virtual DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        
        #endregion persistent

        #region ScheduleDetail implementaion

        public override TimeInterval GetScheduledHoursOn(DateTime timestamp)
        {
            if (timestamp.Day == this.date.Day && timestamp.Month == this.date.Month 
                && timestamp.Year == this.date.Year)
                return new TimeInterval(timestamp, base.HourInterval);
            return null;
        }

        public override bool IsScheduledDate(DateTime date)
        {
            return date.Day == this.date.Day && date.Month == this.date.Month
                    && date.Year == this.date.Year;
        }

        //public override bool IsScheduledOrRescheduledDay(DateTime givenDate, TimeSchedule workSchedule, TimeSchedule nonworkSchedule,
        //                                                out TimeInterval scheduledHours)
        //{
        //    //Check if the given date is a scheduled day
        //    if (this.date.Date == givenDate.Date) // && this.hourInterval.Includes(date))
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

        //    if (null != workSchedule || null != nonworkSchedule)
        //    {
        //        //The given date is not in schedule; 
        //        //check if is coincided with a rescheduled date of one of the surrounding scheduled dates
        //        DateTime scheduledDate = this.date;
        //        switch (this.rescheduleIfHoliday)
        //        {
        //            case RescheduleOption.ScheduledDayAfter:
        //                if (givenDate < scheduledDate) break;
        //                while (null == nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //                {
        //                    scheduledHours = workSchedule.FindWorkDayAfter(scheduledDate, nonworkSchedule);
        //                    scheduledDate = scheduledHours.From.Date;
        //                }
        //                if (scheduledDate.Date == givenDate.Date)
        //                {
        //                    scheduledHours = this.hourInterval.Clone();
        //                    return true;
        //                }
        //                break;

        //            case RescheduleOption.ScheduledDayBefore:
        //                if (givenDate > scheduledDate) break;
        //                while (null == nonworkSchedule.GetScheduledHoursOn(scheduledDate))
        //                {
        //                    scheduledHours = workSchedule.FindWorkDayBefore(scheduledDate, nonworkSchedule);
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
            return ToString() + GetRescheduleOptionText(base.RescheduleIfHoliday);
        }

        #endregion ScheduleDetail implementaion

        public override string ToString()
        {
            return date.ToShortDateString();
        }

        public class SortByDate : IComparer
        {
            public int Compare(object a, object b)
            {
                ScheduleSpecificDate aa = (ScheduleSpecificDate)a;
                ScheduleSpecificDate bb = (ScheduleSpecificDate)b;
                if (aa.Date > bb.Date) return 1;
                if (aa.Date < bb.Date) return -1;
                return 0;
            }
        }

        public override string ToLog()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");

            //From ScheduleDetail
            builder.Append("ScheduleDetailID:");
            builder.Append(ID);
            builder.Append(",");

            builder.Append("SeqNo:");
            builder.Append(SeqNo);
            builder.Append(", ");

            builder.Append("Title:");
            builder.Append(Title.ToLog());
            builder.Append(", ");

            builder.Append("RescheduleIfHoliday:");
            builder.Append(RescheduleIfHoliday);
            builder.Append(", ");

            //builder.Append("DayNo:");
            //builder.Append(DayNo);
            //builder.Append(", ");

            builder.Append("Schedule:");
            builder.Append(Schedule.ToLog());
            builder.Append(", ");

            builder.Append("Description:");
            builder.Append(Description);
            builder.Append(", ");

            //From ScheduleSpecificDate
            builder.Append("Date:");
            builder.Append(Date);
            builder.Append("]");

            return builder.ToString();
        }
    }
}
