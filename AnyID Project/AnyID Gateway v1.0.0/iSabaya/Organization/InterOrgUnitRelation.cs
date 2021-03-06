using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    public abstract class InterOrgUnitRelation : PartyRelation
    {
        public InterOrgUnitRelation()
        {
        }

        public InterOrgUnitRelation(String code, DateTime effectiveDate, TreeListNode relationshipCategory, String relationshipNo,
                                    OrgUnit orgSrc, OrgUnit orgDst, int seqNo, int level, String reference, String remark)
            : base(code, effectiveDate, relationshipCategory, orgSrc, orgDst, relationshipNo, reference, remark)
        {
            this.SeqNo = seqNo;
            this.Level = level;
        }

        #region persistent

        public virtual int Level { get; set; }
        public virtual int SeqNo { get; set; }

        #endregion persistent

        public static IList<InterOrgUnitRelation> GetChildrenOnDate(Context context, OrgUnit orgUnitSrc, DateTime onDate)
        {
            return context.PersistenceSession
                            .QueryOver<InterOrgUnitRelation>()
                            .Where(a => a.SecondaryParty == orgUnitSrc
                                        && a.EffectivePeriod.From <= onDate
                                        && a.EffectivePeriod.To >= onDate)
                            .List();
        }
    }
}
