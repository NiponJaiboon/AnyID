using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class PartyWorkSchedule : PersistentTemporalEntity
    {
        public PartyWorkSchedule()
        {
        }

        public PartyWorkSchedule(TimeSchedule workSchedule)
        {
            this.WorkSchedule = workSchedule;
            this.EffectivePeriod = new TimeInterval(DateTime.Now);
        }

        public PartyWorkSchedule(OrgBase owner, String code, TimeSchedule workSchedule, DateTime effectiveFrom)
        {
            this.Party = owner;
            this.Code = code;
            this.WorkSchedule = workSchedule;
            this.EffectivePeriod = new TimeInterval(effectiveFrom);
        }

        public PartyWorkSchedule(OrgBase owner, String code, TimeSchedule workSchedule, TimeInterval effectivePeriod)
        {
            this.Party = owner;
            this.Code = code;
            this.WorkSchedule = workSchedule;
            this.EffectivePeriod = effectivePeriod;
        }

        #region persistent

        public virtual Party Party { get; set; }
        public virtual TimeSchedule WorkSchedule { get; set; }

        #endregion persistent

        public override void Persist(Context context)
        {
            if (null != this.WorkSchedule) this.WorkSchedule.Persist(context);
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


            if (null != this.Party && !String.IsNullOrEmpty(this.Party.LanguageCode))
                return this.ToString(this.Party.LanguageCode);

            return this.WorkSchedule.ToString();
        }
    }
}
