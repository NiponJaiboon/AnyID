using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using NHibernate;
using iSabaya;

namespace TestAnyIDModel
{
    public abstract class TestBase
    {
        public static iSystem TestSystem;// = new iSystem(1); //create a dummy system for testing

        public static readonly TestSessionContext SessionContext;
        //public static Language th;//TH
        //public static Language en;//EN
        //public static readonly int BizPortalAdminSystemID = 41;
        //public static readonly int BizPortalClientSystemID = 42;

        static TestBase()
        {
            TestSystem = new iSystem(1, "Test AnyID Gateway");
            Configuration.MySystem = TestSystem;
            Configuration.SessionFactoryCreator = SessionFactoryCreator;
            //AnyIDModel.Configuration.ProxyRegistraCreator = () => new ITMXConnector.ProxyRegistra();
            //AnyIDModel.Configuration.CustomerRepositoryCreator = () => new KiatnakinServices.CustomerServices();
            //AnyIDModel.Configuration.AuthenticationServiceCreator = () => new KiatnakinServices.AuthenticationService();
            try
            {
                log4net.Config.XmlConfigurator.Configure();
            }
            catch (Exception exc)
            {
                throw new Exception("Can't configure log4net.", exc);
            }
            SessionContext = new TestSessionContext(1, DateTime.Now);
        }

        public static ISessionFactory SessionFactoryCreator()
        {
            try
            {
                NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
                hibernateConfig.AddAssembly("iSabaya.ORM");
                hibernateConfig.AddAssembly("AnyIDModel.ORM");
                return hibernateConfig.BuildSessionFactory();
            }
            catch (Exception exc)
            {
                throw new Exception("Can't build NHibernate SessionFactory.", exc);
            }
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

        protected int errorCount;
        protected StringBuilder errorMessages;

        protected virtual T Get<T>(object id) where T : class
        {
            try
            {
                T e = SessionContext.PersistenceSession.Get<T>(id);
                return e;
            }
            catch (Exception exc)
            {
                ++errorCount;
                if (errorMessages == null)
                {
                    errorMessages = new StringBuilder();
                }
                errorMessages.AppendLine(typeof(T).Name);
                errorMessages.AppendLine(exc.ToString());
                return (T)null;
            }
        }
    }
}