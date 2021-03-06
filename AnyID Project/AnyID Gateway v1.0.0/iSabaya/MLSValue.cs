using System;
using System.Collections.Generic;

namespace iSabaya
{

    public class MLSValue
    {
        public MLSValue()
        {
        }

        public MLSValue(String languageCode, String stringValue)
        {
            this.LanguageCode = languageCode;
            this.Value = stringValue;
        }

        public MLSValue(MultilingualString owner, MLSValue value)
        {
            this.Owner = owner;
            this.Language = value.Language;
            this.Value = value.Value;
        }

        public MLSValue(MultilingualString owner, string languageCode, string value)
        {
            if (null == Configuration.CurrentConfiguration
                || null == (this.Language = iSabaya.Language.FindByCode(languageCode)))
                throw new iSabayaException(Messages.MLSUndefinedLanguageCode + languageCode);
            this.Owner = owner;
            this.Value = value;
        }

        public MLSValue(MultilingualString owner, Language lang, string value)
        {
            this.Owner = owner;
            this.Language = lang;
            this.Value = value;
        }

        #region persistent

        public virtual long ID { get; set; }
        public virtual MultilingualString Owner { get; set; }
        public virtual string LanguageCode { get; set; }
        public virtual string Value { get; set; }

        #endregion persistent

        public virtual Language Language
        {
            get { return Language.FindByCode(this.LanguageCode); }
            set
            {
                if (null == value)
                    this.LanguageCode = null;
                else
                    this.LanguageCode = value.Code;
            }
        }

        //public virtual void Persist(Context context)
        //{
        //    context.Persist(this);
        //}

        //Used by operator of MultilingualString
        private bool matched;
        public virtual bool Matched
        {
            get { return matched; }
            set { matched = value; }
        }
    }
}
