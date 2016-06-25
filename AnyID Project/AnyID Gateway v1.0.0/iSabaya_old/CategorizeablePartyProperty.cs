using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public abstract class CategorizeablePartyProperty : PartyTemporalPropertyBase
    {
        #region constructors

        public CategorizeablePartyProperty()
        {
        }

        public CategorizeablePartyProperty(CategorizeablePartyProperty original, User user)
            : base(original, user)
        {
            this.Category = original.Category;
            this.isDefault = original.IsDefault;
            this.valueNode = original.ValueNode;
            this.valueDate = original.ValueDate;
            this.valueMLS = original.ValueMLS;
            this.valueNode = original.ValueNode;
            this.valueNumber = original.ValueNumber;
            this.valueString = original.ValueString;
        }

        public CategorizeablePartyProperty(Party party, TreeListNode category,
                                            string description, string reference, string remark,
                                            TimeInterval effectivePeriod, User user)
            : base(party, description, reference, remark, effectivePeriod, user)
        {
            this.Category = category;
        }

        #endregion constructors

        #region persistent

        public virtual TreeListNode CategoryRoot
        {
            get { return this.Category == null ? null : this.Category.Root; }
            set { }
        }

        public virtual TreeListNode CategoryParent
        {
            get { return this.Category == null ? null : this.Category.Parent; }
            set { }
        }

        public virtual TreeListNode Category { get; set; }

        protected TreeListNode valueNodeRoot;
        public virtual TreeListNode ValueNodeRoot
        {
            get { return valueNodeRoot; }
            set { valueNodeRoot = value; }
        }

        protected TreeListNode valueNode;
        public virtual TreeListNode ValueNode
        {
            get { return valueNode; }
            set
            {
                valueNode = value;
                if (null == value) return;
                valueNodeRoot = valueNode.Root;
            }
        }

        protected DateTime valueDate = TimeInterval.MinDate;
        public virtual DateTime ValueDate
        {
            get { return valueDate; }
            set { valueDate = value; }
        }

        protected float valueNumber;
        public virtual float ValueNumber
        {
            get { return valueNumber; }
            set { valueNumber = value; }
        }

        protected MultilingualString valueMLS;
        public virtual MultilingualString ValueMLS
        {
            get { return valueMLS; }
            set { valueMLS = value; }
        }

        protected String valueString;
        public virtual String ValueString
        {
            get { return valueString; }
            set { this.valueString = value; }
        }

        #endregion persistent

        public virtual String CategoryName
        {
            get { return Category.Title.ToString(); }
        }

        public override void Persist(Context context)
        {
            if (null != ValueMLS)
                ValueMLS.Persist(context);

            //if (this.EffectivePeriod.IsEmpty())
            //{
            //    context.PersistenceSession.Delete(this);
            //    return;
            //}
            context.PersistenceSession.SaveOrUpdate(this);
        }

        public override String ToString(String languageCode)
        {
            return Category.Title.ToString(languageCode);
        }
    }
}
