using System;
using System.Collections.Generic;
using NHibernate;

namespace iSabaya
{

    public class Receipt
    {
        #region persistent

        private int receiptID;
        public virtual int ReceiptID
        {
            get { return receiptID; }
            set { receiptID = value; }
        }

        protected String cancelRemark;
        public virtual String CancelRemark
        {
            get { return cancelRemark; }
            protected set { cancelRemark = value; }
        }

        protected User cancelledBy;
        public virtual User CancelledBy
        {
            get { return cancelledBy; }
            protected set { cancelledBy = value; }
        }

        protected DateTime cancelledTS = TimeInterval.MaxDate;
        public virtual DateTime CancelledTS
        {
            get { return cancelledTS; }
            protected set { cancelledTS = value; }
        }

        protected TreeListNode category;
        public virtual TreeListNode Category
        {
            get { return category; }
            set { category = value; }
        }

        private Party payer;
        public virtual Party Payer
        {
            get { return payer; }
            set { payer = value; }
        }

        private String payerName;
        public virtual String PayerName
        {
            get { return payerName; }
            set { payerName = value; }
        }

        private String payerAddress;
        public virtual String PayerAddress
        {
            get { return payerAddress; }
            set { payerAddress = value; }
        }

        private IList<ReceiptPayment> payments;
        public virtual IList<ReceiptPayment> Payments
        {
            get
            {
                if (null == payments) payments = new List<ReceiptPayment>();
                return payments;
            }
            set { payments = value; }
        }

        private DateTime printedDate;
        public virtual DateTime PrintedDate
        {
            get { return printedDate; }
            set { printedDate = value; }
        }

        private String receiptNo;
        public virtual String ReceiptNo
        {
            get { return receiptNo; }
            set { receiptNo = value; }
        }

        private Party recipient;
        public virtual Party Recipient
        {
            get { return recipient; }
            set { recipient = value; }
        }

        private String recipientName;
        public virtual String RecipientName
        {
            get { return recipientName; }
            set { recipientName = value; }
        }

        private String recipientAddress;
        public virtual String RecipientAddress
        {
            get { return recipientAddress; }
            set { recipientAddress = value; }
        }

        private DateTime receiptDate;
        public virtual DateTime ReceiptDate
        {
            get { return receiptDate; }
            set { receiptDate = value; }
        }


        private String reference;
        public virtual String Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        private String remark;
        public virtual String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private IList<ReceiptItem> items;
        public virtual IList<ReceiptItem> Items
        {
            get
            {
                if (null == items) items = new List<ReceiptItem>();
                return items;
            }
            set { items = value; }
        }

        private Money tax;
        public virtual Money Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        private Money totalAmount;
        public virtual Money TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        #endregion persistent

        public virtual void Cancel(Person cancelledBy, DateTime cancelledDate, String cancelRemark)
        {
        }

        public virtual void Persist(Context context)
        {
            //this.ReceiptNo = context.GenReceiptNo(this);

            context.PersistenceSession.SaveOrUpdate(this);

            int seqNo = 0;
            foreach (ReceiptItem item in this.Items)
            {
                item.SeqNo = ++seqNo;
                context.PersistenceSession.SaveOrUpdate(item);
            }

            seqNo = 0;
            foreach (ReceiptPayment p in this.Payments)
            {
                p.SeqNo = ++seqNo;
                context.PersistenceSession.SaveOrUpdate(p);
            }
        }

    }
}
