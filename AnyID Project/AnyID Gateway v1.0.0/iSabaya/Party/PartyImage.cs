using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace iSabaya
{
    public class PartyImage : PartyCategory
    {
        public virtual Image Image { get; set; }
        public virtual ImageFormat Format { get; set; }

        #region persistent

        protected virtual byte[] ImageBytes
        {
            get
            {
                if (null == this.Image)
                    return null;
                MemoryStream ms = new MemoryStream();
                if (null == Format)
                    this.Image.Save(ms, this.Image.RawFormat);
                else
                    this.Image.Save(ms, Format);
                return ms.GetBuffer();
            }
            set
            {
                if (null == this.Image && null != value)
                {
                    //ImageConverter imageConverter = new System.Drawing.ImageConverter();
                    //this.Picture = imageConverter.ConvertFrom(null, new System.Globalization.CultureInfo("th-TH"), value) as Image;

                    MemoryStream ms = new MemoryStream(value, 0, value.Length);
                    this.Image = Image.FromStream(ms);
                    this.Format = this.Image.RawFormat;
                    //this.valueImage = Image.FromStream(new MemoryStream(value));
                }
            }
        }

        #endregion

        public static PartyImage GetFirst(Context context)
        {
            return context.PersistenceSession.Get<PartyImage>(1L);
        }

        public static PartyImage GetByID(Context context, long Id)
        {
            return context.PersistenceSession.Get<PartyImage>(Id);
        }

        public static IList<PartyImage> GetAll(Context context)
        {
            return context.PersistenceSession.QueryOver<PartyImage>().List<PartyImage>();
        }
    }
}
