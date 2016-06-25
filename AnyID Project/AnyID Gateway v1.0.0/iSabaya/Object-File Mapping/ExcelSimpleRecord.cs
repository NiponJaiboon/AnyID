using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
//using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace iSabaya
{
    public class ExcelSimpleRecord<T> : ObjectSimpleRecordMapping<T> where T : class, new()
    {
        #region persistent

        public new virtual ExcelField<T>[] Fields
        {
            get { return (ExcelField<T>[])base.Fields; }
            set
            {
                if (null != value)
                {
                    foreach (ExcelField<T> f in value)
                    {
                        f.Owner = this;
                    }
                }
                base.Fields = value;
            }
        }

        //public new virtual ExcelFileFormat<T> Owner
        //{
        //    get { return (ExcelFileFormat<T>)base.Owner; }
        //    set { base.Owner = value; }
        //}

        #endregion persistent

        public virtual int LineLength
        {
            get { return 0; }
        }

        public new virtual Worksheet RecordBuilder
        {
            get { return (Worksheet)base.RecordBuilder; }
            protected set { base.RecordBuilder = value; }
        }

        public virtual bool Success { get; set; }

        //public override T Extract(Context context, Object source)
        //{
        //    Worksheet ws = (Worksheet)source;
        //    T target = new T();

        //    foreach (ExcelField<T> f in this.Fields)
        //    {
        //        if (null != f)
        //        {
        //            Range cell = (Range)ws.Cells[this.Owner.CurrentRowNo, f.ColumnNo];
        //            f.ExtractIntoTarget(target, cell.Value);
        //        }
        //    }
        //    ++this.Owner.CurrentRowNo;

        //    if (null != base.FinalizeExtraction)
        //        base.FinalizeExtraction(context, target);

        //    return target;
        //}

        ///// <summary>
        ///// Format values in the valueStore as text and put them into the data line
        ///// </summary>
        ///// <param name="values">The number of elements of valueStore must not be greater than the number of fields.</param>
        ///// <param name="dataLine">The text line containing parent values as text.</param>
        //public virtual void FormatValues(ArrayList valueStore, ref StringBuilder dataLine)
        //{
        //    //Debug.Assert(this.Fields.Count() >= valueStore.Count,
        //    //            "The number of elements in valueStore is greater than the number of fields.");
        //    //if (0 == LineLength) CalculateLineLenth();
        //    //if (null == dataLine) dataLine = new StringBuilder { Length = this.LineLength };

        //    ////Clear dataLine
        //    //for (int i = 0; i < this.LineLength; ++i)
        //    //{
        //    //    dataLine[i] = ' ';
        //    //}

        //    //int n = 0;
        //    //foreach (ExcelField f in this.Fields)
        //    //{
        //    //    if (null != f)
        //    //        f.Value = valueStore[n++];
        //    //    f.Fill(dataLine);
        //    //}
        //}

        protected override void InitializeRecordOutput(IFileWriter exportDestination)
        {
        }

        protected override void FinalizeRecordOutput(IFileWriter exportDestination)
        {
        }

        //public override void BuildDescription(StringBuilder descriptionBuilder)
        //{
        //    descriptionBuilder.Append("starts at row no. ");
        //    descriptionBuilder.AppendLine((this.Owner.LineNoOfFirstDetailRecord + 1).ToString());
        //    descriptionBuilder.AppendLine("\nCol no.\tData : Type");
        //    foreach (ExcelField<T> c in base.Fields)
        //    {
        //        descriptionBuilder.AppendLine(c.ToString());
        //    }
        //}

        public override T Import(Context context, IFileReader fileReader)
        {
            ExcelFileReader excelFileReader = (ExcelFileReader)fileReader;
            Worksheet ws = (Worksheet)excelFileReader.ReadLine();
            T target = new T();

            foreach (ExcelField<T> f in this.Fields)
            {
                if (null != f)
                {
                    Range cell = (Range)ws.Cells[excelFileReader.CurrentRowNo, f.ColumnNo];
                    f.ExtractIntoTarget(target, cell.Value);
                }
            }
            ++excelFileReader.CurrentRowNo;

            if (null != base.FinalizeExtraction)
                base.FinalizeExtraction(context, target);

            return target;
        }

        public override void Export(Context context, IFileWriter exportDestination, T recordInstance)
        {
            foreach (ExcelField<T> f in this.Fields)
                f.FormatValue(exportDestination, recordInstance);
        }

        //public override void OutputRecord(Context context, IList<T> recordInstances)
        //{
        //    throw new NotImplementedException();
        //}
    }
}