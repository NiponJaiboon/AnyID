using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    [Serializable]
    public abstract class StatefulEntityType : IComparable<StatefulEntityType>
    {
        public StatefulEntityType()
        {
        }

        public StatefulEntityType(int applicationID, User user, String code, TimeInterval effectivePeriod, 
                                    MultilingualString title)
        {
            this.applicationID = applicationID;
            this.code = code;
            if (effectivePeriod == null)
                this.effectivePeriod = new TimeInterval();
            else
                this.effectivePeriod = effectivePeriod;
            this.title = title;
            this.updatedBy = user;
            this.updatedTS = DateTime.Now;
        }

        public StatefulEntityType(int applicationID, User user, String code, TimeInterval effectivePeriod,
                                    MultilingualString title, MultilingualString shortTitle, MultilingualString description,
                                    Rule creationRule, Rule validationRule, Rule rollbackRule)
        {
            this.applicationID = applicationID;
            this.code = code;
            this.description = description;
            if (effectivePeriod == null)
                this.effectivePeriod = new TimeInterval();
            else
                this.effectivePeriod = effectivePeriod;
            this.shortTitle = shortTitle;
            this.title = title;
            this.creationRule = creationRule;
            this.validationRule = validationRule;
            this.rollbackRule = rollbackRule;
            this.updatedBy = user;
            this.updatedTS = DateTime.Now;
        }

        #region persistent

        protected int statefulEntityTypeID;
        public virtual int StatefulEntityTypeID
        {
            get { return statefulEntityTypeID; }
            set { statefulEntityTypeID = value; }
        }

        private int applicationID;
        public virtual int SystemID
        {
            get { return applicationID; }
            set { applicationID = value; }
        }

        protected String code;
        public virtual String Code
        {
            get { return code; }
            set { code = value; }
        }

        protected Rule creationRule;
        public virtual Rule CreationRule
        {
            get { return creationRule; }
            set { creationRule = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        protected MultilingualString description;
        public virtual MultilingualString Description
        {
            get { return description; }
            set { description = value; }
        }

        protected Rule rollbackRule;
        public virtual Rule RollbackRule
        {
            get { return rollbackRule; }
            set { rollbackRule = value; }
        }

        protected MultilingualString shortTitle;
        public virtual MultilingualString ShortTitle
        {
            get { return shortTitle; }
            set { shortTitle = value; }
        }

        protected int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        private IList<State> states;
        public virtual IList<State> States
        {
            get
            {
                if (states == null) states = new List<State>();
                return states;
            }
            set { states = value; }
        }

        protected MultilingualString title;
        public virtual MultilingualString Title
        {
            get { return title; }
            set { title = value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
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

        protected Rule validationRule;
        public virtual Rule ValidationRule
        {
            get { return validationRule; }
            set { validationRule = value; }
        }

        #endregion persistent

        public virtual State GetInitialState()
        {
            foreach (State s in states)
            {
                if (s.IsInitialState) return s;
            }
            throw new iSabayaException("There is no initial state");
        }

        public virtual State GetState(int stateCategory)
        {
            int category = (int)stateCategory;
            foreach (State s in states)
            {
                if (s.Category == category) return s;
            }
            throw new iSabayaException(String.Format("The transaction type {0} has no '{1}' state ", this.Code, stateCategory));
        }

        public virtual State GetState(String stateCode)
        {
            foreach (State s in states)
            {
                if (s.Code == stateCode) return s;
            }
            throw new iSabayaException("There is no state " + stateCode);
        }

        public static StatefulEntityType FindByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<StatefulEntityType>()
                                    .Add(Expression.Eq("Code", code));
            StatefulEntityType tt = crit.UniqueResult<StatefulEntityType>();
            if (null == tt)
                throw new iSabayaException("There is no transaction type '" + code + "'.");
            return tt;
        }

        public virtual void Persist(Context context)
        {
            this.updatedTS = DateTime.Now;
            if (creationRule != null) creationRule.Persist(context);
            if (validationRule != null) validationRule.Persist(context);
            if (rollbackRule != null) rollbackRule.Persist(context);
            if (title != null) title.Persist(context);
            if (shortTitle != null) shortTitle.Persist(context);
            if (description != null) description.Persist(context);
            //if (this.statefulEntityTypeID == 0)
            //    context.Persist(this);
            //else
            //    context.PersistenceSession.Update(this);
            foreach (State s in states)
            {
                s.Persist(context);
            }
            foreach (State s in states)
                foreach (StateTransition transition in s.Transitions)
                    transition.Persist(context);
        }

        public virtual void Update(Context context)
        {
            if (title != null) title.Persist(context);
            if (shortTitle != null) shortTitle.Persist(context);
            if (description != null) description.Persist(context);
            foreach (State s in states)
            {
                s.Persist(context);
            }

            //context.PersistenceSession.Update(this);
        }

        public virtual State FindStateByCode(String stateCode)
        {
            State output = null;
            foreach (State s in this.States)
            {
                if (s.Code.Equals(stateCode))
                {
                    output = s;
                    break;
                }
            }
            return output;
        }

        public virtual StateTransition FindStateTransition(Context context, String fromStateCode, String toStateCode)
        {
            State from = null;
            foreach (State s in States)
            {
                if (s.Code.Equals(fromStateCode))
                {
                    from = s;
                }
            }
            State to = null;
            foreach (State s in States)
            {
                if (s.Code.Equals(toStateCode))
                {
                    to = s;
                }
            }

            AbstractCriterion fromExp = null == from ? Expression.IsNull("FromState") 
                                                        : Expression.Eq("FromState", from);
            AbstractCriterion toExp = null == to ? Expression.IsNull("ToState")
                                                        : Expression.Eq("ToState", to);

            return context.PersistenceSession.CreateCriteria<StateTransition>()
                            .Add(fromExp).Add(toExp).UniqueResult<StateTransition>();
        }

        public virtual IList<StateTransition> GetStateTransitions(Context context)
        {

            ICriteria crit = context.PersistenceSession.CreateCriteria<State>();
            crit.Add(Expression.Eq("Owner", this));
            IList<State> list = crit.List<State>();

            IList<StateTransition> transitions = new List<StateTransition>();
            foreach (State s in list)
            {
                foreach (StateTransition st in s.Transitions)
                {
                    if (!transitions.Contains(st))
                    {
                        transitions.Add(st);
                    }
                }
            }
            return transitions;
        }

        public override String ToString()
        {
            return this.Title.ToString();
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj)) 
                return true;
            return this.statefulEntityTypeID == ((StatefulEntityType)obj).statefulEntityTypeID;
        }

        public override int GetHashCode()
        {
            return this.statefulEntityTypeID;
        }

        public static bool operator !=(StatefulEntityType a, StatefulEntityType b)
        {
            return !(a == b);
        }

        public static bool operator ==(StatefulEntityType a, StatefulEntityType b)
        {
            if (Object.ReferenceEquals(null, a) && Object.ReferenceEquals(null, b)) return true;
            if (Object.ReferenceEquals(null, a) || Object.ReferenceEquals(null, b)) return false;
            return (a.statefulEntityTypeID == b.statefulEntityTypeID);
        }

        #region IComparable<StatefulEntityType> Members

        public virtual int CompareTo(StatefulEntityType obj)
        {
            if (Object.ReferenceEquals(null, obj))
                return 1;
            if (this.statefulEntityTypeID > obj.statefulEntityTypeID)
                return 1;
            if (this.statefulEntityTypeID < obj.statefulEntityTypeID)
                return -1;
            return 0;
        }

        #endregion

        public virtual RuleResult Create(Context context, ParameterList parameters,
                                            out StatefulEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

