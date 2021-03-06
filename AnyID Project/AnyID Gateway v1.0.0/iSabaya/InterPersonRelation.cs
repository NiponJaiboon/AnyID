using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    public class InterPersonRelation : PartyRelation
    {
        public InterPersonRelation()
        {
        }

        public InterPersonRelation(TreeListNode relationshipCategory, String code, String relationshipNo,
                                int seqNo, int level, Person primaryPerson, Person secondaryPerson,
                                DateTime effectiveDate, String reference, String remark)
            : base(code, effectiveDate, relationshipCategory, primaryPerson, secondaryPerson, relationshipNo, reference, remark)
        {
            this.SeqNo = seqNo;
            this.Level = level;
        }

        #region persistent

        public virtual Person PrimaryPerson
        {
            get { return (Person)base.PrimaryParty; }
            set { base.PrimaryParty = value; }
        }
        public virtual Person SecondaryPerson
        {
            get { return (Person)base.SecondaryParty; }
            set { base.SecondaryParty = value; }
        }
        public virtual int Level { get; set; }
        public virtual int SeqNo { get; set; }

        #endregion persistent

        public static IList<InterPersonRelation> GetCurrentScecondaryPersons(Context context, TreeListNode relationshipCategory, Person primaryPerson, DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            return GetScecondaryPersons(context, relationshipCategory, primaryPerson, now);
        }

        public static IList<InterPersonRelation> GetScecondaryPersons(Context context, TreeListNode relationshipCategory, Person primaryPerson, DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                            .QueryOver<InterPersonRelation>()
                            .Where(e => e.Category == relationshipCategory
                                        && e.PrimaryPerson == primaryPerson
                                        && e.EffectivePeriod.From <= dateTime
                                        && dateTime <= e.EffectivePeriod.To)
                            .List();
        }
    }
}
