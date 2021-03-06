using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public abstract class PartyRelation : PersistentTemporalEntity, ICategorizedTemporal
    {
        public PartyRelation()
        {

        }
        public PartyRelation(string code, DateTime effectiveDate, TreeListNode category, Party first, Party second, 
                            string relationshipNo, string reference, string remark)
            : base(effectiveDate, code, reference, remark)
        {
            this.Category = category;
            this.PrimaryParty = first;
            this.SecondaryParty = second;
            this.RelationshipNo = relationshipNo;
        }

        #region persistent

        public virtual TreeListNode Category { get; set; }
        public virtual string RelationshipNo { get; set; }
        protected virtual Party PrimaryParty { get; set; }
        protected virtual Party SecondaryParty { get; set; }

        #endregion persistent

        public virtual TreeListNode CategoryRoot
        {
            get
            {
                if (null == this.Category) return null;
                return this.Category.Root;
            }
            set { }
        }

        public override String ToString()
        {
            return this.PrimaryParty.ToString()
                + " " + this.SecondaryParty.ToString()
                +" " + this.EffectivePeriod.ToString()
                + " " + this.Category.Code;
        }
    }
}

