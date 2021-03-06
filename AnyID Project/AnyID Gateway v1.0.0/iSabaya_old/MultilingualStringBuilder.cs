using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using System.Collections;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class MultilingualStringBuilder
    {
        struct LanguageStringBuilder
        {
            public Language Language;
            public StringBuilder Builder;

            public LanguageStringBuilder(Language language)
            {
                Language = language;
                Builder = new StringBuilder();
            }
        }

        public MultilingualStringBuilder()
        {
        }

        public MultilingualStringBuilder(MultilingualString original)
        {
            this.Append(original);
        }

        private IList<LanguageStringBuilder> content;
        private IList<LanguageStringBuilder> Content
        {
            get
            {
                if (null == this.content)
                    this.content = new List<LanguageStringBuilder>();
                return this.content;
            }
        }

        #region operators

        public virtual MultilingualString ToMultilingualString()
        {
            MultilingualString mls = new MultilingualString();
            foreach (LanguageStringBuilder b in this.Content)
            {
                mls.Values.Add(new MLSValue(mls, b.Language, b.Builder.ToString()));
            }
            return mls;
        }

        public virtual void Append(MultilingualString mls)
        {
            if (mls == null) return;

            foreach (MLSValue rv in mls.Values)
            {
                bool notFound = true;
                foreach (LanguageStringBuilder b in this.Content)
                {
                    if (b.Language.Code == rv.Language.Code)
                    {
                        b.Builder.Append(rv.Value);
                        notFound = false;
                        break;
                    }
                }
                if (notFound)
                {
                    LanguageStringBuilder b = new LanguageStringBuilder(rv.Language);
                    b.Builder.Append(rv.Value);
                    this.Content.Add(b);
                }
            }
        }

        public virtual void Append(String s)
        {
            foreach (LanguageStringBuilder b in this.Content)
            {
                b.Builder.Append(s);
            }
        }

        #endregion operators

        #region static

        #endregion static
    }
} 