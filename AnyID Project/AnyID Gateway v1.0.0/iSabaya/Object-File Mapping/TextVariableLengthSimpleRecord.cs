using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public class TextVariableLengthSimpleRecord<T> : TextSimpleRecord<T> where T : class, new()
    {
        #region persistent

        public virtual char Delimiter { get; set; }

        /// <summary>
        /// Elements of Fields must be in the same order as the data in a record.
        /// </summary>
        public new virtual TextVariableLengthField<T>[] Fields
        {
            get { return (TextVariableLengthField<T>[])base.Fields; }
            set
            {
                if (null != value)
                {
                    foreach (TextVariableLengthField<T> f in value)
                    {
                        f.Owner = this;
                    }
                }
                base.Fields = value;
            }
        }

        #endregion persistent

        //private String[] fieldDelimiters = null;
        ///// <summary>
        ///// Required.  The first delimiter character will be used to delimit field on formating output
        ///// </summary>
        //public virtual String[] FieldDelimiters
        //{
        //    get { return this.fieldDelimiters; }
        //    set
        //    {
        //        if (null != value && value.Count<String>() > 0)
        //            this.FieldDelimiter = value[0];
        //        this.fieldDelimiters = value;
        //        //if (null != this.Fields)
        //        //    SetFieldDelimiter();
        //    }
        //}

        //private void SetFieldDelimiter()
        //{
        //    if (null != this.FieldDelimiter && null != this.Fields)
        //    {
        //        foreach (TextVariableLengthField<T> f in this.Fields)
        //        {
        //            f.Delimiter = this.FieldDelimiter;
        //        }
        //    }
        //}
        private char[] fieldDelimiters;
        public virtual char[] FieldDelimiters
        {
            get
            {
                if (null == this.fieldDelimiters)
                    this.fieldDelimiters = new char[1];
                this.fieldDelimiters[0] = this.Delimiter;
                return this.fieldDelimiters;
            }
        }

        //public override T ExtractValues(Context context, String line)
        //{
        //    T target = new T();
        //    if (char.MinValue == this.Delimiter)
        //    {
        //        throw new MissingMemberException("Field delimiters are not defined");
        //    }
        //    else
        //    {
        //        String[] values = line.Split(this.FieldDelimiters, StringSplitOptions.None);
        //        for (int i = 0; i < values.Length; ++i)
        //        {
        //            TextVariableLengthField<T> f = (TextVariableLengthField<T>)base.Fields[i];
        //            if (null != f)
        //                f.SetTargetValue(f, target, this.Fields[i].Convert(values[i]));
        //        }
        //    }
        //    return target;
        //}

        //public override String RecordFormatType
        //{
        //    get { return "variable length."; }
        //}

        //public override String RecordFormatColumnHeader
        //{
        //    get { return "Pos no.\tData : Type"; }
        //}

        public override T Import(Context context, IFileReader fileReader)
        {
            string line = (string)fileReader.ReadLine();

            T target = new T();
            if (char.MinValue == this.Delimiter)
            {
                throw new MissingMemberException("Field delimiters are not defined");
            }
            else
            {
                String[] values = line.Split(this.FieldDelimiters, StringSplitOptions.None);
                for (int i = 0; i < values.Length; ++i)
                {
                    TextVariableLengthField<T> f = (TextVariableLengthField<T>)base.Fields[i];
                    if (null != f)
                        f.SetTargetValue(f, target, this.Fields[i].Convert(values[i]));
                }
            }
            return target;
        }

        //public override void OutputRecord(Context context, IList<T> recordInstances)
        //{
        //    throw new NotImplementedException();
        //}
    }
}