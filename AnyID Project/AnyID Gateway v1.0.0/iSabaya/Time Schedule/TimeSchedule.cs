using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class TimeSchedule
    {

        public TimeSchedule()
        {
        }

        public TimeSchedule(TimeSchedule original)
        {
            this.Code = original.Code;
            this.Title = original.Title.Clone();
            this.Description = original.Description.Clone();
        }

        public TimeSchedule(string code, MultilingualString title, MultilingualString description, TimeInterval effectivePeriod)
        {
            this.Code = code;
            this.Title = title;
            this.Description = description;
            if (effectivePeriod == null) effectivePeriod = new TimeInterval();
            this.EffectivePeriod = effectivePeriod;
        }

        #region persistent

        public virtual int ID { get; set; }
        public virtual string Code { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual MultilingualString Description { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }

        protected bool isWork = true;
        /// <summary>
        /// If true, this is a work schedule.
        /// Otherwise this is a nonwork (holiday) schedule.
        /// </summary>
        public virtual bool IsWork
        {
            get { return isWork; }
            set { isWork = value; }
        }

        //public virtual RescheduleOption RescheduleIfHoliday { get; set; }

        protected IList<ScheduleDetail> scheduleDetails;
        public virtual IList<ScheduleDetail> ScheduleDetails
        {
            get
            {
                if (null == scheduleDetails) scheduleDetails = new List<ScheduleDetail>();
                return scheduleDetails;
            }
            set { scheduleDetails = value; }
        }

        public virtual TreeListNode Category { get; set; }
        public virtual User UpdatedBy { get; set; }
        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

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
        /// <param name="hourInterval">The scheduled hours on the given date in the ScheduleDetail instant</param>
        public virtual bool GetFirstMatchedScheduleDetailOnDate(DateTime date, out ScheduleDetail sdItem, out TimeInterval hourInterval)
        {
            sdItem = null;
            hourInterval = null;
            foreach (ScheduleDetail sd in this.ScheduleDetails)
            {
                hourInterval = sd.GetScheduledHoursOn(date);
                if (hourInterval != null && hourInterval != TimeInterval.EmptyInterval)
                {
                    sdItem = sd;
                    return true;
                }
            }
            return false;
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
        /// Find the earliest non-holiday date-time within the range [fromDate, toDate] of the time schedule
        /// starting from fromTimestamp.
        /// Otherwise returns DateTime.MinValue
        /// </summary>
        /// <param name="fromDate">fromTimestamp must be less than or equal to toDate</param>
        /// <param name="toDate">toDate must be equal to or greater than fromTimestamp</param>
        /// <param name="nonworkSchedule">Holiday schedule</param>
        /// <returns></returns>
        //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromTimestamp"></param>
        /// <param name="toDate"></param>
        /// <param name="cutoffTime">cutoff time must be between workhours of the calendar</param>
        /// <param name="nonworkSchedule"></param>
        /// <returns></returns>
        public virtual DateTime FindEarliestScheduledTimestampWithin(DateTime fromTimestamp, DateTime toDate, DateTime cutoffTime, TimeSchedule nonworkSchedule)
        {
            TimeInterval searchInterval;
            DateTime fromDate = fromTimestamp;
            if (fromTimestamp.TimeOfDay > cutoffTime.TimeOfDay)
            {
                DateTime nextDay = fromTimestamp.AddDays(1);
                fromDate = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, 0, 0, 0);
            }
            searchInterval = this.EffectivePeriod.Intersect(fromDate, toDate);

            if (searchInterval.IsEmpty)
                return DateTime.MinValue;

            DateTime scheduledTimestamp;
            TimeInterval scheduledHourInterval = null;
            for (DateTime d = searchInterval.From; d <= searchInterval.To; d = d.AddDays(1))
            {
                ScheduleDetail sdItem;
                if (GetFirstMatchedScheduleDetailOnDate(d, out sdItem, out scheduledHourInterval)
                       && IsNotAHoliday(nonworkSchedule, d))
                    break;
            }

            if (null == scheduledHourInterval)
                scheduledTimestamp = DateTime.MinValue;
            else
            {
                if (fromTimestamp.Date == scheduledHourInterval.From.Date)
                    scheduledTimestamp = fromTimestamp;
                else
                    scheduledTimestamp = scheduledHourInterval.From;
            }
            return scheduledTimestamp;
        }

        private static bool IsNotAHoliday(TimeSchedule nonworkSchedule, DateTime d)
        {
            return (null == nonworkSchedule || null == nonworkSchedule.GetScheduledHoursOn(d));
        }

        ///// <summary>
        ///// Find the closest non-holiday scheduled date after thisDate 
        ///// by looking forward within the number of days in daysToLookBack.
        ///// </summary>
        ///// <param name="thisDate"></param>
        ///// <param name="withinDays">The number of days to look back, must be greater 0</param>
        ///// <param name="holidayCalendar"></param>
        ///// <returns>A scheduled non-holiday date with the same time part as thisDate if found.  Otherwise TimeInterval.MinDate</returns>
        //public virtual DateTime FindClosetScheduledDateAfter(DateTime thisDate, int withinDays, TimeSchedule holidayCalendar)
        //{
        //    TimeInterval scheduledHourInterval = null;
        //    DateTime date = thisDate;
        //    for (int i = 1; i <= withinDays; ++i)
        //    {
        //        date = date.AddDays(i);
        //        ScheduleDetail sdItem;
        //        if (GetFirstMatchedScheduleDetailOnDate(date, out sdItem, out scheduledHourInterval)
        //               && IsNotAHoliday(holidayCalendar, date))
        //            break;
        //    }
        //    if (null == scheduledHourInterval)
        //        return TimeInterval.MinDate;
        //    else
        //        return scheduledHourInterval.From;
        //}

        /// <summary>
        /// Find the closest scheduled non-holiday date before (If withinDays is negative) or after (if withinDays is positive) with in withinDays of thisDate.
        /// </summary>
        /// <param name="ofDate">The date from which to find the close</param>
        /// <param name="withinDays">The number of days (non-zero) before (if negative), or after (if positive) thisDate</param>
        /// <param name="holidayCalendar">Define the holidays to be skipped.</param>
        /// <returns>A scheduled non-holiday date with the same time part as thisDate if found.  Otherwise TimeInterval.MinDate</returns>
        public virtual DateTime FindClosetScheduledDate(DateTime ofDate, int withinDays, TimeSchedule holidayCalendar)
        {
            if (withinDays == 0)
                throw new Exception("The number of days is zero.");

            TimeInterval scheduledHourInterval = null;
            DateTime date = ofDate;
            ScheduleDetail sdItem;
            if (withinDays < 0)
            {
                for (int i = -1; i >= withinDays; --i)
                {
                    date = date.AddDays(i);
                    if (GetFirstMatchedScheduleDetailOnDate(date, out sdItem, out scheduledHourInterval)
                           && IsNotAHoliday(holidayCalendar, date))
                        break;
                }
            }
            else
            {
                for (int i = 1; i <= withinDays; ++i)
                {
                    date = date.AddDays(i);
                    if (GetFirstMatchedScheduleDetailOnDate(date, out sdItem, out scheduledHourInterval)
                           && IsNotAHoliday(holidayCalendar, date))
                        break;
                }
            }

            if (null == scheduledHourInterval)
                return TimeInterval.MinDate;
            else
                return scheduledHourInterval.From;
        }

        /// <summary>
        /// Return DateTime.MinValue or the latest non-holiday scheduled date within the range [fromDate, toTimestamp] of the time schedule
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public virtual DateTime FindLatestScheduledTimestampWithin(DateTime fromDate, DateTime toTimestamp, TimeSchedule nonworkSchedule)
        {
            TimeInterval searchInterval = this.EffectivePeriod.Intersect(fromDate, toTimestamp);
            if (searchInterval.IsEmpty)
                return DateTime.MinValue;

            TimeInterval scheduledHourInterval = null;
            for (DateTime d = searchInterval.To; d >= searchInterval.From; d = d.AddDays(-1))
            {
                ScheduleDetail sdItem;
                if (GetFirstMatchedScheduleDetailOnDate(d, out sdItem, out scheduledHourInterval)
                       && IsNotAHoliday(nonworkSchedule, d))
                    break;
            }
            if (null == scheduledHourInterval)
                return DateTime.MinValue;
            else
                return scheduledHourInterval.From;
        }

        //public virtual DateTime GetScheduledWorkHoursOnOrEarlierThan(DateTime givenDate, TimeSchedule workCalendar, TimeSchedule holidayCalendar)
        //{
        //    int daysFromEffectiveDate = givenDate.Subtract(this.EffectivePeriod.From).Days;
        //    if (daysFromEffectiveDate > 366)
        //        daysFromEffectiveDate = 366;

        //    DateTime scheduledDate = DateTime.MinValue;
        //    for (int i = 0; i < daysFromEffectiveDate; --i)
        //    {
        //        DateTime d = givenDate.AddDays(i);

        //        //if (d > calendar.EffectivePeriod.To)
        //        //    throw new iSabayaException("Can't find a trade date");

        //        TimeInterval workHours = null;
        //        workHours = this.GetScheduledHourIntervalOn(d, workCalendar, holidayCalendar);
        //        if (workHours != null)
        //        {
        //            if (workHours.From.Date >= givenDate.Date || workHours.Includes(givenDate))
        //                scheduledDate = workHours.From;
        //            break;
        //        }
        //    }
        //    if (scheduledDate == DateTime.MinValue)
        //        throw new iSabayaException("Can't find a scheduled date");
        //    return scheduledDate;
        //}

        //public virtual DateTime GetScheduledWorkHoursOnOrLaterThan(DateTime givenDate, TimeSchedule workCalendar, TimeSchedule holidayCalendar)
        //{
        //    int daysToExpiration = this.EffectivePeriod.To.Subtract(givenDate).Days;
        //    DateTime scheduledDate = DateTime.MinValue;
        //    for (int i = 0; i < ((daysToExpiration < 366) ? daysToExpiration : 366); ++i)
        //    {
        //        DateTime d = givenDate.AddDays(i);
        //        TimeInterval workHours = null;
        //        workHours = this.GetScheduledHourIntervalOn(d, workCalendar, holidayCalendar);
        //        if (workHours != null)
        //        {
        //            if (workHours.From.Date >= givenDate.Date || workHours.Includes(givenDate))
        //                scheduledDate = workHours.From;
        //            break;
        //        }
        //    }
        //    if (scheduledDate == DateTime.MinValue)
        //        throw new iSabayaException("Can't find a scheduled date");
        //    return scheduledDate;
        //}

        public virtual bool IsScheduledDay(DateTime date)
        {
            bool isScheduleDay = false;

            foreach (ScheduleDetail sd in scheduleDetails)
            {
                if (sd.IsScheduledDate(date))
                {
                    isScheduleDay = true;
                    break;
                }
            }

            return isScheduleDay;
        }

        public virtual bool IsScheduledDayAndNotAHoliday(DateTime givenDate, TimeSchedule nonworkSchedule)
        {
            if (IsScheduledDay(givenDate))
            {
                if (null == nonworkSchedule)
                    return true;
                if (!nonworkSchedule.IsScheduledDay(givenDate))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check whether the given date is a scheduled date or coincides with a rescheduled date 
        /// (when work schedule and holiday schedule are taken into account).
        /// this.WorkCalendar and this.WorkCalendar.HolidayCalendar should be set for a rescheduled date
        /// </summary>
        /// <param name="givenDate"></param>
        /// <param name="daysToSearch">No. of days to </param>
        /// <param name="scheduledHours"></param>
        /// <returns></returns>
        public virtual bool IsScheduledDayWithin(DateTime fromDate, DateTime toDate, TimeSchedule nonworkSchedule)
        {
            if (fromDate <= toDate)
                for (DateTime d = fromDate; d <= toDate; d = d.AddDays(1))
                {
                    if (IsScheduledDayAndNotAHoliday(d, nonworkSchedule))
                        return true;
                }
            return false;

        }

        public virtual float NumberOfNonworkDays(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public virtual float NumberOfWorkDays(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public virtual float NumberOfWorkDays(TimeSchedule holidayCalendar, DateTime fromDate, DateTime toDate)
        {
            int workDays = 0;
            if (fromDate <= toDate)
            {
                for (DateTime d = fromDate; d <= toDate; d = d.AddDays(1))
                {
                    if (IsScheduledDayAndNotAHoliday(d, holidayCalendar))
                        ++workDays;
                }
            }
            return workDays;
        }

        //public virtual DateTime FindScheduledDateForTimestamp(TimeSchedule workCalendar, TimeSchedule nonworkCalendar, DateTime timestamp)
        //{
        //    if (timestamp < this.EffectivePeriod.From) 
        //        throw new iSabayaException("The calendar was not effective on the given timestamp.");

        //    int daysToExpiration = this.EffectivePeriod.To.Subtract(timestamp).Days;

        //    for (int i = 0; i < ((daysToExpiration < 366) ? daysToExpiration : 366); ++i)
        //    {
        //        TimeInterval workHours;
        //        DateTime d = timestamp.AddDays(i);

        //        //if (d > calendar.EffectivePeriod.To)
        //        //    throw new iSabayaException("Can't find a trade date");

        //        workHours = this.GetScheduledHourIntervalOn(d, workCalendar, nonworkCalendar);
        //        if (workHours == null) continue; //non-scheduled day
        //        if (workHours.From.Date >= timestamp.Date || workHours.Includes(timestamp))
        //            return workHours.From;
        //        break;
        //    }
        //    throw new iSabayaException("Can't find a scheduled date");
        //}

        //public virtual bool GetScheduledOrRescheduledDayOn(DateTime givenDate, int daysToSearch, TimeSchedule nonworkSchedule,
        //                                                out ScheduleDetail sd, out TimeInterval hourInterval)
        //{
        //    bool found = false;
        //    sd = null;
        //    hourInterval = null;

        //    TimeInterval searchInterval;

        //    switch (this.RescheduleIfHoliday)
        //    {
        //        case RescheduleOption.ScheduledDayAfter:
        //            searchInterval = this.EffectivePeriod.Intersect(givenDate, givenDate.AddDays(daysToSearch));
        //            if (!searchInterval.IsEmpty())
        //                for (DateTime d = searchInterval.From; d >= searchInterval.To; d = d.AddDays(1))
        //                {
        //                    if (GetScheduledDayAndNotAHoliday(d, nonworkSchedule, out sd, out hourInterval))
        //                    {
        //                        found = true;
        //                        break;
        //                    }
        //                }
        //            break;

        //        case RescheduleOption.ScheduledDayBefore:
        //            searchInterval = this.EffectivePeriod.Intersect(givenDate.AddDays(-daysToSearch), givenDate);
        //            if (!searchInterval.IsEmpty())
        //                for (DateTime d = searchInterval.To; d >= searchInterval.From; d = d.AddDays(-1))
        //                {
        //                    if (GetScheduledDayAndNotAHoliday(d, nonworkSchedule, out sd, out hourInterval))
        //                    {
        //                        found = true;
        //                        break;
        //                    }
        //                }
        //            break;

        //        default:
        //            if (GetScheduledDayAndNotAHoliday(givenDate, nonworkSchedule, out sd, out hourInterval))
        //            {
        //                found = true;
        //                break;
        //            }
        //            break;

        //    }
        //    return found;
        //}

        //private bool GetScheduledDayAndNotAHoliday(DateTime givenDate, TimeSchedule nonworkSchedule, out ScheduleDetail sd, out TimeInterval hourInterval)
        //{
        //    if (this.GetFirstMatchedScheduleDetailOnDate(givenDate.Date, out sd, out hourInterval))
        //        return (null == nonworkSchedule || !nonworkSchedule.IsScheduledDay(givenDate));
        //    else
        //        return false;
        //}

        //public virtual DateTime FindScheduledDateForTimestamp(DateTime timestamp, DateTime cutoffTime, int daysToSearch, TimeSchedule nonworkSchedule)
        //{
        //    ScheduleDetail sd;
        //    TimeInterval hourInterval = null;
        //    DateTime scheduledTimestamp;
        //    TimeInterval searchInterval;

        //    switch (this.RescheduleIfHoliday)
        //    {
        //        case RescheduleOption.ScheduledDayAfter:
        //            if (timestamp.TimeOfDay > cutoffTime.TimeOfDay)
        //            {
        //                timestamp = timestamp.AddDays(1);
        //                timestamp = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 0, 0, 0);
        //            }
        //            searchInterval = this.EffectivePeriod.Intersect(timestamp, timestamp.AddDays(daysToSearch));

        //            if (!searchInterval.IsEmpty())
        //                for (DateTime d = searchInterval.From; d >= searchInterval.To; d = d.AddDays(1))
        //                {
        //                    if (GetScheduledDayAndNotAHoliday(d, nonworkSchedule, out sd, out hourInterval))
        //                        break;
        //                }
        //            break;

        //        case RescheduleOption.ScheduledDayBefore:
        //            if (timestamp.TimeOfDay <= cutoffTime.TimeOfDay)
        //            {
        //                timestamp = timestamp.AddDays(-1);
        //                timestamp = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 0, 0, 0);
        //            }
        //            searchInterval = this.EffectivePeriod.Intersect(timestamp.AddDays(-daysToSearch), timestamp);
        //            if (!searchInterval.IsEmpty())
        //                for (DateTime d = searchInterval.To; d >= searchInterval.From; d = d.AddDays(-1))
        //                {
        //                    if (GetScheduledDayAndNotAHoliday(d, nonworkSchedule, out sd, out hourInterval))
        //                        break;
        //                }
        //            break;

        //        default:
        //            GetScheduledDayAndNotAHoliday(timestamp, nonworkSchedule, out sd, out hourInterval);
        //            break;

        //    }

        //    if (null == hourInterval)
        //        scheduledTimestamp = DateTime.MinValue;
        //    else
        //    {
        //        if (timestamp.Date == hourInterval.From.Date)
        //            scheduledTimestamp = timestamp;
        //        else
        //            scheduledTimestamp = hourInterval.From;
        //    }
        //    return scheduledTimestamp;
        //}

        public virtual void Persist(Context context)
        {
            if (Title != null) Title.Persist(context);
            if (Description != null) Description.Persist(context);

            context.Persist(this);

            foreach (ScheduleDetail sd in scheduleDetails)
            {
                sd.Schedule = this;
                sd.Persist(context);
            }
        }

        #endregion operations

        #region static

        /// <summary>
        /// End of month
        /// </summary>
        public const int EOM = 31;

        public static IList<TimeSchedule> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(TimeSchedule));
            crit.Add(Expression.IsNotNull("HolidayCalendar"));
            return crit.List<TimeSchedule>();
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

        public virtual void Update(Context context)
        {
            context.PersistenceSession.Update(this);
        }

        public static TimeSchedule Find(Context context, int scheduleId)
        {
            TimeSchedule schedule = context.PersistenceSession.Get<TimeSchedule>(scheduleId);
            return schedule;
        }

        public virtual string ToLog()
        {
            return "";
        }

        //xxx
        public static IList<TimeSchedule> Find(Context context, string keyWord)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<TimeSchedule>();
            TreeListNode category = TreeListNode.FindByCode(context, "MFAccountSchedule");
            crit.Add(Expression.Eq("Category", category));

            crit.CreateAlias("Title", "title");

            //crit.Add(Expression.Like("title", ""));
            return crit.List<TimeSchedule>();
        }
        //xxx
        public static IList<TimeSchedule> List(Context context, TreeListNode category)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<TimeSchedule>();
            crit.Add(Expression.Eq("Category", category));
            //if (!category.Code.Equals("MFAccountSchedule"))
            //{
            //    crit.Add(Expression.IsNotNull("HolidayCalendar"));
            //}
            return crit.List<TimeSchedule>();
        }

        public override string ToString()
        {
            if (this.Title == null)
                return this.Code;
            else
                return this.Code + "-" + this.Title.ToString();

        }

        public virtual string ToString(string langCode)
        {
            throw new NotImplementedException();
        }
    }
}
