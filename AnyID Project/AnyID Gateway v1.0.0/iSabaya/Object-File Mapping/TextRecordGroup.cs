using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class TextRecordGroup<T, H, D, F> : ObjectRecordGroupMapping<T, H, D, F>
        where T : class, new()
        where H : class, new()
        where D : class, new()
        where F : class, new()
    {
        public virtual new TextSimpleRecord<H> HeaderFormat
        {
            get { return (TextSimpleRecord<H>)base.HeaderFormat; }
            set { base.HeaderFormat = value; }
        }

        public virtual new TextSimpleRecord<F> FooterFormat
        {
            get { return (TextSimpleRecord<F>)base.FooterFormat; }
            set { base.FooterFormat = value; }
        }

        public override T Import(Context context, IFileReader fileReader)
        {
            bool isEmpty = true;
            T instance = new T();
            if (null != HeaderFormat)
            {
                H header = HeaderFormat.Import(context, fileReader);
                if (null == header)
                {
                    return null;
                }
                else if (null != SetHeaderInstance)
                {
                    isEmpty = false;
                    SetHeaderInstance(instance, header);
                }
            }
            if (null != DetailFormat && null != SetDetailInstance)
            {
                while (true)
                {
                    D detail = DetailFormat.Import(context, fileReader);
                    if (null == detail)
                        break;
                    else
                    {
                        isEmpty = false;
                        SetDetailInstance(instance, detail);
                    }
                }
            }
            if (null != FooterFormat)
            {
                F footer = FooterFormat.Import(context, fileReader);
                if (null != footer && null != SetFooterInstance)
                {
                    isEmpty = false;
                    SetFooterInstance(instance, footer);
                }
            }

            if (isEmpty)
                return null;
            else
                return instance;
        }

        protected override void InitializeRecordOutput(IFileWriter exportDestination)
        {
        }

        protected override void FinalizeRecordOutput(IFileWriter exportDestination)
        {
        }
    }
}
