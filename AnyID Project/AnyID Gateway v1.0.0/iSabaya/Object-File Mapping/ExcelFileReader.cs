using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace iSabaya
{
    public class ExcelFileReader : IFileReader
    {
        public ExcelFileReader(string filePath)
        {
            this.ImportFilePath = filePath;
        }

        public virtual string ImportFilePath { get; set; }

        /// <summary>
        /// Base is 0.  Default is 0.
        /// </summary>
        public virtual int CurrentRowNo { get; set; }

        private Worksheet recordBuffer;
        public virtual Worksheet RecordBuffer
        {
            get
            {
                if (null == this.recordBuffer)
                {
                    this.recordBuffer = (Worksheet)this.ImportSource.ActiveSheet;
                    if (null == this.recordBuffer)
                        throw new iSabayaException(String.Format("Can't get active sheet of '{0}'" + this.ImportFilePath));
                }
                return this.recordBuffer;
            }
            set { this.recordBuffer = value; }
        }

        private Workbook importSource;
        public virtual Workbook ImportSource
        {
            get
            {
                if (String.IsNullOrEmpty(this.ImportFilePath))
                    throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

                if (null == this.importSource)
                {
                    try
                    {
                        Application excel = new Application();
                        Workbook wb = excel.Workbooks.Open(this.ImportFilePath, 3, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                            Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                        this.importSource = wb;
                    }
                    catch (Exception exc)
                    {
                        throw new iSabayaException(Messages.CantReadFile(this.ImportFilePath), exc);
                    }
                }
                return this.importSource;
            }

            protected set { this.importSource = value; }
        }

        //private StreamReader recordSource { get; set; }
        //public virtual new StreamReader RecordSource
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(this.InputFilePath))
        //            throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

        //        if (null == this.recordSource)
        //        {
        //            try
        //            {
        //                StreamReader reader = new StreamReader(this.InputFilePath);
        //                this.recordSource = reader;
        //            }
        //            catch (Exception exc)
        //            {
        //                throw new iSabayaException(Messages.CantReadFile(this.InputFilePath), exc);
        //            }
        //        }
        //        return (StreamReader)this.recordSource;
        //    }

        //    protected set { this.recordSource = value; }
        //}

        #region IFileReader Members

        public object ReadLine()
        {
            //if (this.notUndo)
            //{
            //    this.notUndo = true;
                //if (null == this.RecordBuffer)
                //    this.RecordBuffer = (Worksheet)this.RecordSource.ActiveSheet;
                //if (null == this.RecordBuffer)
                //    throw new iSabayaException(String.Format("Can't get active sheet of '{0}'" + this.InputFilePath));
            //}
            ++this.CurrentRowNo;
            return this.RecordBuffer;
        }

        public void UndoReadLine()
        {
            --this.CurrentRowNo;
        }

        public void Close()
        {
            this.importSource.Close(false, Missing.Value, Missing.Value);
        }

        #endregion

    }
}
