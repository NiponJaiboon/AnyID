//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace iSabaya
//{
//    public class TextFixedLengthRecordGroup<T, H, D, F> : TextRecordGroup<T, H, D, F>
//        where T : class, new()
//        where H : class, new()
//        where D : class, new()
//        where F : class, new()
//    {
//        public virtual new TextFixedLengthSimpleRecord<H> HeaderFormat
//        {
//            get { return (TextFixedLengthSimpleRecord<H>)base.HeaderFormat; }
//            set { base.HeaderFormat = value; }
//        }

//        public virtual new TextFixedLengthSimpleRecord<F> FooterFormat
//        {
//            get { return (TextFixedLengthSimpleRecord<F>)base.FooterFormat; }
//            set { base.FooterFormat = value; }
//        }
//        //public override T Extract(Context context, Object source)
//        //{
//        //    T record = this.ExtractValues(context, (String)source);
//        //    if (null != base.FinalizeExtraction)
//        //        base.FinalizeExtraction(context, record);
//        //    return record;
//        //}

//        //public override T ExtractValues(Context context, String line)
//        //{
//        //    T target = new T();
//        //    foreach (TextFixedLengthField<T> f in base.Fields)
//        //    {
//        //        if (null != f)
//        //            f.ExtractIntoTarget(target, line);
//        //    }
//        //    return target;
//        //}

//        //private int CalculateLineLenth()
//        //{
//        //    if (this.Fields.Length == 0)
//        //        return 0;

//        //    TextFixedLengthField<T> lastFieldInTheLine = (TextFixedLengthField<T>)base.Fields[0];
//        //    for (int i = 1; i < this.Fields.Length; ++i)
//        //    {
//        //        if (null != this.Fields[i] && this.Fields[i].ColumnNo > lastFieldInTheLine.ColumnNo)
//        //            lastFieldInTheLine = (TextFixedLengthField<T>)base.Fields[i];
//        //    }
//        //    return lastFieldInTheLine.ColumnNo + lastFieldInTheLine.Length;
//        //}

//        public override T Import(Context context, IFileReader fileReader)
//        {
//            T instance = new T();
//            if (null != HeaderFormat && null != SetHeaderInstance)
//            {
//                H header = HeaderFormat.Import(context, fileReader);
//                if (null != header)
//                    SetHeaderInstance(instance, header);
//            }
//            if (null != DetailFormat && null != SetDetailInstance)
//            {
//                while (true)
//                {
//                    D detail = DetailFormat.Import(context, fileReader);
//                    if (null == detail)
//                        break;
//                    else
//                        SetDetailInstance(instance, detail);
//                }
//            }
//            if (null != FooterFormat) 
//            {
//                F footer = FooterFormat.Import(context, fileReader);
//                if (null != footer && null != SetFooterInstance)       
//                    SetFooterInstance(instance, footer);
//            }
//            return instance;
//        }

//        protected override void InitializeRecordOutput(IFileWriter exportDestination)
//        {
//        }

//        protected override void FinalizeRecordOutput(IFileWriter exportDestination)
//        {
//        }
//    }
//}