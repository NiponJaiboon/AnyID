using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public delegate object RecordReader();

    public abstract class ObjectRecordMapping<T> where T : class, new()
    {
        #region persistent

        /// <summary>
        /// Auto-generated Primary Key
        /// </summary>
        public virtual int RecordFormatID { get; protected set; }
        //public virtual FileFormat<T> Owner { get; set; }
        public virtual String Name { get; set; }

        //private FieldFormat<T>[] fields;
        //public virtual FieldFormat<T>[] Fields
        //{
        //    get
        //    {
        //        return this.fields;
        //    }
        //    set
        //    {
        //        if (null != value)
        //        {
        //            foreach (FieldFormat<T> f in value)
        //            {
        //                f.Owner = this;
        //            }
        //        }
        //        this.fields = value;
        //    }
        //}

        #endregion persistent

        public virtual bool Failed { get; set; }
        public virtual Object RecordBuilder { get; set; }
        //public abstract void BuildDescription(StringBuilder descriptionBuilder);

        //private StringBuilder sb = new StringBuilder();

        //public virtual String ErrorMessage
        //{
        //    get
        //    {
        //        if (null == sb)
        //            return "";
        //        else
        //            return sb.ToString();
        //    }
        //    set
        //    {
        //        if (null == sb)
        //            sb = new StringBuilder(value);
        //        else
        //        {
        //            sb.AppendLine();
        //            sb.Append(value);
        //        }
        //        this.Failed = true;
        //    }
        //}

        public virtual RecordExtractionFinalizer<T> FinalizeExtraction { get; set; }
        public abstract T Import(Context context, IFileReader fileReader);
        //public abstract T Extract(Context context, Object source);
        /// <summary>
        /// Will be called before each record is output
        /// </summary>
        protected abstract void InitializeRecordOutput(IFileWriter exportDestination);
        /// <summary>
        /// Will be called after each record is output
        /// </summary>
        protected abstract void FinalizeRecordOutput(IFileWriter exportDestination);

        public abstract void Export(Context context, IFileWriter exportDestination, T recordInstance);

        public virtual void Export(Context context, IFileWriter writer, IList<T> records)
        {
            foreach (T r in records)
            {
                if (null != r)
                    Export(context, writer, r);
            }
        }

        public virtual void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }

        public static DateTime ConvertToDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            int diff = year - DateTime.Now.Year;

            if (diff > 300)
                return new DateTime(year - 543, month, day, hour, minute, second);
            else if (diff < -300)
                return new DateTime(year + 543, month, day, hour, minute, second);
            else
                return new DateTime(year, month, day, hour, minute, second);
        }
    }
}