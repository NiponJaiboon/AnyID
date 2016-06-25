using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public abstract class ObjectRecordGroupMapping<T, H, D, F> : ObjectRecordMapping<T>
        where T : class, new()
        where H : class, new()
        where D : class, new()
        where F : class, new()
    {
        public delegate H GetHeader(T instance);
        //public delegate IEnumerable<T> GetDetails(T instance);
        public delegate D GetDetail(T instance);
        public delegate F GetFooter(T instance);
        public delegate void SetHeader(T instance, H headerInstance);
        public delegate void SetDetail(T instance, D detailInstance);
        public delegate void SetFooter(T instance, F footerInstance);

        #region persistent

        /// <summary>
        /// There is at most one header record.  
        /// There must be one or more literal field that distinguishes it from detail and footer (if any).
        /// </summary>
        public virtual ObjectSimpleRecordMapping<H> HeaderFormat { get; set; }

        /// <summary>
        /// There can be zero or more detail instance.  
        /// There must be one or more literal field that distinguishes it from header and footer (if any).
        /// </summary>
        public virtual ObjectRecordMapping<D> DetailFormat { get; set; }

        /// <summary>
        /// There is at most one footer record.  
        /// There must be one or more literal field that distinguishes it from header and detail (if any).
        /// </summary>
        public virtual ObjectSimpleRecordMapping<F> FooterFormat { get; set; }

        public virtual SetHeader SetHeaderInstance { get; set; }
        public virtual SetDetail SetDetailInstance { get; set; }
        public virtual SetFooter SetFooterInstance { get; set; }

        /// <summary>
        /// Use to get an instance of header to export.  
        /// If the HeaderFormat is not null and this is null, 
        /// HeaderFormat.Export will be called with null instance.
        /// </summary>
        public virtual GetHeader GetHeaderInstance { get; set; }

        /// <summary>
        /// Use to get an instance of footer to export.  
        /// If the FooterFormat is not null and this is null, 
        /// FooterFormat.Export will be called with null instance.
        /// </summary>
        public virtual GetFooter GetFooterInstance { get; set; }

        /// <summary>
        /// Will be iteratively called to get an instance of detail until null is returned.
        /// </summary>
        public virtual GetDetail GetDetailInstance { get; set; }

        #endregion persistent

        //public virtual bool Failed { get; set; }
        //public virtual Object RecordBuilder { get; set; }
        //public abstract void BuildDescription(StringBuilder descriptionBuilder);

        //private StringBuilder sb = new StringBuilder();

        //public virtual String ErrorMessage
        //{
        //    get
        //    {
        //        if (null == sb)
        //            return "";
        //        else
        //            return sb.ToString();
        //    }
        //    set
        //    {
        //        if (null == sb)
        //            sb = new StringBuilder(value);
        //        else
        //        {
        //            sb.AppendLine();
        //            sb.Append(value);
        //        }
        //        this.Failed = true;
        //    }
        //}

        public override T Import(Context context, IFileReader fileReader)
        {
            bool isEmpty = true;
            T instance = new T();

            if (null != HeaderFormat)
            {
                H header = HeaderFormat.Import(context, fileReader);
                if (null != header && null != SetHeaderInstance)
                {
                    SetHeaderInstance(instance, header);
                    isEmpty = false;
                }
            }

            do
            {
                D detail = DetailFormat.Import(context, fileReader);
                if (null == detail) break;
                SetDetailInstance(instance, detail);
                isEmpty = false;
            } while (true);

            if (null != FooterFormat)
            {
                F footer = FooterFormat.Import(context, fileReader);
                if (null != footer && null != SetFooterInstance)
                {
                    SetFooterInstance(instance, footer);
                    isEmpty = false;
                }
            }
            if (isEmpty)
                return null;
            else
                return instance;
        }

        public override void Export(Context context, IFileWriter fileWriter, T recordInstance)
        {
            if (null != HeaderFormat)
            {
                InitializeRecordOutput(fileWriter);
                if (null == GetHeaderInstance)
                    HeaderFormat.Export(context, fileWriter, (H)null);
                else
                    HeaderFormat.Export(context, fileWriter, GetHeaderInstance(recordInstance));
                FinalizeRecordOutput(fileWriter);
            }

            do
            {
                D d = GetDetailInstance(recordInstance);
                if (null == d)
                    break;
                InitializeRecordOutput(fileWriter);
                DetailFormat.Export(context, fileWriter, d);
                FinalizeRecordOutput(fileWriter);
            } while (true);

            if (null != this.FooterFormat)
            {
                InitializeRecordOutput(fileWriter);
                if (null == GetFooterInstance)
                    this.FooterFormat.Export(context, fileWriter, (F)null);
                else
                    this.FooterFormat.Export(context, fileWriter, GetFooterInstance(recordInstance));
                FinalizeRecordOutput(fileWriter);
            }
        }

        //public virtual void Persist(Context context)
        //{
        //    context.PersistenceSession.SaveOrUpdate(this);
        //}
    }
}