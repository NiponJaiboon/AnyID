using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class PartyExpense 
    {
        #region persistent
 
        private int partyExpenseID;
        public virtual int PartyExpenseID
        {
            get { return partyExpenseID; }
            set { partyExpenseID = value; }
        }

        private TreeListNode category;
        public virtual TreeListNode Category
        {
            get { return category; }
            set { category = value; }
        }

        private Party party;
        public virtual Party Party
        {
            get { return party; }
            set { party = value; }
        }

        protected Money expense;
        public virtual Money Expense
        {
            get { return expense; }
            set { expense = value; }
        }

        protected String reference;
        public virtual String Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        protected String remark;
        public virtual String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        protected DateTime date;
        public virtual DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        protected DateTime updatedTS;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        #endregion persistent

        public virtual TreeListNode CategoryParent
        {
            get
            {
                if (null == this.Category) return null;
                return this.Category.Parent;
            }
            set { }
        }

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }

        public override String ToString()
        {
            return this.Date.ToShortDateString() 
                    + " " + this.Category.Code 
                    + " " + this.Expense.ToString();
        }
    }
}

