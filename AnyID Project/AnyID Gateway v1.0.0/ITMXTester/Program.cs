using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyIDModel;
using iSabaya;
using NHibernate;
using log4net;
using ITMXConnector;

namespace ITMXTester
{
    class Program
    {
        static Context SessionContext;

        static void Main(string[] args)
        {
            Initialize();
            SessionContext.Log.Info("starts");
            if (args.Length == 0 || args[0] == "r")
                Register(SessionContext);
            else if (args[0] == "a")
                Amend(SessionContext);
            else if (args[0] == "i")
                Inquire(SessionContext);
            else if (args[0] == "d")
                Deactivate(SessionContext);
            SessionContext.Log.Info("finishes");
        }

        private static void Amend(Context context)
        {
            var proxies = context.PersistenceSession
                            .QueryOver<AccountProxy>()
                            .Where(t => t.RegistrationID != null)
                            .List();
            try
            {
                var registra = new Itmx();
                string registrationID = null;
                foreach (var t in proxies)
                {
                    context.Log.Info("amending " + t.ID + ", " + t.AnyID.ToString());
                    var response = AnyIDModel.Configuration.ProxyRegistra.Amend(context.Log, t, out registrationID);
                    if (registrationID == null)
                        context.Log.Error("amending failed " + t.RegistrationID + ", " + response);
                    else
                        context.Log.Info("amended " + t.ID + ", " + t.AnyID.ToString());
                }
            }
            catch (Exception exc)
            {
                context.Log.Fatal("fatal error", exc);
            }
        }

        private static void Inquire(Context context)
        {
            var proxies = context.PersistenceSession
                            .QueryOver<AccountProxy>()
                            .Where(t => t.RegistrationID != null)
                            .List();
            try
            {
                var registra = new Itmx();
                AccountProxy proxy;
                IList<AccountProxy> proxyList;
                foreach (var t in proxies)
                {
                    context.Log.Info("inquiring " + t.RegistrationID);
                    var response = AnyIDModel.Configuration.ProxyRegistra.Inquire(context.Log, t.RegistrationID, out proxy);
                    if (proxy == null)
                        context.Log.Error("cannot find " + t.RegistrationID + ", " + response);
                    else
                        context.Log.Info("found registrationID " + t.RegistrationID + " = " + proxy.ToString());

                    context.Log.Info("inquiring " + t.AnyID.ToString());
                    response = AnyIDModel.Configuration.ProxyRegistra.Inquire(context.Log, t.AnyID, out proxyList);
                    if (proxyList == null || proxyList.Count == 0)
                        context.Log.Error("cannot find " + t.AnyID.ToString() + ", " + response);
                    else
                    {
                        context.Log.Info("found anyID " + t.AnyID.ToString() + " recieves " + proxyList.Count + " proxies");
                        int i = 0;
                        foreach (var p in proxyList)
                        {
                            context.Log.Info(++i + ") " + p.ToString());
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                context.Log.Fatal("fatal error", exc);
            }
        }

        private static void Deactivate(Context context)
        {
            var transactions = context.PersistenceSession
                            .QueryOver<AccountProxy>()
                            .Where(t => t.RegistrationID != null)
                            .List();
            try
            {
                var registra = new Itmx();
                string registrationID = null;
                foreach (var t in transactions)
                {
                    context.Log.Info("deactivating " + t.ID + ", " + t.AnyID.IDNo);
                    var response = AnyIDModel.Configuration.ProxyRegistra.Deactivate(context.Log, registrationID);
                    if (string.IsNullOrEmpty(registrationID))
                        context.Log.Error("deactivation failed " + t.RegistrationID + ", " + response);
                    else
                    {
                        t.Status = EntityStatus.Inactive;
                        t.AnyID.Status = AnyIDStatus.Unsubscribed;
                        t.Persist(SessionContext);
                    }
                }
                SessionContext.PersistenceSession.Flush();
            }
            catch (Exception exc)
            {
                context.Log.Fatal("fatal error", exc);
            }
        }

        private static void Register(Context context)
        {
            var transactions = context.PersistenceSession
                            .QueryOver<RegisterTransaction>()
                            .List();
            try
            {
                var registra = new Itmx();
                string registrationID = null;
                foreach (var t in transactions)
                {
                    context.Log.Info("register " + t.ID + ", " + t.AccountProxy.AnyID.IDNo);
                    var code = AnyIDModel.Configuration.ProxyRegistra.Register(context.Log, t.AccountProxy, out registrationID);
                    if (!string.IsNullOrEmpty(registrationID))
                    {
                        context.Log.Error("registration success " + t.ID + ", " + registrationID);
                        t.RegistrationID = t.AccountProxy.RegistrationID = registrationID;
                        t.AccountProxy.RegisteredTS = DateTime.Now;
                        t.AccountProxy.Status = EntityStatus.Active;
                        t.AccountProxy.AnyID.Status = AnyIDStatus.Subscribed;
                        t.Persist(SessionContext);
                    }
                    else
                        context.Log.Error("registration failed " + t.ID + ", " + t.AccountProxy.AnyID.IDNo);
                }
                SessionContext.PersistenceSession.Flush();
            }
            catch (Exception exc)
            {
                context.Log.Fatal("fatal error", exc);
            }
        }

        static void Initialize()
        {
            AnyIDModel.Configuration.ProxyRegistraCreator = () => new Itmx();
            iSabaya.Configuration.MySystem = new iSystem(1, "Test AnyID Gateway");
            iSabaya.Configuration.SessionFactoryCreator = SessionFactoryCreator;
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
            SessionContext = new Context(1, DateTime.Now);
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
    }
}
