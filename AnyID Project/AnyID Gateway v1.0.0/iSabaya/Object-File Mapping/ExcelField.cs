using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace iSabaya
{
    public abstract class ExcelField<T> : PropertyFieldMapping<T> where T : class, new()
    {
        #region persistent
        
        public new virtual ExcelSimpleRecord<T> Owner
        {
            get { return (ExcelSimpleRecord<T>)base.Owner; }
            set { base.Owner = value; }
        }
        
        #endregion persistent

        public override void FormatValue(IFileWriter exportDestination, T record)
        {
            ExcelFileWriter writer = (ExcelFileWriter)exportDestination;
            if (null != record && base.HasValueGetter())
                writer.RecordBuffer.Cells[writer.CurrentRowNo, this.ColumnNo].Value2 = base.GetTargetValue(record);
            else if (null != base.Value)
                writer.RecordBuffer.Cells[writer.CurrentRowNo, this.ColumnNo].Value2 = base.Value;
        }

        //public virtual Range GetCurrentCell(RecordFormat<T> format)
        //{
        //    ExcelSimpleRecord<T> excelFormat = (ExcelSimpleRecord<T>)format;
        //    Worksheet ws = (Worksheet)((Workbook)excelFormat.Owner.ExportDestination).ActiveSheet;
        //    return (Range)ws.Cells[excelFormat.CurrentRowNo, this.ColumnNo];
        //}

        protected const String descriptionTemplate = "{0}\t{1} : {2}";
        public override string ToString()
        {
            return String.Format(descriptionTemplate, base.ColumnNo, base.Name,
                                    this.GetTypeName());
        }

        #region Field Classes

        public class Date : ExcelField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    return DateTime.Parse(fieldValue);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }

            public override bool ExtractIntoTarget(T target, Object record)
            {
                if (!base.HasValueSetter()) return true;
                this.SetTargetValue(this, target, (DateTime)record);
                return true;

            }

            public override string GetTypeName()
            {
                return "date-time";
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

        public class Integer : ExcelField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    return System.Convert.ToInt32(fieldValue);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }

            public override bool ExtractIntoTarget(T target, Object record)
            {
                if (!base.HasValueSetter())
                    return true;
                this.SetTargetValue(this, target, System.Convert.ToInt32(record));
                return true;
            }

            public override string GetTypeName()
            {
                return "integer";
            }
        }

        public class Double : ExcelField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    return System.Convert.ToDouble(fieldValue);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }

            public override bool ExtractIntoTarget(T target, Object record)
            {
                if (!base.HasValueSetter())
                    return true;
                this.SetTargetValue(this, target, System.Convert.ToDouble(record));
                return true;
            }

            public override string GetTypeName()
            {
                return "double precision number";
            }
        }

        public class Money : ExcelField<T>
        {
            public override Object Convert(String fieldValue)
            {
                try
                {
                    return System.Convert.ToDecimal(fieldValue);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }

            public override bool ExtractIntoTarget(T target, Object record)
            {
                if (!base.HasValueSetter()) return true;
                this.SetTargetValue(this, target, System.Convert.ToDecimal(record));
                return true;
            }

            public override string GetTypeName()
            {
                return "money";
            }
        }

        public class Text : ExcelField<T>
        {
            public override Object Convert(String fieldValue)
            {
                return fieldValue;
            }

            public override bool ExtractIntoTarget(T target, Object record)
            {
                if (!base.HasValueSetter()) return true;
                this.SetTargetValue(this, target, record.ToString());
                return true;
            }

            public override string GetTypeName()
            {
                return "text";
            }
        }

        #endregion Field Classes

        public override object Convert(string value)
        {
            throw new NotImplementedException();
        }

        public override string GetTypeName()
        {
            throw new NotImplementedException();
        }
    }
}