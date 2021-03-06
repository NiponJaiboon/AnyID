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
    public abstract class StatefulEntity
    {

        #region constructors

        public StatefulEntity()
        {
            this.CreatedTS = DateTime.Now;
        }

        public StatefulEntity(User user, StatefulEntityType type, String reference, String remark)
        {
            this.RecordedBy = user;
            this.Type = type;
            this.Reference = reference;
            this.Remark = remark;
            this.CreatedTS = DateTime.Now;
        }


        #endregion constructors

        //public event EventHandler Change;
        public virtual bool IsToBeSaved { get; set; }

        #region persistent

        protected Int64 id;
        public virtual Int64 ID
        {
            get { return id; }
            set { id = value; }
        }

        //protected String entityNo = null;
        //public virtual String EntityNo
        //{
        //    get { return entityNo; }
        //    set { entityNo = value; }
        //}

        ///// <summary>
        ///// Get and set the current state of the transaction.
        ///// Setting the current state also add it to this.States.
        ///// </summary>
        //public abstract EntityState CurrentState { get; set; }

        public virtual String Remark { get; set; }

        protected DateTime effectiveDate = TimeInterval.MinDate;
        public virtual DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }

        public virtual User RecordedBy { get; set; }

        public virtual String Reference { get; set; }

        public virtual StatefulEntity Parent { get; set; }

        protected IList<EntityState> states;
        public virtual IEnumerable<EntityState> States
        {
            get { return this.states; }

            protected set { this.states = (IList<EntityState>)value; }
        }

        public virtual DateTime CreatedTS { get; set; }

        public virtual StatefulEntityType Type { get; set; }

        public virtual EntityState CurrentState { get; set; }

        public virtual object Tag { get; set; }


        #endregion persistent

        #region static

        #endregion static

        //public abstract bool Rollback(Context context, StatefulEntity contraTran);

        /// <summary>
        /// Transit directly to a state specified in the parameters
        /// </summary>
        /// <param name="transactionState"></param>
        /// <returns></returns>
        //public abstract RuleResult Transit(Context context, ParameterList parameters);

        /// <summary>
        /// Transit directly to a given EntityState
        /// </summary>
        /// <param name="transactionState"></param>
        /// <returns></returns>
        //public abstract RuleResult Transit(Context context, EntityState destinationState);
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
        //        this.CurrentState = new EntityState(this, transitionPara.ToState, transitionPara.Units,
        //                                    transitionPara.Amount, transitionPara.Reference,
        //                                    transitionPara.Remark, transitionPara.RuleMessage,
        //                                    transitionPara.User);

        //    return result;
        //}


        #region operations

        //public virtual void AddState(EntityState state)
        //{
        //    this.States.Add(state);
        //    this.CurrentState = state;
        //}

        public virtual bool IsRoot()
        {
            return null == this.Parent;
        }

        public virtual StatefulEntity GetRoot()
        {
            StatefulEntity r = this;
            while (null != r.Parent)
                r = r.Parent;
            return r;
        }

        public virtual void Persist(Context context)
        {
            bool isNewTransaction = this.ID == 0;

            //this.CurrentState and/or this.accountBalance may be newly created object
            //(TransactionStateID and/or this.AccountBalanceID are 0).
            //In such case we will have to update this transaction later.
            context.PersistenceSession.SaveOrUpdate(this);

        }

        #endregion operations

    }
}