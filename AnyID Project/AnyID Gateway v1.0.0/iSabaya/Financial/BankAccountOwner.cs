using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Type;

namespace iSabaya
{


    public class BankAccountOwner
    {
        public BankAccountOwner()
        {
        }

        public BankAccountOwner(Party owner, BankAccount bankAccount, int seqNo)
        {
            this.owner = owner;
            this.bankAccount = bankAccount;
            this.seqNo = seqNo;
        }

        #region persistent

        protected int bankAccountOwnerID;
        public virtual int BankAccountOwnerID
        {
            get { return bankAccountOwnerID; }
            set { bankAccountOwnerID = value; }
        }

        protected BankAccount bankAccount;
        public virtual BankAccount BankAccount
        {
            get { return bankAccount; }
            set { bankAccount = value; }
        }

        protected Party owner;
        public virtual Party Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        protected int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        private User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        private DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        #endregion persistent

        public virtual void Persist(Context context)
        {
            //this.UpdatedTS = DateTime.Now;
            context.PersistenceSession.SaveOrUpdate(this);
        }

        public virtual string ToString(String languageCode)
        {
            return ((this.Owner == null) ? "[No Owner]" : this.Owner.ToString())
                    + ((this.BankAccount == null) ? " [No Bank Account]" : this.BankAccount.ToString(languageCode));
        }

        public override string ToString()
        {
            return ((this.Owner == null) ? "[No Owner]" : this.Owner.ToString())
                    + ((this.BankAccount == null) ? " [No Bank Account]" : "-" + this.BankAccount.ToString());
        }

        public virtual string ToLog()
        {
            return "";
        }

        #region static


        #endregion static

    }
}
