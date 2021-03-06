using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class Person : Party, IEqualityComparer<Person>//, IHibernateEvent<Person>
    {
        #region Constructor

        public Person()
        {
        }

        public Person(int id)
        {
            this.ID = id;
        }

        //public Person(PersonName name, PartyIdentity id)
        //{
        //    this.CurrentName = name;
        //    id.Party = this;
        //    this.identities.Add(id);
        //}

        //public Person(PersonName name, PartyIdentity id, DateTime birthDate, Country citizenOf,
        //                TreeListNode gender, PartyAddress address, string email, string phones, string mobilePhones,
        //                TreeListNode religion, TreeListNode bloodGroup)
        //    : base(birthDate)
        //{
        //    this.CurrentName = name;
        //    id.Party = this;
        //    this.identities.Add(id);
        //    address.Party = this;
        //    this.addresses.Add(address);
        //    this.CitizenOf = citizenOf;
        //    this.Gender = gender;
        //    this.EmailAddress = email;
        //    this.Phone = phones;
        //    this.MobilePhone = mobilePhones;
        //    this.Religion = religion;
        //    this.BloodGroup = bloodGroup;
        //}

        #endregion

        public virtual DateTime BirthDate
        {
            get { return base.EffectivePeriod.From; }
        }
        public virtual DateTime DeceasedDate
        {
            get { return base.EffectivePeriod.To; }
        }
        public virtual TimeSpan Age
        {
            get { return base.EffectivePeriod.TimeSpan; }
        }

        #region persistent

        public virtual TreeListNode BloodGroup { get; set; }
        public virtual TreeListNode Gender { get; set; }
        public virtual TreeListNode BirthNationality { get; set; }
        public virtual Country CitizenOf { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Faxes { get; set; }
        public virtual string MobilePhone { get; set; }

        //protected IList<Appointment> appointments;
        //public virtual IList<Appointment> Appointments
        //{
        //    get
        //    {
        //        if (appointments == null)
        //            appointments = new List<Appointment>();
        //        return appointments;
        //    }
        //    set { appointments = value; }
        //}

        protected ITemporalList<PersonName> names;
        public virtual ITemporalList<PersonName> Names
        {
            get
            {
                if (names == null) names = new TemporalList<PersonName>();
                return names;
            }
            set { names = value; }
        }
        public virtual TreeListNode Occupation { get; set; }
        public virtual string Phone { get; set; }
        //public virtual PropertyValueContainerBase Properties { get; set; }
        public virtual TreeListNode Religion { get; set; }
        public virtual TreeListNode MaritalStatus { get; set; }
        public virtual String URL { get; set; }

        //protected IList<Employee> employees;
        //public virtual IList<Employee> Employees
        //{
        //    get
        //    {
        //        if (this.employees == null)
        //            this.employees = new List<Employee>();
        //        return this.employees;
        //    }
        //    set { this.employees = value; }
        //}

        //protected IList<Staff> staffs;
        //public virtual IList<Staff> Staffs
        //{
        //    get
        //    {
        //        if (this.staffs == null)
        //            this.staffs = new List<Staff>();
        //        return this.staffs;
        //    }
        //    set { this.staffs = value; }
        //}

        #endregion persistent

        #region Operations

        protected PersonName currentName;
        public virtual PersonName CurrentName
        {
            get
            {
                if (null == this.currentName)
                    if (null != this.Names)
                        this.currentName = GetName(DateTime.Now);
                return this.currentName;
            }
            set
            {
                if (value == null) return;
                if (value.EffectivePeriod.IsNullOrEmpty())
                    throw new Exception("The effective period of the person name is invalid.");
                //if (this.currentName == value) return;
                value.Person = this;
                this.Names.Add(value);

                if (null != this.currentName)
                {
                    this.currentName.Terminate(value.EffectivePeriod.From);
                    if (value.IsEffective)
                        this.currentName = value;
                }
            }
        }

        public virtual Image GetSignature(DateTime onDate)
        {
            foreach (PartyAttribute pa in base.Attributes)
            {
                if (pa.Match(iSabayaConstants.PersonAttributeCode.Signature, onDate))
                    return pa.ValueImage;
            }
            return null;
        }

        public virtual PersonName GetName(DateTime onDate)
        {
            foreach (PersonName name in this.Names)
            {
                if (name.EffectivePeriod.Includes(onDate))
                    return name;
            }
            return null;
        }

        public virtual User FindUser(Context context, DateTime onDate)
        {
            return context.PersistenceSession
                            .QueryOver<User>()
                                .Where(e => e.EffectivePeriod.From <= onDate && onDate <= e.EffectivePeriod.To
                                            && e.Person == this)
                            .SingleOrDefault();
        }

        public virtual PartyAttribute GetEffectiveAttributeOfCategory(Context context, TreeListNode category, DateTime effectiveDate)
        {
            return context.PersistenceSession
                            .QueryOver<PartyAttribute>()
                            .Where(a => a.Party == this && a.Category == category
                                    && a.EffectivePeriod.From <= effectiveDate && effectiveDate <= a.EffectivePeriod.To)
                            .SingleOrDefault();
        }

        public virtual IList<PartyAttribute> GetAttributesOfCategory(Context context, TreeListNode category)
        {
            return context.PersistenceSession
                            .QueryOver<PartyAttribute>()
                            .Where(a => a.Party == this && a.Category == category)
                            .List();
        }

        public override void Initiate(Context context, TimeInterval effectivePeriod, UserAction approvedAction)
        {
            base.Initiate(context, effectivePeriod, approvedAction);
            if (null != this.CurrentName)
                this.CurrentName.Initiate(context, effectivePeriod, approvedAction);
        }

        //public virtual IList<Appointment> FindEffectiveAppointmentsOnDate(Context context, DateTime date)
        //{
        //    return context.PersistenceSession.QueryOver<Appointment>()
        //                .Where(a => a.Person == this
        //                            && a.EffectivePeriod.From <= date && date <= a.EffectivePeriod.To)
        //                .List();
        //}

        //public virtual Staff FindEffectiveOrgUnitPersonOnDate(Context context, DateTime onDate)
        //{
        //    return context.PersistenceSession
        //                    .QueryOver<Staff>()
        //                    .Where(e => e.Person == this
        //                                && e.EffectivePeriod.From <= onDate
        //                                && onDate <= e.EffectivePeriod.To)
        //                    .SingleOrDefault();
        //}

        //public virtual Employee FindCurrentEmployment(Context context)
        //{
        //    DateTime when = DateTime.Now;
        //    return context.PersistenceSession.QueryOver<Employee>()
        //                .Where(a => a.Person == this
        //                            && a.EffectivePeriod.From <= when && when <= a.EffectivePeriod.To)
        //                .SingleOrDefault();
        //}

        public virtual TreeListNode FindCurrentReligion(Context context)
        {
            return this.FindCurrentAttributeOfCategory(context, context.Configuration.Person.GenderRootNode);
        }

        public virtual TreeListNode FindCurrentMaritalStatus(Context context)
        {
            return this.FindCurrentAttributeOfCategory(context, context.Configuration.Person.MaritalStatusRootNode);
        }

        public virtual TreeListNode FindCurrentNationality(Context context)
        {
            return this.FindCurrentAttributeOfCategory(context, context.Configuration.Person.NationalityRootNode);
        }

        public virtual TreeListNode FindCurrentAttributeOfCategory(Context context, TreeListNode attributeCategory)
        {
            DateTime when = DateTime.Now;
            return context.PersistenceSession.QueryOver<PersonAttribute>()
                        .Where(a => a.Person == this && a.AttributeCategory == attributeCategory
                                    && a.EffectivePeriod.From <= when && when <= a.EffectivePeriod.To)
                        .SingleOrDefault()
                        .AttributeValue;
        }

        //public virtual IList<PersonAttribute> FindAttributesOfCategory(Context context, TreeListNode attributeCategory, DateTime when)
        //{
        //    return context.PersistenceSession.QueryOver<PersonAttribute>()
        //                .Where(a => a.Person == this && a.AttributeCategory == attributeCategory
        //                            && a.EffectivePeriod.From <= when && when <= a.EffectivePeriod.To)
        //                .List();
        //}

        //public virtual Appointment GetCurrentAppointment(Context context)
        //{
        //    DateTime when = DateTime.Now;
        //    return context.PersistenceSession.QueryOver<Appointment>()
        //                    .Where(a => a.EffectivePeriod.From <= when && when <= a.EffectivePeriod.To && a.Person == this)
        //                    .SingleOrDefault();
        //}

        ///// <summary>
        ///// Expire and persist all effective, on the given expiry date, attributes of a given category
        ///// </summary>
        ///// <param name="context"></param>
        ///// <param name="attributeCategory"></param>
        ///// <param name="expiryDate"></param>
        ///// <returns>the lsit of attributes being expired</returns>
        //public virtual IList<PersonAttribute> ExpireEffectiveAttributesOfCategory(Context context, TreeListNode attributeCategory, DateTime expiryDate)
        //{
        //    IList<PersonAttribute> attributes = context.PersistenceSession
        //                                                .QueryOver<PersonAttribute>()
        //                                                .Where(a => a.Person == this && a.AttributeCategory == attributeCategory
        //                                                            && a.EffectivePeriod.From < expiryDate && expiryDate <= a.EffectivePeriod.To)
        //                                                .List();
        //    foreach (var a in attributes)
        //    {
        //        a.EffectivePeriod.ExpiryDate = expiryDate;
        //        a.Persist(context);
        //    }

        //    return attributes;
        //}

        public override void Persist(Context context)
        {
            if (this.ID == 0)
                base.Persist(context);
            foreach (var e in Names)
            {
                if (e.ID == 0)
                {
                    e.Person = this;
                    e.Persist(context);
                }
            }
            //foreach (var e in this.Appointments)
            //{
            //    if (e.ID == 0)
            //    {
            //        e.Person = this;
            //        e.Persist(context);
            //    }
            //}
            //foreach (var e in this.Employees)
            //{
            //    if (e.ID == 0)
            //    {
            //        e.Person = this;
            //        e.Persist(context);
            //    }
            //}
            //foreach (var e in this.Staffs)
            //{
            //    if (e.ID == 0)
            //    {
            //        e.Person = this;
            //        e.Persist(context);
            //    }
            //}
            context.PersistenceSession.SaveOrUpdate(this);
        }

        public override string ToString()
        {
            if (null == this.CurrentName)
                if (this.ID == 0)
                    return "New anonymous person";
                else
                    return "Person " + this.ID.ToString();
            else
                return this.CurrentName.ToString();
        }

        public virtual String ToLog()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion Operations

        public override string LanguageCode
        {
            get
            {
                return base.LanguageCode;
            }
            set
            {
                base.LanguageCode = value;
                this.CurrentName.LanguageCode = value;
            }
        }

        #region static

        protected static String propertyTemplateCode;
        public static String PropertyTemplateCode
        {
            get { return propertyTemplateCode; }
            set { propertyTemplateCode = value; }
        }

        public static Person Find(Context context, int id)
        {
            Person p = context.PersistenceSession.Get<Person>(id);
            p.LanguageCode = context.CurrentLanguage.Code;
            return p;
        }

        public static Person FindByPartyIdentity(Context context, TreeListNode identityCategory, string identityNo)
        {
            if (identityCategory == null)
                return null;

            IQuery query = context.PersistenceSession.CreateQuery(
                            @"from Person p left join fetch p.Identities ids
                            where ids.IdentityNo = :IdentityNo
                            and ids.Category = :Category");

            query.SetString("IdentityNo", identityNo);
            query.SetInt64("Category", identityCategory.ID);
            Person p = query.UniqueResult<Person>();
            p.LanguageCode = context.CurrentLanguage.Code;
            return p;
        }

        public static String QueryLikeFirstName =
@"SELECT p.*
    FROM Person AS p 
    INNER JOIN PersonName pn ON p.CurrentNameID = pn.ID
    INNER JOIN MLSValue n on pn.FirstNameID = n.MLSID and n.LanguageCode = '{0}' and n.Value LIKE N'{1}%'
";

        public static String QueryLikeLastName =
@"SELECT p.*
    FROM Person AS p 
    INNER JOIN PersonName pn ON p.CurrentNameID = pn.ID
    INNER JOIN MLSValue n on pn.LastNameID = n.MLSID and n.LanguageCode = '{0}' and n.Value LIKE N'{1}%'
";

        public static String QueryFirstAndLastName =
@"SELECT p.*
    FROM Person AS p 
    INNER JOIN PersonName pn ON p.CurrentNameID = pn.ID
    INNER JOIN MLSValue f on pn.FirstNameID = f.MLSID and f.LanguageCode = '{0}' and f.Value = N'{1}'
    INNER JOIN MLSValue l on pn.LastNameID = l.MLSID and l.LanguageCode = '{0}' and l.Value = N'{2}'
";

        public static IList<Person> FindLikeByName(Context context, bool isFirstName, String likeCustomerName)
        {
            ICriteria criteria = context.PersistenceSession.CreateCriteria<Person>();
            criteria.CreateAlias("CurrentName", "pname");
            if (isFirstName)
            {
                criteria.CreateAlias("pname.FirstName", "firstName")
                    .CreateAlias("firstName.Values", "vls")
                    .Add(Expression.Like("vls.Value", likeCustomerName, MatchMode.Start));
            }

            IList<Person> people = criteria.List<Person>();
            SetLanguage(context, people);

            return people;
            //String languageCode = context.CurrentLanguage.Code;
            //String query;

            //if (isFirstName)
            //    query = String.Format(QueryLikeFirstName, languageCode, likeCustomerName);
            //else
            //    query = String.Format(QueryLikeLastName, languageCode, likeCustomerName);

            //return context.PersistenceSession
            //                .CreateSQLQuery(query)
            //                .AddEntity("person", typeof(Person))
            //                .List<Person>();
        }

        public static IList<Person> FindByName(Context context, Language language, String firstName, String lastName)
        {
            String query = String.Format(QueryFirstAndLastName, language.Code, firstName, lastName);

            IList<Person> people = context.PersistenceSession
                            .CreateSQLQuery(query)
                            .AddEntity("person", typeof(Person))
                            .List<Person>();
            SetLanguage(context, people);
            return people;
        }

        #endregion

        #region Party Members

        public override MultilingualString MultilingualName
        {
            get
            {
                if (CurrentName == null) return null;
                return CurrentName.ToMultilingualString();
            }
        }

        public override string FullName
        {
            get
            {
                if (null == this.CurrentName)
                    return "-";
                if (null == base.Context)
                    return this.CurrentName.ToString();
                else
                    return this.CurrentName.ToString(base.Context.CurrentLanguage.Code);
            }
        }

        public virtual string NameWithoutAffixes
        {
            get
            {
                if (null == this.CurrentName)
                    return "-";
                return this.CurrentName.NameWithoutAffixes;
            }
        }

        #endregion Party Members

        #region IEqualityComparer<Person> Members

        public virtual bool Equals(Person x, Person y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(null, x) || Object.ReferenceEquals(null, y)) return false;
            return x.ID > 0 && x.ID == y.ID;
        }

        public virtual int GetHashCode(Person obj)
        {
            return obj.ID.GetHashCode();
        }

        #endregion

        //#region IHibernateEvent<Person> Members

        //public virtual bool SaveEvent(Context context)
        //{
        //    try
        //    {
        //        context.Persist(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return true;
        //}

        //public virtual bool UpdateEvent(Context context)
        //{
        //    try
        //    {
        //        this.UpdatedTS = DateTime.Now;
        //        context.PersistenceSession.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return true;
        //}

        //public virtual bool DeleteEvent(Context context)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public static Person GetEvent(Context context, int id)
        //{
        //    return (Person)context.PersistenceSession.Get(typeof(Person), id);
        //}
        //#endregion

        //public virtual Position FindCurrentImmediateSuperiorPosition()
        //{
        //    Position pos = null;
        //    foreach (var e in this.Appointments)
        //    {
        //        if (e.IsEffective)
        //        {
        //            pos = e.Position.FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(this);
        //            if (pos != null)
        //                break;
        //        }
        //    }
        //    return pos;
        //}

        //public virtual Position FindCurrentNonEmptySuperiorPositionNotAppointedToMe()
        //{
        //    Position pos = null;
        //    foreach (var e in this.Appointments)
        //    {
        //        if (e.IsEffective)
        //        {
        //            pos = e.Position.FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(this);
        //            break;
        //        }
        //    }
        //    return pos;
        //}

        //public virtual Position FindCurrentNonEmptyLeaveApproverPositionNotAppointedToMe()
        //{
        //    Position pos = null;
        //    foreach (var e in this.Appointments)
        //    {
        //        if (e.IsEffective)
        //        {
        //            pos = e.Position.FindCurrentNonEmptyLeaveApproverPositionNotAppointedTo(this);
        //            break;
        //        }
        //    }
        //    return pos;
        //}

        //public virtual bool IsImmediateSuperiorOf(Person person)
        //{
        //    Position pos = person.FindCurrentImmediateSuperiorPosition();
        //    foreach (var e in this.Appointments)
        //    {
        //        if (e.IsEffective && this == e.Person)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public virtual bool IsCurrentlyAppointedTo(Position position)
        //{
        //    foreach (var e in this.Appointments)
        //    {
        //        if (e.IsEffective && e.Position == position)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public virtual Position FindSuperiorPostion(string positionCategoryCode)
        //{
        //    Position position = null;
        //    foreach (var e in this.Appointments)
        //    {
        //        if (e.IsEffective && e.Position.IsEffective)
        //        {
        //            position = e.Position.FindCurrentSuperiorPosition(positionCategoryCode);
        //            if (position != null)
        //                break;
        //        }
        //    }
        //    return position;
        //}

        //public virtual TimeSchedule CurrentWorkSchedule
        //{
        //    get
        //    {
        //        TimeSchedule w = null;
        //        foreach (var e in this.WorkSchedules)
        //            if (e.IsEffective)
        //            {
        //                w = e.WorkSchedule;
        //                break;
        //            }
        //        return w;
        //    }
        //}

        public static Person FindByEmailAddress(Context context, string emailAddress)
        {
            Person person = context.PersistenceSession
                                            .QueryOver<Person>()
                                            .Where(e => e.EmailAddress == emailAddress)
                                            .SingleOrDefault();
            return person;
        }
    }
}
