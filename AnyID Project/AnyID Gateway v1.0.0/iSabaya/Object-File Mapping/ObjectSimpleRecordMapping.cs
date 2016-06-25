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
    public abstract class ObjectSimpleRecordMapping<T> : ObjectRecordMapping<T> where T : class, new()
    {
        #region persistent

        private PropertyFieldMapping<T>[] fields;
        public virtual PropertyFieldMapping<T>[] Fields
        {
            get
            {
                return this.fields;
            }
            set
            {
                if (null != value)
                {
                    foreach (PropertyFieldMapping<T> f in value)
                    {
                        f.Owner = this;
                    }
                }
                this.fields = value;
            }
        }

        #endregion persistent

        //public virtual bool Failed { get; set; }
        //public virtual Object RecordBuilder { get; set; }
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

        //public virtual RecordExtractionFinalizer<T> FinalizeExtraction { get; set; }

        //public abstract T Extract(Context context, Object source);
        ///// <summary>
        ///// Will be called before each record is output
        ///// </summary>
        //protected abstract void InitializeRecordOutput();
        ///// <summary>
        ///// Will be called after each record is output
        ///// </summary>
        //protected abstract void FinalizeRecordOutput();

        ///// <summary>
        ///// For record format with literals or fillers only.
        ///// </summary>
        //public virtual void OutputRecord()
        //{
        //    InitializeRecordOutput();
        //    foreach (FieldFormat<T> f in this.Fields)
        //    {
        //        if (null != f)
        //            f.FormatValue(this, null);
        //    }
        //    FinalizeRecordOutput();
        //}

        public override void Export(Context context, IFileWriter writer, T recordInstance)
        {
            InitializeRecordOutput(writer);
            foreach (PropertyFieldMapping<T> f in this.Fields)
            {
                if (null != f)
                    f.FormatValue(writer, recordInstance);
            }
            FinalizeRecordOutput(writer);
        }

        public virtual void FillIfExist(int fieldIndex, IFileWriter writer, T recordInstance)
        {
            PropertyFieldMapping<T> f = this.Fields[fieldIndex];
            if (null != f)
                f.FormatValue(writer, recordInstance);
        }

    }
}