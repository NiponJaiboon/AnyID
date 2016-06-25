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
        private static string ExportFolder = @"C:\Users\supoj\Documents\Projects\Kiatnakin\Tests\Export";

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
            string folder = GetArgumentFolderOrDefault(sessionContext, args, 0, ExportFolder);
            sessionContext.Log.Info("export to " + folder);

            var exp = new TransactionExporter();
            exp.Export(sessionContext, folder, GenFileName());

            sessionContext.Log.Info("finishes.");
        }

        private static string GetArgumentFolderOrDefault(Context sessionContext, string[] args, int argNo, string defaultFolder)
        {
            string folder = null;
            if (args.Length > argNo)
            {
                folder = args[argNo];
                if (string.IsNullOrEmpty(folder))
                {
                    folder = defaultFolder;
                    sessionContext.Log.Info("folder in command argument is empty.");
                }
                else if (!Directory.Exists(folder))
                {
                    folder = defaultFolder;
                    sessionContext.Log.Info("folder in command argument does not exist - " + folder);
                }
            }
            else
                folder = defaultFolder;
            return folder;
        }

        private static string GenFileName()
        {
            return "MPP_001_KKB_" + DateTime.Today.ToString("yyMMdd");
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
