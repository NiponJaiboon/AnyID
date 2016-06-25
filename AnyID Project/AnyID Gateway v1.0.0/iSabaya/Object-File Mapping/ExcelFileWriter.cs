using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace iSabaya
{
    public class ExcelFileWriter : IFileWriter
    {
        public ExcelFileWriter(string filePath)
        {
            this.ExportFilePath = filePath;
        }

        public virtual string ExportFilePath { get; set; }

        private Worksheet currentWorksheet;
        public virtual Worksheet RecordBuffer
        {
            get
            {
                if (null == this.currentWorksheet)
                {
                    this.currentWorksheet = (Worksheet)this.ExportDestination.ActiveSheet;
                    if (null == this.currentWorksheet)
                        throw new iSabayaException(String.Format("Can't get active sheet of '{0}'" + this.ExportFilePath));
                }
                return this.currentWorksheet;
            }
            set { this.currentWorksheet = value; }
        }

        private Workbook exportDestination;
        public virtual Workbook ExportDestination
        {
            get
            {
                if (String.IsNullOrEmpty(this.ExportFilePath))
                    throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

                if (null == this.exportDestination)
                {
                    try
                    {
                        Application excel = new Application();
                        Workbook wb = excel.Workbooks.Open(this.ExportFilePath, 3, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                            Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                        this.exportDestination = wb;
                    }
                    catch (Exception exc)
                    {
                        throw new iSabayaException(Messages.CantReadFile(this.ExportFilePath), exc);
                    }
                }
                return this.exportDestination;
            }

            protected set { this.exportDestination = value; }
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
            return this.RecordBuffer;
        }

        //private bool notUndo = true;

        public void UndoReadLine()
        {
            //this.notUndo = false;
        }

        public void Close()
        {
            this.exportDestination.Close(false, Missing.Value, Missing.Value);
        }

        #endregion


        #region IFileWriter Members

        /// <summary>
        /// Base is 0.  Default is 0.
        /// </summary>
        public virtual int CurrentRowNo { get; set; }

        public virtual int CurrentColNo { get; set; }
        public virtual void ClearLineBuffer()
        {
        }

        public virtual void Append(object value)
        {
            this.RecordBuffer.Cells[this.CurrentRowNo, this.CurrentColNo].Value2 = value;
            ++this.CurrentColNo;
        }

        public virtual object WriteLine()
        {
            ++this.CurrentRowNo;
            return null;
        }

        #endregion
    }
}
