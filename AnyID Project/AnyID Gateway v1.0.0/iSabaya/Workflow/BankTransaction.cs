using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace iSabaya
{
    [Serializable]
    public abstract class BankTransaction : StatefulTransaction
    {

        #region constructors

        public BankTransaction()
        {
            this.TransactionTS = DateTime.Now;
        }

        //For Provident Fund Transactions
        public BankTransaction(User user, BankTransactionType type, DateTime transactionDate,
                                DateTime effectiveDate, DateTime settlementDate, BankAccount account, 
                                String reference, String description, IList<Payment> payments)
            : base(user, type, reference, description)
        {
            //this.recordedBy = user;
            //this.type = type;
            //this.transactionChannel = null;
            //this.account = account;
            //this.fund = fund;
            ////this.quantity.units = 0d;
            ////this.amount = (null == amount) ? null : new Money(amount);
            //this.reference = reference;
            //this.description = description;
            //this.effectiveDate = effectiveDate;
            //this.orderedDate = orderedDate;
            this.settlementDate = settlementDate;
            this.transactionDate = transactionDate;
            this.TransactionTS = DateTime.Now;
            //this.payments = payments;

            //if (null != payments)
            //{
            //    foreach (TransactionPayment tp in this.Payments)
            //    {
            //        tp.Transaction = this;
            //    }
            //}
        }

        //For Mutual Fund Transactions
        public BankTransaction(User user, BankTransactionType type, DateTime transactionDate, DateTime effectiveDate, 
                                TreeListNode channel, BankAccount account, String reference, String description, 
                                IList<Payment> payments)
            : base(user, type, reference, description)
        {
            //this.recordedBy = user;
            //this.type = type;
            this.Channel = channel;
            //this.account = account;
            //this.fund = fund;
            //this.reference = reference;
            //this.description = description;
            //this.effectiveDate = effectiveDate;
            //this.orderedDate = orderedDate;
            this.EffectiveDate = effectiveDate;
            this.transactionDate = transactionDate;
            //this.transactionTS = DateTime.Now;
            if (null != account)
                this.Fee = new Money(0m, account.CurrencyCode);
            //this.payments = payments;
            //if (null != payments)
            //{
            //    foreach (TransactionPayment tp in this.Payments)
            //    {
            //        tp.Transaction = this;
            //    }
            //}
        }

        #endregion constructors

        //public event EventHandler Change;
        //public virtual bool IsToBeSaved { get; set; }

        #region persistent

        //protected String transactionNo = null;
        //public virtual String TransactionNo
        //{
        //    get { return transactionNo; }
        //    set { transactionNo = value; }
        //}

        public virtual DateTime TransactionTS { get; set; }
        public virtual Money Fee { get; set; }

        public virtual BankAccount BankAccount {get;set;}

        //protected Money capital;
        //public virtual Money Capital
        //{
        //    get { return capital; }
        //    set { capital = value; }
        //}

        //public virtual Money CapitalGainTax { get; set; }
        //public virtual MoneyRateSchedule CapitalGainTaxSchedule { get; set; }

        //protected bool changesInvestment = false;
        ///// <summary>
        ///// Default = false
        ///// </summary>
        //public virtual bool ChangesInvestment
        //{
        //    get { return changesInvestment; }
        //    set { changesInvestment = value; }
        //}

        //protected TransactionState currentState = null;
        ///// <summary>
        ///// Get or set the current state of the transaction.
        ///// If the set value is not exist in this.States, it will be added to this.States.
        ///// </summary>
        //public virtual TransactionState CurrentState
        //{
        //    get { return this.currentState; }
        //    set
        //    {
        //        //Check for redundant setting of the current state;
        //        if (Object.ReferenceEquals(this.currentState, value)) return;
        //        if (null == value) return;

        //        //Set the value of the current state;
        //        if (!this.States.Contains(value))
        //            this.States.Add(value);
        //        value.Transaction = this;
        //        this.currentState = value;
        //    }
        //}

        //protected String description;
        //public virtual String Description
        //{
        //    get { return description; }
        //    set { description = value; }
        //}

        //protected DateTime effectiveDate = TimeInterval.MinDate;
        //public virtual DateTime EffectiveDate
        //{
        //    get { return effectiveDate; }
        //    set { effectiveDate = value; }
        //}

        //protected Money fee;
        //public virtual Money Fee
        //{
        //    get { return fee; }
        //    set { fee = value; }
        //}

        //private BracketedMoneyRate feeBracket = null;
        //public virtual BracketedMoneyRate FeeBracket
        //{
        //    get { return feeBracket; }
        //    set { feeBracket = value; }
        //}

        //private MoneyRateSchedule feeSchedule = null;
        //public virtual MoneyRateSchedule FeeSchedule
        //{
        //    get { return feeSchedule; }
        //    set { feeSchedule = value; }
        //}

        //protected Investment investment;
        //public virtual Investment Investment
        //{
        //    get { return investment; }
        //    set { investment = value; }
        //}

        //protected TreeListNode investmentType;
        //public virtual TreeListNode InvestmentType
        //{
        //    get { return investmentType; }
        //    set { investmentType = value; }
        //}

        //protected TreeListNode investmentCategory;
        //public virtual TreeListNode InvestmentCategory
        //{
        //    get { return investmentCategory; }
        //    set { investmentCategory = value; }
        //}

        //protected bool isDetail = false;
        ///// <summary>
        ///// True = this is a detail of another transaction.  Not to be used in fee calculation.
        ///// Default = false.
        ///// </summary>
        //public virtual bool IsDetail
        //{
        //    get { return isDetail; }
        //    set { isDetail = value; }
        //}

        //protected bool isLeaf = true;
        ///// <summary>
        ///// Default = true
        ///// </summary>
        //public virtual bool IsLeaf
        //{
        //    get { return isLeaf; }
        //    set { isLeaf = value; }
        //}

        //protected bool isProcessedIndependently = true;
        ///// <summary>
        ///// Default = true
        ///// </summary>
        //public virtual bool IsProcessedIndependently
        //{
        //    get { return isProcessedIndependently; }
        //    set { isProcessedIndependently = value; }
        //}

        //protected bool isRoot = true;
        ///// <summary>
        ///// Default = true
        ///// </summary>
        //public virtual bool IsRoot
        //{
        //    get { return isRoot; }
        //    set
        //    {
        //        isRoot = value;
        //        if (!isRoot) isProcessedIndependently = false;
        //    }
        //}

        public virtual Money Amount { get; set; }
        public virtual TreeListNode Channel { get; set; }

        //protected DateTime orderedDate;
        //public virtual DateTime OrderedDate
        //{
        //    get { return orderedDate; }
        //    set { orderedDate = value; }
        //}

        //private BankTransaction relatedTransaction;
        //public virtual BankTransaction RelatedTransaction
        //{
        //    get { return relatedTransaction; }
        //    set { relatedTransaction = value; }
        //}

        //private ContraTransaction rollbackTransaction;
        //public virtual ContraTransaction RollbackTransaction
        //{
        //    get { return rollbackTransaction; }
        //    set { rollbackTransaction = value; }
        //}

        protected DateTime settlementDate;
        public virtual DateTime SettlementDate
        {
            get { return settlementDate; }
            set { settlementDate = value; }
        }

        //protected new IList<TransactionState> states;
        //public virtual new IList<TransactionState> States
        //{
        //    get
        //    {
        //        if (this.states == null) this.states = new List<TransactionState>();
        //        return this.states;
        //    }
        //    set { this.states = value; }
        //}

        //protected Money tax;
        //public virtual Money Tax
        //{
        //    get { return tax; }
        //    set { tax = value; }
        //}

        //protected BankAccount toBankAccount;
        //public virtual BankAccount ToBankAccount
        //{
        //    get { return toBankAccount; }
        //    set { toBankAccount = value; }
        //}

        protected DateTime transactionDate;
        public virtual DateTime TradeDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }

        //protected TreeListNode transactionChannel;
        //public virtual TreeListNode TransactionChannel
        //{
        //    get { return transactionChannel; }
        //    set { transactionChannel = value; }
        //}

        //protected DateTime transactionTS;
        //public virtual DateTime TransactionTS
        //{
        //    get { return transactionTS; }
        //    set { transactionTS = value; }
        //}

        //public new virtual BankTransactionType Type
        //{
        //    get { return (BankTransactionType)base.type; }
        //    set { base.type = value; }
        //}

        //protected IList<TransactionChildRelation> children;
        //public virtual IList<TransactionChildRelation> Children
        //{
        //    get
        //    {
        //        if (this.children == null) children = new List<TransactionChildRelation>();
        //        return children;
        //    }
        //    set { children = value; }
        //}

        //protected IList<TransactionCousinRelation> cousins;
        //public virtual IList<TransactionCousinRelation> Cousins
        //{
        //    get
        //    {
        //        if (this.cousins == null)
        //            this.cousins = new List<TransactionCousinRelation>();
        //        return this.cousins;
        //    }
        //    set { this.cousins = value; }
        //}

        protected IList<TransactionPayment> payments;
        public virtual IList<TransactionPayment> Payments
        {
            get
            {
                if (payments == null) payments = new List<TransactionPayment>();
                return payments;
            }
            set { payments = value; }
        }

        //protected InvestmentTransactionRollbackStatus rollbackStatus = InvestmentTransactionRollbackStatus.None;
        //public virtual InvestmentTransactionRollbackStatus RollbackStatus
        //{
        //    get { return rollbackStatus; }
        //    set { rollbackStatus = value; }
        //}

        #region External Switch-In Transaction

        protected DateTime externalInvestmentDate = TimeInterval.MinDate;
        public virtual DateTime ExternalInvestmentDate
        {
            get { return externalInvestmentDate; }
            set { externalInvestmentDate = value; }
        }

        protected Money gain;
        public virtual Money Gain
        {
            get { return gain; }
            set { gain = value; }
        }

        protected Organization externalInvestmentOrg;
        public virtual Organization ExternalInvestmentOrg
        {
            get { return externalInvestmentOrg; }
            set { externalInvestmentOrg = value; }
        }

        protected OrgUnit externalFund;
        public virtual OrgUnit ExternalFund
        {
            get { return externalFund; }
            set { externalFund = value; }
        }

        protected String externalFundName;
        public virtual String ExternalFundName
        {
            get { return externalFundName; }
            set { externalFundName = value; }
        }

        protected String externalPortfolioNo;
        public virtual String ExternalPortfolioNo
        {
            get { return externalPortfolioNo; }
            set { externalPortfolioNo = value; }
        }

        protected DateTime initialInvestmentDate = TimeInterval.MaxDate;
        public virtual DateTime InitialInvestmentDate
        {
            get { return initialInvestmentDate; }
            set { initialInvestmentDate = value; }
        }

        //protected int seqNo;
        //public virtual int SeqNo
        //{
        //    get { return seqNo; }
        //    set { seqNo = value; }
        //}

        protected DateTime printedTS = TimeInterval.MaxDate;
        public virtual DateTime PrintedTS
        {
            get { return printedTS; }
            set { printedTS = value; }
        }

        //protected Money withheldTax;
        //public virtual Money WithheldTax
        //{
        //    get { return withheldTax; }
        //    set { withheldTax = value; }
        //}

        #endregion External Switch-In Transaction

        //protected Money unitPrice;
        //public virtual Money UnitPrice
        //{
        //    get { return unitPrice; }
        //    set { unitPrice = value; }
        //}

        #endregion persistent

        #region transient

        //public virtual AmountChange AmountChangedOnSaveHandler { get; set; }
        //public virtual bool AffectByNAVChange { get; set; }

        public new virtual BankTransaction Parent
        {
            get { return (BankTransaction)base.Parent; }
            set { base.Parent = value; }
        }

        #endregion transient

        //#region static

        //public static IList<BankTransaction> GetTransactions(Context context, InvestmentInstrument instrument,
        //                                                    BankTransactionType transactionType,
        //                                                    TransactionStateCategory stateCategory,
        //                                                    DateTime transactionDate)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria<BankTransaction>();
        //    if (transactionType != null) crit.Add(Expression.Eq("Type", transactionType));
        //    return crit.Add(Expression.Eq("Instrument", instrument))
        //                .CreateAlias("CurrentState", "cs")
        //                .Add(Expression.Eq("cs.StateCategory", stateCategory))
        //                .Add(Expression.Eq("TradeDate", transactionDate))
        //                .List<BankTransaction>();
        //}

        //public static IList<BankTransaction> GetTransactions(Context context, InvestmentInstrument instrument,
        //                                                    BankTransactionType transactionType,
        //                                                    TransactionStateCategory stateCategory)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria<BankTransaction>();
        //    if (transactionType != null) crit.Add(Expression.Eq("Type", transactionType));
        //    return crit.Add(Expression.Eq("Instrument", instrument))
        //                .CreateAlias("CurrentState", "cs")
        //                .Add(Expression.Eq("cs.StateCategory", stateCategory))
        //                .List<BankTransaction>();
        //}

        //public static BankTransaction FindByTransactionNo(Context context, String transactionNo)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria<BankTransaction>();
        //    crit.Add(Expression.Eq("TransactionNo", transactionNo));
        //    BankTransaction fundTransaction = crit.UniqueResult<BankTransaction>();
        //    return fundTransaction;
        //}

        //public static BankTransaction Find(Context context, Int64 tranId)
        //{
        //    return (BankTransaction)context.PersistenceSession.Get(typeof(BankTransaction), tranId);
        //}

        //#endregion static

        #region abstract

        //public abstract String ToPassbookLine();
        //public abstract void CreateInvestmentIfNull();
        //public abstract void Commit(Context context);
        //public abstract void SaveChildTransaction(Context context);
        //public abstract void SaveCousinTransaction(Context context);

        #endregion abstract

        #region operations


        //public virtual bool Rollback(Context context, ContraTransaction contraTran)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual String ToPassbookLine()
        //{
        //    return null;
        //}

        //public abstract Money Amount { get; set; }

        //public virtual double Units
        //{
        //    get { return 0d; }
        //    set { }
        //}

        //public virtual bool IsBeingRollbacked
        //{
        //    get { return this.RollbackStatus == InvestmentTransactionRollbackStatus.PendingRollback; }
        //}



        //public virtual bool HasBeenRollbacked
        //{
        //    get { return this.RollbackStatus == InvestmentTransactionRollbackStatus.BeenRollbacked; }
        //}

        //public virtual String ToLabel()
        //{
        //    return this.TransactionNo + " : " + TransactionTS.ToString("dd/MM/yyyy");
        //}

        //public virtual void AddState(TransactionState state)
        //{
        //    this.States.Add(state);
        //    this.CurrentState = state;
        //}

        /// <summary>
        /// Transit directly to a state specified in the parameters
        /// </summary>
        /// <param name="transactionState"></param>
        /// <returns></returns>
        //public virtual RuleResult Transit(Context context, ParameterList parameters)
        //{
        //    TransactionStateTransitionParameter transitionPara
        //        = (TransactionStateTransitionParameter)parameters[0].Value;

        //    if (transitionPara.FromState == null)
        //        throw new iSabayaException(Messages.SourceStateIsNotDefined);

        //    if (transitionPara.FromState != this.CurrentState.State)
        //        throw new iSabayaException(Messages.SourceStateIsNotTheCurrentState);

        //    if (transitionPara.ToState == null)
        //        throw new iSabayaException(Messages.DestinationStateIsNotDefined);

        //    if (context.User == null || context.User.Person == null)
        //        throw new iSabayaException(Messages.UserIsInvalid);

        //    RuleResult result;
        //    result = transitionPara.FromState.OnExit(parameters);
        //    if (result.Category == RuleResultCategory.Success)
        //        result = transitionPara.ToState.OnEnter(parameters);

        //    if (null != transitionPara.ToState)
        //        this.CurrentState = new TransactionState(this, transitionPara.ToState,
        //                                    transitionPara.Units, transitionPara.Amount,
        //                                    transitionPara.Reference, transitionPara.Remark,
        //                                    transitionPara.RuleMessage, context.User);

        //    return result;
        //}

        ///// <summary>
        ///// Transit directly to a given TransactionState
        ///// </summary>
        ///// <param name="transactionState"></param>
        ///// <returns></returns>
        //public virtual RuleResult Transit(Context context, TransactionState destinationState)
        //{
        //    if (null == destinationState)
        //        throw new iSabayaException(Messages.DestinationStateIsNotDefined);

        //    RuleResult result;
        //    if ((null == this.CurrentState || null == this.CurrentState.State.OnExitRule)
        //        && null == destinationState.State.OnEnterRule)
        //    {
        //        this.CurrentState = destinationState;
        //        destinationState.Owner = this;
        //        result = RuleResult.Success;
        //    }
        //    else
        //    {
        //        destinationState.Transaction = this;
        //        ParameterList parameters = new ParameterList();
        //        TransactionStateTransitionParameter transitionPara
        //            = new TransactionStateTransitionParameter
        //            {
        //                Amount = destinationState.Amount,
        //                Context = context,
        //                FromState = this.CurrentState == null ? null : this.CurrentState.State,
        //                Reference = destinationState.Reference,
        //                Remark = destinationState.Remark,
        //                Timestamp = DateTime.Now,
        //                ToState = destinationState.State,
        //                Transaction = this,
        //                Units = destinationState.Units,
        //                //User = context.User,
        //            };

        //        parameters.Add(new RuleParameter(ParameterDirection.INOUT, "TransitionParameter",
        //                                            typeof(TransactionStateTransitionParameter),
        //                                            transitionPara
        //                                        )
        //                        );

        //        if (null != this.CurrentState)
        //        {
        //            result = this.CurrentState.OnExit(parameters);
        //            if (result.Category == RuleResultCategory.Success)
        //                result = transitionPara.ToState.OnEnter(parameters);
        //        }
        //        else
        //        {
        //            result = destinationState.OnEnter(parameters);
        //        }

        //        if (null != transitionPara.ToState)
        //            this.CurrentState = new TransactionState(this, transitionPara.ToState,
        //                                        transitionPara.Units, transitionPara.Amount,
        //                                        transitionPara.Reference, transitionPara.Remark,
        //                                        transitionPara.RuleMessage, context.User);
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// Transit from the current state to the state specified by transition
        ///// </summary>
        ///// <param name="stateTransition">Selected transition, must not be null</param>
        ///// <param name="amount">The amount of money to be set to the transaction</param>
        ///// <param name="units">The number of investment units to be set to the transanction</param>
        ///// <param name="transitionTimestamp">The timestamp of the transition</param>
        ///// <param name="reference">The reference, if any</param>
        ///// <param name="remark">The remark, if any</param>
        ///// <param name="executedBy">The user who makes this transition</param>
        ///// <returns></returns>
        //public virtual RuleResult Transit(Context context,
        //                                    TransactionStateCategory toStateCategory,
        //                                    double units, Money amount, String reference,
        //                                    String remark, String message)
        //{
        //    State toState = this.Type.GetState(toStateCategory);

        //    RuleResult result;
        //    if ((null == this.CurrentState || null == this.CurrentState.State.OnExitRule)
        //        && null == toState.OnEnterRule)
        //    {
        //        this.CurrentState = new TransactionState(this, toState, units, amount, reference,
        //                                                    remark, message, context.User);
        //        result = RuleResult.Success;
        //    }
        //    else
        //    {
        //        ParameterList parameters = new ParameterList();
        //        TransactionStateTransitionParameter transitionPara = new TransactionStateTransitionParameter
        //        {
        //            Amount = amount,
        //            FromState = this.CurrentState.State,
        //            Reference = reference,
        //            Remark = remark,
        //            Context = context,
        //            Timestamp = DateTime.Now,
        //            ToState = toState,
        //            Transaction = this,
        //            Units = units,
        //            //User = context.User,
        //        };
        //        parameters.Add(new RuleParameter(ParameterDirection.INOUT, "TransitionParameter",
        //        typeof(TransactionStateTransitionParameter), transitionPara));

        //        if (null != this.CurrentState)
        //        {
        //            result = this.CurrentState.OnExit(parameters);
        //            if (result.Category == RuleResultCategory.Success)
        //                result = toState.OnEnter(parameters);
        //        }
        //        else
        //        {
        //            result = toState.OnEnter(parameters);
        //        }

        //        if (null != transitionPara.ToState)
        //            this.CurrentState = new TransactionState(this, transitionPara.ToState,
        //                                        transitionPara.Units, transitionPara.Amount,
        //                                        transitionPara.Reference, transitionPara.Remark,
        //                                        transitionPara.RuleMessage, context.User);
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// Transit from the current state to the state specified by transition
        ///// </summary>
        ///// <param name="stateTransition">Selected transition, must not be null</param>
        ///// <param name="amount">The amount of money to be set to the transaction</param>
        ///// <param name="units">The number of investment units to be set to the transanction</param>
        ///// <param name="transitionTimestamp">The timestamp of the transition</param>
        ///// <param name="reference">The reference, if any</param>
        ///// <param name="remark">The remark, if any</param>
        ///// <param name="executedBy">The user who makes this transition</param>
        ///// <returns></returns>
        //public virtual RuleResult Transit(Context context, StateTransition transition,
        //                                    Money amount, double units, DateTime transitionTimestamp,
        //                                    String reference, String remark)
        //{
        //    if (transition == null)
        //        throw new iSabayaException(Messages.TransitionIsNotDefined);
        //    if (null == transition.ToState)
        //        throw new iSabayaException(Messages.DestinationStateIsNotDefined);
        //    if (transition.FromState != this.CurrentState.State)
        //        throw new iSabayaException(Messages.SourceStateIsNotTheCurrentState);

        //    ParameterList parameters = new ParameterList();
        //    TransactionStateTransitionParameter transitionPara = new TransactionStateTransitionParameter
        //    {
        //        Amount = amount,
        //        FromState = transition.FromState,
        //        Reference = reference,
        //        Remark = remark,
        //        Context = context,
        //        Timestamp = DateTime.Now,
        //        ToState = transition.ToState,
        //        Transaction = this,
        //        Units = units,
        //    };
        //    parameters.Add(new RuleParameter(ParameterDirection.INOUT, "TransitionParameter",
        //    typeof(TransactionStateTransitionParameter), transitionPara));

        //    RuleResult result;

        //    result = transition.PreTransit(parameters);
        //    if (result.Category == RuleResultCategory.Success)
        //    {
        //        result = transition.Transit(parameters);
        //        if (result.Category == RuleResultCategory.Success)
        //            result = transition.ToState.OnEnter(parameters);
        //    }
        //    if (null != transitionPara.ToState)
        //        this.CurrentState = new TransactionState(this, transitionPara.ToState,
        //                                    transitionPara.Units, transitionPara.Amount,
        //                                    transitionPara.Reference, transitionPara.Remark,
        //                                    transitionPara.RuleMessage, context.User);
        //    return result;
        //}

        public override void Persist(Context context)
        {
            if (null != this.ExecuteBeforeSave)
                this.ExecuteBeforeSave(context, this);

            bool isNewTransaction = base.ID == 0;

            bool requireExtraUpdate;
            if (null == this.CurrentState)
                requireExtraUpdate = false;
            else
                requireExtraUpdate = isNewTransaction && this.CurrentState.TransactionStateID == 0;

            //this.CurrentState and/or this.accountBalance may be newly created object
            //(TransactionStateID and/or this.AccountBalanceID are 0).
            //In such case we will have to update this transaction later.
            if (base.ID == 0)
                context.Persist(this); //Get TransactionID

            //Save children transaction
            int seqNo = -1;
            foreach (TransactionRelation r in this.Children)
            {
                //r.Child.States = null;
                r.SeqNo = ++seqNo;
                r.Parent = this;
                r.Child.Persist(context);
                r.Persist(context);
            }

            //this.CurrentState is saved as part of this.states
            if (this.States != null)
            {
                foreach (TransactionState s in this.States)
                {
                    //begin bug avoidance : the hibernate-generated proxy inserted null if states contains none
                    if (null == s) continue;
                    //end bug avoidance

                    //s.Transaction = this;
                    s.Persist(context);
                }
            }

            if (this.payments != null)
            {
                foreach (TransactionPayment p in this.payments)
                {
                    p.Transaction = this;
                    p.Persist(context);
                }
            }

            //if (null != this.Fund && this.Fund.IsToBeSaved)
            //{
            //    this.Fund.IsToBeSaved = false;
            //    this.Fund.Persist(context);
            //}

            context.PersistenceSession.Update(this);

            if (null != this.ExecuteAfterSave)
                this.ExecuteAfterSave(context, this);

            //context.PersistenceSession.Flush();
        }

        //public virtual IList<TransactionChildRelation> GetParentRelations(Context context)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(TransactionChildRelation));
        //    return crit.Add(Expression.Eq("Child", this)).List<TransactionChildRelation>();
        //}

        //public override BankTransaction GetRoot(Context context)
        //{
        //    return (BankTransaction)base.GetRoot(context);
        //}


        ///// <summary>
        ///// status = 0 -> no rollback, 1 -> rollback is pending, 2 -> rollback is committed
        ///// </summary>
        //public virtual void SetRollbackStatus(InvestmentTransactionRollbackStatus status)
        //{
        //    if (this.CurrentState.StateCategory == TransactionStateCategory.Released)
        //    {
        //        this.rollbackStatus = status;
        //        foreach (TransactionChildRelation tr in Children)
        //        {
        //            tr.Child.SetRollbackStatus(status);
        //        }
        //    }
        //}

        //public virtual bool IsContra_able(out String validationMessage)
        //{

        //    if (!this.Type.IsReversible)
        //    {
        //        validationMessage = Messages.RollbackNotEligible;
        //        return false;
        //    }

        //    if (!this.isRoot)
        //    {
        //        validationMessage = Messages.RollbackNotMain;
        //        return false;
        //    }

        //    if (null != this.Investment
        //        && this.Investment.Transaction.TransactionID != this.TransactionID)
        //    {
        //        validationMessage = Messages.RollbackNotLastTransaction;
        //        return false;
        //    }

        //    //target transaction must have been released 
        //    //and its children (if any) must have been released or rejected
        //    if (this.CurrentState.StateCategory != TransactionStateCategory.Released)
        //    {
        //        validationMessage = Messages.RollbackNotReleased;
        //        return false;
        //    }

        //    foreach (TransactionChildRelation r in this.Children)
        //    {
        //        BankTransaction t = r.Child;

        //        if (t.CurrentState.StateCategory != TransactionStateCategory.Released
        //            && t.CurrentState.StateCategory != TransactionStateCategory.Rejected)
        //        {
        //            validationMessage = Messages.RollbackChildNotCommitted;
        //            return false;
        //        }
        //        if (null != t.Investment
        //            && t.Investment.Transaction.TransactionID != t.TransactionID)
        //        {
        //            validationMessage = Messages.RollbackNotLastTransaction;
        //            return false;
        //        }
        //    }

        //    validationMessage = null;
        //    return true;
        //}

        #endregion operations

    }
}