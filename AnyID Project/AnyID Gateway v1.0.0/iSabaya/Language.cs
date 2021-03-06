using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class Language : IComparer
    {
        public Language()
        {
        }

        public Language(string code)
        {
            this.code = code;
            this.isDirty = true;
        }

        public Language(string code, int seqNo, String title, String shortTitle)
        {
            this.code = code;
            this.seqNo = seqNo;
            this.title = title;
            this.shortTitle = shortTitle;
            this.isDirty = true;
        }

        #region Persistence

        protected string code;
        public virtual string Code
        {
            get { return code; }
            set
            {
                code = value;
                this.isDirty = true;
            }
        }

        protected int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set
            {
                seqNo = value;
                this.isDirty = true;
            }
        }

        protected String shortTitle;
        public virtual String ShortTitle
        {
            get { return shortTitle; }
            set
            {
                shortTitle = value;
                this.isDirty = true;
            }
        }

        /// <summary>
        /// For persisting to nonvolatile storage.
        /// </summary>
        public virtual byte[] SmallImageBytes
        {
            get
            {
                if (null == this.SmallImage)
                    return null;
                MemoryStream ms = new MemoryStream();
                this.SmallImage.Save(ms, this.SmallImage.RawFormat);
                return ms.GetBuffer();
            }
            set
            {
                if (null != value)
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream(value);
                        this.SmallImage = Image.FromStream(ms);
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected Image smallImage;
        public virtual Image SmallImage
        {
            get { return smallImage; }
            set
            {
                smallImage = value;
                this.isDirty = true;
            }
        }

        protected String title;
        public virtual String Title
        {
            get { return title; }
            set
            {
                title = value;
                this.isDirty = true;
            }
        }

        #endregion


        public static IList<Language> Languages { get; set; }
        public static IEnumerable<Language> GetAll(ISession session)
        {
            if (null == Languages)
            {
                ICriteria crit = session.CreateCriteria<Language>()
                                        .Add(Expression.IsNotNull("SeqNo"))
                                        .AddOrder(Order.Asc("SeqNo"));
                Languages = crit.List<Language>();
            }
            return Languages;
        }

        public static Language FindByCode(string langCode)
        {
            Language language = null;
            if (null != Languages)
            {
                foreach (Language l in Languages)
                {
                    if (l.Code == langCode)
                    {
                        language = l;
                        break;
                    }
                }
            }
            return language;
        }

        public static Language FindByCode(Context context, string langCode)
        {
            Language language = null;
            foreach (Language l in Languages)
            {
                if (l.Code == langCode)
                {
                    language = l;
                    break;
                }
            }
            return language;
        }

        private bool isDirty = false;

        public virtual void Persist(Context context)
        {
            if (this.isDirty)
            {
                context.PersistenceSession.SaveOrUpdate(this);
                this.isDirty = false;
            }
        }

        StringBuilder builder = new StringBuilder();

        public virtual string ToLog()
        {
            builder.Append("[");
            builder.Append(this.Code);
            builder.Append("]");

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj)) return true;
            if (!(obj is Language) || Object.ReferenceEquals(obj, null)) return false;
            return this.Code == ((Language)obj).Code;
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }

        #region static

        public static bool operator !=(Language x, Language y)
        {
            return !(x == y);
        }

        public static bool operator ==(Language x, Language y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(null, y)) return false;
            return x.Code == y.Code;
        }

        #endregion

        #region IComparer Members

        public virtual int Compare(object x, object y)
        {
            if (Object.ReferenceEquals(x, y)) return 0;
            if (Object.ReferenceEquals(x, null)) return 1;
            if (Object.ReferenceEquals(null, y)) return -1;
            if (x is Language && y is Language)
                return ((Language)x).Code.CompareTo(((Language)y).Code);
            else
                throw new ArgumentException();
        }

        #endregion
    }
}
