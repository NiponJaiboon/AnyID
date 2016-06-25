using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class TextFileWriter : IFileWriter
    {
        public TextFileWriter(string filePath, Encoding encoding)
        {
            this.ExportFilePath = filePath;
            this.Encoding = encoding;
        }

        public string ExportFilePath { get; set; }
        public Encoding Encoding { get; set; }

        private StreamWriter exportDestination { get; set; }
        public virtual StreamWriter ExportDestination
        {
            get
            {
                if (String.IsNullOrEmpty(this.ExportFilePath))
                    throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

                if (null == this.exportDestination)
                {
                    try
                    {
                        StreamWriter writer;
                        if (null != this.Encoding)
                            writer = new StreamWriter(this.ExportFilePath, false, this.Encoding);
                        else
                            writer = new StreamWriter(this.ExportFilePath, false, new UTF8Encoding(false));// Encoding.UTF8);
                        this.exportDestination = writer;
                    }
                    catch (Exception exc)
                    {
                        throw new iSabayaException(Messages.CantWriteFile(this.ExportFilePath), exc);
                    }
                }
                return this.exportDestination;
            }

            protected set { this.exportDestination = value; }
        }

        #region IFileWriter Members

        public StringBuilder RecordBuffer = new StringBuilder();

        public void WriteLine(string recordText)
        {
            ExportDestination.WriteLine(recordText);
        }

        public void Close()
        {
            this.ExportDestination.Close();
        }


        #endregion


        #region IFileWriter Members

        public int CurrentRowNo
        {
            get;
            //{
            //    throw new NotImplementedException();
            //}
            set;
            //{
            //    throw new NotImplementedException();
            //}
        }

        #endregion

        #region IFileWriter Members

        public void ClearLineBuffer()
        {
            this.RecordBuffer.Clear();
        }

        public void Append(object value)
        {
            this.RecordBuffer.Append(value);
        }

        public object WriteLine()
        {
            this.ExportDestination.WriteLine(this.RecordBuffer.ToString());
            this.RecordBuffer.Clear();
            return this.RecordBuffer;
        }

        #endregion
    }
}
