using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Type;

namespace iSabaya
{

    public class BankAccountBalance : IComparable<BankAccountBalance>
    {
        public BankAccountBalance()
        {
        }

        //public BankAccountBalance(BankAccount account, DateTime date, decimal available, decimal outstanding, User createdBy, string remark)
        //{
        //    this.Account = account;
        //    this.Timestamp = date;
        //    this.balance = balance;
        //    this.updatedBy = createdBy;
        //    this.remark = remark;
        //}

        #region persistent

        protected int iD;

        public virtual int ID
        {
            get { return this.iD; }
            set { this.iD = value; }
        }

        public virtual BankAccount Account { get; set; }

        public virtual decimal WithheldAmount { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual decimal OverdraftLimit { get; set; }

        //public virtual BankAccountTransaction Transaction { get; set; }
        //public virtual string AccountNo { get; set; }
        //public virtual string TransactionNo { get; set; }
        //public virtual string TransactionCode { get; set; }
        public virtual DateTime Timestamp { get; set; }

        /// <summary>
        /// Amount that can be withdrawn
        /// </summary>
        //public virtual decimal CreditAmount { get; set; }
        //public virtual decimal DebitAmount { get; set; }
        //public virtual decimal AvailableAmount { get; set; }
        //public virtual decimal OutstandingAmount { get; set; }
        public virtual string Reference { get; set; }
        public virtual decimal CurrentBalance { get; set; }
        public virtual decimal AvailableBalance { get; set; }
        public virtual decimal HoldAmount { get; set; }
        public virtual decimal CreditLineAmount { get; set; }
        public virtual decimal YesterdayBalance { get; set; }
        public virtual decimal FloatAmount { get; set; }
        public virtual decimal LedgerBalance { get; set; }
        public virtual float Rate { get; set; }
        public virtual string Status { get; set; }

        #region Loan Account

        public virtual string ProductCode { get; set; }
        public virtual string ProductName { get; set; }
        public virtual decimal OriginalLineAmount { get; set; }
        public virtual string FirstDueDate { get; set; }
        public virtual string TermIncrementOrTenor { get; set; }
        public virtual DateTime OriginalApproveDate { get; set; }
        public virtual decimal InstallmentAmount { get; set; }
        public virtual int DayOfMonthlyInstalment { get; set; }
        public virtual string GracePeriodForInstallment { get; set; }
        public virtual string InstallmentFrequency { get; set; }
        public virtual string InstallmentTerm { get; set; }
        public virtual string PaymentMode { get; set; }
        public virtual DateTime LastDateAccessLoanUtilized { get; set; }
        public virtual decimal LoanLineAmountUtilized { get; set; }
        public virtual decimal OverDraftUtilized { get; set; }
        public virtual decimal AvailableLineAmount { get; set; }
        public virtual string DueDate { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual string FacilityAccountNo { get; set; }

        //by kittikun
        public virtual DateTime PaymentDueDate { get; set; }
        public virtual DateTime PaymentInterestDueDate { get; set; }
        #endregion Loan Account

        #region Fixed Account
        public virtual decimal Principal { get; set; }
        public virtual string Tenor { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual decimal InterestAmount { get; set; }
        public virtual DateTime MaturityDate { get; set; }
        public virtual string MaturityInstruction { get; set; }
        public virtual string PrincipalPayment { get; set; }
        public virtual decimal InterestPayment { get; set; }
        public virtual string PlacementID { get; set; }
        #endregion Fixed Account

        #endregion persistent

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }

        public virtual int CompareTo(BankAccountBalance other)
        {
            return this.Timestamp.CompareTo(other);
        }
    }
}