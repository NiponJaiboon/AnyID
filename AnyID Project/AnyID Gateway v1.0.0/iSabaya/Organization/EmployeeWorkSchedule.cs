using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class EmployeeWorkSchedule : PersistentTemporalEntity
    {
        public EmployeeWorkSchedule()
        {
        }

        public EmployeeWorkSchedule(TimeSchedule workSchedule)
        {
            this.WorkSchedule = workSchedule;
            this.EffectivePeriod = new TimeInterval(DateTime.Now);
        }

        public EmployeeWorkSchedule(Employee owner, String code, TimeSchedule workSchedule, DateTime effectiveFrom)
        {
            this.Employee = owner;
            this.Code = code;
            this.WorkSchedule = workSchedule;
            this.EffectivePeriod = new TimeInterval(effectiveFrom);
        }

        public EmployeeWorkSchedule(Employee owner, String code, TimeSchedule workSchedule, TimeInterval effectivePeriod)
        {
            this.Employee = owner;
            this.Code = code;
            this.WorkSchedule = workSchedule;
            this.EffectivePeriod = effectivePeriod;
        }

        #region persistent

        public virtual Employee Employee { get; set; }
        public virtual TimeSchedule WorkSchedule { get; set; }

        #endregion persistent

        public override void Persist(Context context)
        {
            if (null != this.WorkSchedule && this.WorkSchedule.ID == 0) 
                this.WorkSchedule.Persist(context);
            context.Persist(this);
        }

        public override string ToString(String langCode)
        {
            return this.WorkSchedule.ToString(langCode);
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(this.LanguageCode))
                return this.WorkSchedule.ToString(this.LanguageCode);


            if (null != this.Employee && !String.IsNullOrEmpty(this.Employee.LanguageCode))
                return this.ToString(this.Employee.LanguageCode);

            return this.WorkSchedule.ToString();
        }
    }
}
