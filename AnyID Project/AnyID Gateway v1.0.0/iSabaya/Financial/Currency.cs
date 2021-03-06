using System;
using System.Collections.Generic;
using System.Text;
using iSabaya;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class Currency
    {
        #region persistent

        public virtual string Symbol { get; set; }
        public virtual string ISOCode { get; set; }
        public virtual string Description { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }

        #endregion persistent

        public static Currency CurrentCurrency;

        public static IList<Currency> Currencies
        {
            get;
            set;
        }

        public static IEnumerable<Currency> GetAll(ISession session)
        {
            if (null == Currencies)
            {
                ICriteria crit = session.CreateCriteria<Currency>();
                Currencies = crit.List<Currency>();
                if (null == CurrentCurrency && Currencies.Count > 0)
                    CurrentCurrency = Currencies[0];
            }
            return Currencies;
        }

        public static Currency Find(string code)
        {
            Currency currency = null;
            if (null != Currencies)
            {
                foreach (Currency c in Currencies)
                {
                    if (c.ISOCode == code)
                    {
                        currency = c;
                        break;
                    }
                }
            }
            return currency;
        }

        public static Currency Find(Context context, string code)
        {
            //List(context);
            return Find(code);
        }

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }

        //public virtual string ToLog()
        //{
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append("[");
        //    builder.Append("ID:");
        //    builder.Append(ID);
        //    builder.Append(", ");

        //    builder.Append("Symbol:");
        //    builder.Append(Symbol);
        //    builder.Append(", ");

        //    builder.Append("Code:");
        //    builder.Append(Code);
        //    builder.Append(", ");

        //    //builder.Append("Title:");
        //    //builder.Append(Title.ToLog());
        //    //builder.Append("]");

        //    return builder.ToString();
        //}

        public override string ToString()
        {
            return this.ISOCode;
        }

        public override bool Equals(object obj)
        {
            Currency cur = obj as Currency;
            if (null == cur) return false;
            return (this.ISOCode == cur.ISOCode);
        }

        public override int GetHashCode()
        {
            return this.ISOCode.GetHashCode();
        }

        #region operators

        public static bool operator ==(Currency a, Currency b)
        {
            if (Object.ReferenceEquals(a, b)) return true;
            if (Object.ReferenceEquals(null, a) || Object.ReferenceEquals(null, b)) return false;
            return (a.ISOCode == b.ISOCode);
        }

        public static bool operator !=(Currency a, Currency b)
        {
            return !(a == b);
        }

        #endregion operators

        public static Currency GetByCode(string currencyCode)
        {
            if (null == Currencies)
                throw new iSabayaException("The currency list is null.");
            foreach (Currency c in Currencies)
            {
                if (c.ISOCode == currencyCode)
                    return c;
            }
            return null;
        }
    }
}