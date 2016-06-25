using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public abstract class TextVariableLengthField<T> : PropertyFieldMapping<T> where T : class, new()
    {
        #region persistent

        public new virtual TextVariableLengthSimpleRecord<T> Owner
        {
            get { return (TextVariableLengthSimpleRecord<T>)base.Owner; }
            set { base.Owner = value; }
        }
        
        #endregion persistent

        private char Delimiter
        {
            get { return this.Owner.Delimiter; }
        }

        protected virtual void Write(TextFileWriter writer, String v)
        {
            StringBuilder record = writer.RecordBuffer;
            if (record.Length > 0)
                record.Append(Delimiter);
            record.Append(v);
        }

        protected const String descriptionTemplate = "{0}\t{1} : {2}";
        public override String ToString()
        {
            return String.Format(descriptionTemplate, base.ColumnNo, base.Name,
                                    this.GetTypeName());
        }

        public override bool ExtractIntoTarget(T target, Object source)
        {
            return true;
        }

        #region Field Classes

        public class Decimal : TextVariableLengthField<T>
        {
            private const String DataFormat = "F2";
            public override Object Convert(String record)
            {
                try
                {
                    return decimal.Parse(record);
                }
                catch
                {
                    return 0m;
                }
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                if (null != record && base.HasValueGetter())
                    Write((TextFileWriter)writer, ((decimal)base.GetTargetValue(record)).ToString(DataFormat));
                else if (null != base.Value)
                    Write((TextFileWriter)writer, ((decimal)base.Value).ToString(DataFormat));
                else
                    Write((TextFileWriter)writer, null);
            }

            public override string GetTypeName()
            {
                return "money with two digits after decimal point";
            }
        }

        public class Decimal_x_100 : TextVariableLengthField<T>
        {
            public override Object Convert(String record)
            {
                try
                {
                    return decimal.Parse(record) / 100m;
                }
                catch
                {
                    return 0m;
                }
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                if (null != record && base.HasValueGetter())
                    Write((TextFileWriter)writer, ((Int64)((decimal)base.GetTargetValue(record) * 100)).ToString());
                else if (null != base.Value)
                    Write((TextFileWriter)writer, ((Int64)((decimal)base.Value * 100)).ToString());
                else
                    Write((TextFileWriter)writer, null);
            }

            public override string GetTypeName()
            {
                return "money x 100";
            }
        }

        public class Double : TextVariableLengthField<T>
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

            private String format = null;
            public override void FormatValue(IFileWriter writer, T record)
            {
                double v = 0d;
                if (null != record && base.HasValueGetter())
                    v = (double)base.GetTargetValue(record);
                else if (null != base.Value)
                    v = (double)base.Value;

                if (null == this.format)
                    this.format = "{0:F" + this.DigitsAfterDecimalPoint.ToString() + "}";
                Write((TextFileWriter)writer, String.Format(this.format, v));
            }

            public override string GetTypeName()
            {
                return String.Format("floating point number ({0} digits after decimal point)", this.DigitsAfterDecimalPoint);
            }
        }

        public abstract class GregorianDate : TextVariableLengthField<T>
        {
            public abstract String DataFormat { get; }

            public override void FormatValue(IFileWriter writer, T record)
            {
                String dateString = null;
                if (null != record && base.HasValueGetter())
                {
                    dateString = ((DateTime)base.GetTargetValue(record)).ToString(DataFormat, CultureInfo.InvariantCulture);
                }
                else if (null != base.Value)
                {
                    dateString = ((DateTime)base.Value).ToString(DataFormat, CultureInfo.InvariantCulture);
                }

                Write((TextFileWriter)writer, dateString);
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
                if (String.IsNullOrEmpty(text))
                    return DateTime.MinValue;

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
                if (String.IsNullOrEmpty(text))
                    return DateTime.MinValue;

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

        public class GregorianDate_YYYYMMDD : GregorianDate
        {
            public override String DataFormat
            {
                get { return "yyyyMMdd"; }
            }

            public override Object Convert(String text)
            {
                if (String.IsNullOrEmpty(text))
                    return DateTime.MinValue;

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

        public class Integer : TextVariableLengthField<T>
        {
            public override Object Convert(String record)
            {
                try
                {
                    return int.Parse(record);
                }
                catch
                {
                    return 0;
                }
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                if (null != record && base.HasValueGetter())
                    Write((TextFileWriter)writer, base.GetTargetValue(record).ToString());
                else if (null != base.Value)
                    Write((TextFileWriter)writer, ((int)base.Value).ToString());
                else
                    Write((TextFileWriter)writer, null);
            }

            public override string GetTypeName()
            {
                return "integer";
            }
        }

        public class Literal : TextVariableLengthField<T>
        {
            public virtual String LiteralValue
            {
                get { return (String)base.Value; }
                set { base.Value = value; }
            }

            public override Object Convert(String record)
            {
                if (this.LiteralValue != record)
                    throw new iSabayaException(Messages.LiteralFieldConvertFailed(record.ToString(), record));
                return record;
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                Write((TextFileWriter)writer, this.LiteralValue);
            }

            public override string GetTypeName()
            {
                return "\"" + this.LiteralValue + "\"";
            }
        }

        public class Text : TextVariableLengthField<T> //where T : class, new()
        {
            public override Object Convert(String record)
            {
                if (String.IsNullOrEmpty(record))
                    return "";
                else
                    return record.Trim();
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                if (null != record && base.HasValueGetter())
                    Write((TextFileWriter)writer, (String)base.GetTargetValue(record));
                else
                    Write((TextFileWriter)writer, (String)base.Value);
            }

            public override string GetTypeName()
            {
                return "variable length text";
            }
        }

        public abstract class ThaiDate : TextVariableLengthField<T>
        {
            public abstract String DataFormat { get; }

            public override void FormatValue(IFileWriter writer, T record)
            {
                String dateString = null;
                if (null != record && base.HasValueGetter())
                {
                    dateString = ((DateTime)base.GetTargetValue(record)).ToString(DataFormat, CultureInfo.InvariantCulture);
                }
                else if (null != base.Value)
                {
                    dateString = ((DateTime)base.Value).ToString(DataFormat, CultureInfo.InvariantCulture);
                }

                Write((TextFileWriter)writer, dateString);
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

        ///// <summary>
        ///// Thai date separated by the delimiter
        ///// </summary>
        //public class ThaiDate_DD_MM_YYYY : TextVariableLengthField<T>
        //{
        //    public const String DataFormat = "DD|MM|YYYY";
        //    public override Object Convert(String text)
        //    {
        //        if (String.IsNullOrEmpty(text))
        //            return DateTime.MinValue;

        //        if (text.Length < 8)
        //            throw new iSabayaException(Messages.DateStringIncorrectFormat(text, DataFormat));
        //        int day = int.Parse(text.Substring(0, 2));
        //        int month = int.Parse(text.Substring(2, 2));
        //        int year = int.Parse(text.Substring(4, 4));
        //        return (new DateTime(year, month, day, Configuration.ThaiCulture.Calendar));
        //    }

        //    public override void FormatValue(IFileWriter writer, T record)
        //    {
        //        DateTime d;
        //        if (null != record && base.HasValueGetter())
        //            d = (DateTime)base.GetTargetValue(record);
        //        else if (null != base.Value)
        //            d = (DateTime)base.Value;
        //        else
        //            return;

        //        Write((TextFileWriter)writer, d.Day.ToString("D2"));
        //        Write((TextFileWriter)writer, d.Month.ToString("D2"));
        //        Write((TextFileWriter)writer, (d.Year + 543).ToString());
        //    }

        //    public override string GetTypeName()
        //    {
        //        return "Thai delimited date (DD|MM|YYYY)";
        //    }
        //}

        public class ThaiDate_DDMMYY : ThaiDate
        {
            public override String DataFormat
            {
                get { return "ddMMyy"; }
            }

            public override Object Convert(String text)
            {
                if (String.IsNullOrEmpty(text))
                    return DateTime.MinValue;

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
                if (String.IsNullOrEmpty(text))
                    return DateTime.MinValue;

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
                if (String.IsNullOrEmpty(text))
                    return DateTime.MinValue;

                if (text.Length < 8)
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

        public class Time_HHMMSS : TextVariableLengthField<T>
        {
            public const String DataFormat = "HHmmss";

            public override Object Convert(String text)
            {
                if (String.IsNullOrEmpty(text))
                    return DateTime.MinValue;

                if (text.Length < 6)
                    throw new iSabayaException(Messages.TimeStringIncorrectFormat(text, DataFormat));
                int hour = int.Parse(text.Substring(0, 2));
                int minute = int.Parse(text.Substring(2, 2));
                int second = int.Parse(text.Substring(4, 2));
                return (new DateTime(2000, 1, 1, hour, minute, second));
            }

            public override void FormatValue(IFileWriter writer, T record)
            {
                String dateString = null;
                if (null != record && base.HasValueGetter())
                {
                    dateString = ((DateTime)base.GetTargetValue(record)).ToString(DataFormat, CultureInfo.InvariantCulture);
                }
                else if (null != base.Value)
                {
                    dateString = ((DateTime)base.Value).ToString(DataFormat, CultureInfo.InvariantCulture);
                }

                Write((TextFileWriter)writer, dateString);
            }

            public override string GetTypeName()
            {
                return "time (HHMMSS)";
            }
        }

        #endregion Field Classes
    }
}
