using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public abstract class ScheduleDetail
    {
        public static string[] RescheduleOptionText = { "", ", rescheduled to the immediate prior work day if coinciding with holiday", ", rescheduled to the next work day if coinciding with holiday" };
        public static string GetRescheduleOptionText(RescheduleOption opt)
        {
            return RescheduleOptionText[(int)opt];
        }

        public ScheduleDetail()
        {
        }

        public ScheduleDetail(MultilingualString title)
        {
            this.Title = title;
        }

        public ScheduleDetail(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval,
                                TreeListNode timeCategory)
        {
            this.SeqNo = seqNo;
            this.RescheduleIfHoliday = rescheduleIfHoliday;
            this.HourInterval = hourInterval;
            this.TimeCategory = timeCategory;
        }

        public ScheduleDetail(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval,
                                TreeListNode timeCategory, MultilingualString title)
        {
            this.SeqNo = seqNo;
            this.RescheduleIfHoliday = rescheduleIfHoliday;
            this.HourInterval = hourInterval;
            this.Title = title;
            this.TimeCategory = timeCategory;
        }

        #region persistent

        public virtual int ID {get;set;}
        public virtual int SeqNo { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual RescheduleOption RescheduleIfHoliday { get; set; }
        //protected int dayNo;
        ///// <summary>
        ///// DayNo = 0..6 for weekly schedule where 0 is Sunday
        ///// DayNo = 0..31 for monthly schedule where DayNo > end-of-month day implies the end-of-month
        ///// </summary>
        //public virtual int DayNo
        //{
        //    get { return dayNo; }
        //    set { dayNo = value; }
        //}

        //protected bool isWork = true;
        ///// <summary>
        ///// IsWork is ignored if the property IsWork of the schedule that owns this instance is false.
        ///// </summary>
        //public virtual bool IsWork
        //{
        //    get { return isWork; }
        //    set { isWork = value; }
        //}

        /// <summary>
        /// Hour interval for work hour
        /// </summary>
        public virtual TimeInterval HourInterval { get; set; }

        /// <summary>
        /// The schedule to which this instance belongs 
        /// </summary>
        public virtual TimeSchedule Schedule { get; set; }
        public virtual TreeListNode TimeCategory { get; set; }

        #endregion persistent

        public abstract string ToLongString();
        //public abstract List<TimeInterval> GetScheduledHours(TimeInterval interval);
        public abstract TimeInterval GetScheduledHoursOn(DateTime timestamp);
        public abstract bool IsScheduledDate(DateTime date);
        //public abstract bool IsScheduledOrRescheduledDay(DateTime date, TimeSchedule workCalendar, TimeSchedule nonworkSchedule, 
        //                                                out TimeInterval scheduledHours);

        #region transient

        public virtual String Description
        {
            get
            {
                if (Title == null) { return "undefined"; }
                if (Title.ID == 0) { return "undefined"; }
                return Title.ToString();
            }
        }

        #endregion transient

        public virtual void Persist(Context context)
        {
            if (Title != null)
            {
                Title.Persist(context);
            }
            context.Persist(this);
        }

        public static ScheduleDetail Find(Context context, int scheduleDetailID)
        {
            Object obj = context.PersistenceSession.Get(typeof(ScheduleDetail), scheduleDetailID);
            if (obj == null)
            {
                return null;
            }
            return (ScheduleDetail)obj;
        }

        public virtual void Delete(Context context)
        {
            context.PersistenceSession.Delete(this);
        }

        public virtual String Text
        {
            get { return ToLongString(); }
        }

        public abstract String ToLog();

        public virtual String ToLog(String tail)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");

            builder.Append("ScheduleDetailID:");
            builder.Append(this.ID);
            builder.Append(", ");

            builder.Append("SeqNo:");
            builder.Append(this.SeqNo);
            builder.Append(", ");

            builder.Append("Title:");
            builder.Append(this.Title.ToLog());
            builder.Append(", ");

            builder.Append("RescheduleIfHoliday:");
            builder.Append(this.RescheduleIfHoliday);
            builder.Append(", ");

            builder.Append("Schedule:");
            builder.Append(this.Schedule.ToLog());
            builder.Append(", ");

            builder.Append("Description:");
            builder.Append(this.Description);
            builder.Append(", ");

            builder.Append(tail);
            builder.Append("]");

            return builder.ToString();
        }

        public override string ToString()
        {
            if (TimeInterval.EmptyInterval == this.HourInterval)
                return base.ToString();
            else
                return base.ToString() + " " + this.HourInterval.From.ToShortTimeString() + " - " + this.HourInterval.From.ToShortTimeString();
        }
    }
}
