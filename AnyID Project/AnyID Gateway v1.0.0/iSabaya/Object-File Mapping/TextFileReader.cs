using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class TextFileReader : IFileReader
    {
        public TextFileReader(string filePath)
        {
            this.ImportFilePath = filePath;
        }

        public string ImportFilePath { get; set; }

        private StreamReader recordSource { get; set; }
        public virtual StreamReader RecordSource
        {
            get
            {
                if (String.IsNullOrEmpty(this.ImportFilePath))
                    throw new iSabayaException(Messages.FileFormatFilePathIsNotDefined);

                if (null == this.recordSource)
                {
                    try
                    {
                        StreamReader reader = new StreamReader(this.ImportFilePath);
                        this.recordSource = reader;
                    }
                    catch (Exception exc)
                    {
                        throw new iSabayaException(Messages.CantReadFile(this.ImportFilePath), exc);
                    }
                }
                return (StreamReader)this.recordSource;
            }

            protected set { this.recordSource = value; }
        }

        #region IFileReader Members

        private string recordBuffer;

        public object ReadLine()
        {
            if (this.notUndo)
            {
                recordBuffer = RecordSource.ReadLine();
                if (null == recordBuffer)
                {
                    // sawangchai add Close(); due to error file being use by another process.
                    Close();
                    throw new EndOfStreamException();
                }
            }
            this.notUndo = true;
            return recordBuffer;
        }

        private bool notUndo = true;

        public void UndoReadLine()
        {
            this.notUndo = false;
        }

        public void Close()
        {
            this.recordSource.Close();
        }


        #endregion

    }
}
