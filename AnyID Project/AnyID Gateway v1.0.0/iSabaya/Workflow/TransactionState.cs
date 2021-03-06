using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public abstract class TransactionState : EntityState
    {
        public TransactionState()
        {
        }

        public TransactionState(State state, User user)
        {
            this.owner = null;
            this.state = state;
            this.reference = null;
            this.remark = null;
            this.systemMessage = null;
            this.EnteredTS = this.updatedTS = DateTime.Now;
            this.updatedBy = user;
        }

        public TransactionState(StatefulEntity owner, State state, String reference, String remark, 
                            String systemMessage, User user)
        {
            this.owner = owner;
            this.state = state;
            this.reference = reference;
            this.remark = remark;
            if (null != systemMessage) this.systemMessage = systemMessage;
            this.EnteredTS = this.updatedTS = DateTime.Now;
            this.updatedBy = user;
        }

        public TransactionState(StatefulEntity owner, State state, String reference, String remark, 
                            DateTime enteredTS, User user)
        {
            this.owner = owner;
            this.state = state;
            this.reference = reference;
            this.remark = remark;
            this.systemMessage = "";
            this.EnteredTS = enteredTS;
            this.updatedTS = DateTime.Now;
            this.updatedBy = user;
        }

        #region persistent

        private Int64 transactionStateID;
        public virtual Int64 TransactionStateID
        {
            get { return transactionStateID; }
            set { transactionStateID = value; }
        }

        //private DateTime enteredTS;
        //public virtual DateTime EnteredTS
        //{
        //    get { return enteredTS; }
        //    set { enteredTS = value; }
        //}

        //protected StatefulEntity owner;
        public virtual StatefulTransaction Transaction
        {
            get { return (StatefulTransaction)base.Owner; }
            set { base.Owner = value; }
        }

        //protected String reference;
        //public virtual String Reference
        //{
        //    get { return reference; }
        //    set { reference = value; }
        //}

        public virtual TreeListNode CategoryNode { get; set; }

        #endregion persistent

        //public virtual RuleResult OnEnter(ParameterList parameters)
        //{
        //    return state.OnEnter(parameters);
        //}

        //public virtual RuleResult OnExit(ParameterList parameters)
        //{
        //    return state.OnExit(parameters);
        //}

        //public virtual RuleResult Rollback()
        //{
        //    ParameterList parameters = new ParameterList();
        //    if (parameters == null)
        //        parameters = new ParameterList();
        //    else
        //        parameters.Clear();

        //    //parameters.Add(new RuleParameter("Current State", this, typeof(TransactionState), ParameterDirection.IN));

        //    return state.Rollback(parameters);
        //}

    }
}

