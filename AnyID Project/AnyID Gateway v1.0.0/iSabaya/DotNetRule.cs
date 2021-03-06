using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using NHibernate;

namespace iSabaya
{
    [Serializable]
    public class DotNetRule : Rule
    {
        public DotNetRule()
        {
        }

        public DotNetRule(string name, string version, MultilingualString description,
                        string assemblyName, string qualifiedClassName)
            : base(name, version, description)
        {
            this.assemblyName = assemblyName;
            this.qualifiedClassName = qualifiedClassName;
        }

        //public DotNetRule(string code, MultilingualString description, string version,
        //                    string assemblyName, string qualifiedClassName)
        //    : base(code, description, version)
        //{
        //    this.assemblyName = assemblyName;
        //    this.qualifiedClassName = qualifiedClassName;
        //}

        #region persistent

        private String assemblyName;
        public virtual String AssemblyName
        {
            get { return assemblyName; }
            set { this.assemblyName = value; }
        }

        protected string qualifiedClassName;
        public virtual string QualifiedClassName
        {
            get { return qualifiedClassName; }
            set { qualifiedClassName = value; }
        }

        #endregion persistent

        private Assembly ruleAssembly;
        private Assembly RuleAssembly
        {
            get
            {
                if (ruleAssembly == null)
                {
                    try
                    {
                        ruleAssembly = Assembly.LoadFile(assemblyName);
                    }
                    catch (Exception e)
                    {
                        throw new iSabayaException("Please call administrator: Can't load business rule assembly " 
                                            + this.assemblyName, e);
                    }
                }
                return ruleAssembly;
            }
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            if (id == 0)
                context.Persist(this);
            else
                context.PersistenceSession.Update(this);
        }

        public static new DotNetRule Find(Context context, int id)
        {
            return (DotNetRule)context.PersistenceSession.Get(typeof(DotNetRule), id);
        }

        public static new IList<DotNetRule> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(DotNetRule));
            return crit.List<DotNetRule>();
        }

        public override RuleResult Execute(object owner, ParameterList parameters)
        {
            throw new NotImplementedException();
        }
    }
}
