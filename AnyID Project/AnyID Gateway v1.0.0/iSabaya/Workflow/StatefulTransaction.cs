using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace iSabaya
{
    public delegate void ProcessTransaction(Context context, StatefulTransaction t);

    [Serializable]
    public abstract class StatefulTransaction : StatefulEntity
    {

        #region constructors

        public StatefulTransaction()
        {
            this.CreatedTS = DateTime.Now;
        }

        public StatefulTransaction(User user, StatefulTransactionType type, String reference, String remark)
        {
            this.CreatedBy = user;
            this.Type = type;
            this.Reference = reference;
            this.Remark = remark;
            this.CreatedTS = DateTime.Now;
        }


        #endregion constructors


        #region persistent

        public virtual string TransactionNo { get; set; }

        //public virtual User OrderedBy { get; set; }
        //public virtual DateTime OrderedTS { get; set; }
        //public virtual DateTime RecordTS { get; set; }

        //public virtual StatefulEntity GetChild(int childNo)
        //{
        //    StatefulEntity e = null;
        //    foreach (TransactionRelation r in this.Children)
        //    {
        //        if (childNo == 0)
        //            e = r.Child;
        //    }
        //    return e;
        //}

        protected IEnumerable<TransactionRelation> children;
        public virtual IEnumerable<TransactionRelation> Children
        {
            get
            {
                if (this.children == null) children = new List<TransactionRelation>();
                return children;
            }
            set { children = (IEnumerable<TransactionRelation>)value; }
        }

        public virtual new IEnumerable<TransactionState> States
        {
            get
            {
                if (null == base.States)
                    base.States = new List<TransactionState>();
                return (IList<TransactionState>)base.States; 
            }
            set { base.States = value; }
        }

        public virtual User CreatedBy { get; set; }

        protected bool isProcessedIndependently = true;
        /// <summary>
        /// Default = true
        /// </summary>
        public virtual bool IsProcessedIndependently
        {
            get { return this.isProcessedIndependently; }
            set { this.isProcessedIndependently = value; }
        }

        protected bool isRoot = true;
        /// <summary>
        /// Is the transaction the root of transaction tree?
        /// Default = true
        /// </summary>
        public virtual new bool IsRoot
        {
            get { return this.isRoot; }
            set
            {
                this.isRoot = value;
                if (!this.isRoot) this.isProcessedIndependently = false;
            }
        }

        public virtual new StatefulTransactionType Type
        {
            get { return (StatefulTransactionType)base.Type; }
            set { base.Type = value; }
        }

        public virtual new StatefulTransaction Parent
        {
            get { return (StatefulTransaction)base.Parent; }
            set { base.Parent = value; }
        }

        /// <summary>
        /// Get or set the current state of the transaction.
        /// If the set value is not exist in this.States, it will be added to this.States.
        /// </summary>
        public virtual new TransactionState CurrentState
        {
            get { return (TransactionState)base.CurrentState; }
            protected set
            {
                //Check for redundant setting of the current state;
                if (Object.ReferenceEquals(base.CurrentState, value)) return;
                if (null == value) return;

                //Set the value of the current state;
                if (!(null != this.States && base.states.Contains(value)))
                    base.states.Add(value);
                value.Owner = this;
                base.CurrentState = value;
            }
        }


        #endregion persistent

        #region static

        public virtual IList<TransactionPayment> CreateFromPayments(IEnumerable<Payment> payments)
        {
            IList<TransactionPayment> transactionPayments = new List<TransactionPayment>();
            if (null != payments)
            {
                foreach (Payment p in payments)
                {
                    transactionPayments.Add(new TransactionPayment(this, p));
                }
            }

            return transactionPayments;
        }

        #endregion static

        //public abstract bool Rollback(Context context, StatefulTransaction contraTran);

        /// <summary>
        /// Transit directly to a state specified in the parameters
        /// </summary>
        /// <param name="transactionState"></param>
        /// <returns></returns>
        //public abstract RuleResult Transit(Context context, ParameterList parameters);

        /// <summary>
        /// Transit directly to a given TransactionState
        /// </summary>
        /// <param name="transactionState"></param>
        /// <returns></returns>
        //public abstract RuleResult Transit(Context context, TransactionState destinationState);
        //{
        //    if (null == destinationState)
        //        throw new iSabayaException(Messages.DestinationStateIsNotDefined);

        //    destinationState.Transaction = this;
        //    ParameterList parameters = new ParameterList();
        //    TransactionStateTransitionParameter transitionPara = new TransactionStateTransitionParameter();
        //    transitionPara.Amount = destinationState.Amount;
        //    transitionPara.Units = destinationState.Units;
        //    transitionPara.Timestamp = DateTime.Now;
        //    transitionPara.Reference = destinationState.Reference;
        //    transitionPara.Remark = destinationState.Remark;
        //    transitionPara.User = user;
        //    transitionPara.Transaction = this;
        //    transitionPara.FromState = this.CurrentState == null ? null : this.CurrentState.State;
        //    transitionPara.ToState = destinationState.State;
        //    transitionPara.Context = context;
        //    //if (null != transitionParamenters.Session) Config.Session = transitionParamenters.Session;

        //    parameters.Add(new RuleParameter(ParameterDirection.INOUT, "TransitionParameter",
        //                                        typeof(TransactionStateTransitionParameter),
        //                                        transitionPara
        //                                    )
        //                    );

        //    RuleResult result;
        //    if (null != this.CurrentState)
        //    {
        //        result = this.CurrentState.OnExit(parameters);
        //        if (result.Category == RuleResultCategory.Success)
        //            result = transitionPara.ToState.OnEnter(parameters);
        //    }
        //    else
        //    {
        //        result = destinationState.OnEnter(parameters);
        //    }

        //    if (null != transitionPara.ToState)
        //        this.CurrentState = new TransactionState(this, transitionPara.ToState, transitionPara.Units,
        //                                    transitionPara.Amount, transitionPara.Reference,
        //                                    transitionPara.Remark, transitionPara.RuleMessage,
        //                                    transitionPara.User);

        //    return result;
        //}

        //public abstract void SaveChildTransaction(Context context);
        public virtual ProcessTransaction ExecuteAfterSave { get; set; }
        public virtual ProcessTransaction ExecuteBeforeSave { get; set; }


        #region operations

        public virtual StatefulTransaction GetRelatedRoot(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<TransactionRelation>()
                                    .Add(Expression.Eq("Child", this));
            TransactionRelation rel = crit.UniqueResult<TransactionRelation>();

            StatefulTransaction root;
            if (null == rel)
                root = this;
            //throw new iSabayaException(Messages.TransactionHasNoRoot(this.TransactionNo));
            else if (rel.Parent.IsRoot())
                root = rel.Parent;
            else
                root = rel.Parent.GetRelatedRoot(context);
            return root;
        }

        //public virtual void AddState(TransactionState state)
        //{
        //    this.States.Add(state);
        //    this.CurrentState = state;
        //}

        //public virtual void Persist(Context context)
        //{
        //    bool isNewTransaction = this.ID == 0;

        //    //this.CurrentState and/or this.accountBalance may be newly created object
        //    //(TransactionStateID and/or this.AccountBalanceID are 0).
        //    //In such case we will have to update this transaction later.
        //    context.PersistenceSession.SaveOrUpdate(this);

        //}

        #endregion operations

    }
}