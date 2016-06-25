using iSabaya;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
//using Microsoft.AspNet.SignalR;
//using Owin;

namespace AnyIDAdmin
{

    public class MvcApplication : HttpApplication
    {
        public static ISessionFactory SessionFactory { get; set; }
        public static iSystem MySystem;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AuthConfig.RegisterAuth();
            InitializeFramework();
        }

        public ISessionFactory SessionFactoryCreator()
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

        private void InitializeFramework() //(ISession session)
        {
            //MvcApplication.MySystem = new iSystem(int.Parse(WebConfigurationManager.AppSettings["SystemID"].ToString()), "ANYID Web");
            //MvcApplication.MySystem.Initialize(session);
            Configuration.MySystem = MySystem = new iSystem(1, "AnyID Gateway Management System");
            Configuration.SessionFactoryCreator = SessionFactoryCreator;
            AnyIDModel.Configuration.CustomerRepositoryCreator = () => new KiatnakinServices.CustomerServices();
            AnyIDModel.Configuration.AuthenticationServiceCreator = () => new KiatnakinServices.AuthenticationService();
            AnyIDModel.Configuration.ProxyRegistraCreator = () => new ITMXConnector.Itmx();
            //AnyIDModel.Configuration.ProxyRegistraCreator = () => new ProxyRegistraAdapter.Adapter();
            try
            {
                log4net.Config.XmlConfigurator.Configure();
            }
            catch (Exception exc)
            {
                throw new Exception("Can't configure log4net.", exc);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (this.Server.GetLastError().HResult == -2147467259)
            {
                this.Server.ClearError();
                this.Server.Transfer("~/errormaxfilesize.html");
            }

            //if (IsMaxRequestExceededException(this.Server.GetLastError()))
            //{
            //    this.Server.ClearError();
            //    this.Server..Transfer("~/Base/OutOfFileUploadFile2MB");
            //}
        }

        //const int TimedOutExceptionCode = -2147467259;
        //public static bool IsMaxRequestExceededException(Exception e)
        //{
        //    // unhandled errors = caught at global.ascx level
        //    // http exception = caught at page level

        //    Exception main;
        //    var unhandled = e as HttpUnhandledException;

        //    if (unhandled != null) // && unhandled.ErrorCode == TimedOutExceptionCode)
        //    {
        //        main = unhandled.InnerException;
        //    }
        //    else
        //    {
        //        main = e;
        //    }


        //    var http = main as HttpException;

        //    if (http != null)// && http.ErrorCode == TimedOutExceptionCode)
        //    {
        //        // hack: no real method of identifying if the error is max request exceeded as 
        //        // it is treated as a timeout exception
        //        if (http.StackTrace.Contains("GetEntireRawContent"))
        //        {
        //            // MAX REQUEST HAS BEEN EXCEEDED
        //            return true;
        //        }
        //    }

        //    return false;
        //}


        protected void Session_Start()
        {
            
        }

        protected void Session_End()
        {
            Session.Clear();
            Session.Abandon();
        }
    }
}