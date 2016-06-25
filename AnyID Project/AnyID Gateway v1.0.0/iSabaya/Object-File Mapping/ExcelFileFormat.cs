using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace iSabaya
{
    public class ExcelFileFormat<T> : ObjectFileMapping<T> where T : class, new()
    {
        public ExcelFileFormat()
        {
            base.FileNamePattern = "*.xls,*.xlsx,*.xlsb";
            base.FileNameExtension = ".xls";
        }

        public virtual new ExcelSimpleRecord<T> RecordMapping
        {
            get { return (ExcelSimpleRecord<T>)base.RecordMapping; }
            set { base.RecordMapping = value; }
        }

        public virtual Worksheet RecordBuffer { get; set; }

        //public override IFileReader ImportSource
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(base.ImportFilePath))
        //            throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

        //        if (null == base.ImportSource)
        //        {
        //                base.ImportSource = new ExcelFileReader(base.ImportFilePath);
        //        }
        //        return base.ImportSource;
        //    }

        //    protected set { base.ImportSource = value; }
        //}

        //public override IFileWriter ExportDestination
        //{
        //    get
        //    {
        //        if (null == base.ExportDestination)
        //        {
        //            if (String.IsNullOrEmpty(base.ExportFilePath))
        //                throw new iSabayaException("The file path is not defined.");
        //            base.ExportDestination = new ExcelFileWriter(base.ExportFilePath);
        //        }
        //        return base.ExportDestination;
        //    }

        //    protected set { base.ExportDestination = value; }
        //}

        #region abstract implementation

        public override IList<T> Import(Context context, String filePath)
        {
            IList<T> records = new List<T>();

            if (null == this.RecordMapping)
                throw new iSabayaException(Messages.DetailRecordFormatNotDefined);

            ExcelFileReader excelFileReader = new ExcelFileReader(filePath);

            //read and process the first line
            excelFileReader.CurrentRowNo = this.LineNoOfFirstDetailRecord;
            this.RecordBuffer = (Worksheet)excelFileReader.ReadLine();
            Range endRow = this.RecordBuffer.get_Range("A1", Missing.Value).get_End(XlDirection.xlDown);
            int endRowNo = endRow.Row;
            for (excelFileReader.CurrentRowNo = this.LineNoOfFirstDetailRecord; excelFileReader.CurrentRowNo <= endRowNo; ++excelFileReader.CurrentRowNo)
                records.Add(this.RecordMapping.Import(context, excelFileReader));

            excelFileReader.Close();
            return records;
        }

        //public override void ExtractRecords(Context context, String filePath,
        //                                    RecordConsumer<T> headerRecordConsumer,
        //                                    RecordConsumer<T> detailRecordConsumer,
        //                                    RecordConsumer<T> footerRecordConsumer)
        //{
        //    if (null == DetailRecordFormat)
        //        throw new iSabayaException(Messages.DetailRecordFormatNotDefined);

        //    //Validate consistency of parameters 
        //    this.InputFilePath = filePath;
        //    this.RecordBuffer = (Worksheet)this.RecordSource.ActiveSheet;
        //    if (null == this.RecordBuffer)
        //        throw new iSabayaException(String.Format("Can't get active sheet of '{0}'" + this.InputFilePath));

        //    T recordObject;

        //    //read and process the first line
        //    if (null != HeaderRecordFormat)
        //    {
        //        recordObject = this.HeaderRecordFormat.Extract(context, this.RecordBuffer);
        //        if (null != headerRecordConsumer)
        //            if (!headerRecordConsumer(context, recordObject)) return;
        //    }

        //    //read and process subsequent records
        //    this.CurrentRowNo = this.LineNoOfFirstDetailRecord;
        //    Range endRow = this.RecordBuffer.get_Range("A1", Missing.Value).get_End(XlDirection.xlDown);
        //    int endRowNo = endRow.Row;

        //    if (null == this.FooterRecordFormat)
        //    {
        //        for (this.CurrentRowNo = this.LineNoOfFirstDetailRecord; this.CurrentRowNo <= endRowNo; ++this.CurrentRowNo)
        //        {
        //            recordObject = this.DetailRecordFormat.Extract(context, this.RecordBuffer);
        //            if (null != detailRecordConsumer)
        //                if (!detailRecordConsumer(context, recordObject)) return;
        //        }
        //    }
        //    else
        //    {
        //        for (this.CurrentRowNo = this.LineNoOfFirstDetailRecord; this.CurrentRowNo < endRowNo; ++this.CurrentRowNo)
        //        {
        //            recordObject = this.DetailRecordFormat.Extract(context, this.RecordBuffer);
        //            if (null != detailRecordConsumer)
        //                if (!detailRecordConsumer(context, recordObject)) return;
        //        }
        //        recordObject = this.FooterRecordFormat.Extract(context, this.RecordBuffer);
        //        if (null != footerRecordConsumer)
        //            if (!footerRecordConsumer(context, recordObject)) return;
        //    }

        //    this.RecordSource.Close(false, Missing.Value, Missing.Value);
        //}

        public override IFileWriter InitializeOutput(Context context, String filePath)
        {
            ExcelFileWriter excelFileWriter = new ExcelFileWriter(filePath);
            this.user = context.User;
            return excelFileWriter;
        }

        public override void FinalizeOutput(IFileWriter writer)
        {
            writer.Close();
            base.SetFileAuthor(writer.ExportFilePath);
        }

        //public override string GetDescription()
        //{
        //    StringBuilder descriptionBuilder = new StringBuilder();
        //    descriptionBuilder.Append(base.Name);
        //    descriptionBuilder.AppendLine(" : Excel file format.");
        //    if (null != this.headerRecordFormat)
        //    {
        //        descriptionBuilder.Append("Header row ");
        //        this.headerRecordFormat.BuildDescription(descriptionBuilder);
        //    }
        //    if (null != this.detailRecordFormat)
        //    {
        //        descriptionBuilder.Append("Data row ");
        //        this.detailRecordFormat.BuildDescription(descriptionBuilder);
        //    }
        //    if (null != this.footerRecordFormat)
        //    {
        //        descriptionBuilder.Append("Footer row ");
        //        this.footerRecordFormat.BuildDescription(descriptionBuilder);
        //    }
        //    return descriptionBuilder.ToString();
        //}

        #endregion abstract implementation
    }
}
