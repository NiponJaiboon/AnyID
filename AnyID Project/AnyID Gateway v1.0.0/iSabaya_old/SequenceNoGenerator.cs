using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using System.Data.SqlClient;
using System.Configuration;
//using imSabaya;

namespace iSabaya
{
    [Serializable]
    public class SequenceNoGenerator
    {
        private static List<SequenceNoGenerator> instances;
        private static List<SequenceNoGenerator> Instances
        {
            get
            {
                if (instances == null) instances = new List<SequenceNoGenerator>();
                return instances;
            }
        }

        public static SequenceNoGenerator GetInstance(int systemID, int type, long subtype)
        {
            return GetInstance(systemID, type, subtype, 1, 1);
        }

        public static SequenceNoGenerator GetInstance(int systemID, int type, long subtype, long seed, long increment)
        {
            SequenceNoGenerator newGenerator = new SequenceNoGenerator(systemID, type, subtype, seed, increment);
            return newGenerator;
        }

        public int SystemID { get; protected set; }

        public int SequenceType { get; protected set; }

        public long SubsequenceType { get; protected set; }

        private long seed;
        public long Seed
        {
            get { return seed; }
        }

        private long increment;
        public long Increment
        {
            get { return increment; }
            //set { increment = value; }
        }

        private SequenceNoGenerator(int systemID, int sequenceType, long subsequenceType)
        {
            this.SystemID = systemID;
            this.SequenceType = sequenceType;
            this.SubsequenceType = subsequenceType;
            this.seed = 1;
            this.increment = 1;
        }

        private SequenceNoGenerator(int systemID, int sequenceType, long subsequenceType, long seed, long increment)
        {
            this.SystemID = systemID;
            this.SequenceType = sequenceType;
            this.SubsequenceType = subsequenceType;
            this.seed = seed;
            this.increment = increment;
        }

        private System.Data.IDbCommand resetCommand;
        public void ResetSequenceNumber(Context context)
        {

            if (resetCommand == null)
            {
                //String connectionString = ConfigurationSettings.AppSettings["strConnectionString"].ToString();
                //SqlConnection adoCon = new SqlConnection(connectionString);
                System.Data.IDbConnection adoCon = context.PersistenceSession.Connection;
                resetCommand = adoCon.CreateCommand();
                resetCommand.CommandText = "exec dbo.usp_ResetSequenceNo "
                                                + SystemID.ToString() + ","
                                                + SequenceType.ToString() + ","
                                                + SubsequenceType.ToString() + ";";
            }
            resetCommand.ExecuteNonQuery(); 
        }

        private System.Data.IDbCommand genSeqNoCommand;
        public long GenSquenceNumber(Context context)
        {
            if (context.PersistenceSession.Connection.State != ConnectionState.Open)
                context.PersistenceSession.Connection.Open();

            if (context.PersistenceSession.Connection.State != ConnectionState.Open)
                throw new Exception("Can't open connection using the given session.");

            System.Data.IDbConnection adoCon = context.PersistenceSession.Connection;

            genSeqNoCommand = adoCon.CreateCommand();
            genSeqNoCommand.CommandText = "declare @seqNo bigint; exec dbo.usp_GenSequenceNo "
                                                + context.MySystem.SystemID.ToString() + ","
                                                + SequenceType.ToString() + ","
                                                + SubsequenceType.ToString() + ", "
                                                + seed.ToString() + ", "
                                                + increment.ToString()
                                                + ",@seqNo output; select @seqNo";

            if (context.PersistenceSession.Transaction.IsActive)
                context.PersistenceSession.Transaction.Enlist(genSeqNoCommand);

            if (genSeqNoCommand.Connection.State != ConnectionState.Open)
                genSeqNoCommand.Connection.Open();
            return (long)genSeqNoCommand.ExecuteScalar();
        }
    }
}
