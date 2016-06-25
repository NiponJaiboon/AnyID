using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
//using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace iSabaya
{
    public class ExcelRecordGroup<T, H, D, F> : ObjectRecordGroupMapping<T, H, D, F>
        where T : class, new()
        where H : class, new()
        where D : class, new()
        where F : class, new()
    {
        #region persistent

        public virtual new ExcelSimpleRecord<H> HeaderFormat
        {
            get { return (ExcelSimpleRecord<H>)base.HeaderFormat; }
            set { base.HeaderFormat = value; }
        }

        public virtual new ObjectRecordMapping<D> DetailFormat
        {
            get { return (ObjectRecordMapping<D>)base.DetailFormat; }
            set { base.DetailFormat = value; }
        }

        public virtual new ExcelSimpleRecord<F> FooterFormat
        {
            get { return (ExcelSimpleRecord<F>)base.FooterFormat; }
            set { base.FooterFormat = value; }
        }

        //public new virtual ExcelFileFormat<T> Owner
        //{
        //    get { return (ExcelFileFormat<T>)base.Owner; }
        //    set { base.Owner = value; }
        //}

        #endregion persistent

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

        /// <summary>
        /// Format values in the valueStore as text and put them into the data line
        /// </summary>
        /// <param name="values">The number of elements of valueStore must not be greater than the number of fields.</param>
        /// <param name="dataLine">The text line containing parent values as text.</param>
        public virtual void FormatValues(ArrayList valueStore, ref StringBuilder dataLine)
        {
            //Debug.Assert(this.Fields.Count() >= valueStore.Count,
            //            "The number of elements in valueStore is greater than the number of fields.");
            //if (0 == LineLength) CalculateLineLenth();
            //if (null == dataLine) dataLine = new StringBuilder { Length = this.LineLength };

            ////Clear dataLine
            //for (int i = 0; i < this.LineLength; ++i)
            //{
            //    dataLine[i] = ' ';
            //}

            //int n = 0;
            //foreach (ExcelField f in this.Fields)
            //{
            //    if (null != f)
            //        f.Value = valueStore[n++];
            //    f.Fill(dataLine);
            //}
        }

        protected override void InitializeRecordOutput(IFileWriter exportDestination)
        {
            //++this.Owner.CurrentRowNo;
        }

        protected override void FinalizeRecordOutput(IFileWriter exportDestination)
        {
        }

        public override T Import(Context context, IFileReader fileReader)
        {
            ExcelFileReader excelFileReader = (ExcelFileReader)fileReader;
            T instance = new T();
            if (null == DetailFormat)
                throw new iSabayaException(Messages.DetailRecordFormatNotDefined);

            //read and process the first line
            if (null != HeaderFormat)
            {
                this.SetHeaderInstance(instance, this.HeaderFormat.Import(context, excelFileReader));
            }

            D detail = DetailFormat.Import(context, fileReader);
            this.SetDetailInstance(instance, this.DetailFormat.Import(context, excelFileReader));


            //if (null == this.FooterFormat)
            //    this.SetFooterInstance(instance, this.FooterFormat.Import(context, excelFileReader));

            //Worksheet worksheet = excelFileReader.RecordBuffer();
            
            ////read and process subsequent records
            //excelFileReader.CurrentRowNo = this.Owner.LineNoOfFirstDetailRecord;
            //Range endRow = worksheet.get_Range("A1", Missing.Value).get_End(XlDirection.xlDown);
            //int endRowNo = endRow.Row;
            //if (null == this.FooterFormat)
            //{
            //    for (excelFileReader.CurrentRowNo = this.Owner.LineNoOfFirstDetailRecord; excelFileReader.CurrentRowNo <= endRowNo; ++excelFileReader.CurrentRowNo)
            //        this.SetDetailInstance(instance, this.DetailFormat.Import(context, excelFileReader));
            //}
            //else
            //{
            //    for (excelFileReader.CurrentRowNo = this.Owner.LineNoOfFirstDetailRecord; excelFileReader.CurrentRowNo < endRowNo; ++excelFileReader.CurrentRowNo)
            //        SetDetailInstance(instance, this.DetailFormat.Import(context, excelFileReader));
            //    this.SetFooterInstance(instance, this.FooterFormat.Import(context, excelFileReader));
            //}

            return instance;
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

        public override void Export(Context context, IFileWriter writer, T recordInstance)
        {
            throw new NotImplementedException();
        }
    }
}