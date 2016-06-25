using System;
using System.Globalization;
using NHibernate;
using log4net;

namespace iSabaya
{
    public delegate ISessionFactory SessionFactoryCreatorDelegate();
    public delegate ILog LogCreatorDelegate();


    public class Configuration
    {
        public static SessionFactoryCreatorDelegate SessionFactoryCreator;

        private static ISessionFactory sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null && SessionFactoryCreator != null)
                    sessionFactory = SessionFactoryCreator();
                return sessionFactory;
            }
        }
#if Debug
        public static Configuration CurrentConfiguration { get; protected set; }
#else
        public static Configuration CurrentConfiguration { get; set; }
#endif

        private static CultureInfo thaiCulture;
        public static CultureInfo ThaiCulture
        {
            get
            {
                if (null == thaiCulture)
                    thaiCulture = CultureInfo.GetCultureInfo("th-TH");
                return thaiCulture;
            }
        }

        public static iSystem MySystem { get; set; }

        #region persistent

        public virtual int ID { get; set; }
        public virtual int SystemID { get; set; }

        /// <summary>
        /// The default number of fraction digits is 4.
        /// This property defines extra digits over the defualt.
        /// The number of fraction digits is 4 + this value.
        /// </summary>
        public virtual int NumberOfExtraFractionDigitsOfMoney { get; set; }
        public virtual OrganizationConfig Organization { get; set; }
        public virtual PersonConfig Person { get; set; }
        public virtual SecurityConfig Security { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }
        public virtual TreeListNode BankAccountCategoryRootNode { get; set; }
        public virtual TreeListNode BankOrgCategoryNode { get; set; }
        //public virtual MoneyRateSchedule CapitalGainTaxSchedule { get; set; }
        public virtual String ChequeNoToStringFormat { get; set; }
        public virtual TreeListNode ContactCategoryRootNode { get; set; }
        public virtual TreeListNode CountryParentNode { get; set; }
        //public virtual Country DefaultCountry { get; set; }
        public virtual Currency DefaultCurrency { get; set; }
        public virtual Language DefaultLanguage { get; set; }
        public virtual TreeListNode DefaultNationality { get; set; }
        //public virtual MoneyRateSchedule IncomeTaxSchedule { get; set; }
        public virtual TreeListNode NationalityParentNode { get; set; }
        public virtual TreeListNode GeographicAddressCategoryRootNode { get; set; }
        public virtual TreeListNode PartyContactCategoryRootNode { get; set; }
        public virtual TreeListNode PartyIdentityCategoryRootNode { get; set; }
        public virtual TreeListNode IdentityCategoryRootNode { get; set; }
        public virtual TreeListNode RelationshipCategoryParentNode { get; set; }
        /// <summary>
        /// Percentage
        /// </summary>
        public virtual double SalesTaxRate { get; set; }
        //public virtual MoneyRateSchedule SalesTaxSchedule { get; set; }
        public virtual TreeListNode ScheduleCategoryParentNode { get; set; }
        /// <summary>
        /// Percentage
        /// </summary>
        public virtual double ServiceTaxRate { get; set; }
        public virtual Organization SystemOwnerOrg { get; set; }

        public virtual TreeListNode TaxScheduleCategoryRootNode { get; set; }
        /// <summary>
        /// Percentage
        /// </summary>
        public virtual double WithholdDividendTaxRate { get; set; }
        /// <summary>
        /// Percentage
        /// </summary>
        public virtual double WithholdSalesTaxRate { get; set; }
        /// <summary>
        /// Percentage
        /// </summary>
        public virtual double WithholdServiceTaxRate { get; set; }
        public virtual TimeSchedule WorkCalendar { get; set; }
        public virtual TimeSchedule NonworkCalendar { get; set; }

        #endregion persistent

        //public virtual Configuration ShallowClone()
        //{
        //    Configuration clone = new Configuration();

        //    if (null != this.Person) clone.Person = this.Person.ShallowClone();
        //    if (null != this.Organization) this.Organization.ShallowClone();
        //    if (null != this.Security) clone.Security = this.Security.ShallowClone();
        //    if (null != this.GeographicAddressCategoryRootNode) this.GeographicAddressCategoryRootNode.ID;
        //    if (null != BankAccountCategoryRootNode) BankAccountCategoryRootNode.ID;
        //    if (null != BankOrgCategoryNode) BankOrgCategoryNode.ID;
        //    if (null != CapitalGainTaxSchedule) CapitalGainTaxSchedule.Persist(context);
        //    if (null != ContactCategoryRootNode) ContactCategoryRootNode.ID;
        //    if (null != CountryParentNode) CountryParentNode.ID;
        //    if (null != DefaultCountry) DefaultCountry.ID;
        //    if (null != DefaultCurrency) DefaultCurrency.ID;
        //    if (null != DefaultLanguage) DefaultLanguage.ID;
        //    if (null != DefaultNationality) DefaultNationality.ID;
        //    if (null != IncomeTaxSchedule) IncomeTaxSchedule.Persist(context);
        //    if (null != NationalityParentNode) NationalityParentNode.ID;
        //    if (null != GeographicAddressCategoryRootNode) GeographicAddressCategoryRootNode.ID;
        //    if (null != PartyIdentityCategoryRootNode) PartyIdentityCategoryRootNode.ID;
        //    if (null != PartyContactCategoryRootNode) PartyContactCategoryRootNode.ID;
        //    if (null != IdentityCategoryRootNode) IdentityCategoryRootNode.ID;
        //    if (null != RelationshipCategoryParentNode) RelationshipCategoryParentNode.ID;
        //    if (null != SalesTaxSchedule) SalesTaxSchedule.Persist(context);
        //    if (null != ScheduleCategoryParentNode) ScheduleCategoryParentNode.ID;
        //    if (null != SequenceNumberGeneratingRule) SequenceNumberGeneratingRule.ID;
        //    if (null != SystemOwnerOrg) SystemOwnerOrg.Persist(context);
        //    if (null != WorkCalendar) WorkCalendar.ID;
        //    if (null != NonworkCalendar) NonworkCalendar.ID;
        //    if (null != TaxScheduleCategoryRootNode) TaxScheduleCategoryRootNode.ID;
        //}

        public virtual void Persist(Context context)
        {
            if (null != this.Person) this.Person.Persist(context);
            if (null != this.Organization) this.Organization.Persist(context);
            //if (null != this.Security) this.Security.Persist(context);
            if (null != this.GeographicAddressCategoryRootNode && this.GeographicAddressCategoryRootNode.ID == 0) this.GeographicAddressCategoryRootNode.Persist(context);
            if (null != BankAccountCategoryRootNode && this.BankAccountCategoryRootNode.ID == 0) BankAccountCategoryRootNode.Persist(context);
            if (null != BankOrgCategoryNode && this.BankOrgCategoryNode.ID == 0) BankOrgCategoryNode.Persist(context);
            //if (null != CapitalGainTaxSchedule && CapitalGainTaxSchedule.ID == 0) CapitalGainTaxSchedule.Persist(context);
            if (null != ContactCategoryRootNode && ContactCategoryRootNode.ID == 0) ContactCategoryRootNode.Persist(context);
            if (null != CountryParentNode && CountryParentNode.ID == 0) CountryParentNode.Persist(context);
            //if (null != DefaultCountry) DefaultCountry.Persist(context);
            if (null != DefaultCurrency) DefaultCurrency.Persist(context);
            if (null != DefaultLanguage) DefaultLanguage.Persist(context);
            if (null != DefaultNationality) DefaultNationality.Persist(context);
            //if (null != IncomeTaxSchedule) IncomeTaxSchedule.Persist(context);
            if (null != NationalityParentNode && NationalityParentNode.ID == 0) NationalityParentNode.Persist(context);
            if (null != GeographicAddressCategoryRootNode && GeographicAddressCategoryRootNode.ID == 0) GeographicAddressCategoryRootNode.Persist(context);
            if (null != PartyIdentityCategoryRootNode && PartyIdentityCategoryRootNode.ID == 0) PartyIdentityCategoryRootNode.Persist(context);
            if (null != PartyContactCategoryRootNode && PartyContactCategoryRootNode.ID == 0) PartyContactCategoryRootNode.Persist(context);
            if (null != IdentityCategoryRootNode && IdentityCategoryRootNode.ID == 0) IdentityCategoryRootNode.Persist(context);
            if (null != RelationshipCategoryParentNode && RelationshipCategoryParentNode.ID == 0) RelationshipCategoryParentNode.Persist(context);
            //if (null != SalesTaxSchedule && SalesTaxSchedule.ID == 0) SalesTaxSchedule.Persist(context);
            if (null != ScheduleCategoryParentNode && ScheduleCategoryParentNode.ID == 0) ScheduleCategoryParentNode.Persist(context);
            if (null != SystemOwnerOrg && SystemOwnerOrg.ID == 0) SystemOwnerOrg.Persist(context);
            if (null != WorkCalendar && WorkCalendar.ID == 0) WorkCalendar.Persist(context);
            if (null != NonworkCalendar && NonworkCalendar.ID == 0) NonworkCalendar.Persist(context);
            if (null != TaxScheduleCategoryRootNode && TaxScheduleCategoryRootNode.ID == 0) TaxScheduleCategoryRootNode.Persist(context);

            context.Persist(this);
        }
    }
}