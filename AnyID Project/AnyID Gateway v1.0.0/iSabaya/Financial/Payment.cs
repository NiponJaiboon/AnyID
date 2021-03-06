using System;
using System.Collections.Generic;
using System.Text;
using iSabaya;
using iSabaya.Financial;

namespace iSabaya
{
    public enum PayMethod
    {
        Cash,
        Cheque,
        BankAccountDeposit,
        BillPayment,
        FundTransfer,
        CreditCard,
        DebitCard,
        None,
    }

    public enum PaymentFeeBearer
    {
        Payer ,
        Payee,
        BothPayerAndPayee,
    }

    public enum PaymentType
    {
        Cheque = 1,
        Cash = 2,
        BankDeposit = 3,
        FundTransfer = 4
    }


    public abstract class Payment
    {
        public Payment()
        {
        }

        public Payment(Party payer, Party payee, String payeeName, bool isPaymentToCustomer, 
                        Money amount, DateTime dueDate, DateTime paymentDate,
                        string reference, string remark, User createdBy)
        {
            if (null == createdBy)
                throw new iSabayaException(Messages.PersonIsNull);
            this.StatusUpdatedBy = createdBy;

            this.Payer = payer;
            this.Payee = payee;
            this.PayeeName = payeeName;
            this.IsPaymentToCustomer = isPaymentToCustomer;
            this.amount = Money.Clone(amount);
            this.dueDate = dueDate;
            this.paymentDate = paymentDate;
            this.Reference = reference;
            this.Remark = remark;
        }

        #region persistent

        public virtual long PaymentID { get; set; }
        public virtual long paymentID { get; set; }

        protected Money amount;

        public virtual Money Amount
        {
            get { return amount; }
            set
            {
                if (null != value && value.Amount < 0m)
                    throw new iSabayaException("Payment amount is less than 0.");
                amount = value;
            }
        }

        public virtual bool IsPaymentToCustomer { get; set; }

        protected DateTime dueDate = TimeInterval.MinDate;

        public virtual DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        protected DateTime paymentDate = TimeInterval.MinDate;

        public virtual DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public virtual Party Payee {get;set;}
        public virtual string PayeeAddress { get; set; }
        public virtual string PayeeAddressPostalCode { get; set; }
        public virtual string PayeeIDNo { get; set; }
        public virtual string PayeeName { get; set; }
        public virtual string PayeeTaxIDNo { get; set; }
        public virtual string PayeeMobile { get; set; }

        public virtual Party Payer { get; set; }
        public virtual string PayerAddress { get; set; }
        public virtual string PayerAddressPostalCode { get; set; }
        public virtual string PayerIDNo { get; set; }
        public virtual string PayerName { get; set; }
        public virtual string PayerTaxIDNo { get; set; }

        public virtual Receipt Receipt { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Remark { get; set; }

        protected DateTime statusDate = TimeInterval.MinDate;

        public virtual DateTime StatusDate
        {
            get { return statusDate; }
            set { statusDate = value; }
        }

        public virtual User StatusUpdatedBy { get; set; }

        protected DateTime statusUpdatedTS = TimeInterval.MinDate;

        public virtual DateTime StatusUpdatedTS
        {
            get { return statusUpdatedTS; }
            set { statusUpdatedTS = value; }
        }

        public virtual WithholdingTax WithholdingTax { get; set; }
        public virtual PaymentFeeBearer FeeBearer { get; set; }
        public virtual NotificationMethod NotificationMethod { get; set; }


        private IList<Tax> taxes;
        public virtual IList<Tax> Taxes
        {
            get
            {
                if (null == this.taxes)
                    this.taxes = new List<Tax>();
                return this.taxes;
            }

            set
            {
                this.taxes = value;
            }
        }
        #endregion persistent

        #region Transient

        private Decimal amountForThisTransaction;

        public virtual Decimal AmountForThisTransaction
        {
            get { return amountForThisTransaction; }
            set { this.amountForThisTransaction = value; }
        }

        #endregion Transient

        private String paymentType;

        public virtual String PaymentType
        {
            get { return paymentType; }
            set { this.paymentType = value; }
        }

        public virtual void CreditAmount(Money amount)
        {
            this.amount += amount;
        }

        public virtual void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }

        public static Payment Find(Context context, int paymentId)
        {
            return (Payment)context.PersistenceSession.Get(typeof(Payment), paymentId);
        }

        public virtual Type Type
        {
            get { return this.GetType(); }
        }

        //Add for mock
        public virtual Money Fee { get; set; }
    }
}