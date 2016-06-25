using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSabaya;
using AnyIDModel;
using NHibernate;
using System.IO;

namespace TransactionExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var thisApp = new iSystem(90, "Transaction Exporter");
            iSabaya.Configuration.MySystem = thisApp;
            iSabaya.Configuration.SessionFactoryCreator = SessionFactoryCreator;
            try
            {
                log4net.Config.XmlConfigurator.Configure();
            }
            catch (Exception exc)
            {
                throw new Exception("Can't configure log4net.", exc);
            }
            var sessionContext = new Context();
            sessionContext.Log.Info("starts.");

            var exp = new TransactionExporter();
            exp.Export(sessionContext, GenFilePath());

            sessionContext.Log.Info("finishes.");
        }

        private static string ExportFolder = @"C:\Users\supoj\Documents\Projects\Kiatnakin\Tests\Export";

        private static string GenFilePath()
        {
            return Path.Combine(ExportFolder, "MPP_001_KKB_" + DateTime.Today.ToString("yyMMdd"));
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
