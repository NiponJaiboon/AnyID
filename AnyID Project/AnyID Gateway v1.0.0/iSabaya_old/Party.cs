using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public abstract class Party : PersistentTemporalEntity
    {
        public Party()
        {
        }
        public Party(DateTime effectiveDate)
            : base(effectiveDate)
        {
        }
        public Party(TimeInterval effectivePeriod)
            : base(effectivePeriod)
        {
        }

        public virtual Context Context { get; set; }

        //public virtual void AddressListModified(ICategorizedTemporalList<PartyAddress> sender, PartyAddress item)
        //{
        //}

        #region persistent

        protected ICategorizedTemporalList<PartyAddress> addresses;
        public virtual ICategorizedTemporalList<PartyAddress> Addresses
        {
            get
            {
                if (addresses == null)
                    addresses = new CategorizedTemporalList<PartyAddress>();
                return addresses;
            }
            set { addresses = value; }
        }

        protected ICategorizedTemporalList<PartyAttribute> attributes;
        public virtual ICategorizedTemporalList<PartyAttribute> Attributes
        {
            get
            {
                if (null == this.attributes)
                    this.attributes = new CategorizedTemporalList<PartyAttribute>();
                return attributes;
            }
            set { attributes = value; }
        }

        public virtual TreeListNode Category { get; set; }

        //protected ICategorizedTemporalList<PartyContact> contacts;
        //public virtual ICategorizedTemporalList<PartyContact> Contacts
        //{
        //    get
        //    {
        //        if (null == this.contacts)
        //            this.contacts = new CategorizedTemporalList<PartyContact>();
        //        return this.contacts;
        //    }
        //    set
        //    {
        //        this.contacts = value;
        //    }
        //}

        //protected IConstrainedList<PartyCreditRating> creditRatings;
        //public virtual IConstrainedList<PartyCreditRating> CreditRatings
        //{
        //    get
        //    {
        //        if (this.creditRatings == null)
        //            this.creditRatings = new ConstrainedList<PartyCreditRating>();
        //        return this.creditRatings;
        //    }
        //    set
        //    {
        //        this.creditRatings = value;
        //        if (null != value)
        //            this.creditRatings.SetEventHandler(OnAddingCreditRating, OnRemovingCreditRating);
        //    }
        //}

        //protected ICategorizedTemporalList<PartyIdentity> identities;
        //public virtual ICategorizedTemporalList<PartyIdentity> Identities
        //{
        //    get
        //    {
        //        if (identities == null)
        //            identities = new CategorizedTemporalList<PartyIdentity>();
        //        return identities;
        //    }
        //    set { identities = value; }
        //}

        //protected ICategorizedTemporalList<PartyImage> images;
        //public virtual ICategorizedTemporalList<PartyImage> Images
        //{
        //    get
        //    {
        //        if (this.images == null)
        //            this.images = new CategorizedTemporalList<PartyImage>();
        //        return this.images;
        //    }
        //    set { this.images = value; }
        //}

        //protected IList<PartyBankAccount> associatedBankAccounts;
        //public virtual IList<PartyBankAccount> AssociatedBankAccounts
        //{
        //    get
        //    {
        //        if (associatedBankAccounts == null)
        //            associatedBankAccounts = new List<PartyBankAccount>();
        //        return associatedBankAccounts;
        //    }
        //    set { associatedBankAccounts = value; }
        //}

        //protected ICategorizedTemporalList<PartyCategory> categories;
        //public virtual ICategorizedTemporalList<PartyCategory> Categories
        //{
        //    get
        //    {
        //        if (categories == null)
        //            categories = new CategorizedTemporalList<PartyCategory>();
        //        return categories;
        //    }
        //    set { categories = value; }
        //}

        //protected ICategorizedTemporalList<PartyMoneyRateSchedule> moneyRateSchedules;
        //public virtual ICategorizedTemporalList<PartyMoneyRateSchedule> MoneyRateSchedules
        //{
        //    get
        //    {
        //        if (moneyRateSchedules == null)
        //            moneyRateSchedules = new CategorizedTemporalList<PartyMoneyRateSchedule>();
        //        return moneyRateSchedules;
        //    }
        //    set { moneyRateSchedules = value; }
        //}

        //protected ITemporalList<PartyName> names;
        //public virtual ITemporalList<PartyName> Names
        //{
        //    get
        //    {
        //        if (names == null)
        //            names = new TemporalList<PartyName>();
        //        return names;
        //    }
        //    set { names = value; }
        //}

        //protected ITemporalList<PartyWorkSchedule> workSchedules;
        //public virtual ITemporalList<PartyWorkSchedule> WorkSchedules
        //{
        //    get
        //    {
        //        if (this.workSchedules == null)
        //            this.workSchedules = new TemporalList<PartyWorkSchedule>();
        //        return this.workSchedules;
        //    }
        //    set { this.workSchedules = value; }
        //}

        public virtual String OfficialIDNo { get; set; }

        #endregion persistent

        #region operations

        //public virtual IList<BankAccountOwner> GetBankAccounts(Context context, DateTime onDate)
        //{
        //    return context.PersistenceSession.CreateCriteria<BankAccountOwner>()
        //            .Add(Expression.Eq("Owner", this))
        //            .CreateAlias("BankAccount", "ba")
        //            .Add(Expression.Le("ba.EffectivePeriod.From", onDate))
        //            .Add(Expression.Ge("ba.EffectivePeriod.To", onDate))
        //            .List<BankAccountOwner>();
        //}

        public virtual IList<PartyAddress> GetCurrentAddresses()
        {
            return GetAddresses(DateTime.Now);
        }

        public virtual PartyAddress GetCurrentAddress(TreeListNode category)
        {
            return GetAddress(category, DateTime.Now);
        }

        public virtual IList<PartyAddress> GetAddresses(DateTime date)
        {
            IList<PartyAddress> list = new List<PartyAddress>();
            foreach (PartyAddress a in this.Addresses)
            {
                if (a.EffectivePeriod.Includes(date)) list.Add(a);
            }
            return list;
        }

        public virtual IList<PartyAddress> GetAddresses(TreeListNode category)
        {
            IList<PartyAddress> list = new List<PartyAddress>();
            foreach (PartyAddress a in this.Addresses)
            {
                if (a.Category == category) list.Add(a);
            }
            return list;
        }

        public virtual PartyAddress GetAddress(string categoryCode, DateTime date)
        {
            foreach (PartyAddress a in this.Addresses)
            {
                if (a.Category.Code == categoryCode && a.EffectivePeriod.Includes(date)) 
                    return a;
            }
            return null;
        }

        public virtual PartyAddress GetAddress(TreeListNode category, DateTime date)
        {
            foreach (PartyAddress a in this.Addresses)
            {
                if (a.Category == category && a.EffectivePeriod.Includes(date)) 
                    return a;
            }
            return null;
        }

        public virtual void AddAddress(PartyAddress newInstance)
        {
            //foreach (PartyAddress a in this.Addresses)
            //{
            //    if (a.Category.ID == newInstance.Category.ID)
            //    {
            //        //expire the existing one
            //        if (a.EffectivePeriod.To >= newInstance.EffectivePeriod.From)
            //            a.EffectivePeriod.To = newInstance.EffectivePeriod.From.Date.AddDays(-1);
            //    }
            //}
            this.Addresses.AddAfterExpiringEffectiveInstancesOfSameCategory(newInstance);
        }

        public virtual void AddAddress(TreeListNode category, GeographicAddress address, string description,
                                        string reference, string remark, TimeInterval effectivePeriod, User user)
        {
            //foreach (PartyAddress a in this.Addresses)
            //{
            //    if (a.Category.ID == category.ID)
            //    {
            //        //expire the existing one
            //        if (a.EffectivePeriod.To >= effectivePeriod.From)
            //            a.EffectivePeriod.To = effectivePeriod.From.Date.AddDays(-1);
            //    }
            //}
            this.Addresses.AddAfterExpiringEffectiveInstancesOfSameCategory(new PartyAddress(this, category, address, description,
                                                reference, remark, effectivePeriod, user));
        }

        //public virtual IList<PartyIdentity> GetCurrentIdentities()
        //{
        //    return GetIdentities(DateTime.Now);
        //}

        //public virtual PartyIdentity GetCurrentIdentity(TreeListNode category)
        //{
        //    return GetIdentity(category, DateTime.Now);
        //}

        //public virtual IList<PartyIdentity> GetIdentities(DateTime date)
        //{
        //    IList<PartyIdentity> list = new List<PartyIdentity>();
        //    foreach (PartyIdentity a in this.Identities)
        //    {
        //        if (a.EffectivePeriod.Includes(date)) list.Add(a);
        //    }
        //    return list;
        //}

        //public virtual IList<PartyIdentity> GetIdentities(TreeListNode category)
        //{
        //    IList<PartyIdentity> list = new List<PartyIdentity>();
        //    foreach (PartyIdentity a in this.Identities)
        //    {
        //        if (a.Category == category) list.Add(a);
        //    }
        //    return list;
        //}

        //public virtual PartyIdentity GetIdentity(TreeListNode category, DateTime date)
        //{
        //    foreach (PartyIdentity a in this.Identities)
        //    {
        //        if (a.Category == category && a.EffectivePeriod.Includes(date)) return a;
        //    }
        //    return null;
        //}

        //public virtual void AddIdentity(PartyIdentity newInstance)
        //{
        //    //foreach (PartyIdentity a in this.Identities)
        //    //{
        //    //    if (a.Category.ID == newInstance.Category.ID)
        //    //    {
        //    //        //expire the existing one
        //    //        if (a.EffectivePeriod.To >= newInstance.EffectivePeriod.From)
        //    //            a.EffectivePeriod.To = newInstance.EffectivePeriod.From.Date.AddDays(-1);
        //    //    }
        //    //}
        //    this.Identities.Add(newInstance);
        //}

        //public virtual void AddIdentity(TreeListNode category, string identityNo, string issuedBy,
        //                                string description, string reference, string remark,
        //                                TimeInterval effectivePeriod, User user)
        //{
        //    //foreach (PartyIdentity a in this.Identities)
        //    //{
        //    //    if (a.Category.ID == category.ID)
        //    //    {
        //    //        //expire the existing one
        //    //        if (a.EffectivePeriod.To >= effectivePeriod.From)
        //    //            a.EffectivePeriod.To = effectivePeriod.From.Date.AddDays(-1);
        //    //    }
        //    //}
        //    this.Identities.Add(new PartyIdentity(this, category, identityNo, issuedBy, description,
        //                                        reference, remark, effectivePeriod, user));
        //}

        //public virtual IList<PartyCategory> GetCurrentCategories()
        //{
        //    return GetCategories(DateTime.Now);
        //}

        //public virtual PartyCategory GetCurrentCategory(TreeListNode categoryRootNode)
        //{
        //    return GetCategory(categoryRootNode, DateTime.Now);
        //}

        //public virtual PartyCategory GetCurrentCategory(TreeListNode categoryRootNode, TreeListNode categoryParentNode)
        //{
        //    return GetCategory(categoryRootNode, categoryParentNode, DateTime.Now);
        //}

        //public virtual IList<PartyCategory> GetCategories(DateTime date)
        //{
        //    IList<PartyCategory> list = new List<PartyCategory>();
        //    foreach (PartyCategory a in this.Categories)
        //    {
        //        if (a.EffectivePeriod.Includes(date)) list.Add(a);
        //    }
        //    return list;
        //}

        //public virtual IList<PartyCategory> GetCategories(TreeListNode category)
        //{
        //    IList<PartyCategory> list = new List<PartyCategory>();
        //    foreach (PartyCategory a in this.Categories)
        //    {
        //        if (a.Category == category) list.Add(a);
        //    }
        //    return list;
        //}

        //public virtual PartyCategory GetCategory(TreeListNode categoryRootNode, DateTime date)
        //{
        //    foreach (PartyCategory a in this.Categories)
        //    {
        //        if (a.Category.Root == categoryRootNode && a.EffectivePeriod.Includes(date)) return a;
        //    }
        //    return null;
        //}

        //public virtual PartyCategory GetCategory(TreeListNode categoryRootNode, TreeListNode categoryParentNode, DateTime date)
        //{
        //    if (null == categoryRootNode)
        //    {
        //        foreach (PartyCategory a in this.Categories)
        //        {
        //            if (a.Category.Parent == categoryParentNode && a.EffectivePeriod.Includes(date)) return a;
        //        }
        //    }
        //    else
        //    {
        //        foreach (PartyCategory a in this.Categories)
        //        {
        //            if (a.Category.Root == categoryRootNode && a.EffectivePeriod.Includes(date)) return a;
        //        }
        //    }
        //    return null;
        //}

        //public virtual void AddCategory(PartyCategory newInstance)
        //{
        //    //foreach (PartyCategory a in this.Categories)
        //    //{
        //    //    if (a.CategoryRoot.ID == newInstance.CategoryRoot.ID)
        //    //    {
        //    //        //expire the existing one
        //    //        if (a.EffectivePeriod.To >= newInstance.EffectivePeriod.From)
        //    //            a.EffectivePeriod.To = newInstance.EffectivePeriod.From.Date.AddDays(-1);
        //    //    }
        //    //}
        //    this.Categories.Add(newInstance);
        //}

        //public virtual void AddCategory(TreeListNode category, string description, string reference, string remark,
        //                                TimeInterval effectivePeriod, User user)
        //{
        //    //foreach (PartyCategory a in this.Categories)
        //    //{
        //    //    if (a.Category.ID == category.ID)
        //    //    {
        //    //        //expire the existing one
        //    //        if (a.EffectivePeriod.To >= effectivePeriod.From)
        //    //            a.EffectivePeriod.To = effectivePeriod.From.Date.AddDays(-1);
        //    //    }
        //    //}
        //    this.Categories.Add(new PartyCategory(this, category, description,
        //                                        reference, remark, effectivePeriod, user));
        //}

        public virtual Type Type
        {
            get { return this.GetType(); }
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (object.ReferenceEquals(obj, this)) return true;
            if (obj.GetType().GetNestedType("Party") == typeof(Party)) return true;
            Party p = obj as Party;
            if (null == p) return false;
            return (p.GetHashCode() == this.GetHashCode());
        }

        public override void Persist(Context context)
        {
            context.Persist(this);
            foreach (PartyAddress a in this.Addresses)
            {
                a.Party = this;
                a.Persist(context);
            }
            foreach (PartyAttribute a in this.Attributes)
            {
                a.Party = this;
                a.Persist(context);
            }
            foreach (PartyIdentity a in this.Identities)
            {
                a.Party = this;
                a.Persist(context);
            }
            foreach (PartyImage a in this.Images)
            {
                a.Party = this;
                a.Persist(context);
            }
            //foreach (PartyMoneyRateSchedule a in this.MoneyRateSchedules)
            //{
            //    a.Party = this;
            //    a.Persist(context);
            //}
            //foreach (PartyBankAccount a in this.AssociatedBankAccounts)
            //{
            //    a.Party = this;
            //    a.Persist(context);
            //}
            foreach (var a in this.WorkSchedules)
            {
                a.Party = this;
                a.Persist(context);
            }
        }

        public abstract MultilingualString MultilingualName { get; }

        public abstract String FullName { get; }

        #endregion operations

        #region static

        //public static bool OnAddingCreditRating(IConstrainedList<PartyCreditRating> list, PartyCreditRating item)
        //{
        //    bool success = false;
        //    return success;
        //}

        //public static bool OnRemovingCreditRating(IConstrainedList<PartyCreditRating> list, PartyCreditRating item)
        //{
        //    bool success = false;
        //    return success;
        //}

        //public static Party FindByIdentity(TreeListNode identityCategory, string identityNo, Context context)
        //{
        //    PartyIdentity pid = context.PersistenceSession.QueryOver<PartyIdentity >()
        //        .Where(e => e.Category == identityCategory && e.IdentityNo == identityNo)
        //        .SingleOrDefault();
        //    return pid.Party;
        //}

        #endregion static
    }
}