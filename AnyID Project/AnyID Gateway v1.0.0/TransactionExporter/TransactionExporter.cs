using System;
using System.Text;
using System.IO;
using AnyIDModel;
using iSabaya;
using System.Globalization;
using NHibernate;

namespace TransactionExporter
{
    class TransactionExporter
    {
        public void Export(Context context, string folderName,  string fileName)
        {
#if DEBUG
            var transactions = ProxyTransaction.GetAllTransactions(context);
#else
            var transactions = ProxyTransaction.GetOfflineTransactions(context);
#endif
            var filePath = Path.Combine(folderName, fileName);
            int transactionCount = transactions.Count;
            if (transactionCount == 0)
            {
                context.Log.Info("no transactions to export.");
            }
            else
            {
                context.Log.Info("start exporting " + transactionCount + " transactions to " + filePath);
                ITransaction atomicTransaction = null;
                StreamWriter outputStream = null;
                try
                {
                    File.Delete(filePath);
                    var outputFile = File.OpenWrite(filePath);
                    outputStream = new StreamWriter(outputFile, new UTF8Encoding());
                    outputStream.NewLine = "\n";
                }
                catch (Exception exc)
                {
                    if (atomicTransaction != null && atomicTransaction.IsActive)
                        atomicTransaction.Rollback();
                    context.Log.Info("error while trying to create " + filePath, exc);
                }

                try
                {
                    //Write header
                    outputStream.WriteLine(@"""KKB"",""" + fileName + @"""," + transactionCount);
                    //Write transactions
                    using (atomicTransaction = context.PersistenceSession.BeginTransaction())
                    {
                        foreach (var t in transactions)
                        {
                            outputStream.WriteLine(Format(t));
#if !DEBUG
                            t.Transit(context, null, null, ProxyTransactionTransitionEvent.Exported);
                            t.Persist(context);
#endif
                        }
                        outputStream.Close();
                        context.Log.Info("finish exporting " + transactionCount + " transactions to " + filePath);
                        atomicTransaction.Commit();
                    }
                }
                catch (Exception exc)
                {
                    if (atomicTransaction != null && atomicTransaction.IsActive)
                        atomicTransaction.Rollback();
                    context.Log.Info("error while trying to export to " + filePath, exc);
                }
            }
        }

        private string Format(ProxyTransaction t)
        {
            var r = t as RegisterTransaction;
            if (r != null)
                return r.Format();

            var d = t as DeactivateTransaction;
            if (d != null)
                return d.Format();

            var a = t as AmendTransaction;
            return a.Format();
        }
    }
}
