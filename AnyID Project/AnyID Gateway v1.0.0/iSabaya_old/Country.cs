using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class Country : IEnumerable<GeographicRegion>
    {
        public Country()
        {
        }

        public virtual int ISONumericCode { get; set; }
        public virtual MultilingualString Name { get; set; }
        public virtual MultilingualString AbbreviatedName { get; set; }
        public virtual MultilingualString NationalityName { get; set; }
        public virtual string ISOAlpha2Code { get; set; }
        /// <summary>
        /// Primary key
        /// </summary>
        public virtual string ISOAlpha3Code { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Remark { get; set; }
        public virtual MultilingualString RegionLevel1Title { get; set; }
        public virtual MultilingualString RegionLevel2Title { get; set; }
        public virtual MultilingualString RegionLevel3Title { get; set; }
        public virtual MultilingualString RegionLevel4Title { get; set; }
        /// <summary>
        /// between 0 and 4 (inclusive)
        /// </summary>
        public virtual int LevelCount { get; set; }

        public virtual Language OfficialLanguage { get; set; }

        public virtual Language AltOfficialLanguage { get; set; }

        private IList<GeographicRegion> level1Regions;
        public virtual IList<GeographicRegion> Level1Regions
        {
            get
            {
                if (null == level1Regions)
                    level1Regions = new List<GeographicRegion>();
                return level1Regions;
            }
            set
            {
                level1Regions = value;
            }
        }

        private TreeListNode level1RegionRootNode;

        public virtual TreeListNode Level1RegionRootNode
        {
            get { return level1RegionRootNode; }
            set { level1RegionRootNode = value; }
        }

        #region IEnumerable<GeographicRegion> Members

        public virtual IEnumerator<GeographicRegion> GetEnumerator()
        {
            return this.Level1Regions.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Level1Regions.GetEnumerator();
        }

        #endregion

        public static Country FindRegionByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<Country>()
                                    .Add(Expression.Or(Expression.Eq("ISOCode2", code), Expression.Eq("ISOCode3", code)));
            Country country = crit.UniqueResult<Country>();
            return country;

        }

        public static Country FindRegionByInternalCode(Context context, String internalCode)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<Country>()
                                    .Add(Expression.Or(Expression.Eq("ISOCode2", internalCode), Expression.Eq("ISOCode3", internalCode)));
            Country country = crit.UniqueResult<Country>();
            return country;

        }

        public static Country FindByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<Country>()
                                    .Add(Expression.Or(Expression.Eq("ISOCode2", code), Expression.Eq("ISOCode3", code)));
            Country country = crit.UniqueResult<Country>();
            return country;

        }

        public virtual void Persist(Context context)
        {
            if (this.Name != null) this.Name.Persist(context);
            if (this.AbbreviatedName != null) this.AbbreviatedName.Persist(context);
            if (this.NationalityName != null) this.NationalityName.Persist(context);
            if (this.RegionLevel1Title != null) this.RegionLevel1Title.Persist(context);
            if (this.RegionLevel2Title != null) this.RegionLevel2Title.Persist(context);
            if (this.RegionLevel3Title != null) this.RegionLevel3Title.Persist(context);
            if (this.RegionLevel4Title != null) this.RegionLevel4Title.Persist(context);
            if (this.level1RegionRootNode != null) this.level1RegionRootNode.Persist(context);
            foreach (GeographicRegion r in Level1Regions)
            {
                r.Country = this;
                r.Persist(context);
            }
            context.Persist(this);
        }

        public static Country Find(Context context, int id)
        {
            Country country = (Country)context.PersistenceSession.Get(typeof(Country), id);
            return country;
        }

        public static IList<Country> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Country));
            return crit.List<Country>();

        }

        public virtual String ToLog()
        {

            return "";
        }

        public virtual String ToString(String languageCode)
        {
            return this.Name.ToString(languageCode);
        }

        public override String ToString()
        {
            return this.Name.ToString();
        }

    }

} // iSabaya
