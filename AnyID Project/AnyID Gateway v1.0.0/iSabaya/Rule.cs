using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    //public interface IRule
    //{
    //}
    [Serializable]
    public abstract class Rule //: IRule
    {
        public virtual void GetParameterList()
        {

        }

        public virtual void SetParameterValue(string name, object value)
        {

        }

        public virtual void GetRuleName()
        {
        }

        public virtual void GetRuleVersion()
        {
        }

        public Rule()
        {
        }

        public Rule(string name, string version, MultilingualString description)
        {
            this.name = name;
            this.version = version;
            this.description = description;
        }

        #region persistent

        protected int id = 0;
        public virtual int ID
        {
            get { return id; }
            set { id = value; }
        }

        protected string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected MultilingualString description;
        public virtual MultilingualString Description
        {
            get { return description; }
            set { description = value; }
        }

        protected string version;
        public virtual string Version
        {
            get { return version; }
            set { version = value; }
        }

        protected DateTime createdDate = DateTime.Now;
        public virtual DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        protected DateTime modifiedDate = DateTime.Now;
        public virtual DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        protected User modifiedBy;
        public virtual User ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        #endregion persistent

        public virtual void Persist(Context context)
        {
            if (description != null) description.Persist(context);
        }

        public static IList<Rule> Find(Context context, string code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Rule));

            crit.Add(Expression.Eq("Code", code));
            return crit.List<Rule>();
        }

        public static IList<Rule> Find(Context context, string code, string version)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Rule));

            crit.Add(Expression.Eq("Code", code));
            crit.Add(Expression.Eq("Version", version));
            return crit.List<Rule>();
        }

        public abstract RuleResult Execute(object owner, ParameterList parameters);

        public static Rule Find(Context context, int id)
        {
            return (Rule)context.PersistenceSession.Get(typeof(Rule), id);
        }

        public static IList<Rule> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Rule));
            return crit.List<Rule>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
} 
