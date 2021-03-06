using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    [Serializable]
    public class PartyName : PersistentTemporalEntity
    {
        public PartyName()
        {
        }

        public PartyName(Party owner, String code, MultilingualString name, MultilingualString shortName,
                        DateTime effectiveFrom, User updatedBy)
        {
            this.Party = owner;
            this.Code = code;
            this.Name = name;
            this.ShortName = shortName;
            this.EffectivePeriod = new TimeInterval(effectiveFrom);
            this.UpdatedBy = updatedBy;
        }

        public PartyName(Party owner, String code, MultilingualString name, MultilingualString shortName,
                        TimeInterval effectivePeriod, User updatedBy)
        {
            this.Party = owner;
            this.Code = code;
            this.Name = name;
            this.ShortName = shortName;
            this.EffectivePeriod = effectivePeriod;
            this.UpdatedBy = updatedBy;
        }

        #region persistent

        public virtual Party Party { get; set; }
        public virtual MultilingualString Name { get; set; }
        public virtual MultilingualString ShortName { get; set; }
        public virtual DateTime OrderedDate { get; set; }
        public virtual object Logo { get; set; }
        public virtual DateTime UpdatedTS { get; set; }
        public virtual User UpdatedBy { get; set; }

        #endregion persistent

        public override void Persist(Context context)
        {
            if (0 == this.Name.ID)
                this.Name.Persist(context);
            if (0 == this.ShortName.ID)
                this.ShortName.Persist(context);
            context.Persist(this);
        }

        public override string ToString(String langCode)
        {
            return this.Code + " - " + this.Name.ToString(langCode);
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        public virtual string ToLog()
        {
            return "";
        }
    }
} 
