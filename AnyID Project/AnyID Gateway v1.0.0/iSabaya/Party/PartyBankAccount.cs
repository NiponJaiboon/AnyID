using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class PartyBankAccount : CategorizeablePartyProperty, ITemporal
    {
        public PartyBankAccount()
        {
        }

        public PartyBankAccount(PartyBankAccount original, User user)
            : base(original, user)
        {
            this.bankAccount = original.BankAccount;
        }

        #region persistent

        protected BankAccount bankAccount;
        public virtual BankAccount BankAccount
        {
            get { return bankAccount; }
            set { bankAccount = value; }
        }

        #endregion persistent

        #region for ui access property
        //public virtual String Bank
        //{
        //    get
        //    {
        //        if (bankAccount.Bank != null)
        //            return bankAccount.Bank.ToString();
        //        else
        //            return "-";
        //    }
        //}
        //public virtual String Branch
        //{
        //    get
        //    {
        //        if (bankAccount.Branch != null)
        //            return bankAccount.Branch.ToString();
        //        else
        //            return "-";
        //    }
        //}
        #endregion

        //public virtual bool IsDefaultForDeposit
        //{
        //    get { return base.isDefault; }
        //    set { base.isDefault = value; }
        //}

        public override void Persist(Context context)
        {
            if (0 == bankAccount.ID)
                bankAccount.Persist(context);

            //this.UpdatedTS = DateTime.Now;
            context.PersistenceSession.SaveOrUpdate(this);
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

        //public virtual String AccountName
        //{
        //    get
        //    {
        //        if (BankAccount == null || BankAccount.MultilingualName == null)
        //            return "-";
        //        return BankAccount.MultilingualName.ToString();
        //    }

        //}

        public virtual String AccountNo
        {
            get
            {
                if (BankAccount == null)
                    return "-";
                return BankAccount.AccountNo;
            }

        }

        //public virtual String BranchName
        //{
        //    get
        //    {
        //        if (BankAccount == null || null == BankAccount.Branch)
        //            return "-";
        //        return BankAccount.Branch.FullName;
        //    }
        //}

        //public virtual string BankName
        //{
        //    get
        //    {
        //        if (BankAccount == null)
        //            return "-";
        //        return BankAccount.Bank.ToString();
        //    }
        //}

        public virtual DateTime EffectiveFrom
        {
            get
            {
                if (BankAccount == null)
                    return DateTime.MinValue;
                return BankAccount.EffectivePeriod.From;
            }

        }

        public virtual DateTime EffectiveTo
        {
            get
            {
                if (BankAccount == null)
                    return DateTime.MinValue;
                return BankAccount.EffectivePeriod.To;
            }

        }
        #endregion

        public static IList<PartyBankAccount> Find(Context context, int bankAccountID)
        {
            return context.PersistenceSession.QueryOver<PartyBankAccount>()
                            .JoinQueryOver<BankAccount>(pba => pba.BankAccount)
                            .Where(ba => ba.ID == bankAccountID)
                            .List<PartyBankAccount>();
        }

        public static IList<PartyBankAccount> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria<PartyBankAccount>()
                            .List<PartyBankAccount>();
        }
    }
}

