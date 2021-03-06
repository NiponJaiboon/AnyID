using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{
    [Serializable]
    public class DepositBankAccount : ITemporal, IHibernateEvent<DepositBankAccount>
    {

        public DepositBankAccount()
        {
        }

        #region persistent

        private int depositBankAccountID;
        public virtual int DepositBankAccountID
        {
            get { return depositBankAccountID; }
            set { depositBankAccountID = value; }
        }

        protected BankAccount bankAccount;
        public virtual BankAccount BankAccount
        {
            get { return bankAccount; }
            set { bankAccount = value; }
        }

        private Party owner;
        public virtual Party Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private String description;
        public virtual String Description
        {
            get { return description; }
            set { description = value; }
        }

        protected bool isDefault;
        public virtual bool IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        protected Person updatedBy;
        public virtual Person UpdatedBy
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

        #region for ui access property

        public virtual String Bank
        {
            get { return bankAccount.Bank.ToString(); }
        }
        public virtual String Branch
        {
            get { return bankAccount.Branch.ToString(); }
        }
        
        #endregion

        public virtual void Save(iSabayaContext context)
        {
            bankAccount.SaveOrUpdate(context);

            this.UpdatedTS = DateTime.Now;
            context.PersistencySession.SaveOrUpdate(this);
        }

        public virtual void Delete(iSabayaContext context)
        {
            context.PersistencySession.Delete(this);
        }

        #region transient

        private int bankOrgId;
        public virtual int BankOrgId
        {
            get { return bankOrgId; }
            set { bankOrgId = value; }
        }

        protected int lineNo;
        public virtual int LineNo
        {
            get { return lineNo; }
            set { lineNo = value; }
        }

        public virtual String AccountNo
        {
            get
            {
                if (BankAccount == null) { return ""; }
                return BankAccount.AccountNo;
            }

        }

        public virtual DateTime EffectiveFrom
        {
            get
            {
                if (BankAccount == null) { return DateTime.MinValue; }
                return BankAccount.EffectivePeriod.From;
            }

        }
        public virtual DateTime EffectiveTo
        {
            get
            {
                if (BankAccount == null) { return DateTime.MinValue; }
                return BankAccount.EffectivePeriod.To;
            }

        }
        #endregion

        public static DepositBankAccount Find(iSabayaContext context, int bankAccountID)
        {
            return (DepositBankAccount)context.PersistencySession.Get(typeof(DepositBankAccount), bankAccountID);
        }
        //xxx
        public virtual void SetDefault()
        {
            IList<DepositBankAccount> bankAccounts = Owner.BankAccounts;
            foreach (DepositBankAccount de in bankAccounts)
            {
                if (de.DepositBankAccountID == this.DepositBankAccountID)
                {
                    de.IsDefault = true;
                    de.UpdatedTS = DateTime.Now;
                }
                else
                {
                    de.IsDefault = false;
                    de.UpdatedTS = DateTime.Now;
                }
            }
        }

        public virtual int BankAccountID
        {
            get { return BankAccount.BankAccountID; }
        }

        public static IList<DepositBankAccount> List(iSabayaContext context)
        {
            ICriteria crit = context.PersistencySession.CreateCriteria(typeof(DepositBankAccount));
            return crit.List<DepositBankAccount>();
        }

        #region IHibernateEvent<DepositBankAccount> Members

        public virtual bool SaveEvent(iSabayaContext context)
        {
            try
            {
                context.PersistencySession.Save(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public virtual bool UpdateEvent(iSabayaContext context)
        {
            try
            {
                context.PersistencySession.Update(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public virtual bool DeleteEvent(iSabayaContext context)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public static DepositBankAccount GetEvent(iSabayaContext context, int id)
        {
            return (DepositBankAccount)context.PersistencySession.Get(typeof(DepositBankAccount), id);
        }
        #endregion
    }
}

