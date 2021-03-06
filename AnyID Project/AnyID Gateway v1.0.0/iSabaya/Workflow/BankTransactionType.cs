using System;
using System.Collections.Generic;
using System.Text;
using iSabaya;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class BankTransactionType : StatefulTransactionType
    {
        public BankTransactionType()
        {
        }

        public BankTransactionType(int applicationID, User user, String code, TimeInterval effectivePeriod,
                                MultilingualString title)
            : base(applicationID, user, code, effectivePeriod, title)
        {
        }

        public BankTransactionType(int applicationID, User user, String code, TimeInterval effectivePeriod,
                                MultilingualString title, MultilingualString shortTitle, MultilingualString description,
                                bool isExecutable, bool isCredit, bool isDebit, bool isPrincipal, bool directlyAffectInvestmentUnits,
                                Rule creationRule, Rule validateRule, Rule rollbackRule)
            : base(applicationID, user, code, effectivePeriod, title, shortTitle, description,
                    creationRule, validateRule, rollbackRule)
        {
            this.isPrincipal = isPrincipal;
            this.isExecutable = isExecutable;
            this.isCredit = isCredit;
            this.isDebit = isDebit;
            this.directlyAffectInvestmentUnits = directlyAffectInvestmentUnits;
        }

        #region persistent

        protected int transactionTypeID;

        public virtual int TransactionTypeID
        {
            get { return transactionTypeID; }
            set { transactionTypeID = value; }
        }

        protected String bookCode;

        public virtual String BookCode
        {
            get { return bookCode; }
            set { bookCode = value; }
        }

        protected bool directlyAffectInvestmentUnits = false;

        /// <summary>
        /// If true, the transactions of this type change the units of its target investment
        /// </summary>
        public virtual bool DirectlyAffectInvestmentUnits
        {
            get { return directlyAffectInvestmentUnits; }
            set { directlyAffectInvestmentUnits = value; }
        }

        protected bool isPrincipal = false;

        /// <summary>
        /// if true, the transactions of this type can be processed independently
        /// </summary>
        public virtual bool IsPrincipal
        {
            get { return isPrincipal; }
            set { isPrincipal = value; }
        }

        protected bool isExecutable = true;

        public virtual bool IsExecutable
        {
            get { return isExecutable; }
            set { isExecutable = value; }
        }

        protected bool isCredit = true;

        public virtual bool IsCredit
        {
            get { return isCredit; }
            set { isCredit = value; }
        }

        protected bool isDebit = false;

        public virtual bool IsDebit
        {
            get { return isDebit; }
            set { isDebit = value; }
        }

        protected bool isReversible = true;

        public virtual bool IsReversible
        {
            get { return isReversible; }
            set { isReversible = value; }
        }

        protected bool requireTradeCalendar = false;

        public virtual bool RequireTradeCalendar
        {
            get { return requireTradeCalendar; }
            set { requireTradeCalendar = value; }
        }

        protected TreeListNode subType;

        public virtual TreeListNode SubType
        {
            get { return subType; }
            set { subType = value; }
        }

        #endregion persistent

        protected Context context;
        public virtual Context Context
        {
            get { return context; }
            set
            {
                context = value;
                if (null != Title)
                    Title.Context = context;
                if (null != ShortTitle)
                    ShortTitle.Context = context;
                if (null != Description)
                    Description.Context = context;
            }
        }

        public virtual BusinessRuleProcedure ReleaseProc { get; set; }

        public virtual BusinessRuleProcedure OnSaveProc { get; set; }

        //public virtual State GetState(string stateCategoryCode)
        //{
        //    foreach (State s in base.States)
        //    {
        //        if (s.Category == stateCategoryCode) return s;
        //    }
        //    throw new iSabayaException(Messages.TransactionTypeNoState(this.Code, stateCategory.ToString()));
        //}

        //public override State GetState(String stateCode)
        //{
        //    foreach (State s in base.States)
        //    {
        //        if (s.Code == stateCode) return s;
        //    }
        //    throw new iSabayaException("There is no state " + stateCode);
        //}

        public static new BankTransactionType FindByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<BankTransactionType>()
                                    .Add(Expression.Eq("Code", code));
            BankTransactionType tt = crit.UniqueResult<BankTransactionType>();
            if (null == tt)
                throw new iSabayaException("There is no transaction type '" + code + "'.");
            return tt;
        }

        //public override void Persist(Context context)
        //{
        //    this.updatedTS = DateTime.Now;
        //    if (base.CreationRule != null) base.CreationRule.Persist(context);
        //    if (base.ValidationRule != null) base.ValidationRule.Persist(context);
        //    if (base.RollbackRule != null) base.RollbackRule.Persist(context);
        //    if (title != null) title.Persist(context);
        //    if (shortTitle != null) shortTitle.Persist(context);
        //    if (description != null) description.Persist(context);
        //    if (transactionTypeID == 0)
        //        context.Persist(this);
        //    else
        //        context.PersistenceSession.Update(this);
        //    foreach (State s in base.States)
        //    {
        //        s.Persist(context);
        //    }
        //    foreach (State s in base.States)
        //        foreach (StateTransition transition in s.Transitions)
        //            transition.Persist(context);
        //}

        //public override void Update(Context context)
        //{
        //    base.Update(context);
        //    if (title != null) title.Persist(context);
        //    if (shortTitle != null) shortTitle.Persist(context);
        //    if (description != null) description.Persist(context);
        //    foreach (State s in base.States)
        //    {
        //        s.Persist(context);
        //    }

        //    context.PersistenceSession.Update(this);
        //}

        private ParameterList parameterList = null;

        public override RuleResult Create(Context context, ParameterList parameters, out StatefulEntity entity)
        {
            RuleResult result;
            if (null == base.CreationRule)
                throw new iSabayaException("BankTransactionType.ValidateRule is null.");

            result = base.CreationRule.Execute(this, parameterList);
            entity = (StatefulEntity)parameterList[2].Value;
            if (RuleResult.Success != result)
                return result;

            if (null != base.ValidationRule)
                result = base.ValidationRule.Execute(this, parameterList);

            return result;
        }

        //public virtual RuleResult Create<T>(Context context, TransactionParameterBase parameters,
        //                                    out T transaction)
        //    where T : InvestmentTransaction
        //{
        //    if (null == parameterList)
        //    {
        //        parameterList = new ParameterList();
        //        parameterList.Add(new RuleParameter(ParameterDirection.IN, "transactionType", typeof(BankTransactionType), this));
        //        parameterList.Add(new RuleParameter(ParameterDirection.IN, "transactionInfo", typeof(TransactionParameterBase)));
        //        parameterList.Add(new RuleParameter(ParameterDirection.OUT, "transaction", typeof(InvestmentTransaction)));
        //    }

        //    parameterList[1].Value = parameters;
        //    parameterList[2].Value = null;

        //    RuleResult result;
        //    if (null == base.CreationRule)
        //        throw new iSabayaException("BankTransactionType.ValidateRule is null.");

        //    result = base.CreationRule.Execute(this, parameterList);
        //    transaction = (T)parameterList[2].Value;
        //    if (RuleResult.Success != result)
        //        return result;

        //    if (null != base.ValidationRule)
        //        result = base.ValidationRule.Execute(this, parameterList);

        //    return result;
        //}

        public static IList<BankTransactionType> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(BankTransactionType));
            return crit.List<BankTransactionType>();
        }

        public static IList<BankTransactionType> List(Context context, int applicationID)
        {
            return context.PersistenceSession
                        .CreateCriteria<BankTransactionType>()
                        .Add(Expression.Eq("Application", applicationID))
                        .List<BankTransactionType>();
        }

        public static IList<BankTransactionType> ListPrincipalTypes(Context context, int applicationID)
        {
            return context.PersistenceSession
                        .CreateCriteria<BankTransactionType>()
                        .Add(Expression.Eq("Application", applicationID))
                        .Add(Expression.Eq("IsPrincipal", true))
                        .List<BankTransactionType>();
        }

        public static IList<BankTransactionType> ListRequiredTradeCalendarTypes(Context context, int applicationID)
        {
            return context.PersistenceSession
                        .CreateCriteria<BankTransactionType>()
                        .Add(Expression.Eq("Application", applicationID))
                        .Add(Expression.Eq("RequireTradeCalendar", true))
                        .List<BankTransactionType>();
        }

        //public virtual State FindStateByCode(String stateCode)
        //{
        //    State output = null;
        //    foreach (State s in this.States)
        //    {
        //        if (s.Code.Equals(stateCode))
        //        {
        //            output = s;
        //            break;
        //        }
        //    }
        //    return output;
        //}

        public static BankTransactionType Find(Context context, int id)
        {
            return (BankTransactionType)context.PersistenceSession.Get(typeof(BankTransactionType), id);
        }

        //public virtual StateTransition FindStateTransition(Context context, String fromStateCode, String toStateCode)
        //{
        //    State from = null;
        //    foreach (State s in States)
        //    {
        //        if (s.Code.Equals(fromStateCode))
        //        {
        //            from = s;
        //        }
        //    }
        //    State to = null;
        //    foreach (State s in States)
        //    {
        //        if (s.Code.Equals(toStateCode))
        //        {
        //            to = s;
        //        }
        //    }
        //    ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(StateTransition));
        //    crit.Add(Expression.Eq("FromState", from));
        //    crit.Add(Expression.Eq("ToState", to));
        //    return crit.UniqueResult<StateTransition>();
        //}

        //public virtual IList<StateTransition> GetStateTransitions(Context context)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(State));
        //    crit.Add(Expression.Eq("Owner", this));
        //    IList<State> list = crit.List<State>();

        //    IList<StateTransition> transitions = new List<StateTransition>();
        //    foreach (State s in list)
        //    {
        //        foreach (StateTransition st in s.Transitions)
        //        {
        //            if (!transitions.Contains(st))
        //            {
        //                transitions.Add(st);
        //            }
        //        }
        //    }
        //    return transitions;
        //}

        //public virtual IList<T> GetLeafTransactions<T, F>(Context context, F instrument,
        //                                                    TransactionStateCategory stateCategory,
        //                                                    TimeInterval period)
        //    where T : InvestmentTransaction
        //    where F : InvestmentInstrument
        //{
        //    return context.PersistenceSession.CreateCriteria<T>()
        //                    .Add(Expression.Eq("Type", this))
        //                    .Add(Expression.Eq("Instrument", instrument))
        //                    .CreateAlias("CurrentState", "cs")
        //                    .Add(Expression.Eq("cs.StateCategory", stateCategory))
        //                    .Add(Expression.Eq("IsLeaf", true))
        //                    .Add(Expression.Between("TradeDate", period.From, period.To))
        //                    .List<T>();
        //}

        //public virtual Money TotalTransactionAmount<T, F>(Context context, F fund,
        //                                            TransactionStateCategory stateCategory,
        //                                            TimeInterval period)
        //    where T : InvestmentTransaction
        //    where F : InvestmentInstrument
        //{
        //    IList<T> transactions = this.GetLeafTransactions<T, F>(context, fund,
        //                                                                    stateCategory, period);
        //    MoneyBuilder totalAmount = new MoneyBuilder();
        //    foreach (T t in transactions)
        //    {
        //        totalAmount.Add(t.Amount);
        //    }
        //    return totalAmount.ToMoney();
        //}

        public override bool Equals(object obj)
        {
            return this.TransactionTypeID == ((BankTransactionType)obj).TransactionTypeID;
        }

        public override int GetHashCode()
        {
            return this.TransactionTypeID;
        }

        public static bool operator !=(BankTransactionType a, BankTransactionType b)
        {
            return !(a == b);
        }

        public static bool operator ==(BankTransactionType a, BankTransactionType b)
        {
            if (Object.ReferenceEquals(null, a) && Object.ReferenceEquals(null, b)) return true;
            if (Object.ReferenceEquals(null, a) || Object.ReferenceEquals(null, b)) return false;
            return (a.TransactionTypeID == b.TransactionTypeID);
        }

        #region IComparable<BankTransactionType> Members

        public virtual int CompareTo(BankTransactionType obj)
        {
            if (Object.ReferenceEquals(null, obj))
                return 1;
            if (this.transactionTypeID > obj.transactionTypeID)
                return 1;
            if (this.transactionTypeID < obj.transactionTypeID)
                return -1;
            return 0;
        }

        #endregion IComparable<BankTransactionType> Members
    }

    // END CLASS DEFINITION BankTransactionType
}