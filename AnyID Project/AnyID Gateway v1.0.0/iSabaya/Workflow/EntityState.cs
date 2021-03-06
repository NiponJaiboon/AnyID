using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public abstract class EntityState
    {
        public EntityState()
        {
        }

        public EntityState(State state, User user)
        {
            this.owner = null;
            this.state = state;
            this.reference = null;
            this.remark = null;
            this.systemMessage = null;
            this.enteredTS = this.updatedTS = DateTime.Now;
            this.updatedBy = user;
        }

        public EntityState(StatefulEntity owner, State state, String reference, String remark, 
                            String systemMessage, User user)
        {
            this.owner = owner;
            this.state = state;
            this.reference = reference;
            this.remark = remark;
            if (null != systemMessage) this.systemMessage = systemMessage;
            this.enteredTS = this.updatedTS = DateTime.Now;
            this.updatedBy = user;
        }

        public EntityState(StatefulEntity owner, State state, String reference, String remark, 
                            DateTime enteredTS, User user)
        {
            this.owner = owner;
            this.state = state;
            this.reference = reference;
            this.remark = remark;
            this.systemMessage = "";
            this.enteredTS = enteredTS;
            this.updatedTS = DateTime.Now;
            this.updatedBy = user;
        }

        #region persistent

        private Int64 entityStateID;
        public virtual Int64 EntityStateID
        {
            get { return entityStateID; }
            set { entityStateID = value; }
        }

        private DateTime enteredTS;
        public virtual DateTime EnteredTS
        {
            get { return enteredTS; }
            set { enteredTS = value; }
        }

        protected StatefulEntity owner;
        public virtual StatefulEntity Owner
        {
            get { return owner; }
            set { owner = value; }
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

        protected State state;
        public virtual State State
        {
            get { return state; }
            set { state = value; }
        }

        //private TransactionStateCategory stateCategory;
        public virtual int StateCategory
        {
            get { return state.Category; }
            set { /*stateCategory = value;*/ }
        }

        protected String systemMessage = null;
        /// <summary>
        /// Get or set system message
        /// </summary>
        public virtual String SystemMessage
        {
            get { return systemMessage; }
            set { systemMessage += " " + value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        protected DateTime updatedTS = TimeInterval.MinDate;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        #endregion persistent

        //protected User user;
        //public virtual User User
        //{
        //    get { return user; }
        //    set { user = value; }
        //}

        public virtual RuleResult OnEnter(ParameterList parameters)
        {
            return state.OnEnter(parameters);
        }

        public virtual RuleResult OnExit(ParameterList parameters)
        {
            return state.OnExit(parameters);
        }

        public virtual RuleResult Rollback()
        {
            ParameterList parameters = new ParameterList();
            if (parameters == null)
                parameters = new ParameterList();
            else
                parameters.Clear();

            //parameters.Add(new RuleParameter("Current State", this, typeof(EntityState), ParameterDirection.IN));

            return state.Rollback(parameters);
        }

        public abstract void Persist(Context context);
    }
}

