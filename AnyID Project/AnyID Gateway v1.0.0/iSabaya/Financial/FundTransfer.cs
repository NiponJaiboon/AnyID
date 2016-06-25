using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Type;

namespace iSabaya
{
    public class FundTransfer : Payment
    {
        public FundTransfer()
        {
        }

        public FundTransfer(Party payer, Party payee, bool isPaymentToCustomer, Money amount, 
                            DateTime dueDate, DateTime paymentDate, string reference, 
                            string remark, BankAccount fromBankAccount, BankAccount toBankAccount, 
                            User createdBy)
            : base(payer, payee, "", isPaymentToCustomer, amount, dueDate, paymentDate, reference, 
                    remark, createdBy)
        {
            this.fromBankAccount = fromBankAccount;
            this.toBankAccount = toBankAccount;
        }

        #region persistent

        private BankAccount fromBankAccount;
        private BankAccount toBankAccount;
        private String bankTransactionNo;

        public virtual BankAccount FromBankAccount
        {
            get { return fromBankAccount; }
            set { fromBankAccount = value; }
        }

        public virtual BankAccount ToBankAccount
        {
            get { return toBankAccount; }
            set { toBankAccount = value; }
        }

        public virtual String BankTransactionNo
        {
            get { return bankTransactionNo; }
            set { bankTransactionNo = value; }
        }

        //private FundTransferStatus status = FundTransferStatus.Pending;
        //public virtual FundTransferStatus Status
        //{
        //    get { return status; }
        //    set {
        //        status = value;
        //        if (value == FundTransferStatus.Pending) return;
        //        if (value == FundTransferStatus.Success)
        //            this.FromBankAccount.ConsecutiveDebitRejects = 0;
        //        else //(value == BankTransactionResponse.Failed)
        //            this.FromBankAccount.ConsecutiveDebitRejects += 1;
        //    }
        //}

        #endregion persistent

        public static IList<FundTransfer> GetPendingInstances(Context context, String bankCode)
        {
            return context.PersistenceSession.CreateCriteria<FundTransfer>()
                            .CreateAlias("FromBankAccount", "f")
                            .CreateAlias("f.Bank", "fb")
                            .Add(Expression.Eq("fb.OfficialIDNo", bankCode))
							.Add(Expression.Eq("Status", FundTransferStatus.Pending))
                            .List<FundTransfer>();
        }

        public override void Persist(Context context)
        {
            if (null == this.fromBankAccount || null == this.toBankAccount)
                throw new iSabayaException(Messages.FundTransferNoSrcOrDstBankAccount);
            base.Persist(context);
        }
    }

    public enum FundTransferStatus
    {
        Pending,
        Success,
        InsufficientFund,
        IncorrectBankAccountNo,
        BankAccountClosed,
        Others,
    }

    public class EnumFundTransferStatus : EnumStringType
    {
        public EnumFundTransferStatus()
            : base(typeof(FundTransferStatus))
        {
        }
    }
}
