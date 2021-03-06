using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public abstract class ScheduleDayOfWeek : ScheduleDetail
    {
        public ScheduleDayOfWeek()
        {
        }

        public ScheduleDayOfWeek(int seqNo, RescheduleOption rescheduleIfHoliday, TimeInterval hourInterval, 
                                    TreeListNode timeCategory, DayOfWeek dayOfWeek)
            : base(seqNo, rescheduleIfHoliday, hourInterval, timeCategory)
        {
            this.DayOfWeek = dayOfWeek;
        }

        #region persistent


        protected int dayOfWeek;
        /// <summary>
        /// Sunday = 0, Saturday = 6
        /// </summary>
        public virtual System.DayOfWeek DayOfWeek
        {
            get { return (System.DayOfWeek)dayOfWeek; }
            set { dayOfWeek = (int)value; }
        }

        #endregion

        public override string ToLog()
        {
            return base.ToLog("Weekly:" + this.DayOfWeek.ToString());
        }

    }
}
