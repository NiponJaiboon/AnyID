using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    public class InterOrgRelation
    {
        public InterOrgRelation()
        {
        }

        public InterOrgRelation(TreeListNode relationshipCategory, String code, String relationshipNo,
                                int seqNo, int level, OrgBase orgSrc, OrgBase orgDst, 
                                DateTime effectiveDate, String reference, String remark, User updatedBy)
        {
            this.code = code;
            this.relationshipNo = relationshipNo;
            this.relationshipCategory = relationshipCategory;
            this.seqNo = seqNo;
            this.level = level;
            this.orgSrc = orgSrc;
            this.orgDst = orgDst;
            this.effectivePeriod = new TimeInterval(effectiveDate);
            this.reference = reference;
            this.remark = remark;
            this.updatedBy = updatedBy;
        }

        #region persistent

        protected string code;
        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        private OrgBase orgDst;
        public virtual OrgBase OrgDst
        {
            get { return orgDst; }
            set { orgDst = value; }
        }

        private int orgOrgRelationID;
        public virtual int OrgOrgRelationID
        {
            get { return orgOrgRelationID; }
            set { orgOrgRelationID = value; }
        }

        private OrgBase orgSrc;
        public virtual OrgBase OrgSrc
        {
            get { return orgSrc; }
            set { orgSrc = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        protected int level;
        public virtual int Level
        {
            get { return level; }
            set { level = value; }
        }

        private TreeListNode relationshipCategory;
        public virtual TreeListNode RelationshipCategory
        {
            get { return relationshipCategory; }
            set { relationshipCategory = value; }
        }

        protected string relationshipNo;
        public virtual string RelationshipNo
        {
            get { return relationshipNo; }
            set { relationshipNo = value; }
        }

        protected string reference;
        public virtual string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        protected string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        protected int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        protected User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        #endregion persistent

        public virtual void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }

        public static InterOrgRelation GetRelationCurrentOf(Context context, TreeListNode relationshipCategory, Person person, DateTime dateTime)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<InterOrgRelation>();
            crit.Add(Expression.Eq("RelationshipCategory", relationshipCategory));
            crit.Add(Expression.Eq("Person", person));           
            addEffectiveCriteria(crit);
            return crit.UniqueResult<InterOrgRelation>();
        }

        private static void addEffectiveCriteria(ICriteria crit)
        {
            crit.Add(Expression.Le("EffectivePeriod.From", DateTime.Now));
            crit.Add(Expression.Ge("EffectivePeriod.To", DateTime.Now));
        }

        public static InterOrgRelation FindCurrent(Context context, Person person)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<InterOrgRelation>();
            crit.Add(Expression.Eq("Person", person));
            addEffectiveCriteria(crit);
            return crit.UniqueResult<InterOrgRelation>();
        }
    }
} 
