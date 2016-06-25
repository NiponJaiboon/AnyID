using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{

    public class AccountStatement
    {
        #region persistent

        public virtual long ID { get; set; }

        public virtual BankAccount Account { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime PostedTS { get; set; }
        public virtual string TransactionCode { get; set; }
        public virtual DateTime TransactionDate { get; set; }
        public virtual string TransactionNo { get; set; }
        public virtual string ReferenceNo { get; set; }
        public virtual string CreditDebitCode { get; set; }
        public virtual decimal LedgerBalance { get; set; }
        public virtual int SequenceNo { get; set; }
        public virtual string Description { get; set; }
        //public virtual decimal Balance { get; set; }
        public virtual string ChequeNo { get; set; }
        //public virtual string Reference1 { get; set; }
        //public virtual string Reference2 { get; set; }
        //info of the other bank account in funds transfer
        //public virtual string BankID { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string TransactionBranch { get; set; }
        public virtual string TransactionBranchDesc { get; set; }
        public virtual string TellerID { get; set; }

        //Fixed Account
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual decimal FromTransactionAmount { get; set; }
        public virtual decimal ToTransactionAmount { get; set; }
        public virtual string TrxCodeSearch { get; set; }
        public virtual DateTime EffectiveDate { get; set; }
        public virtual DateTime PostingTimestamp { get; set; }
        public virtual string AuxiliaryTransactionCode { get; set; }
        public virtual decimal TransactionAmount { get; set; }
        public virtual string RunningBalance { get; set; }
        public virtual string DebitOrCreditCode { get; set; }
        public virtual decimal WithdrawalAmount { get; set; }
        public virtual decimal DepositAmount { get; set; }

        #endregion persistent

        public override string ToString()
        {
            return this.AccountNo + this.PostedTS + ", " + this.Amount.ToString() + "] ";
        }

        public virtual string ToString(string languageCode)
        {
            return this.ToString() + "] ";
        }

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }
    }
}