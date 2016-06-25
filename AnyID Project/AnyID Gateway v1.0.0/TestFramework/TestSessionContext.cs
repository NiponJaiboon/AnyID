using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using iSabaya;

namespace TestFramework
{
    [Serializable]
    public class TestContext : Context
    {
        public TestContext(iSystem system)
            : base(system)
        {
            if (null == Configuration.SessionFactory)
            {
                try
                {
                    NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
                    hibernateConfig.AddAssembly("iSabaya.ORM");
                    Configuration.SessionFactory = hibernateConfig.BuildSessionFactory();
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
            try
            {
                this.MySystem.Initialize(this);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        //public TestContext(iSystem system, System.Web.SessionState.HttpSessionState session)
        //    :base(system)
        //{
        //}

        //public override User User
        //{
        //    //get
        //    //{
        //    //    if (null == this.user)
        //    //        this.user = this.PersistenceSession.Get<User>(this.UserID);
        //    //    return this.user;
        //    //}
        //    set
        //    {
        //        if (null == value)
        //            throw new Exception("User is null");
        //        base.User = value;
        //        //this.UserSession = StartNewSession(value);
        //    }
        //}
    }
}
