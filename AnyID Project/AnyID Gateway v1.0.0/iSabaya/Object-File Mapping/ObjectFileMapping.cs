using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Reflection;
using System.Text;

namespace iSabaya
{
    public delegate bool RecordConsumer<T>(Context context, T recordObject) where T : class, new();
    public delegate void RecordExtractionFinalizer<T>(Context context, T recordObject) where T : class, new();

    public abstract class ObjectFileMapping<T> where T : class, new()
    {
        #region abstract

        public abstract IList<T> Import(Context context, String filePath);
        public abstract void FinalizeOutput(IFileWriter writer);
        public abstract IFileWriter InitializeOutput(Context context, String filePath);

        #endregion abstract

        #region persistent

        /// <summary>
        /// Auto-generated Primary Key
        /// </summary>
        public virtual int FileFormatID { get; protected set; }

        public virtual String Code { get; set; }
        public virtual String Description { get; set; }
        public virtual String Name { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }
        public virtual String FileNamePattern { get; set; }
        public virtual String FileNameExtension { get; set; }

        protected ObjectRecordMapping<T> recordMapping;
        public virtual ObjectRecordMapping<T> RecordMapping
        {
            get { return this.recordMapping; }
            set { this.recordMapping = value; }
        }

        //protected RecordFormat<T> headerRecordFormat;
        //public virtual RecordFormat<T> HeaderRecordFormat
        //{
        //    get { return this.headerRecordFormat; }
        //    set
        //    {
        //        if (null != value)
        //            value.Owner = this;
        //        this.headerRecordFormat = value;
        //    }
        //}

        //protected RecordFormat<T> groupHeaderFormat;
        //public virtual RecordFormat<T> GroupHeaderFormat
        //{
        //    get { return this.groupHeaderFormat; }
        //    set
        //    {
        //        if (null != value)
        //            value.Owner = this;
        //        this.groupHeaderFormat = value;
        //    }
        //}

        //protected RecordFormat<T> detailRecordFormat;
        //public virtual RecordFormat<T> DetailRecordFormat
        //{
        //    get { return this.detailRecordFormat; }
        //    set
        //    {
        //        if (null != value)
        //            value.Owner = this;
        //        this.detailRecordFormat = value;
        //    }
        //}

        //protected RecordFormat<T> footerRecordFormat;
        //public virtual RecordFormat<T> FooterRecordFormat
        //{
        //    get { return this.footerRecordFormat; }
        //    set
        //    {
        //        if (null != value)
        //            value.Owner = this;
        //        this.footerRecordFormat = value;
        //    }
        //}

        public virtual int LineNoOfFirstDetailRecord { get; set; }
        public virtual System.Text.Encoding Encoding { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual DateTime CreatedTS { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual DateTime UpdatedTS { get; set; }
        public virtual String Version { get; set; }

        #endregion persistent

        /// <summary>
        /// Base is 0.  Default is 0.
        /// </summary>
        public virtual int CurrentRowNo { get; set; }

        public virtual bool HasBeenInitialized { get; set; }
        //public virtual IFileReader ImportSource { get; protected set; }

        //protected String inputFilePath;
        //public virtual String ImportFilePath
        //{
        //    get { return this.inputFilePath; }
        //    set
        //    {
        //        if (String.IsNullOrEmpty(value))
        //            throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);
        //        this.ImportSource = null;
        //        this.inputFilePath = value;
        //    }
        //}

        //protected String outputFilePath;
        //public virtual String ExportFilePath
        //{
        //    get { return this.outputFilePath; }
        //    set
        //    {
        //        if (String.IsNullOrEmpty(value))
        //            throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);
        //        this.ExportDestination = null;
        //        this.outputFilePath = value;
        //    }
        //}

        public virtual void Export(Context context, String filePath, T instance)
        {
            IFileWriter exportDestination = InitializeOutput(context, filePath);
            this.RecordMapping.Export(context, exportDestination, instance);
            FinalizeOutput(exportDestination);
        }

        public virtual void Export(Context context, String filePath, IList<T> instances)
        {
            IFileWriter exportDestination = InitializeOutput(context, filePath);
            this.RecordMapping.Export(context, exportDestination, instances);
            FinalizeOutput(exportDestination);
        }

        protected User user;
        protected void SetFileAuthor(string filePath)
        {
            //if (null != this.user)
            //{
            //    DSOFile.OleDocumentProperties fileProperties = new DSOFile.OleDocumentProperties();
            //    fileProperties.Open(filePath, false, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
            //    fileProperties.SummaryProperties.Author = this.user.ToString();
            //    fileProperties.Save();
            //}
        }

        public virtual void Persist(Context context)
        {
            if (null != this.RecordMapping)
                this.RecordMapping.Persist(context);
            if (null == this.EffectivePeriod)
                this.EffectivePeriod = new TimeInterval(DateTime.Now);
            if (DateTime.MinValue == this.CreatedTS)
                this.CreatedTS = DateTime.Now;
            if (DateTime.MinValue == this.UpdatedTS)
                this.UpdatedTS = DateTime.Now;

            context.PersistenceSession.SaveOrUpdate(this);
        }
    }
}
