using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    public class GeographicRegion : IEnumerable<GeographicRegion>, IEnumerator<GeographicRegion>
    {
        public GeographicRegion()
        {
        }

        public GeographicRegion(Country country, int seqNo, string code, string internalCode, MultilingualString name)
        {
            // TODO: Complete member initialization
            this.Country = country;
            this.SeqNo = seqNo;
            this.Code = code;
            this.InternalCode = internalCode;
            this.Name = name;
        }

        public virtual int ID { get; set; }
        public virtual int SeqNo { get; set; }
        public virtual int LevelNo { get; set; }
        public virtual string Code { get; set; }
        public virtual String InternalCode { get; set; }
        public virtual MultilingualString Name { get; set; }
        public virtual MultilingualString ShortName { get; set; }
        public virtual string Remark { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Country Country { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }

        private IList<GeographicRegion> subregions;
        public virtual IList<GeographicRegion> Subregions
        {
            get
            {
                if (null == this.subregions)
                    this.subregions = new List<GeographicRegion>();
                return this.subregions;
            }

            set
            {
                this.subregions = value;
            }
        }

        public virtual GeographicRegion SuperRegion { get; set; }

        //public virtual Country Country { get;set;}

        //public bool IsLeaf()
        //{

        //}

        //public bool AddSubregion(GeographicRegion subregion)
        //{

        //}

        //public void RemoveSubregion(GeographicRegion subregion)
        //{

        //}

        //// Get a subregion that is effective at present.
        //public GeographicRegion GetEffectiveSubregion(string path)
        //{

        //}

        //// Get a subregion that is effective at present.
        //public GeographicRegion GetSubregionEffectiveOn(DateTime date, string path)
        //{

        //}

        #region IEnumerable<GeographicRegion> Members

        public virtual IEnumerator<GeographicRegion> GetEnumerator()
        {
            throw new iSabayaException("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new iSabayaException("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerator<GeographicRegion> Members

        public virtual GeographicRegion Current
        {
            get { throw new iSabayaException("The method or operation is not implemented."); }
        }

        #endregion

        #region IDisposable Members

        public virtual void Dispose()
        {
            throw new iSabayaException("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get { throw new iSabayaException("The method or operation is not implemented."); }
        }

        public virtual bool MoveNext()
        {
            throw new iSabayaException("The method or operation is not implemented.");
        }

        public virtual void Reset()
        {
            throw new iSabayaException("The method or operation is not implemented.");
        }

        #endregion

        public virtual void Persist(Context context)
        {
            if (null != Name) Name.Persist(context);
            if (null != ShortName) ShortName.Persist(context);
            foreach (GeographicRegion r in Subregions)
            {
                r.Country = this.Country;
                r.SuperRegion = this;
                r.Persist(context);
            }
            context.Persist(this);
        }
    }
} // iSabaya
