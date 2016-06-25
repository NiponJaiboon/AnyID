using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public abstract class TextFixedLengthField<T> : PropertyFieldMapping<T> where T : class, new()
    {
        #region persistent

        public virtual int SeqNo { get; set; }

        public virtual int Length { get; set; }

        public new virtual TextFixedLengthSimpleRecord<T> Owner
        {
            get { return (TextFixedLengthSimpleRecord<T>)base.Owner; }
            set { base.Owner = value; }
        }

        #endregion persistent

        public virtual void Write(TextFileWriter writer, Object v)
        {
            if (null == v)
                return;

            FillLeftJustified((TextFileWriter)writer, v.ToString());
        }

        protected virtual void Overwrite(TextFileWriter writer, String text)
        {
            if (String.IsNullOrEmpty(text))
                return;

            int i = this.ColumnNo;
            StringBuilder record = writer.RecordBuffer;
            for (int j = 0; j < this.Length; ++i, ++j)
            {
                record[i] = text[j];
            }
        }

        protected virtual void FillRightJustified(TextFileWriter writer, String v, char paddingChar = '0')
        {
            if (String.IsNullOrEmpty(v))
                return;

            if (this.Length > v.Length)
                Overwrite(writer, v.PadLeft(this.Length, paddingChar));
            else
                Overwrite(writer, v.Substring(0, this.Length));
        }

        protected virtual void FillLeftJustified(TextFileWriter writer, String v)
        {
            if (String.IsNullOrEmpty(v))
                return;

            if (this.Length > v.Length)
                Overwrite(writer, v.PadRight(this.Length));
            else
                Overwrite(writer, v.Substring(0, this.Length));
        }

        protected const String descriptionTemplate = "C{0} L{1} {2} : {3}";
        public override string ToString()
        {
            return String.Format(descriptionTemplate, base.ColumnNo, this.Length,
                                    base.Name, this.GetTypeName());
        }


        #region Field Classes

        /// Money with two digits after decimal point
        public class Decimal : TextFixedLengthField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    if (String.IsNullOrEmpty(fieldValue))
                        return 0m;
                    else
                        return decimal.Parse(fieldValue);
                }
                catch (Exception e)
                {
                    throw new iSabayaException(Messages.DecimalFieldConvertFailed(fieldValue), e);
                }
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    this.SetTargetValue(this, target, 0m);
                else
                    this.SetTargetValue(this, target, this.Convert(line.Substring(this.ColumnNo, this.Length)));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T instance)
            {
                if (null != instance && base.HasValueGetter())
                    FillRightJustified((TextFileWriter)writer, ((decimal)base.GetTargetValue(instance)).ToString());
                else if (null != base.Value)
                    FillRightJustified((TextFileWriter)writer, ((decimal)base.Value).ToString());
            }

            public override string GetTypeName()
            {
                return "money";
            }
        }

        public class Decimal_x_100 : TextFixedLengthField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    return decimal.Parse(fieldValue) / 100m;
                }
                catch (Exception e)
                {
                    throw new iSabayaException(Messages.Decimal_x_100FieldConvertFailed(fieldValue), e);
                }
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;

                if (base.ColumnNo + base.Length > line.Length)
                    this.SetTargetValue(this, target, 0m);
                else
                    this.SetTargetValue(this, target, this.Convert(line.Substring(base.ColumnNo, base.Length)));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T instance)
            {
                if (null != instance && base.HasValueGetter())
                    FillRightJustified((TextFileWriter)writer, ((Int64)((decimal)base.GetTargetValue(instance) * 100)).ToString());
                else if (null != base.Value)
                    FillRightJustified((TextFileWriter)writer, ((Int64)(((decimal)base.Value) * 100)).ToString());
            }

            public override string GetTypeName()
            {
                return "money x 100";
            }
        }

        public class Double : TextFixedLengthField<T>
        {
            public int DigitsAfterDecimalPoint = 0;

            public override Object Convert(String fieldValue)
            {
                try
                {
                    if (String.IsNullOrEmpty(fieldValue))
                        return 0m;
                    else
                        return double.Parse(fieldValue);
                }
                catch (Exception e)
                {
                    throw new iSabayaException(Messages.DecimalFieldConvertFailed(fieldValue), e);
                }
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    this.SetTargetValue(this, target, 0m);
                else
                    this.SetTargetValue(this, target, this.Convert(line.Substring(this.ColumnNo, this.Length)));
                return true;
            }

            private String format = null;
            public override void FormatValue(IFileWriter writer, T instance)
            {
                double v = 0d;
                if (null != instance && base.HasValueGetter())
                    v = (double)base.GetTargetValue(instance);
                else if (null != base.Value)
                    v = (double)base.Value;
                else
                    return;

                if (null == this.format)
                    this.format = "{0:F" + this.DigitsAfterDecimalPoint.ToString() + "}";
                FillRightJustified((TextFileWriter)writer, String.Format(this.format, v));
            }

            public override string GetTypeName()
            {
                return String.Format("floating point number ({0},{1})", base.Length, this.DigitsAfterDecimalPoint);
            }
        }

        public abstract class GregorianDate : TextFixedLengthField<T>
        {
            public abstract String DataFormat { get; }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    throw new iSabayaException(Messages.DataLineIsTooShort(line.Length, this.ColumnNo + this.Length));
                this.SetTargetValue(this, target, this.Convert(line.Substring(this.ColumnNo, this.Length)));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                DateTime d;
                if (null != record && base.HasValueGetter())
                    d = (DateTime)base.GetTargetValue(record);
                else if (null != base.Value)
                    d = (DateTime)base.Value;
                else
                    return;

                Overwrite((TextFileWriter)writer, d.ToString(DataFormat, CultureInfo.InvariantCulture));
            }

            public override string GetTypeName()
            {
                return "Christian date " + DataFormat;
            }

            public new virtual DateTime Value
            {

                get
                {
                    if (null == base.Value)
                        base.Value = TimeInterval.MinDate;
                    return (DateTime)base.Value;
                }
                set
                {
                    base.Value = value;
                }
            }
        }

        public class GregorianDate_DDMMYY : GregorianDate
        {
            public override String DataFormat
            {
                get { return "ddMMyy"; }
            }

            public override Object Convert(String text)
            {
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                try
                {
                    int day = int.Parse(text.Substring(0, 2));
                    int month = int.Parse(text.Substring(2, 2));
                    int year = int.Parse(text.Substring(4, 2));
                    if (year > 50)
                        year += 1900;
                    else
                        year += 2000;
                    return new DateTime(year, month, day, CultureInfo.InvariantCulture.Calendar);
                }
                catch (Exception exc)
                {
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat), exc);
                }
            }
        }

        public class GregorianDate_DDMMYYYY : GregorianDate
        {
            public override String DataFormat
            {
                get { return "ddMMyyyy"; }
            }

            public override Object Convert(String text)
            {
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                try
                {
                    int day = int.Parse(text.Substring(0, 2));
                    int month = int.Parse(text.Substring(2, 2));
                    int year = int.Parse(text.Substring(4, 4));
                    return new DateTime(year, month, day, CultureInfo.InvariantCulture.Calendar);
                }
                catch (Exception exc)
                {
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat), exc);
                }
            }
        }

        public class GregorianDate_YYMMDD : GregorianDate
        {
            public override String DataFormat
            {
                get { return "yyMMdd"; }
            }

            public override Object Convert(String text)
            {
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                try
                {
                    int day = int.Parse(text.Substring(4, 2));
                    int month = int.Parse(text.Substring(2, 2));
                    int year = int.Parse(text.Substring(0, 2));
                    if (year > 50)
                        year += 1900;
                    else
                        year += 2000;
                    return new DateTime(year, month, day, CultureInfo.InvariantCulture.Calendar);
                }
                catch (Exception exc)
                {
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat), exc);
                }
            }
        }

        public class GregorianDate_YYYYMMDD : GregorianDate
        {
            public override String DataFormat
            {
                get { return "yyyyMMdd"; }
            }

            public override Object Convert(String text)
            {
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                try
                {
                    int day = int.Parse(text.Substring(6, 2));
                    int month = int.Parse(text.Substring(4, 2));
                    int year = int.Parse(text.Substring(0, 4));
                    return new DateTime(year, month, day, CultureInfo.InvariantCulture.Calendar);
                }
                catch (Exception exc)
                {
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat), exc);
                }
            }
        }

        public class Integer : TextFixedLengthField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    return int.Parse(fieldValue);
                }
                catch (Exception e)
                {
                    throw new iSabayaException(Messages.IntegerFieldConvertFailed(fieldValue), e);
                }
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    this.SetTargetValue(this, target, 0);
                else
                    this.SetTargetValue(this, target, this.Convert(line.Substring(this.ColumnNo, this.Length).Trim()));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T instance)
            {
                if (base.HasValueGetter())
                    FillRightJustified((TextFileWriter)writer, ((int)base.GetTargetValue(instance)).ToString());
                else if (null != base.Value)
                    FillRightJustified((TextFileWriter)writer, ((int)base.Value).ToString());
            }

            public override string GetTypeName()
            {
                return "integer";
            }
        }

        public class Long : TextFixedLengthField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    return long.Parse(fieldValue);
                }
                catch (Exception e)
                {
                    throw new iSabayaException(Messages.LongFieldConvertFailed(fieldValue), e);
                }
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    this.SetTargetValue(this, target, 0L);
                else
                    this.SetTargetValue(this, target, this.Convert(line.Substring(this.ColumnNo, this.Length).Trim()));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T instance)
            {
                if (base.HasValueGetter())
                    FillRightJustified((TextFileWriter)writer, ((long)base.GetTargetValue(instance)).ToString());
                else if (null != base.Value)
                    FillRightJustified((TextFileWriter)writer, ((long)base.Value).ToString());
            }

            public override string GetTypeName()
            {
                return "long";
            }
        }

        public class Filler : TextFixedLengthField<T>
        {
            public virtual char FillerChar { get; set; }

            /// <summary>
            /// Mandatory.  Must be >= 1
            /// </summary>
            public override int Length { get; set; }

            public override Object Convert(String fieldValue)
            {
                //if (this.LiteralValue != fieldValue)
                //    throw new iSabayaException(Messages.LiteralFieldConvertFailed(this.LiteralValue, fieldValue.ToString()));
                return fieldValue;
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;

                String line = (String)source;
                return (this.ColumnNo + this.Length <= line.Length);
            }

            private string fillerString;
            public override void FormatValue(IFileWriter writer, T record)
            {
                if (null == fillerString)
                    fillerString = new string(this.FillerChar, this.Length);
                FillLeftJustified((TextFileWriter)writer, fillerString);
            }

            public override string GetTypeName()
            {
                return "Filler(\'" + this.FillerChar + "\'," + this.Length + ")";
            }
        }

        public class Literal : TextFixedLengthField<T>
        {
            public virtual String LiteralValue { get; set; }

            public override int Length
            {
                get { return LiteralValue.Length; }
                set { }
            }

            public override Object Convert(String fieldValue)
            {
                if (this.LiteralValue != fieldValue)
                    throw new iSabayaException(Messages.LiteralFieldConvertFailed(this.LiteralValue, fieldValue.ToString()));
                return fieldValue;
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source)
                    return false;

                String line = (String)source;
                if (this.ColumnNo + this.Length <= line.Length)
                    if ((String)this.LiteralValue == line.Substring(ColumnNo, Length))
                    {
                        if (base.HasValueSetter())
                            this.SetTargetValue(this, target, this.LiteralValue);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                throw new iSabayaException(String.Format("Literal parent at column {0} differs from the given '{1}'.",
                                                    this.ColumnNo + 1, this.LiteralValue));
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                String literal = this.LiteralValue;
                if (null != literal)
                    FillLeftJustified((TextFileWriter)writer, literal);
            }

            public override string GetTypeName()
            {
                return "\"" + this.LiteralValue + "\"";
            }
        }

        public class Text : TextFixedLengthField<T>
        {
            public override Object Convert(String fieldValue)
            {
                return fieldValue.Trim();
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    this.SetTargetValue(this, target, "");
                else
                    this.SetTargetValue(this, target, line.Substring(this.ColumnNo, this.Length).Trim());
                return true;
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                if (null != record && base.HasValueGetter())
                    FillLeftJustified((TextFileWriter)writer, (String)base.GetTargetValue(record));
                else if (null != base.Value)
                    FillLeftJustified((TextFileWriter)writer, (String)base.Value);
            }

            public override string GetTypeName()
            {
                return "variable length text";
            }
        }

        public class TextFixedLength : TextFixedLengthField<T>
        {
            public override Object Convert(String fieldValue)
            {
                return (fieldValue);
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    this.SetTargetValue(this, target, "");
                else
                    this.SetTargetValue(this, target, line.Substring(this.ColumnNo, this.Length));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                if (null != record && base.HasValueGetter())
                    FillLeftJustified((TextFileWriter)writer, (String)base.GetTargetValue(record));
                else if (null != base.Value)
                    FillLeftJustified((TextFileWriter)writer, (String)base.Value);
            }

            public override string GetTypeName()
            {
                return "fixed length text";
            }
        }

        public abstract class ThaiDate : TextFixedLengthField<T>
        {
            public abstract String DataFormat { get; }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    throw new iSabayaException(Messages.DataLineIsTooShort(line.Length, this.ColumnNo + this.Length));
                this.SetTargetValue(this, target, this.Convert(line.Substring(this.ColumnNo, this.Length)));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                DateTime d;
                if (null != record && base.HasValueGetter())
                    d = (DateTime)base.GetTargetValue(record);
                else if (null != base.Value)
                    d = (DateTime)base.Value;
                else
                    return;

                Overwrite((TextFileWriter)writer, d.ToString(DataFormat, Configuration.ThaiCulture));
            }

            public override string GetTypeName()
            {
                return "Thai date " + DataFormat;
            }

            public new virtual DateTime Value
            {

                get
                {
                    if (null == base.Value)
                        base.Value = TimeInterval.MinDate;
                    return (DateTime)base.Value;
                }
                set
                {
                    base.Value = value;
                }
            }
        }

        public class ThaiDate_DDMMYY : ThaiDate
        {
            public override String DataFormat
            {
                get { return "ddMMyy"; }
            }

            public override Object Convert(String text)
            {
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                try
                {
                    int day = int.Parse(text.Substring(0, 2));
                    int month = int.Parse(text.Substring(2, 2));
                    int year = int.Parse(text.Substring(4, 2)) + 2500 - 543;
                    return (new DateTime(year, month, day, Configuration.ThaiCulture.Calendar));
                }
                catch (Exception exc)
                {
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat), exc);
                }
            }
        }

        public class ThaiDate_DDMMYYYY : ThaiDate
        {
            public override String DataFormat
            {
                get { return "ddMMyyyy"; }
            }

            public override Object Convert(String text)
            {
                if (!base.HasValueSetter())
                    return true;
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                try
                {
                    int day = int.Parse(text.Substring(0, 2));
                    int month = int.Parse(text.Substring(2, 2));
                    int year = int.Parse(text.Substring(4, 4));
                    return (new DateTime(year, month, day, Configuration.ThaiCulture.Calendar));
                }
                catch (Exception exc)
                {
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat), exc);
                }
            }
        }

        public class ThaiDate_YYYYMMDD : ThaiDate
        {
            public override String DataFormat
            {
                get { return "yyyyMMdd"; }
            }

            public override Object Convert(String text)
            {
                if (!base.HasValueSetter())
                    return true;
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                try
                {
                    int day = int.Parse(text.Substring(6, 2));
                    int month = int.Parse(text.Substring(4, 2));
                    int year = int.Parse(text.Substring(0, 4));
                    return (new DateTime(year, month, day, Configuration.ThaiCulture.Calendar));
                }
                catch (Exception exc)
                {
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat), exc);
                }
            }
        }

        public class Time_HHMMSS : TextFixedLengthField<T>
        {
            public const String DataFormat = "HHmmss";

            public override Object Convert(String text)
            {
                if (text.Length < DataFormat.Length)
                    throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));

                int hour = int.Parse(text.Substring(0, 2));
                int minute = int.Parse(text.Substring(2, 2));
                int second = int.Parse(text.Substring(4, 2));
                return (new DateTime(2000, 1, 1, hour, minute, second));
            }

            public override bool ExtractIntoTarget(T target, Object source)
            {
                if (null == source || !base.HasValueSetter())
                    return false;
                String line = (String)source;
                if (this.ColumnNo + this.Length > line.Length)
                    throw new iSabayaException(Messages.DataLineIsTooShort(line.Length, this.ColumnNo + this.Length));
                this.SetTargetValue(this, target, this.Convert(line.Substring(this.ColumnNo, this.Length)));
                return true;
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                DateTime d;
                if (null != record && base.HasValueGetter())
                    d = (DateTime)base.GetTargetValue(record);
                else if (null != base.Value)
                    d = (DateTime)base.Value;
                else
                    return;

                Overwrite((TextFileWriter)writer, d.Hour.ToString("D2") + d.Minute.ToString("D2") + d.Second.ToString("D2"));
            }

            public override string GetTypeName()
            {
                return "Time (HHMMSS)";
            }
        }
    }

        #endregion Field Classes
}
