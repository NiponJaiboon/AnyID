using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    public class PersonOrgRelation : PartyRelation
    {
        public PersonOrgRelation()
        {
        }

        public PersonOrgRelation(string code, DateTime effectiveDate, TreeListNode relationshipCategory, Person person, OrgBase org,
                                String relationshipNo, String reference, String remark)
            : base(code, effectiveDate, relationshipCategory, person, org, relationshipNo, reference, remark)
        {
        }

        public PersonOrgRelation(String code, DateTime effectiveDate, TreeListNode relationshipCategory, MultilingualString title,
                                MultilingualString shortTitle, MultilingualString description,
                                String relationshipNo, int seqNo, int level, Person person, OrgBase org, 
                                String reference, String remark, User updatedBy)
            : base(code, effectiveDate, relationshipCategory, person, org, relationshipNo, reference, remark)
        {
            this.SeqNo = seqNo;
            this.Level = level;
        }

        #region persistent

        public virtual Person Person
        {
            get { return (Person)base.PrimaryParty; }
            set { base.PrimaryParty = value; }
        }
        protected virtual OrgBase Org
        {
            get { return (OrgBase)base.SecondaryParty; }
            set { base.SecondaryParty = value; }
        }
        public virtual int SeqNo { get; set; }
        public virtual int Level { get; set; }

        #endregion persistent

        //public static IList<PersonOrgRelation> List(Context context, Organization org, DateTime onDate)
        //{
        //    return context.PersistenceSession.QueryOver<PersonOrgRelation>()
        //                    .Where(a => a.Org as Organization == org
        //                            && a.EffectivePeriod.From <= onDate
        //                            && a.EffectivePeriod.To >= onDate)
        //                    .List<PersonOrgRelation>();
        //}

        //public static IList<PersonOrgRelation> List(Context context, TreeListNode category, Organization org, DateTime onDate)
        //{
        //    return context.PersistenceSession.QueryOver<PersonOrgRelation>()
        //                    .Where(a => a.Category == category
        //                            && a.Org as Organization == org
        //                            && a.EffectivePeriod.From <= onDate
        //                            && a.EffectivePeriod.To >= onDate)
        //                    .List<PersonOrgRelation>();
        //}

        //public static IList<PersonOrgRelation> List(Context context, TreeListNode category, Organization org, OrgUnit orgUnit, DateTime onDate)
        //{
        //    AbstractCriterion orgUnitExp = orgUnit == null ? Expression.IsNull("OrgUnit") : Expression.Eq("OrgUnit", orgUnit);
        //    return context.PersistenceSession.CreateCriteria<PersonOrgRelation>()
        //                    .Add(Expression.Eq("Category", category))
        //                    .Add(Expression.Eq("Organization", org))
        //                    .Add(orgUnitExp)
        //                    .Add(Expression.Le("EffectivePeriod.From", onDate))
        //                    .Add(Expression.Ge("EffectivePeriod.To", onDate))
        //                    .List<PersonOrgRelation>();
        //}

        //public static IList<PersonOrgRelation> List(Context context, Person person)
        //{
        //    return context.PersistenceSession.QueryOver<PersonOrgRelation>()
        //                    .Where(a => a.Person == person)
        //                    .List<PersonOrgRelation>();
        //}

        //public static IList<PersonOrgRelation> List(Context context, Person person, DateTime onDate)
        //{
        //    return context.PersistenceSession.QueryOver<PersonOrgRelation>()
        //                    .Where(a => a.Person == person
        //                            && a.EffectivePeriod.From <= onDate
        //                            && a.EffectivePeriod.To >= onDate)
        //                    .List<PersonOrgRelation>();
        //}

        //public static IList<PersonOrgRelation> List(Context context, TreeListNode category, Person person, DateTime onDate)
        //{
        //    return context.PersistenceSession
        //                    .QueryOver<PersonOrgRelation>()
        //                    .Where(a => a.Category == category
        //                            && a.Person == person
        //                            && a.EffectivePeriod.From <= onDate
        //                            && a.EffectivePeriod.To >= onDate)
        //                    .List<PersonOrgRelation>();
        //}
    }
}
