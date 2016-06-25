using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyIDModel;
using iSabaya;
using NHibernate;
using System.IO;

namespace ResponseImporter
{
    class Program
    {
        static string SuccessResponseFileNamePattern = @"CRMPP_*.02";
        static string ErrorResponseFileNamePattern = @"CRMPP_*.03";
        static string BadResponseFileNamePattern = @"CRMPP_*.04";
        static string ResponseFolder = @"C:\Users\supoj\Documents\Projects\Kiatnakin\Tests\Responses";
        static string ArchiveFolder = @"C:\Users\supoj\Documents\Projects\Kiatnakin\Tests\Archive";

        static void Main(string[] args)
        {
            var thisApp = new iSystem(91, "Response Importer");
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

            var exp = new ResponseImporter();

            //Import success responses
            string responseFolder = GetArgumentFolderOrDefault(sessionContext, args, 0, ResponseFolder);
            string archiveFolder = GetArgumentFolderOrDefault(sessionContext, args, 1, ArchiveFolder);
#if DEBUG
            Console.WriteLine("Response Folder " + responseFolder);
            Console.WriteLine("Archive Folder " + archiveFolder);
#endif
            sessionContext.Log.Info("start importing response files in folder " + responseFolder);
            ImportResponseFiles(sessionContext, exp.ImportSuccessResponses, responseFolder, archiveFolder, SuccessResponseFileNamePattern);
            ImportResponseFiles(sessionContext, exp.ImportErrorResponses, responseFolder, archiveFolder, ErrorResponseFileNamePattern);
            ImportResponseFiles(sessionContext, exp.ImportErrorResponses, responseFolder, archiveFolder, BadResponseFileNamePattern);
            sessionContext.Log.Info("finish importing response files in folder " + responseFolder);
        }

        private static void ImportResponseFiles(Context sessionContext, Func<Context, string, int> importer, string responseFolder, string archiveFolder, string filePattern)
        {
            var files = Directory.EnumerateFiles(responseFolder, filePattern);
            var fileCount = 0;
            var totalTransactions = 0;
            foreach (var filePath in files)
            {
                string fileName = filePath.Substring(responseFolder.Length + 1);
                sessionContext.Log.Info("start importing " + fileName);
                ++fileCount;
                int transactionCount = importer(sessionContext, filePath);
                if (transactionCount >= 0)
                {
                    totalTransactions += transactionCount;
#if !DEBUG
                    Directory.Move(filePath, Path.Combine(archiveFolder, fileName));
#endif
                    sessionContext.Log.Info("move " + filePath + " to " + Path.Combine(archiveFolder, fileName));
                    sessionContext.Log.Info("finish importing " + transactionCount + " transactions in " + fileName);
                }
            }
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
