using System;

namespace iSabaya
{

    public class MoneyBuilder
    {
        public MoneyBuilder()
        {
            this.amount = 0m;
        }

        public MoneyBuilder(Money original)
        {
            if (null != original)
            {
                this.amount = original.Amount;
                this.Currency = original.Currency;
            }
        }

        public MoneyBuilder(decimal amount, Currency currency)
        {
            this.amount = amount;
            this.Currency = currency;
        }

        private decimal amount;
        private Currency Currency;

        public void Add(Money m)
        {
            if (Object.ReferenceEquals(null, m)) return;
            if (null == this.Currency)
            {
                this.amount = m.Amount;
                this.Currency = m.Currency;
            }
            else if (this.Currency == m.Currency)
                this.amount += m.Amount;
            else
                throw new iSabayaException(Messages.MoneyDifferentCurrencies);
        }

        public void Add(MoneyBuilder m)
        {
            if (Object.ReferenceEquals(null, m)) return;
            if (null == this.Currency)
            {
                this.amount = m.amount;
                this.Currency = m.Currency;
            }
            else if (this.Currency == m.Currency)
                this.amount += m.amount;
            else
                throw new iSabayaException(Messages.MoneyDifferentCurrencies);
        }

        public void Add(decimal m, Currency currency)
        {
            if (null == this.Currency)
            {
                this.amount = m;
                this.Currency = currency;
            }
            else if (this.Currency == currency)
                this.amount += m;
            else
                throw new iSabayaException(Messages.MoneyDifferentCurrencies);
        }

        public void Deduct(Money m)
        {
            if (Object.ReferenceEquals(null, m)) return;
            if (null == this.Currency)
            {
                this.amount = -m.Amount;
                this.Currency = m.Currency;
            }
            else if (this.Currency == m.Currency)
                this.amount -= m.Amount;
            else
                throw new iSabayaException(Messages.MoneyDifferentCurrencies);
        }

        public void Deduct(MoneyBuilder m)
        {
            if (Object.ReferenceEquals(null, m)) return;
            if (null == this.Currency)
            {
                this.amount = -m.amount;
                this.Currency = m.Currency;
            }
            else if (this.Currency == m.Currency)
                this.amount -= m.amount;
            else
                throw new iSabayaException(Messages.MoneyDifferentCurrencies);
        }

        public decimal Amount
        {
            get { return this.amount; }
        }

        public Money ToMoney()
        {
            return new Money(this.amount, this.Currency);
        }

        public void Clear()
        {
            this.amount = 0m;
            this.Currency = null;
        }

        public static MoneyBuilder operator +(MoneyBuilder mb, Money b)
        {
            if (null == mb)
                mb = new MoneyBuilder();
            mb.Add(b);
            return mb;
        }

        public static MoneyBuilder operator -(MoneyBuilder mb, Money b)
        {
            if (null == mb)
                mb = new MoneyBuilder();
            mb.Deduct(b);
            return mb;
        }
    }
}