using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class WorkCalendar : TimeSchedule
    {

        public WorkCalendar()
        {
        }

        public WorkCalendar(WorkCalendar original)
            : base(original)
        {
        }

        public WorkCalendar(string code, MultilingualString title, MultilingualString description, TimeInterval effectivePeriod)
            : base(code, title, description, effectivePeriod)
        {
        }

        #region persistent

        //protected int scheduleID;
        //public virtual int ScheduleID
        //{
        //    get { return scheduleID; }
        //    set { scheduleID = value; }
        //}

        //protected string code;
        //public virtual string Code
        //{
        //    get { return code; }
        //    set { code = value; }
        //}

        //protected MultilingualString title;
        //public virtual MultilingualString Title
        //{
        //    get { return title; }
        //    set { title = value; }
        //}

        //protected MultilingualString description;
        //public virtual MultilingualString Description
        //{
        //    get { return description; }
        //    set { description = value; }
        //}

        //protected TimeInterval effectivePeriod;
        //public virtual TimeInterval EffectivePeriod
        //{
        //    get { return effectivePeriod; }
        //    set { effectivePeriod = value; }
        //}

        //protected bool isWork = true;
        ///// <summary>
        ///// If true, this is a work schedule.
        ///// Otherwise this is a nonwork (holiday) schedule.
        ///// </summary>
        //public virtual bool IsWork
        //{
        //    get { return isWork; }
        //    set { isWork = value; }
        //}

        ////public virtual RescheduleOption RescheduleIfHoliday { get; set; }

        //protected IList<ScheduleDetail> scheduleDetails;
        //public virtual IList<ScheduleDetail> ScheduleDetails
        //{
        //    get
        //    {
        //        if (null == scheduleDetails) scheduleDetails = new List<ScheduleDetail>();
        //        return scheduleDetails;
        //    }
        //    set { scheduleDetails = value; }
        //}

        //////if workCalendar exists, use it to reschedule (if any)
        ////protected Schedule workCalendar;
        ////public virtual Schedule WorkCalendar
        ////{
        ////    get { return workCalendar; }
        ////    set { workCalendar = value; }
        ////}

        ////protected Schedule holidayCalendar;
        ////public virtual Schedule HolidayCalendar
        ////{
        ////    get { return holidayCalendar; }
        ////    set { holidayCalendar = value; }
        ////}

        //private TreeListNode category;//xxx
        //public virtual TreeListNode Category
        //{
        //    get { return category; }
        //    set { category = value; }
        //}

        //protected User updatedBy;
        //public virtual User UpdatedBy
        //{
        //    get { return updatedBy; }
        //    set { updatedBy = value; }
        //}

        //protected DateTime updatedTS = DateTime.Now;
        //public virtual DateTime UpdatedTS
        //{
        //    get { return updatedTS; }
        //    set { updatedTS = value; }
        //}

        #endregion persistent

        #region operations

        ///// <summary>
        ///// Find a work day after the given date that is not coincide with date in nonworkSchedule
        ///// </summary>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public virtual TimeInterval FindWorkDayAfter(DateTime date, TimeSchedule nonworkSchedule)
        //{
        //    TimeInterval workHours;
        //    ScheduleDetail sdItem;

        //    for (DateTime d = date.AddDays(1); d <= effectivePeriod.To; d = d.AddDays(1))
        //    {
        //        GetScheduleDetail(d, out sdItem, out workHours);
        //        if (sdItem == null) continue;
        //        if (null != nonworkSchedule && null != nonworkSchedule.GetScheduledHoursOn(d)) continue;
        //        return workHours;
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Find a work day before the given date taking this.HolidayCalendar into account 
        ///// </summary>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public virtual TimeInterval FindWorkDayBefore(DateTime date, TimeSchedule nonworkSchedule)
        //{
        //    TimeInterval workHours;
        //    ScheduleDetail sdItem;

        //    for (DateTime d = date.AddDays(-1); d >= effectivePeriod.From; d = d.AddDays(-1))
        //    {
        //        GetScheduleDetail(d, out sdItem, out workHours);
        //        if (sdItem == null) continue;
        //        if (null != nonworkSchedule && null != nonworkSchedule.GetScheduledHoursOn(d)) continue;
        //        return workHours;
        //    }
        //    return null;
        //}

        /// <summary>
        /// Return the work hours on the given date if it is in this schedule except when it is 
        /// one of the holidays in HolidayCalendar.  In such case, the reschedule option of the 
        /// matched schedule item will guide the search for a work day before/after the given date
        /// using the this.WorkCalendar and HolidayCalendar
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual TimeInterval GetScheduledWorkHoursOn(HolidayCalendar nonworkSchedule, DateTime date)
        {
            TimeInterval workHours = null;
            ScheduleDetail sdItem;

            GetScheduleDetail(date, out sdItem, out workHours);

            if (sdItem == null) return null;

            if (null == nonworkSchedule)
            {
                //if (holidayCalendar == null || !holidayCalendar.IsNonWorkDay(date))
                return workHours;
            }

            if (null != nonworkSchedule.GetScheduledHoursOn(date))
            {
                TimeInterval workInterval;

                switch (sdItem.RescheduleIfHoliday)
                {
                    case RescheduleOption.ScheduledDayAfter:
                        workInterval = FindWorkDayAfter(date, nonworkSchedule);
                        workHours = new TimeInterval(workInterval.From, workHours);
                        break;
                    default: //case RescheduleOption.ScheduledDayBefore:
                        //find the work day before the date parameter
                        workInterval = FindWorkDayBefore(date, nonworkSchedule);
                        //return the combined interval (date from workInterval.From and hours)
                        workHours = new TimeInterval(workInterval.From, workHours);
                        break;
                }
            }

            return workHours;
        }

        #endregion operations

        #region static

        public static IList<WorkCalendar> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria<WorkCalendar>().List<WorkCalendar>();
        }

        public static WorkCalendar Find(Context context, int scheduleId)
        {
            WorkCalendar schedule = context.PersistenceSession.Get<WorkCalendar>(scheduleId);
            return schedule;
        }

        public static IList<WorkCalendar> Find(Context context, string categoryCode)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<WorkCalendar>();
            crit.CreateAlias("Category", "cat");
            crit.Add(Expression.Eq("cat.Code", categoryCode));
            return crit.List<WorkCalendar>();
        }

        public static IList<WorkCalendar> List(Context context, TreeListNode category)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<WorkCalendar>();
            crit.Add(Expression.Eq("Category", category));
            return crit.List<WorkCalendar>();
        }

        #endregion static

        #region Transient
        public virtual String TitleDisplay
        {
            get { return Title.GetValue(); }
        }
        public virtual String DescriptionDisplay
        {
            get { return Description.GetValue(); }
        }
        public virtual DateTime EffectivePeriodFrom
        {
            get { return EffectivePeriod.From; }
        }
        public virtual DateTime EffectivePeriodTo
        {
            get { return EffectivePeriod.To; }
        }
        #endregion
    }
}
