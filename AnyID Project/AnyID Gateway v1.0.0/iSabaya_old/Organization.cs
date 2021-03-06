using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace iSabaya
{
    [Serializable]
    public class Organization : OrgBase,
                                IComparer,
                                IComparer<Organization>,
                                IEqualityComparer<Organization>
    {
        public Organization()
        {
        }
        public Organization(DateTime effectiveDate)
            : base(effectiveDate)
        {
        }
        public Organization(TimeInterval effectivePeriod)
            : base(effectivePeriod)
        {
        }

        #region persistent
        public virtual BusinessCycle FiscalYear { get; set; }
        public virtual BusinessCycle LeaveYear { get; set; }
        public virtual TreeListNode Nationality { get; set; }
        public virtual String RegistrationNo { get; set; }
        public virtual string WebSite { get; set; }
        public virtual string EmailDomain { get; set; }
        /// <summary>
        /// In years
        /// </summary>
        public virtual int RetirementAge { get; set; }
        public virtual OrgUnit OrgUnitRoot { get; set; }
        //public virtual Position ChainOfCommandRootPosition { get; set; }
        //public virtual Position LeaveRequestChainRootPosition { get; set; }

        //private IList<Subunit> subunits;
        //public virtual IList<Subunit> Subunits
        //{
        //    get
        //    {
        //        if (subunits == null)
        //        {
        //            subunits = new List<Subunit>();
        //        }
        //        return subunits;
        //    }
        //    set { subunits = value; }
        //}

        private IList<User> users;
        public virtual IList<User> Users
        {
            get
            {
                if (null == this.users)
                    this.users = new List<User>();
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }

        //private IList<Employee> employments;
        //public virtual IList<Employee> Employees
        //{
        //    get
        //    {
        //        if (this.employments == null)
        //            this.employments = new List<Employee>();
        //        return this.employments;
        //    }
        //    set
        //    {
        //        this.employments = value;
        //    }
        //}

        //private IList<Position> positions;
        //public virtual IList<Position> Positions
        //{
        //    get
        //    {
        //        if (this.positions == null)
        //            this.positions = new List<Position>();
        //        return this.positions;
        //    }
        //    set
        //    {
        //        this.positions = value;
        //    }
        //}

        #endregion persistent

        //private IList<ObjectCategory> categories;
        //public virtual IList<ObjectCategory> Categories
        //{
        //    get {
        //        if (categories == null)
        //        {
        //            categories = new List<ObjectCategory>();
        //        }
        //        return categories; 
        //    }
        //    set { categories = value; }
        //}
        #region static

        protected static Language defaultLanguage;
        public static Language DefaultLanguage
        {
            get { return defaultLanguage; }
            set { defaultLanguage = value; }
        }

        //protected static Currency defaultCurrent;
        //public static Currency DefaultCurrent
        //{
        //    get { return defaultCurrent; }
        //    set { defaultCurrent = value; }
        //}

        protected static OrgUnit currentOrganization;
        public static OrgUnit CurrentOrganization
        {
            get { return currentOrganization; }
            set { currentOrganization = value; }
        }

        public static Organization FindByOfficialIDNo(Context context, String officialIDNo)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Organization));
            Organization org = crit.Add(Expression.Eq("OfficialIDNo", officialIDNo))
                                .UniqueResult<Organization>();
            org.LanguageCode = context.CurrentLanguage.Code;
            return org;
        }

        public static Organization FindByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Organization));
            Organization org = crit.Add(Expression.Eq("Code", code)).UniqueResult<Organization>();
            org.LanguageCode = context.CurrentLanguage.Code;
            return org;
        }

        public static Organization FindByCode(Context context, TreeListNode category, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<Organization>()
                                    .Add(Expression.Eq("Code", code))
                                    .CreateAlias("Categories", "orgcat")
                                    .Add(Expression.Le("orgcat.EffectivePeriod.From", DateTime.Now))
                                    .Add(Expression.Ge("orgcat.EffectivePeriod.To", DateTime.Now))
                                    .Add(Expression.Eq("orgcat.Category", category));
            Organization org = crit.UniqueResult<Organization>();
            org.LanguageCode = context.CurrentLanguage.Code;
            return org;
        }

        public static Organization Find(Context context, int id)
        {
            Organization org = context.PersistenceSession.Get<Organization>(id);
            org.LanguageCode = context.CurrentLanguage.Code;
            return org;
        }

        public static IList<Organization> Find(Context context, TreeListNode businessCategory)
        {
            IList<Organization> orgs = context.PersistenceSession.CreateCriteria<Organization>()
                                            .CreateAlias("Categories", "orgcat")
                                            .Add(Expression.Le("orgcat.EffectivePeriod.From", DateTime.Now))
                                            .Add(Expression.Ge("orgcat.EffectivePeriod.To", DateTime.Now))
                                            .Add(Expression.Eq("orgcat.Category", businessCategory)).List<Organization>();
            SetLanguage(context, orgs);
            return orgs;
        }

        public static IList<Organization> List(Context context)
        {
            IList<Organization> orgs = context.PersistenceSession.QueryOver<Organization>().List();
            SetLanguage(context, orgs);
            return orgs;
        }

        public static IList<Organization> FindByNamePrefix(Context context, string partialName)
        {
            return FindByNamePrefix(context, context.CurrentLanguage.Code, partialName);
        }

        public static IList<Organization> FindByNamePrefix(Context context, String languageCode, string partialName)
        {
            IList<Organization> orgs = context.PersistenceSession.CreateCriteria<Organization>()
                                .CreateAlias("CurrentName", "oname")
                                .CreateAlias("oname.Name", "name")
                                .CreateAlias("name.Values", "vls")
                                .Add(Expression.Like("vls.Value", partialName, MatchMode.Start))
                                .List<Organization>();
            SetLanguage(context, orgs);
            return orgs;
        }

        #endregion static

        public virtual bool IsPersonOrgRelationExisted(Context context, TreeListNode category, Person person, DateTime onDate)
        {
            Object result = context.PersistenceSession
                            .CreateQuery(String.Format("select count(*) from PersonOrgRelation where "
                                                        + "RelationshipCategory.ID = {0} "
                                                        + "and Organization.OrganizationID = {1}"
                                                        + "and Person.ID = {2}"
                                                        + "and '{3}'-'{4}'-'{5}' between EffectivePeriod.From and EffectivePeriod.To"
                                                        , category.ID, this.ID, person.ID
                                                        , onDate.Year, onDate.Month, onDate.Day))
                            .UniqueResult();
            return (long)result > 0;

        }

        //public virtual IList<Employee> GetEffectiveEmployees(Context context, TreeListNode category, Person person, DateTime onDate)
        //{
        //    return context.PersistenceSession
        //                    .QueryOver<Employee>()
        //                    .Where(r => r.Employer == this
        //                            && r.Category == category
        //                            && r.Person == person
        //                            && r.EffectivePeriod.From <= onDate
        //                            && r.EffectivePeriod.To >= onDate)
        //                    .List();
        //}

        public virtual OrgUnit GetEffectiveOrgUnit(Context context, String officialIDNo)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                        .QueryOver<OrgUnit>()
                        .Where(ou => ou.OfficialIDNo == officialIDNo
                                    && ou.Organization == this
                                    && ou.EffectivePeriod.From <= now && now <= ou.EffectivePeriod.To)
                        .SingleOrDefault();
        }

        public override void Persist(Context context)
        {
            if (this.DefaultWorkSchedule != null) this.DefaultWorkSchedule.Persist(context);
            base.Persist(context);
            if (this.OrgUnitRoot != null)
            {
                this.OrgUnitRoot.Organization = this;
                this.OrgUnitRoot.Persist(context);
            }
            foreach (User e in this.Users)
            {
                e.Organization = this;
                e.Persist(context);
            }
            if (ContactName != null)
                ContactName.Persist(context);

            context.Persist(this);
        }

        private MultilingualString contactName;
        public virtual MultilingualString ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public override String ToString()
        {
            if (null == this.CurrentName)
                if (null == this.Code || "" == this.Code)
                    return "Org " + this.ID;
                else
                    return this.Code;
            else
                return this.Code + "-" + this.CurrentName.ToString(this.LanguageCode); // +" - " + this.CurrentName.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(Organization a, Organization b)
        {
            if (Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null)) return true;
            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null)) return false;
            return (a.ID == b.ID);
        }

        public static bool operator !=(Organization a, Organization b)
        {
            return !(a == b);
        }

        #region IEqualityComparer<Organization> Members

        public virtual bool Equals(Organization x, Organization y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(null, x) || Object.ReferenceEquals(null, y)) return false;
            return x.ID > 0 && x.ID == y.ID;
        }

        public virtual int GetHashCode(Organization obj)
        {
            return obj.ID.GetHashCode();
        }

        #endregion

        #region IComparer<Organization> Members

        public virtual int Compare(Organization x, Organization y)
        {
            if (Object.ReferenceEquals(x, y)) return 0;
            return x.Code.CompareTo(y.Code);
        }

        #endregion

        #region IComparer Members

        public virtual int Compare(object x, object y)
        {
            if (Object.ReferenceEquals(x, y)) return 0;
            return ((Organization)y).Code.CompareTo(((Organization)x).Code);
        }

        #endregion

        //public virtual OrgUnit GetOrgUnit(string code)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual DateTime DetermineRetirementDate(DateTime birthDate)
        {
            DateTime retireDate = birthDate.AddYears(this.RetirementAge);
            int retireYear = this.FiscalYear.DetermineYearOf(retireDate);
            return this.FiscalYear.FirstDateOfYear(retireYear + 1);
        }
    }
}