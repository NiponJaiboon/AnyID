using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    public class InterPositionRelation : PersistentTemporalEntity
    {
        public InterPositionRelation()
        {
        }

        public InterPositionRelation(string code, DateTime effectiveDate, TreeListNode category, Position primaryPosition, Position secondaryPosition,
                                        string relationshipNo, string reference, string remark)
            : base(effectiveDate, code, reference, remark)
        {
            this.PrimaryPosition = primaryPosition;
            this.SecondaryPosition = secondaryPosition;
            this.RelationshipNo = relationshipNo;
        }

        public InterPositionRelation(TimeInterval effectivePeriod, TreeListNode category, OrgUnitPosition primaryPosition, OrgUnitPosition secondaryPosition)
        {
            if (primaryPosition == null || secondaryPosition == null)
                throw new Exception("superiorPosition == null || subordinatePosition == null");
            this.EffectivePeriod = effectivePeriod;
            this.PrimaryPosition = primaryPosition.Position;
            this.SecondaryPosition = secondaryPosition.Position;
        }

        //public InterPositionRelation(string code, DateTime effectiveDate, TreeListNode category, Position primaryPosition, Position secondaryPosition, 
        //                                string relationshipNo, string reference, string remark)
        //    : this(code, effectiveDate, primaryPosition, secondaryPosition, relationshipNo, reference, remark)
        //{
        //    this.Category = category;
        //}

        public InterPositionRelation(TreeListNode relationshipCategory, String code, String relationshipNo,
                                int seqNo, int level, Position primaryPosition, Position secondaryPosition,
                                DateTime effectiveDate, String reference, String remark)
            : this(code, effectiveDate, relationshipCategory, primaryPosition, secondaryPosition, relationshipNo, reference, remark)
        {
            this.SeqNo = seqNo;
            this.Level = level;
        }

        #region persistent

        public virtual string RelationshipNo { get; set; }
        public virtual TreeListNode Category { get; set; }
        public virtual Position PrimaryPosition { get; set; }
        public virtual Position SecondaryPosition { get; set; }
        public virtual int Level { get; set; }
        public virtual int SeqNo { get; set; }

        public virtual TreeListNode CategoryRoot
        {
            get
            {
                if (null == this.Category) return null;
                return this.Category.Root;
            }
            set { }
        }

        #endregion persistent

        public static IList<InterPositionRelation> GetCurrentScecondaryPositions(Context context, TreeListNode relationshipCategory, Position primaryPosition, DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            return GetScecondaryPositions(context, relationshipCategory, primaryPosition, now);
        }

        public static IList<InterPositionRelation> GetScecondaryPositions(Context context, TreeListNode relationshipCategory, Position primaryPosition, DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                            .QueryOver<InterPositionRelation>()            
                            .Where(e => e.Category == relationshipCategory
                                        && e.PrimaryPosition ==primaryPosition
                                        && e.EffectivePeriod.From <= dateTime
                                        && dateTime <= e.EffectivePeriod.To)
                            .List();
        }
    }
}
