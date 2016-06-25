using iSabaya;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyIDAdmin.Models
{
    public class SessionContext : Context
    {
        public SessionContext(iSystem system)
            : base(system)
        {

        }

        //public SessionContext(iSystem iSystem, ISessionFactory sessionFactory)
        //    : this(iSystem)
        //{
        //}
    }
}