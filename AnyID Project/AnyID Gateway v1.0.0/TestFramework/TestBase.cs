using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Criterion;
using iSabaya;

namespace TestFramework
{
    public abstract class TestBase
    {
        public static readonly iSystem TestSystem = new iSystem(1); //create a dummy system for testing

        public static readonly TestContext SessionContext;
        //public static Language th;//TH
        //public static Language en;//EN
        public static readonly int BizPortalAdminSystemID = 41;
        public static readonly int BizPortalClientSystemID = 42;

        static TestBase()
        {
            try
            {
                //System.Web.SessionState.HttpSessionState session = null;
                SessionContext = new TestContext(TestSystem);
            }
            catch (Exception exc)
            {
                throw new Exception("Can't create persistence session!", exc);
            }
            //th = Context.Languages[0];//TH
            //en = Context.Languages[1];//EN
        }

        public static void TruncateTable(params string[] tableNames)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string tn in tableNames)
            {
                sb.Append("truncate table ");
                sb.Append(tn);
                sb.Append(";");
            }
            SessionContext.PersistenceSession.CreateSQLQuery(sb.ToString()).ExecuteUpdate();
        }

        public static void RunSQLCommand(string commandString)
        {
            SessionContext.PersistenceSession.CreateSQLQuery(commandString).ExecuteUpdate();
        }

        public static IList<T> GetAll<T>() where T : class
        {
            IList<T> list = null;
            ICriteria crit = SessionContext.PersistenceSession.CreateCriteria<T>();
            list = crit.List<T>();
            //try
            //{
            //    list = crit.List<T>();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    throw e;
            //}
            return list;
        }

        public static void FindEmployeeAndUser(string emailAddressOfEmployee, out User user, out Employee employee)
        {
            user = User.FindCurrentUserWithLoginName(SessionContext, emailAddressOfEmployee);
            if (user == null)
                throw new Exception("Can't find user.");
            employee = user.Person.FindCurrentEmployment(SessionContext);
        }
    }
}