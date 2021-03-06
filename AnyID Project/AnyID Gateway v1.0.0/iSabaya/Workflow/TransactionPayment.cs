using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class TransactionPayment
    {
        public TransactionPayment()
        {
        }

        /// <summary>
        /// The applicable amount is the entire amount of payment.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="payment"></param>
        public TransactionPayment(StatefulEntity transaction, Payment payment)
        {
            this.transaction = transaction;
            this.payment = payment;
            this.amount = payment.Amount;
        }

        /// <summary>
        /// The appliedAmount must be between 0 and the payment amount.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="payment"></param>
        /// <param name="appliedAmount"></param>
        public TransactionPayment(StatefulEntity transaction, Payment payment, Money appliedAmount)
        {
            this.transaction = transaction;
            this.payment = payment;
            if (0m >= appliedAmount.Amount || payment.Amount < appliedAmount)
                throw new iSabayaException("Applied amount is less than 0 or greater than the amount of payment.");
            this.amount = appliedAmount;
        }

        public TransactionPayment(StatefulEntity transaction, Payment payment, float percentage)
        {
            this.transaction = transaction;
            this.payment = payment;
            if (percentage < 0 || 100 < percentage)
                throw new iSabayaException("Percentage is not between 0 and 100");
            this.amount = payment.Amount * (percentage / 100);
        }

        #region persistent

        private int transactionPaymentID;
        public virtual int TransactionPaymentID
        {
            get { return transactionPaymentID; }
            set { transactionPaymentID = value; }
        }

        private Payment payment;
        public virtual Payment Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        private StatefulEntity transaction;
        public virtual StatefulEntity Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        protected Money amount;
        public virtual Money Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        #endregion persistent

        public virtual void CreditAmount(Money m)
        {
            this.amount.Add(m);
            if (null != this.payment) this.payment.CreditAmount(m);
        }

        public virtual void Persist(Context context)
        {
            Payment.Persist(context);
            context.Persist(this);
        }

        public static IList<TransactionPayment> List(Context context, Payment payment)
        {
            return context.PersistenceSession.CreateCriteria<TransactionPayment>()
                        .Add(Expression.Eq("Payment", payment))
                        .List<TransactionPayment>();
        }
    }
}