using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;


namespace iSabaya
{

    public class OrganizationRating 
    {
        #region persistent

        public virtual int OrganizationRatingID { get; set; }

        protected String Rating { get; set; }
        protected Organization RatingAgency { get; set; }
        public virtual DateTime RatingDate { get; set; }

        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        #endregion persistent

        #region static

        protected static Language defaultLanguage;
        public static Language DefaultLanguage
        {
            get { return defaultLanguage; }
            set { defaultLanguage = value; }
        }

        protected static Currency defaultCurrent;
        public static Currency DefaultCurrent
        {
            get { return defaultCurrent; }
            set { defaultCurrent = value; }
        }

        protected static OrgUnit currentOrganization;
        public static OrgUnit CurrentOrganization
        {
            get { return currentOrganization; }
            set { currentOrganization = value; }
        }

        public static Organization FindByOfficialIDNo(Context context, String officialIDNo)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Organization));
            return crit.Add(Expression.Eq("OfficialIDNo", officialIDNo))
                        .UniqueResult<Organization>();
        }

        public static Organization FindByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Organization));
            crit.Add(Expression.Eq("Code", code));
            return crit.UniqueResult<Organization>();
        }

        public static Organization FindByCode(Context context, TreeListNode category, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Organization))
                                    .Add(Expression.Eq("Code", code))
                                    .CreateAlias("Categories", "orgcat")
                                    .Add(Expression.Le("orgcat.EffectivePeriod.From", DateTime.Now))
                                    .Add(Expression.Ge("orgcat.EffectivePeriod.To", DateTime.Now))
                                    .Add(Expression.Eq("orgcat.Category", category));
            return crit.UniqueResult<Organization>();
        }

        public static Organization Find(Context context, int id)
        {
            return (Organization)context.PersistenceSession.Get(typeof(Organization), id);
        }

        public static IList<Organization> Find(Context context, TreeListNode businessCategory)
        {
            String qry = "select org.* from Organization org "
                        + "inner join PartyCategory pc on pc.PartyID=org.OrganizationID and pc.PartyDiscriminator=10 "
                        + "inner join TreeListNode cat on cat.ID=pc.CategoryNodeID "
                        + "where GetDate() between pc.EffectiveFrom and pc.EffectiveTo "
                        + "and cat.ID=" + businessCategory.ID.ToString();
            return context.PersistenceSession
                            .CreateSQLQuery(qry)
                            .AddEntity(typeof(Organization))
                            .List<Organization>();
        }

        public static IList<Organization> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Organization));
            return crit.List<Organization>();
        }

        public static IList<Organization> FindByNamePrefix(Context context, string partialName)
        {
            return FindByNamePrefix(context, context.CurrentLanguage.Code, partialName);
        }

        public static IList<Organization> FindByNamePrefix(Context context, String languageCode, string partialName)
        {
            String script = "select o.* from Organization o "
                            + " inner join OrgName n on o.OrgID=n.OwnerID"
                            + " inner join MLSValue nv on n.NameMLSID=nv.MLSID and nv.LanguageCode='"
                            + languageCode + "'"
                            + " where nv.Value like '" + partialName + "%'";
            return context.PersistenceSession.CreateSQLQuery(script)
                            .AddEntity(typeof(Organization)).List<Organization>();
        }

        #endregion static

        public virtual void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }
    }
}