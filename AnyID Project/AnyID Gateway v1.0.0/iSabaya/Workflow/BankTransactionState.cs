using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class BankTransactionState : TransactionState
    {
        public BankTransactionState()
        {
        }

        public BankTransactionState(State state, Money creditAmount, Money debitAmount, User user)
            :base(state, user)
        {
            base.Owner = null;
            this.CreditAmount = Money.Clone(CreditAmount);
            this.DebitAmount = Money.Clone(DebitAmount);
            this.reference = null;
            this.remark = null;
            this.systemMessage = null;
            this.errorNo = 0;
        }

        public BankTransactionState(State state, Money CreditAmount, Money DebitAmount,
                                String reference, String remark, String systemMessage, User user)
            : base(null, state, reference, remark, systemMessage, user)
        {
            this.CreditAmount = Money.Clone(CreditAmount);
            this.DebitAmount = Money.Clone(DebitAmount);
            this.errorNo = 0;
        }

        public BankTransactionState(BankTransaction transaction, State state, Money CreditAmount, Money DebitAmount,
                        String reference, String remark, String systemMessage, int errorCode, User user)
            : base(transaction, state, reference, remark, systemMessage, user)
        {
            this.CreditAmount = Money.Clone(CreditAmount);
            this.DebitAmount = Money.Clone(DebitAmount);
            this.errorNo = errorCode;
        }

        public BankTransactionState(BankTransaction transaction, State state, Money CreditAmount, Money DebitAmount,
                                String reference, String remark, String systemMessage, User user)
            : base(transaction, state, reference, remark, systemMessage, user)
        {
            this.CreditAmount = Money.Clone(CreditAmount);
            this.DebitAmount = Money.Clone(DebitAmount);
            this.errorNo = 0;
        }

        public BankTransactionState(BankTransaction transaction, State state, Money CreditAmount, Money DebitAmount,
                                String reference, String remark, DateTime enteredTS, User user)
            : base(transaction, state, reference, remark, enteredTS, user)
        {
            this.CreditAmount = Money.Clone(CreditAmount);
            this.DebitAmount = Money.Clone(DebitAmount);
            this.systemMessage = null;
            this.errorNo = 0;
        }

        #region persistent

        public virtual new BankTransaction Transaction
        {
            get { return (BankTransaction)base.Owner; }
            set { base.Owner = value; }
        }

        public new virtual TreeListNode StateCategory
        {
            get { return base.state.CategoryNode; }
            set { base.state.CategoryNode = value; }
        }

        private TreeListNode alertCategory;
        public virtual TreeListNode AlertCategory
        {
            get { return alertCategory; }
            set { alertCategory = value; }
        }

        public virtual Money CreditAmount {get;set;}
        public virtual Money DebitAmount {get;set;}

        private int errorNo;
        public virtual int ErrorNo 
        {
            get { return errorNo; }
            set { errorNo = value; }
        }

        #endregion persistent

        public static BankTransactionState Find(Context context, Int64 id)
        {
            return (BankTransactionState)context.PersistenceSession.Get(typeof(BankTransactionState), id);
        }

        public override void Persist(Context context)
        {
            if (null == this.UpdatedBy) 
                throw new iSabayaException("BankTransactionState.UpdatedBy is null");
            context.PersistenceSession.SaveOrUpdate(this);
        }
    }
}

