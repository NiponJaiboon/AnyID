using System;
using System.Collections.Generic;
using System.Text;
using iSabaya;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public abstract class OrgBase : Party
    {
        public const char CodePathSeparator = '|';
        public OrgBase()
        {
        }
        public OrgBase(DateTime effectiveDate)
            : base(effectiveDate)
        {
        }
        public OrgBase(TimeInterval effectivePeriod)
            : base(effectivePeriod)
        {
        }

        #region persistent


        protected OrgName currentName;

        public virtual OrgName CurrentName
        {
            get { return currentName; }
            set
            {
                if (value == null) return;
                if (!object.ReferenceEquals(this.currentName, value))
                {
                    this.currentName = value;
                    value.Owner = this;
                    if (!this.Names.Contains(value))
                        this.Names.Add(value);
                }
            }
        }

        public virtual bool IsInactive { get; set; }

        private String url;

        public virtual String URL
        {
            get { return url; }
            set { url = value; }
        }

        protected ITemporalList<OrgName> names;

        public virtual ITemporalList<OrgName> Names
        {
            get
            {
                if (null == this.names)
                    names = new TemporalList<OrgName>();
                return names;
            }
            protected set { names = value; }
        }

        public virtual TimeSchedule HolidayCalendar { get; set; }
        public virtual TimeSchedule DefaultWorkSchedule { get; set; }

        #endregion persistent

        //protected System.Collections.ArrayList persons;

        #region Party Members

        public override String ToString()
        {
            if (null == this.CurrentName)
                if (null == this.Code || "" == this.Code)
                    return "Org " + this.ID;
                else
                    return this.Code;
            else
                return this.Code + "-" + this.CurrentName.ToString(this.LanguageCode); // +" - " + this.CurrentName.ToString();
        }

        public override MultilingualString MultilingualName
        {
            get { return null == this.CurrentName ? null : CurrentName.Name; }
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            foreach (OrgName n in this.Names)
            {
                n.Owner = this;
                n.Persist(context);
            }
            if (null != this.DefaultWorkSchedule)
                this.DefaultWorkSchedule.Persist(context);
            if (null != this.HolidayCalendar)
                this.HolidayCalendar.Persist(context);
            //foreach (PartyContact a in this.Contacts)
            //{
            //    a.Party = this;
            //    a.Persist(context);
            //}
        }

        public override string FullName
        {
            get
            {
                if (null == this.CurrentName)
                    return "";
                else
                    if (null == base.Context)
                        return this.CurrentName.ToString();
                    else
                        return this.CurrentName.ToString(base.Context.CurrentLanguage.Code);
            }
        }

        #endregion

        #region operations

        public override String ToString(String langCode)
        {
            if (null == this.CurrentName)
                return "";
            else
                return this.CurrentName.ToString(langCode);
        }

        //public virtual OrgName GetName(DateTime onDate)
        //{
        //    return TemporalCollection<OrgName>.GetInstanceOn(this.Names, onDate);
        //}

        #endregion operations

        public override string LanguageCode
        {
            get
            {
                return base.LanguageCode;
            }
            set
            {
                base.LanguageCode = value;
                this.CurrentName.LanguageCode = value;
            }
        }
    }
}
