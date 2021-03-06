using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    public class Subunit : InterOrgUnitRelation 
    {
        public Subunit()
        {
        }

        public Subunit(TreeListNode relationshipCategory, String code, String relationshipNo,
                                        int seqNo, int level, OrgUnit orgSrc, OrgUnit orgDst,
                                        DateTime effectiveDate, String reference, String remark)
            : base(code, effectiveDate, relationshipCategory, relationshipNo, orgSrc, orgDst, seqNo, level, reference, remark)
        {
        }

        #region persistent

        public virtual OrgUnit ParentUnit
        {
            get { return (OrgUnit)base.PrimaryParty; }
            set { base.PrimaryParty = value; }
        }
        public virtual OrgUnit ChildUnit
        {
            get { return (OrgUnit)base.SecondaryParty; }
            set { base.SecondaryParty = value; }
        }

        #endregion persistent

        public static IList<Subunit> GetChildrenEffectiveOnDate(Context context, OrgUnit orgUnitSrc, DateTime onDate)
        {
            return context.PersistenceSession
                            .QueryOver<Subunit>()
                            .Where(a => a.ChildUnit == orgUnitSrc
                                        && a.EffectivePeriod.From <= onDate
                                        && a.EffectivePeriod.To >= onDate)
                            .List();
        }

        public override void Persist(Context context)
        {
            if (this.ChildUnit != null && this.ChildUnit.ID == 0)
                this.ChildUnit.Persist(context);
            base.Persist(context);
        }

        public virtual Subunit FindCurrentSubunit(string pathTail)
        {
            if (string.IsNullOrEmpty(pathTail))
                return this;
            else
                return this.ChildUnit.FindCurrentSubunit(pathTail);
        }
    }
}
