using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class ObjectTextFileMapping<T> : ObjectFileMapping<T> where T : class, new()
    {
        public ObjectTextFileMapping()
            : base()
        {
            base.FileNamePattern = "*.txt";
            base.FileNameExtension = ".txt";
        }

        /// <summary>
        /// For file of variable length records only
        /// </summary>
        public virtual char FieldDelimiterChar { get; set; }

        //public override IFileReader ImportSource
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(base.ImportFilePath))
        //            throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

        //        if (null == base.ImportSource)
        //        {
        //            try
        //            {
        //                TextFileReader reader = new TextFileReader(base.ImportFilePath);
        //                base.ImportSource = reader;
        //            }
        //            catch (Exception exc)
        //            {
        //                throw new iSabayaException(Messages.CantReadFile(this.ImportFilePath), exc);
        //            }
        //        }
        //        return (TextFileReader)base.ImportSource;
        //    }

        //    protected set { base.ImportSource = value; }
        //}

        //public override IFileWriter ExportDestination
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(base.ExportFilePath))
        //            throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

        //        if (null == base.ExportDestination)
        //        {
        //            base.ExportDestination = new TextFileWriter(base.ExportFilePath);
        //        }
        //        return base.ExportDestination;
        //    }

        //    protected set { base.ExportDestination = value; }
        //}

        public virtual String RecordBuffer { get; set; }
        public virtual StringBuilder RecordBuilder { get; set; }

        #region abstract implementation

        public override IList<T> Import(Context context, String filePath)
        {
            TextFileReader reader = new TextFileReader(filePath);
            IList<T> instances = new List<T>();

            while (true)
            {
                try
                {
                    T instance = this.RecordMapping.Import(context, reader);
                    instances.Add(instance);
                }
                catch (Exception exc)
                {
                    if (exc is EndOfStreamException)
                        break;
                    else
                        throw exc;
                }
            }
            return instances;
        }

        //public override IList<T> ExtractRecords(Context context, String filePath)
        //{
        //    IList<T> records = new List<T>();

        //    //Validate consistency of parameters 
        //    if (null == DetailRecordFormat)
        //        throw new iSabayaException(Messages.DetailRecordFormatNotDefined);

        //    this.InputFilePath = filePath;

        //    try
        //    {
        //        //read and process the first line
        //        this.RecordBuffer = this.RecordSource.ReadLine();
        //        if (null == this.RecordBuffer)
        //            return records;

        //        if (null == HeaderRecordFormat)
        //            records.Add(this.DetailRecordFormat.Extract(context, this.RecordBuffer));
        //        else
        //            records.Add(this.HeaderRecordFormat.Extract(context, this.RecordBuffer));

        //        //read and process subsequent records
        //        if (null == this.FooterRecordFormat)
        //            for (int i = 0; null != (this.RecordBuffer = this.RecordSource.ReadLine()); ++i)
        //            {
        //                records.Add(this.DetailRecordFormat.Extract(context, this.RecordBuffer));
        //            }
        //        else
        //            for (int i = 0; null != (this.RecordBuffer = this.RecordSource.ReadLine()); ++i)
        //            {
        //                if (this.RecordSource.Peek() == -1)
        //                {
        //                    //process the footer record (last record)
        //                    records.Add(this.FooterRecordFormat.Extract(context, this.RecordBuffer));
        //                    break;
        //                }
        //                records.Add(this.DetailRecordFormat.Extract(context, this.RecordBuffer));
        //            }

        //        this.RecordSource.Close();
        //    }
        //    catch (Exception exc)
        //    {
        //        if (null != this.RecordSource)
        //            this.RecordSource.Close();
        //        throw exc;
        //    }

        //    return records;
        //}

        //public override void ExtractRecords(Context context, String filePath,
        //                                    RecordConsumer<T> headerRecordConsumer,
        //                                    RecordConsumer<T> detailRecordConsumer,
        //                                    RecordConsumer<T> footerRecordConsumer)
        //{
        //    //Validate consistency of parameters 
        //    if (null == DetailRecordFormat)
        //        throw new iSabayaException(Messages.DetailRecordFormatNotDefined);

        //    this.InputFilePath = filePath;

        //    try
        //    {
        //        //read and process the first line
        //        this.RecordBuffer = this.RecordSource.ReadLine();
        //        if (null == this.RecordBuffer)
        //            return;

        //        T recordObject;
        //        if (null == HeaderRecordFormat)
        //        {
        //            recordObject = this.DetailRecordFormat.Extract(context, this.RecordBuffer);
        //            if (null != detailRecordConsumer)
        //                if (!detailRecordConsumer(context, recordObject))
        //                {
        //                    return;
        //                }
        //        }
        //        else
        //        {
        //            recordObject = this.HeaderRecordFormat.Extract(context, this.RecordBuffer);
        //            if (null != headerRecordConsumer)
        //                if (!headerRecordConsumer(context, recordObject))
        //                {
        //                    this.RecordSource.Close();
        //                    return;
        //                }
        //        }

        //        //read and process subsequent records
        //        if (null == this.FooterRecordFormat)
        //            for (int i = 0; null != (this.RecordBuffer = this.RecordSource.ReadLine()); ++i)
        //            {
        //                recordObject = this.DetailRecordFormat.Extract(context, this.RecordBuffer);
        //                if (null != detailRecordConsumer)
        //                    if (!detailRecordConsumer(context, recordObject))
        //                    {
        //                        this.RecordSource.Close();
        //                        return;
        //                    }
        //            }
        //        else
        //            for (int i = 0; null != (this.RecordBuffer = this.RecordSource.ReadLine()); ++i)
        //            {
        //                if (this.RecordSource.Peek() == -1)
        //                {
        //                    //process the footer record (last record)
        //                    recordObject = this.FooterRecordFormat.Extract(context, this.RecordBuffer);
        //                    if (null != footerRecordConsumer)
        //                        if (!footerRecordConsumer(context, recordObject))
        //                        {
        //                            this.RecordSource.Close();
        //                            return;
        //                        }
        //                    break;
        //                }
        //                recordObject = this.DetailRecordFormat.Extract(context, this.RecordBuffer);
        //                if (null != detailRecordConsumer)
        //                    if (!detailRecordConsumer(context, recordObject))
        //                    {
        //                        this.RecordSource.Close();
        //                        return;
        //                    }
        //            }

        //        this.RecordSource.Close();
        //    }
        //    catch (Exception exc)
        //    {
        //        if (null != this.RecordSource)
        //            this.RecordSource.Close();
        //        throw exc;
        //    }

        //}

        public override void FinalizeOutput(IFileWriter writer)
        {
            writer.Close();
            //base.SetFileAuthor(writer.ExportFilePath);
        }

        public override IFileWriter InitializeOutput(Context context, String filePath)
        {
            TextFileWriter writer = new TextFileWriter(filePath, base.Encoding);
            return writer;
        }

        //public override string GetDescription()
        //{
        //    StringBuilder descriptionBuilder = new StringBuilder();
        //    descriptionBuilder.Append(base.Name);
        //    descriptionBuilder.AppendLine(" : Text file format.");
        //    if (null != this.headerRecordFormat)
        //    {
        //        descriptionBuilder.Append("Header record is ");
        //        this.headerRecordFormat.BuildDescription(descriptionBuilder);
        //    }
        //    if (null != this.detailRecordFormat)
        //    {
        //        descriptionBuilder.Append("Data record is ");
        //        this.detailRecordFormat.BuildDescription(descriptionBuilder);
        //    }
        //    if (null != this.footerRecordFormat)
        //    {
        //        descriptionBuilder.Append("Footer record is ");
        //        this.footerRecordFormat.BuildDescription(descriptionBuilder);
        //    }
        //    return descriptionBuilder.ToString();
        //}

        #endregion abstract implementation
    }
}