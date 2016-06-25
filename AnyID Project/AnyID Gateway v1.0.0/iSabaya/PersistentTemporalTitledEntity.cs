using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{

    public abstract class PersistentTemporalTitledEntity : PersistentTemporalEntity, ITemporal
    {
        public PersistentTemporalTitledEntity()
        {
            //this.IsNotFinalized = true;
        }

        public PersistentTemporalTitledEntity(DateTime effectiveDate, string code, MultilingualString title, MultilingualString shortTitle, MultilingualString description)
            : base(effectiveDate)
        {
            this.Code = code;
            this.Title = title;
            this.ShortTitle = shortTitle;
            this.Description = description;
        }

        public PersistentTemporalTitledEntity(TimeInterval effectivePeriod, string code, MultilingualString title, MultilingualString shortTitle, MultilingualString description)
            : base(effectivePeriod)
        {
            this.Code = code;
            this.Title = title;
            this.ShortTitle = shortTitle;
            this.Description = description;
        }

        public PersistentTemporalTitledEntity(DateTime effectiveDate, string code, MultilingualString title, MultilingualString description, string reference, string remark)
            : base(effectiveDate)
        {
            this.Title = title;
            this.Description = description;
            this.Reference = reference;
            this.Remark = remark;
        }

        #region persistent
        public virtual MultilingualString Title { get; set; }
        public virtual MultilingualString ShortTitle { get; set; }
        public virtual MultilingualString Description { get; set; }

        #endregion

        public override void Persist(Context context)
        {
            if (Title != null)
                Title.Persist(context);
            if (ShortTitle != null)
                ShortTitle.Persist(context);
            if (Description != null)
                Description.Persist(context);
            base.Persist(context);
        }

        public override string ToString(string languageCode)
        {
            StringBuilder sb = new StringBuilder();
            if (Title != null)
                sb.Append(Title.ToString(languageCode));
            return sb.ToString();
        }
    }
}
