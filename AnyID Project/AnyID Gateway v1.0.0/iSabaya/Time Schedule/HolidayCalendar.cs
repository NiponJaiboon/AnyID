using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class HolidayCalendar : TimeSchedule
    {

        public HolidayCalendar()
        {
        }

        public HolidayCalendar(HolidayCalendar original)
            :base(original)
        {
        }

        public HolidayCalendar(string code, MultilingualString title, MultilingualString description, TimeInterval effectivePeriod)
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

        protected Context context;
        public virtual Context Context
        {
            get { return context; }
            set
            {
                context = value;
                if (null != Title)
                    Title.Context = context;
                if (null != Description)
                    Description.Context = context;
            }
        }

        public virtual void Add(ScheduleDetail sd)
        {
            ScheduleDetails.Add(sd);
            sd.Schedule = this;
        }

        /// <summary>
        /// Return the first ScheduleDetail instant containing the given date (first parameter)
        /// </summary>
        /// <param name="date">The date that is to be covered by the returned sdItem</param>
        /// <param name="isWorkDay">Indicates whether the given date is a work day or non-work day</param>
        /// <param name="sdItem">The ScheduleDetail instant containing the given date</param>
        /// <param name="workHours">The scheduled hours on the given date in the ScheduleDetail instant</param>
        public virtual void GetScheduleDetail(DateTime date, out ScheduleDetail sdItem, out TimeInterval workHours)
        {
            sdItem = null;
            workHours = null;
            foreach (ScheduleDetail sd in this.ScheduleDetails)
            {
                workHours = sd.GetScheduledHoursOn(date);
                if (workHours != null && workHours != TimeInterval.EmptyInterval)
                {
                    sdItem = sd;
                    return;
                }
            }
        }

        public virtual TimeInterval GetScheduledHoursOn(DateTime date)
        {
            TimeInterval scheduledHours = null;
            foreach (ScheduleDetail sd in scheduleDetails)
            {
                scheduledHours = sd.GetScheduledHoursOn(date);
                if (null != scheduledHours)
                    break;
            }
            return scheduledHours;
        }

        /// <summary>
        /// Find a work day after the given date that is not coincide with date in nonworkSchedule
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual TimeInterval FindWorkDay(DateTime date, TimeSchedule nonworkSchedule, RescheduleOption rescheduleOption)
        {
            TimeInterval workHours;
            ScheduleDetail sdItem;

            for (DateTime d = date; d <= effectivePeriod.To; d = d.AddDays(1))
            {
                sdItem = null;
                workHours = null;
                foreach (ScheduleDetail sd in this.ScheduleDetails)
                {
                    
                    workHours = sd.GetScheduledHoursOn(date);
                    if (workHours != null && workHours != TimeInterval.EmptyInterval)
                    {
                        sdItem = sd;
                        break;
                    }
                }

                if (sdItem == null) continue;
                if (null != nonworkSchedule && null != nonworkSchedule.GetScheduledHoursOn(d)) continue;
                return workHours;
            }
            return null;
        }

        /// <summary>
        /// Find a work day after the given date that is not coincide with date in nonworkSchedule
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual TimeInterval FindWorkDayAfter(DateTime date, TimeSchedule nonworkSchedule)
        {
            TimeInterval workHours;
            ScheduleDetail sdItem;

            for (DateTime d = date.AddDays(1); d <= effectivePeriod.To; d = d.AddDays(1))
            {
                GetScheduleDetail(d, out sdItem, out workHours);
                if (sdItem == null) continue;
                if (null != nonworkSchedule && null != nonworkSchedule.GetScheduledHoursOn(d)) continue;
                return workHours;
            }
            return null;
        }

        /// <summary>
        /// Find a work day before the given date taking this.HolidayCalendar into account 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual TimeInterval FindWorkDayBefore(DateTime date, TimeSchedule nonworkSchedule)
        {
            TimeInterval workHours;
            ScheduleDetail sdItem;

            for (DateTime d = date.AddDays(-1); d >= effectivePeriod.From; d = d.AddDays(-1))
            {
                GetScheduleDetail(d, out sdItem, out workHours);
                if (sdItem == null) continue;
                if (null != nonworkSchedule && null != nonworkSchedule.GetScheduledHoursOn(d)) continue;
                return workHours;
            }
            return null;
        }

        /// <summary>
        /// Return the work hours on the given date if it is in this schedule except when it is 
        /// one of the holidays in HolidayCalendar.  In such case, the reschedule option of the 
        /// matched schedule item will guide the search for a work day before/after the given date
        /// using the this.WorkCalendar and HolidayCalendar
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual TimeInterval GetScheduledWorkHoursOn(WorkCalendar workCalendar, HolidayCalendar nonworkSchedule, DateTime date)
        {
            TimeInterval workHours = null;
            ScheduleDetail sdItem;

            GetScheduleDetail(date, out sdItem, out workHours);

            if (sdItem == null) return null;

            if (null == workCalendar || null == nonworkSchedule)
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
                        workInterval = workCalendar.FindWorkDayAfter(date, nonworkSchedule);
                        workHours = new TimeInterval(workInterval.From, workHours);
                        break;
                    default: //case RescheduleOption.ScheduledDayBefore:
                        //find the work day before the date parameter
                        workInterval = workCalendar.FindWorkDayBefore(date, nonworkSchedule);
                        //return the combined interval (date from workInterval.From and hours)
                        workHours = new TimeInterval(workInterval.From, workHours);
                        break;
                }
            }

            return workHours;
        }

        public virtual DateTime GetScheduledWorkHoursOnOrEarlierThan(WorkCalendar workCalendar, HolidayCalendar holidayCalendar, DateTime givenDate)
        {
            int daysFromEffectiveDate = givenDate.Subtract(this.EffectivePeriod.From).Days;
            if (daysFromEffectiveDate > 366)
                daysFromEffectiveDate = 366;

            DateTime scheduledDate = DateTime.MinValue;
            for (int i = 0; i < daysFromEffectiveDate; --i)
            {
                DateTime d = givenDate.AddDays(i);

                //if (d > calendar.EffectivePeriod.To)
                //    throw new iSabayaException("Can't find a trade date");

                TimeInterval workHours = null;
                workHours = this.GetScheduledWorkHoursOn(workCalendar, holidayCalendar, d);
                if (workHours != null)
                {
                    if (workHours.From.Date >= givenDate.Date || workHours.Includes(givenDate))
                        scheduledDate = workHours.From;
                    break;
                }
            }
            if (scheduledDate == DateTime.MinValue)
                throw new iSabayaException("Can't find a scheduled date");
            return scheduledDate;
        }

        public virtual DateTime GetScheduledWorkHoursOnOrLaterThan(WorkCalendar workCalendar, HolidayCalendar holidayCalendar, DateTime givenDate)
        {
            int daysToExpiration = this.EffectivePeriod.To.Subtract(givenDate).Days;
            DateTime scheduledDate = DateTime.MinValue;
            for (int i = 0; i < ((daysToExpiration < 366) ? daysToExpiration : 366); ++i)
            {
                DateTime d = givenDate.AddDays(i);
                TimeInterval workHours = null;
                workHours = this.GetScheduledWorkHoursOn(workCalendar, holidayCalendar, d);
                if (workHours != null)
                {
                    if (workHours.From.Date >= givenDate.Date || workHours.Includes(givenDate))
                        scheduledDate = workHours.From;
                    break;
                }
            }
            if (scheduledDate == DateTime.MinValue)
                throw new iSabayaException("Can't find a scheduled date");
            return scheduledDate;
        }

        public virtual bool IsScheduledDate(DateTime date)
        {
            bool yes = false;

            foreach (ScheduleDetail sd in scheduleDetails)
            {
                if (sd.IsScheduledDate(date))
                {
                    yes = true;
                    break;
                }
            }
            return yes;
        }

        public virtual bool IsWorkDay(DateTime date, WorkCalendar alternativeWorkCalendar, HolidayCalendar holidayCalendar)
        {
            TimeInterval scheduledHours;
            bool isWorkDay = false;

            foreach (ScheduleDetail sd in scheduleDetails)
            {
                if (sd.IsScheduledOrRescheduledDay(date, alternativeWorkCalendar, holidayCalendar, out scheduledHours))
                {
                    isWorkDay = true;
                    break;
                }
                if (scheduledHours != null && scheduledHours != TimeInterval.EmptyInterval)
                    if (holidayCalendar == null || null == holidayCalendar.GetScheduledHoursOn(date))
                        return true;
                if (alternativeWorkCalendar == null)
                    continue;
                switch (sd.RescheduleIfHoliday)
                {
                    case RescheduleOption.NoReschedule:
                        continue;
                    case RescheduleOption.ScheduledDayAfter:
                        //for ()
                        //{
                        //}
                        break;
                    default: //RescheduleOption.ScheduledDayBefore
                        break;
                }
            }

            return isWorkDay;
        }

        public virtual DateTime FindScheduledDateForTimestamp(WorkCalendar workCalendar, HolidayCalendar nonworkCalendar, DateTime timestamp)
        {
            if (timestamp < this.effectivePeriod.From) 
                throw new iSabayaException("The calendar was not effective on the given timestamp.");

            int daysToExpiration = this.effectivePeriod.To.Subtract(timestamp).Days;

            for (int i = 0; i < ((daysToExpiration < 366) ? daysToExpiration : 366); ++i)
            {
                TimeInterval workHours;
                DateTime d = timestamp.AddDays(i);

                //if (d > calendar.EffectivePeriod.To)
                //    throw new iSabayaException("Can't find a trade date");

                workHours = this.GetScheduledWorkHoursOn(workCalendar, nonworkCalendar, d);
                if (workHours == null) continue; //non-scheduled day
                if (workHours.From.Date >= timestamp.Date || workHours.Includes(timestamp))
                    return workHours.From;
                break;
            }
            throw new iSabayaException("Can't find a scheduled date");
        }

        /// <summary>
        /// Check whether the given date is a scheduled date or coincides with a rescheduled date 
        /// (when work schedule and holiday schedule are taken into account).
        /// this.WorkCalendar and this.WorkCalendar.HolidayCalendar should be set for a rescheduled date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="scheduledHours"></param>
        /// <returns></returns>
        public virtual bool IsScheduledOrRescheduledDay(DateTime date, WorkCalendar workCalendar,
                                                        HolidayCalendar nonworkCalendar,
                                                        out TimeInterval scheduledHours)
        {
            foreach (ScheduleDetail sd in scheduleDetails)
            {
                if (sd.IsScheduledOrRescheduledDay(date, workCalendar, nonworkCalendar, out scheduledHours))
                    return true;
            }

            scheduledHours = null;
            return false;
        }

        #endregion operations

        #region static

        public static IList<HolidayCalendar> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria<TimeSchedule>().List<HolidayCalendar>();
        }

        public static HolidayCalendar Find(Context context, int scheduleId)
        {
            HolidayCalendar schedule = context.PersistenceSession.Get<HolidayCalendar>(scheduleId);
            return schedule;
        }

        public static IList<HolidayCalendar> List(Context context, TreeListNode category)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<HolidayCalendar>();
            crit.Add(Expression.Eq("Category", category));
            return crit.List<HolidayCalendar>();
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
