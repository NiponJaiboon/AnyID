using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public abstract class TextSimpleRecord<T> : ObjectSimpleRecordMapping<T> where T : class, new()
    {
        //public virtual new TextFileFormat<T> Owner
        //{
        //    get { return (TextFileFormat<T>)base.Owner; }
        //    set { base.Owner = value; }
        //}

        public virtual new StringBuilder RecordBuilder
        {
            get 
            {
                if (null == base.RecordBuilder)
                {
                    base.RecordBuilder = new StringBuilder();
                }
                return (StringBuilder)base.RecordBuilder; 
            }
            set { base.RecordBuilder = value; }
        }

        //public abstract String RecordFormatType { get; }
        //public abstract String RecordFormatColumnHeader { get; }
        //public abstract T ExtractValues(Context context, String line);

        //public override T Extract(Context context, Object source)
        //{
        //    T record = this.ExtractValues(context, (String)source);
        //    if (null != base.FinalizeExtraction)
        //        base.FinalizeExtraction(context, record);
        //    return record;
        //}

        protected override void FinalizeRecordOutput(IFileWriter exportDestination)
        {
            exportDestination.WriteLine();
        }

        protected override void InitializeRecordOutput(IFileWriter exportDestination)
        {
            this.RecordBuilder.Clear();
        }

        //public override void BuildDescription(StringBuilder descriptionBuilder)
        //{
        //    descriptionBuilder.AppendLine(RecordFormatType);
        //    descriptionBuilder.AppendLine(RecordFormatColumnHeader);
        //    foreach (FieldFormat<T> c in base.Fields)
        //    {
        //        descriptionBuilder.AppendLine(c.ToString());
        //    }
        //}
    }
}
