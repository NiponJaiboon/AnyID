using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public class TextFixedLengthSimpleRecord<T> : TextSimpleRecord<T> where T : class, new()
    {
        #region persistent

        public new virtual TextFixedLengthField<T>[] Fields
        {
            get
            {
                return (TextFixedLengthField<T>[])base.Fields;
            }
            set
            {
                VerfiyAndSetColumnNo(value);
                base.Fields = value;
            }
        }

        private static void VerfiyAndSetColumnNo(TextFixedLengthField<T>[] value)
        {
            if (null == value || value.Length == 0)
                throw new iSabayaException("The text fixed-length fields are null or empty.");

            int columnNoOfNextField = value[0].ColumnNo + value[0].Length;
            for (int i = 1; i < value.Length; ++i)
            {
                TextFixedLengthField<T> f = value[i];
                if (null == f)
                    throw new iSabayaException("The text fixed-length field no. " + i.ToString() + " is null.");
                if (f.Length <= 0)
                    throw new iSabayaException("The length of text fixed-length field no. " + i.ToString() + " is incorrect.");

                //Set columnNo if not defined
                if (f.ColumnNo == 0)
                {
                    f.ColumnNo = columnNoOfNextField;
                    columnNoOfNextField += f.Length;
                }
                else if (f.ColumnNo >= columnNoOfNextField)
                {
                    columnNoOfNextField = f.ColumnNo + f.Length;
                }
                else
                    throw new iSabayaException("The column no. of text fixed-length field no. " + i.ToString() + " overlaps the preceeding field.");
            }
        }

        #endregion persistent

        public virtual int LineLength
        {
            get { return this.CalculateLineLenth(); }
        }

        //public override T Extract(Context context, Object source)
        //{
        //    T record = this.ExtractValues(context, (String)source);
        //    if (null != base.FinalizeExtraction)
        //        base.FinalizeExtraction(context, record);
        //    return record;
        //}

        //public override T ExtractValues(Context context, String line)
        //{
        //    T target = new T();
        //    foreach (TextFixedLengthField<T> f in base.Fields)
        //    {
        //        if (null != f)
        //            f.ExtractIntoTarget(target, line);
        //    }
        //    return target;
        //}

        private int CalculateLineLenth()
        {
            if (this.Fields.Length == 0)
                return 0;

            TextFixedLengthField<T> lastFieldInTheLine = (TextFixedLengthField<T>)base.Fields[0];
            for (int i = 1; i < this.Fields.Length; ++i)
            {
                if (null != this.Fields[i] && this.Fields[i].ColumnNo > lastFieldInTheLine.ColumnNo)
                    lastFieldInTheLine = (TextFixedLengthField<T>)base.Fields[i];
            }
            return lastFieldInTheLine.ColumnNo + lastFieldInTheLine.Length;
        }

        private String blanks;

        protected override void InitializeRecordOutput(IFileWriter writer)
        {
            if (0 >= this.LineLength)
                throw new iSabayaException("Record length is not a positive number.");
            if (null == this.blanks)
                this.blanks = new String(' ', this.LineLength);
            //this.RecordBuilder.Clear();
            //this.RecordBuilder.Append(this.blanks);
            writer.ClearLineBuffer();
            writer.Append(this.blanks);
        }

        //public override String RecordFormatType
        //{
        //    get { return "fixed length."; }
        //}

        //public override String RecordFormatColumnHeader
        //{
        //    get { return "Col no.\tLen\tData : Type"; }
        //}

        public override T Import(Context context, IFileReader fileReader)
        {
            string line = (string)fileReader.ReadLine();
            if (String.IsNullOrEmpty(line))
                return null;

            T instance = new T();
            foreach (TextFixedLengthField<T> f in base.Fields)
            {
                if (!f.ExtractIntoTarget(instance, line) && f is TextFixedLengthField<T>.Literal)
                {
                    //The literal value in the line does not match the format
                    fileReader.UndoReadLine();
                    return null;
                }
            }
            return instance;
        }

        //public override void OutputRecord(Context context, IList<T> recordInstances)
        //{
        //    throw new NotImplementedException();
        //}
    }
}