using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using iSabaya;
using log4net;

namespace TestAnyIDModel
{
    [Serializable]
    public class TestSessionContext : Context
    {
        public TestSessionContext(long userID, DateTime loginTS)
            : base(userID, loginTS)
        {
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
