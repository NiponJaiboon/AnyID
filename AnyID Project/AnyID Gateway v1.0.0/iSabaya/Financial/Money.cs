using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    //is Component in hibernate

    public class Money : IComparable, IComparable<Money>, IComparer<Money> //, ISimpleMath<Money>
    {
        public Money()
        {
        }

        public Money(Money original)
        {
            if (null == original)
                throw new iSabayaException("Orginal money amount is null.");
            this.amount = original.amount;
            this.Currency = original.Currency;
        }

        public Money(decimal amount)
        {
            this.amount = amount;
        }

        public Money(Currency currency, decimal amount)
        {
            this.amount = amount;
            this.Currency = currency;
        }

        public Money(decimal amount, Currency currency)
        {
            this.amount = amount;
            this.Currency = currency;
        }

        public Money(decimal amount, String currencyCode)
        {
            this.amount = amount;
            this.Currency = Currency.Find(currencyCode);
            if (null == this.Currency)
                throw new iSabayaException("Currency code is not incorrect or not supported.");
        }

        #region persistent

        protected decimal amount;

        public decimal Amount
        {
            get { return amount; }
            protected set
            {
                if (this.amount != value)
                {
                    amount = value;
                }
            }
        }

        public string CurrencyCode
        {
            get
            {
                if (null == this.Currency)
                    return "";
                else
                    return this.Currency.ISOCode;
            }
            set
            {
                this.Currency = Currency.Find(value);
            }
        }

        #endregion persistent

        public Currency Currency { get; set; }

        #region operators

        //public static Money operator ++(Money m)
        //{
        //    return new Money(++m.amount, m.Currency);
        //}

        //public static Money operator --(Money m)
        //{
        //    return new Money(--m.amount, m.Currency);
        //}

        public static Money operator +(Money m)
        {
            return Money.Clone(m);
        }

        public static Money operator -(Money m)
        {
            if (Object.ReferenceEquals(null, m)) return null;
            return new Money(-m.amount, m.Currency);
        }

        public static Money operator +(Money m, Money n)
        {
            if (Object.ReferenceEquals(null, m) && Object.ReferenceEquals(null, n)) return null;
            if (Object.ReferenceEquals(null, m)) return new Money(n);
            if (Object.ReferenceEquals(null, n)) return new Money(m);
            if (m.Currency != n.Currency)
                throw new iSabayaException("Money operator +: " + Messages.MoneyDifferentCurrencies);
            return new Money(m.amount + n.amount, m.Currency);
        }

        public static Money operator -(Money m, Money n)
        {
            if (Object.ReferenceEquals(null, m) && Object.ReferenceEquals(null, n)) return null;
            if (Object.ReferenceEquals(null, m)) return new Money(-n.Amount, n.Currency);
            if (Object.ReferenceEquals(null, n)) return new Money(m);
            if (m.Currency != n.Currency)
                throw new iSabayaException("Money operator -: " + Messages.MoneyDifferentCurrencies);
            return new Money(m.amount - n.amount, m.Currency);
        }

        public static double operator /(Money m, Money n)
        {
            if (Object.ReferenceEquals(null, m))
                return 0d;
            if (Object.ReferenceEquals(null, n))
                throw new iSabayaException(String.Format(Messages.MoneyOneOrBothBothOperandsAreNull, "/"));
            if (m.Currency != n.Currency)
                throw new iSabayaException("Money operator /: " + Messages.MoneyDifferentCurrencies);
            return (double)(m.amount / n.amount);
        }

        public static Money operator *(Money m, int n)
        {
            if (Object.ReferenceEquals(null, m)) return null;
            return new Money((decimal)(n * (double)m.amount), m.Currency);
        }

        public static Money operator *(int n, Money m)
        {
            if (Object.ReferenceEquals(null, m)) return null;
            return new Money((decimal)(n * (double)m.amount), m.Currency);
        }

        public static Money operator /(Money m, int n)
        {
            if (Object.ReferenceEquals(null, m)) return null;
            return new Money((decimal)((double)m.amount / n), m.Currency);
        }

        public static Money operator *(Money m, double n)
        {
            if (Object.ReferenceEquals(null, m)) return null;
            return new Money((decimal)(n * (double)m.amount), m.Currency);
        }

        public static Money operator *(double n, Money m)
        {
            if (Object.ReferenceEquals(null, m)) return null;
            return new Money((decimal)(n * (double)m.amount), m.Currency);
        }

        public static Money operator /(Money m, double n)
        {
            if (Object.ReferenceEquals(null, m)) return null;
            return new Money((decimal)((double)m.amount / n), m.Currency);
        }

        public static bool operator ==(Money m, Money n)
        {
            if (Object.ReferenceEquals(m, n)) return true;
            if (Object.ReferenceEquals(m, null) || Object.ReferenceEquals(n, null)) return false;
            if (m.amount == 0m && n.amount == 0m) return true;
            if (m.CurrencyCode != n.CurrencyCode)
                throw new iSabayaException("Money operator ==: " + Messages.MoneyDifferentCurrencies);

            return m.amount == n.amount;
        }

        public static bool operator !=(Money m, Money n)
        {
            if (Object.ReferenceEquals(m, n)) return false;
            if (Object.ReferenceEquals(m, null) || Object.ReferenceEquals(n, null)) return true;
            if (m.amount == 0m && n.amount == 0m) return false;
            if (m.CurrencyCode != n.CurrencyCode)
                throw new iSabayaException("Money operator !=: " + Messages.MoneyDifferentCurrencies);

            return m.amount != n.amount;
        }

        public static bool operator <(Money m, Money n)
        {
            if (Object.ReferenceEquals(null, m) || Object.ReferenceEquals(null, n))
                throw new iSabayaException(String.Format(Messages.MoneyOneOrBothBothOperandsAreNull, "<"));
            if (m.Currency == n.Currency)
                return m.amount < n.amount;
            else
                throw new iSabayaException("Money operator <: " + Messages.MoneyDifferentCurrencies);
        }

        public static bool operator <=(Money m, Money n)
        {
            if (Object.ReferenceEquals(null, m) || Object.ReferenceEquals(null, n))
                throw new iSabayaException(String.Format(Messages.MoneyOneOrBothBothOperandsAreNull, "<="));
            if (m.Currency == n.Currency)
                return m.amount <= n.amount;
            else
                throw new iSabayaException("Money operator <=: " + Messages.MoneyDifferentCurrencies);
        }

        public static bool operator >(Money m, Money n)
        {
            if (Object.ReferenceEquals(null, m) || Object.ReferenceEquals(null, n))
                throw new iSabayaException(String.Format(Messages.MoneyOneOrBothBothOperandsAreNull, ">"));
            if (m.Currency == n.Currency)
                return m.amount > n.amount;
            else
                throw new iSabayaException("Money operator >: " + Messages.MoneyDifferentCurrencies);
        }

        public static bool operator >=(Money m, Money n)
        {
            if (Object.ReferenceEquals(null, m) || Object.ReferenceEquals(null, n))
                throw new iSabayaException(String.Format(Messages.MoneyOneOrBothBothOperandsAreNull, ">="));
            if (m.Currency == n.Currency)
                return m.amount >= n.amount;
            else
                throw new iSabayaException("Money operator >=: " + Messages.MoneyDifferentCurrencies);
        }

        public static implicit operator double(Money m)
        {
            return (double)m.amount;
        }

        #endregion operators

        public Money Add(Money m)
        {
            if (Object.ReferenceEquals(null, m)) return this;
            if (this.Currency == m.Currency)
            {
                this.amount += m.amount;
                return this;
            }
            throw new iSabayaException("Money.Add: " + Messages.MoneyDifferentCurrencies);
        }

        public Money Deduct(Money m)
        {
            if (Object.ReferenceEquals(null, m)) return this;
            if (this.Currency == m.Currency)
            {
                this.amount -= m.amount;
                return this;
            }
            throw new iSabayaException("Money.Deduct: " + Messages.MoneyDifferentCurrencies);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, this)) return true;
            if (object.ReferenceEquals(obj, null)) return true;

            return this == obj as Money;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private int numberOfFractionDigits = 4;
        private string moneyFormat = "#,##0.0000";
        public override string ToString()
        {
            if (null != Configuration.CurrentConfiguration)
            {
                CreateMoneyFormat(Configuration.CurrentConfiguration.NumberOfExtraFractionDigitsOfMoney);
            }

            if (null == this.Currency)
                return amount.ToString(moneyFormat);
            else
                return this.Currency.ISOCode + amount.ToString(moneyFormat);
        }

        private void CreateMoneyFormat(int extraLength)
        {
            int length = 4 + extraLength;
            
            if (length == numberOfFractionDigits) return;
            numberOfFractionDigits = length;
            if (numberOfFractionDigits <= 0)
                moneyFormat = "#,##0.";
            else 
                moneyFormat = "#,##0." + "000000000000".Substring(0, numberOfFractionDigits);
        }

        public string ToWords()
        {
            if (this.Currency.ISOCode == "th-TH")
                return this.ToThaiWords();
            else
                return this.ToThaiWords();
        }

        public static Money Clone(Money original)
        {
            if (null == original) return null;
            return new Money(original);
        }

        public static bool IsNullOrZero(Money m)
        {
            return Object.ReferenceEquals(null, m) || m.Amount == 0m;
        }

        #region IComparer<Money> Members

        public int Compare(Money x, Money y)
        {
            if (x < y) return -1;
            if (x > y) return 1;
            return 0;
        }

        #endregion IComparer<Money> Members

        //#region ISimpleMath<Money> Members

        //Money ISimpleMath<Money>.Add(Money b)
        //{
        //    return this + b;
        //}

        //Money ISimpleMath<Money>.Subtract(Money b)
        //{
        //    return this - b;
        //}

        //Money ISimpleMath<Money>.Multiply(double rate)
        //{
        //    return this * rate;
        //}

        //#endregion ISimpleMath<Money> Members

        #region IComparable<Money> Members

        int IComparable<Money>.CompareTo(Money other)
        {
            if (this < other) return -1;
            if (this > other) return 1;
            return 0;
        }

        #endregion IComparable<Money> Members

        #region IComparable Members

        int IComparable.CompareTo(object obj)
        {
            Money m = obj as Money;
            if (!Object.ReferenceEquals(null, m))
            {
                if (this < m) return -1;
                return (this > m) ? 1 : 0;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        #endregion IComparable Members

        /// <summary>
        /// Convert string of money value to an instance of Money
        /// </summary>
        /// <param name="value">
        /// value must begin with a 3-character currency code
        /// followed by a string of number e.g, "THB100.00"
        /// </param>
        /// <returns></returns>
        public static Money Parse(string value)
        {
            if (String.IsNullOrEmpty(value))
                return null;
            if (value.Length < 4 || !char.IsLetter(value[0]))
                throw new iSabayaException(String.Format("Argument is not in the proper format '{0}'", value));

            Money m = new Money(decimal.Parse(value.Substring(3)), Currency.Find(value.Substring(0, 3)));
            return m;
        }
    }
}