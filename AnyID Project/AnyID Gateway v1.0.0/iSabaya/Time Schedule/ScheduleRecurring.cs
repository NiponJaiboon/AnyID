using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// Recurring schedule defines a recurring period of any number of consecutive days.
    /// <para/> The first day of the period is day no. 0 and the last day is day no. DaysPerPeriod - 1.
    /// <para/> E.g., A 5-day-of-work weekly schedule is a recurring period of 7 consecutive days 
    /// <para/> in which day no. 1 (Monday, Sunday is day no. 0) to 5 (Friday) are work (scheduled) days.
    /// </summary>

    public class ScheduleRecurring : ScheduleDetail
    {
        /// <summary>
        /// Recurring schedule defines a recurring period of any number of consecutive days.
        /// <para/> The first day of the period is day no. 0 and the last day is day no. DaysPerPeriod - 1.
        /// <para/> E.g., A 5-day-of-work weekly schedule is a recurring period of 7 consecutive days 
        /// <para/> in which day no. 1 (Monday, Sunday is day no. 0) to 5 (Friday) are work (scheduled) days.
        /// </summary>
        public ScheduleRecurring()
        {
        }

        public ScheduleRecurring(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval,
                                TreeListNode timeCategory, DateTime dayZeroDate, int periodLength, int fromDayNo, int toDayNo)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory)
        {
            this.FromDayNo = fromDayNo;
            this.ToDayNo = toDayNo;
            this.daysPerPeriod = periodLength;
            this.DateOfDayZero = dayZeroDate;
        }

        #region persistent

        /// <summary>
        /// The date of the first day of the recurring schedule.
        /// </summary>
        public virtual DateTime DateOfDayZero { get; set; }
        /// <summary>
        /// The first day number (zero-based) in the period, must be between 0 and DaysPerPeriod-1.
        /// </summary>
        public virtual int FromDayNo { get; set; }
        /// <summary>
        /// ToDayNo is the zero-based number of the last day in the period.
        /// <para/> Must be between FromDayNo+1 and DaysPerPeriod-1.
        /// </summary>
        public virtual int ToDayNo { get; set; }

        private int daysPerPeriod = 1; 
        /// <summary>
        /// The number of days in the recurring period, must be greater than 0.
        /// <para/> If this is 7, the schedule is the same as a weekly schedule
        /// </summary>
        public virtual int DaysPerPeriod
        {
            get { return this.daysPerPeriod; }
            set
            {
                if (value < 1)
                    throw new iSabayaException("PeriodLength must be greater than or equal to 1.");
                else
                    this.daysPerPeriod = value;
            }
        }

        #endregion persistent

        #region ScheduleDetail implementaion

        public override string ToLog()
        {
            return base.ToLog(String.Format("SchedulePeriodicInterval: length={0}, interval={1}-{2}", 
                                            this.daysPerPeriod, this.FromDayNo, this.ToDayNo));
        }

        public override TimeInterval GetScheduledHoursOn(DateTime timestamp)
        {
            if (IsScheduledDate(timestamp))
                return base.HourInterval.Clone();
            else
                return null;
        }

        public virtual int GetDayNo(DateTime date)
        {
            int dayNoOfTimeStamp = (date.Date - this.DateOfDayZero.Date).Days % this.DaysPerPeriod;
            if (dayNoOfTimeStamp < 0) dayNoOfTimeStamp += this.DaysPerPeriod;
            return dayNoOfTimeStamp;
        }

        public override bool IsScheduledDate(DateTime date)
        {
            int dayNoOfTimeStamp = GetDayNo(date);
            return (this.FromDayNo <= dayNoOfTimeStamp && dayNoOfTimeStamp <= this.ToDayNo);
        }

        //public override bool IsScheduledOrRescheduledDay(DateTime date, TimeSchedule workCalendar, TimeSchedule nonworkSchedule, 
        //                                                out TimeInterval scheduledHours)
        //{
        //    throw new NotImplementedException();
        //}

        public override string ToLongString()
        {
            throw new NotImplementedException();
        }

        #endregion ScheduleDetail implementaion
    }
}
