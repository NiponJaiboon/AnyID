using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class OrgName : PersistentTemporalEntity
    {
        public OrgName()
        {
        }

        public OrgName(MultilingualString name)
        {
            this.Name = name;
            this.EffectivePeriod = new TimeInterval(DateTime.Now);
        }

        public OrgName(OrgBase owner, String code, MultilingualString name, MultilingualString shortName,
                        DateTime effectiveFrom, User updatedBy)
        {
            this.Owner = owner;
            this.Code = code;
            this.Name = name;
            this.ShortName = shortName;
            this.EffectivePeriod = new TimeInterval(effectiveFrom);
            this.UpdatedBy = updatedBy;
        }

        public OrgName(OrgBase owner, String code, MultilingualString name, MultilingualString shortName,
                        TimeInterval effectivePeriod, User updatedBy)
        {
            this.Owner = owner;
            this.Code = code;
            this.Name = name;
            this.ShortName = shortName;
            this.EffectivePeriod = effectivePeriod;
            this.UpdatedBy = updatedBy;
        }

        #region persistent

        public virtual OrgBase Owner{get;set;}
        public virtual MultilingualString Name { get; set; }
        public virtual MultilingualString ShortName { get; set; }
        public virtual DateTime OrderedDate { get; set; }
        public virtual object Logo { get; set; }
        public virtual DateTime UpdatedTS { get; set; }
        public virtual User UpdatedBy { get; set; }

        #endregion persistent

        public override void Persist(Context context)
        {
            if (null != this.Name) this.Name.Persist(context);
            if (null != this.ShortName) this.ShortName.Persist(context);
            context.Persist(this);
        }

        public override string ToString(String langCode)
        {
            return this.Name.ToString(langCode);
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(this.LanguageCode))
                return this.Name.ToString(this.LanguageCode);


            if (null != this.Owner && !String.IsNullOrEmpty(this.Owner.LanguageCode))
                return this.ToString(this.Owner.LanguageCode);

            return this.Name.ToString();
        }

        public virtual string ToLog()
        {
            return "";
        }
    }
} 
