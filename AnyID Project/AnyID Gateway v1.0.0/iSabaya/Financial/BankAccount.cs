using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using System.Runtime.Serialization;

namespace iSabaya
{

    public enum BankAccountType
    {
        DUMMY,
        BANKAC
    }


    public enum BankAccountStatus
    {
        //Active = 1,
        //Closed = 2,
        //MaturedNotRedeem = 3,
        //NewToday = 4,
        //DoNotCloseOnZero = 5,
        //NoDebitAllowed = 6,
        //Frozen = 7,
        //ChargeOff = 8,
        //Dormant = 9,
        //Withheld,
        Active,
        Closed,
        Frozen,
        Dormant,
    }


    public enum DirectDebitStatus
    {
        None,
        New,
        Pending,
        Rejected,
        Enabled
    }

    //None, Pending, Rejected, Enabled
    //[Serializable]
    //public class EnumDirectDebitStatus : EnumStringType
    //{
    //    public EnumDirectDebitStatus()
    //        : base(typeof(DirectDebitStatus))
    //    {
    //    }
    //}

    public class BankAccount : PersistentTemporalEntity //, IEqualityComparer<BankAccount>, IComparable<BankAccount>
    {
        //public BankAccount()
        //{
            //this.DirectDebitStatus = DirectDebitStatus.None;
            //this.StatusDate = DateTime.Now;
        //}

        #region persistent

        //public virtual string Type
        //{
        //    get { return this.AccountType.ToString(); }
        //    set
        //    {
        //        try
        //        {
        //            this.AccountType = (BankAccountType)Enum.Parse(typeof(BankAccountType), value);
        //        }
        //        catch (ArgumentException)
        //        {
        //            throw new Exception("Not a bank account type " + value);
        //        }
        //    }
        //}

        public virtual BankAccountType AccountType { get; set; } = BankAccountType.DUMMY;

        //[DataMember(Name = "accountNo")]
        public virtual string AccountNo { get; set; }

        public virtual string UniqueAccountNo { get; set; }


        //[DataMember(Name = "name")]
        public virtual string Name { get; set; }

        //public virtual MultilingualString MultilingualName { get; set; }

        public virtual string BankCode { get; set; }

        public virtual string BranchCode { get; set; }

        //public virtual TreeListNode Category { get; set; }

        public virtual string CustomerID { get; set; }

        //public virtual TimeInterval SuspendedPeriod { get; set; }

        //private Organization bank;
        //public virtual Organization Bank
        //{
        //    get { return this.bank; }
        //    set
        //    {
        //        this.bank = value;
        //        if (null != value)
        //            this.BankCode = value.Code;
        //    }
        //}

        //private OrgUnit branch;
        //public virtual OrgUnit Branch
        //{
        //    get { return this.branch; }
        //    set
        //    {
        //        this.branch = value;
        //        if (null != value)
        //            this.BranchCode = value.Code;
        //    }
        //}

        //public virtual int ConsecutiveDebitRejects { get; set; }

        //public virtual int DirectDebitFailCount { get; set; }
        //public virtual string GrantRemark { get; set; }
        //public virtual bool IsEFTEnable { get; set; }
        //public virtual TimeInterval PowerOfAttorneyGrantPeriod { get; set; }

        //private IList<BankAccountOwner> owners;

        //public virtual IList<BankAccountOwner> Owners
        //{
        //    get
        //    {
        //        if (owners == null)
        //        {
        //            owners = new List<BankAccountOwner>();
        //        }
        //        return owners;
        //    }
        //    set { owners = value; }
        //}

        //private IList<AccountStatement> statements;
        //public virtual IList<AccountStatement> Statements
        //{
        //    get
        //    {
        //        if (null == this.statements) this.statements = new List<AccountStatement>();
        //        return statements;
        //    }
        //    set { statements = value; }
        //}

        //private IList<BankAccountBalance> balances;
        //public virtual IList<BankAccountBalance> Balances
        //{
        //    get
        //    {
        //        if (null == this.balances) this.balances = new List<BankAccountBalance>();
        //        return balances;
        //    }
        //    set { balances = value; }
        //}

        //public virtual string DisplayName { get; set; }
        public virtual BankAccountStatus Status { get; set; }
        public virtual DateTime StatusDate { get; set; }
        public virtual DirectDebitStatus DirectDebitStatus { get; set; }
        public virtual string CurrencyCode { get; set; }

        //protected BankAccountBalance currentBalance;
        //public virtual BankAccountBalance CurrentBalance
        //{
        //    get
        //    {
        //        //if (null == this.currentBalance)
        //        //    throw new iSabayaException("The bank account has no balance.");
        //        return this.currentBalance;
        //    }

        //    set
        //    {
        //        if (ReferenceEquals(this.currentBalance, value))
        //            return;
        //        if (null != this.currentBalance)
        //        {
        //            if (this.currentBalance.Timestamp == value.Timestamp) //assume that the value is the same as currentBalance
        //                return;
        //            if (this.currentBalance.Timestamp > value.Timestamp)
        //                throw new iSabayaException("The new balance is older than the curent balance.");
        //        }
        //        this.Balances.Add(value);
        //        this.currentBalance = value;
        //    }
        //}

        #endregion persistent

        public virtual int LineNo { get; set; }

        //public virtual String GetBranchName(Language language)
        //{
        //    if (this.Branch == null)
        //        return "";
        //    return this.Branch.ToString(language.Code);
        //}

        //public virtual string GetBankName(Language language)
        //{
        //    if (this.Bank.CurrentName == null)
        //        return "";
        //    return this.Bank.CurrentName.Name.GetValue(language.Code);
        //}

        //public virtual string GetAccountName(Language language)
        //{
        //    if (this.MultilingualName == null)
        //        return "";
        //    return this.MultilingualName.GetValue(language.Code);
        //}

        public override void Persist(Context context)
        {
            bool requireSecondPassUpdate = false;

            if (this.ID == 0)
            {
                //if (this.MultilingualName != null)
                //    this.MultilingualName.Persist(context);
                context.Persist(this);
                requireSecondPassUpdate = true;
            }
            else
                context.PersistenceSession.Update(this);

            //foreach (BankAccountOwner o in this.Owners)
            //{
            //    o.BankAccount = this;
            //    o.Persist(context);
            //}

            //foreach (AccountStatement b in this.Statements)
            //{
            //    b.Account = this;
            //    b.Persist(context);
            //}

            //foreach (BankAccountBalance b in this.Balances)
            //{
            //    b.Account = this;
            //    b.Persist(context);
            //}

            if (requireSecondPassUpdate)
            {
                //this.UpdatedTS = DateTime.Now;
                context.PersistenceSession.Update(this);
            }
        }

        public virtual void ReplaceMyProperties(BankAccount account)
        {
            //Assuming that branch never change
            this.Name = account.BankCode;
            this.Status = account.Status;
        }

        public static BankAccount FindByAccountNoAndBankCode(Context context, string accountNo, Organization organization)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(BankAccount));
            crit.Add(Expression.Eq("AccountNo", accountNo));
            crit.Add(Expression.Eq("Bank", organization));
            return crit.UniqueResult<BankAccount>();
        }

        public override string ToString(String languageCode)
        {
            //if (null == this.Category)
            //    return "[" + this.AccountType + this.AccountNo + "-" + this.MultilingualName.ToString(languageCode) + "]";
            //else
            //    return "[" + this.Category.ToString(languageCode) + this.AccountNo + "-" + this.MultilingualName.ToString(languageCode) + "]";
            return "{" + this.AccountNo + "-" + this.Name + "}";
        }

        public virtual string ToLog()
        {
            return "";
        }

        //public virtual bool IsDirectDebit
        //{
        //    get
        //    {
        //        if (PowerOfAttorneyGrantPeriod == null) return false;
        //        return PowerOfAttorneyGrantPeriod.IsEffective;
        //    }
        //}

        //public virtual bool IsActive(DateTime onDatetime)
        //{
        //    return EffectivePeriod != null && EffectivePeriod.Includes(onDatetime)
        //        && (SuspendedPeriod == null || SuspendedPeriod.Includes(onDatetime));
        //}

        //public virtual void Validate(Context context, DateTime datetime, Money amount, string remark)
        //{
        //    if (!IsActive(DateTime.Now))
        //        throw new iSabayaException("The bank account is not active.");

        //    if (amount.CurrencyID != this.Currency.ID)
        //        throw new iSabayaException("The currency of the amount is different from the currency of the bank account.");

        //    if (this.CurrentBalance.Timestamp > datetime)
        //        throw new iSabayaException("The date of the balance is not less than the operation date.");

        //}

        //public virtual void Credit(Context context, DateTime datetime, Money amount, string remark)
        //{
        //    Validate(context, datetime, amount, remark);
        //    BankAccountBalance newBalance = new BankAccountBalance(this.CurrentBalance.Account, DateTime.Now,
        //        this.CurrentBalance.OutstandingAmount + amount, context.User, remark);
        //    this.CurrentBalance = newBalance;
        //}

        //public virtual void Debit(Context context, DateTime datetime, Money amount, string remark)
        //{
        //    Validate(context, datetime, amount, remark);

        //    if (this.CurrentBalance.Balance < amount)
        //        throw new iSabayaException("Insufficient funds for debit.");

        //    BankAccountBalance newBalance = new BankAccountBalance(this.CurrentBalance.Account, DateTime.Now,
        //        this.CurrentBalance.Balance - amount, context.User, remark);
        //    this.CurrentBalance = newBalance;
        //}

        public virtual int GetHashCode(BankAccount obj)
        {
            return obj.ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            BankAccount b = (BankAccount)obj;
            if (this.ID == 0 || b.ID == 0)
                return this.AccountNo == b.AccountNo && this.ID == b.ID;
            else
                return this.ID == b.ID;
        }

        public override int GetHashCode()
        {
            return this.AccountNo.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + this.AccountType.ToString() + ", " + this.AccountNo + ", " + this.Name + "}";
        }

        #region static

        public static BankAccount Find(Context context, int ID)
        {
            return (BankAccount)context.PersistenceSession.Get(typeof(BankAccount), ID);
        }

        public static IList<BankAccount> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(BankAccount));
            return crit.List<BankAccount>();
        }

        public static IList<BankAccount> Find(Context context, Organization bank)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(BankAccount));
            crit.Add(Expression.Eq("Bank", bank));

            //iSabaya.CriteriaUtil.AddCriteriaEffective(crit, DateTime.Now);
            return crit.List<BankAccount>();
        }

        public static BankAccount Find(Context context, int organizationId, string accountNo)
        {
            Organization bank = Organization.Find(context, organizationId);
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(BankAccount));
            crit.Add(Expression.Eq("Bank", bank));
            crit.Add(Expression.Eq("AccountNo", accountNo));
            return crit.UniqueResult<BankAccount>();
        }

        public static BankAccount Find(Context context, String officialIDNo, String accountNo)
        {
            Organization bank = Organization.FindByOfficialIDNo(context, officialIDNo);
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(BankAccount));
            crit.Add(Expression.Eq("Bank", bank));
            crit.Add(Expression.Eq("AccountNo", accountNo));
            return crit.UniqueResult<BankAccount>();
        }

        #endregion static

        #region IEqualityComparer<BankAccount> Members

        public virtual bool Equals(BankAccount x, BankAccount y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(null, x) || Object.ReferenceEquals(null, y)) return false;
            if (0 != x.ID && x.ID == y.ID) return true;
            //if (x.Bank == y.Bank && x.AccountNo == y.AccountNo) return true;
            if (x.UniqueAccountNo == y.UniqueAccountNo) return true;
            return false;
        }

        #endregion IEqualityComparer<BankAccount> Members

        #region IComparable<BankAccount> Members

        public virtual int CompareTo(BankAccount other) //เพิ่ม virtaul -> วัชระ
        {
            if (this.ID == 0 || other.ID == 0)
            {
                if (this.ID == other.ID)
                    return String.CompareOrdinal(this.AccountNo, other.AccountNo);
                else
                    return this.ID.CompareTo(other.ID);
            }
            else if (this.ID == other.ID)
                return 0;
            else
                return this.ID.CompareTo(other.ID);
        }

        #endregion IComparable<BankAccount> Members
    }
}