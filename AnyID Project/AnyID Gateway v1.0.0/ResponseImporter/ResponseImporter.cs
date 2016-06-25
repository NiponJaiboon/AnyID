using System;
using System.Text;
using System.IO;
using AnyIDModel;
using iSabaya;
using System.Globalization;
using System.Collections.Generic;
using NHibernate;

namespace ResponseImporter
{
    class ResponseImporter
    {
        public int ImportSuccessResponses(Context context, string filePath)
        {
            //context.Log.Info("start importing success responses " + filePath);
            ITransaction atomicTransaction = null;
            int transactionCount = 0;
            StreamReader reader = null;
            try
            {
                reader = CreateSteamReader(context, filePath);

                //Read header
                string header = reader.ReadLine();
                transactionCount = GetTransaction(header);
                using (atomicTransaction = context.PersistenceSession.BeginTransaction())
                {
                    while (!reader.EndOfStream)
                    {
                        string record = reader.ReadLine();
#if DEBUG
                        Console.WriteLine("record=" + record);
#endif
                        var tokens = record.Split(Delimiter);
                        ProxyTransaction tran = GetProxyTransaction(context, tokens[0]);
                        tran.RegistrationID = tokens[3].Trim('"');
#if DEBUG
                        Console.WriteLine("Success transaction " + tran.ID + ", registration ID " + tran.RegistrationID);
#else
                        tran.Transit(context, null, tran.RegistrationID.ToString(), ProxyTransactionTransitionEvent.Success);
                        tran.Persist(context);
#endif
                    }
                    atomicTransaction.Commit();
                }
                reader.Close();
                //context.Log.Info("finish importing " + transactionCount + " success responses from " + filePath);
            }
            catch (Exception exc)
            {
                if (reader != null) reader.Close();
                if (atomicTransaction != null && atomicTransaction.IsActive)
                    atomicTransaction.Rollback();
                context.Log.Info("error importing " + filePath, exc);
                transactionCount = -1;
            }
            return transactionCount;
        }

        public static StreamReader CreateSteamReader(Context context, string filePath)
        {
            StreamReader reader = null;
            try
            {
                var inputFile = File.OpenRead(filePath);
                reader = new StreamReader(inputFile, new UTF8Encoding());
            }
            catch (Exception exc)
            {
                context.Log.Info("can't access file " + filePath, exc);
            }

            return reader;
        }

        private static int GetTransaction(string header)
        {
            return int.Parse(header.Substring(header.LastIndexOf(Delimiter) + 1));
        }

        private static char Delimiter = ',';
        private static ProxyTransaction GetProxyTransaction(Context context, string transactionID)
        {
            long id = long.Parse(transactionID);
            var tran = context.PersistenceSession.Get<ProxyTransaction>(id);
            if (tran == null)
                context.Log.Error("Incorrect ");
            if (tran is RegisterTransaction)
            { }
            else if (tran is AmendTransaction)
            { }
            else    //(tran is RegisterTransaction)
            { }
            return tran;
        }

        public int ImportErrorResponses(Context context, string filePath)
        {
            context.Log.Info("start importing error responses " + filePath);
            ITransaction atomicTransaction = null;
            int transactionCount = 0;
            StreamReader reader = CreateSteamReader(context, filePath);

            try
            {
                //Read header
                string header = reader.ReadLine();
                transactionCount = int.Parse(header.Substring(header.LastIndexOf(Delimiter) + 1));
                using (atomicTransaction = context.PersistenceSession.BeginTransaction())
                {
                    while (!reader.EndOfStream)
                    {
                        string record = reader.ReadLine();
                        //int msgStartPosition = record.LastIndexOf(Delimiter) + 2;
                        //int messageLength = record.Length - msgStartPosition - 1;
                        var tokens = record.Split(Delimiter);
                        string errorMessage = tokens[16].Trim('"') + ", " + tokens[17].Trim('"');
                        ProxyTransaction tran = GetProxyTransaction(context, tokens[0]);
#if DEBUG
                        Console.WriteLine(tran.ID + " - " + errorMessage);
#else
                        tran.Transit(context, null, errorMessage, ProxyTransactionTransitionEvent.Fail);
                        tran.Persist(context);
#endif
                    }
                    atomicTransaction.Commit();
                }
                reader.Close();
                context.Log.Info("finish importing " + transactionCount + " error responses from " + filePath);
            }
            catch (Exception exc)
            {
                if (atomicTransaction != null && atomicTransaction.IsActive)
                    atomicTransaction.Rollback();
                context.Log.Info("error importing " + filePath, exc);
            }
            return transactionCount;
        }
    }
}
