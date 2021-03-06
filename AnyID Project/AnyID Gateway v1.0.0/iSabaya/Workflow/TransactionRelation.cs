using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    [Serializable]
    public abstract class TransactionRelation
    {
        public TransactionRelation()
        {
        }

        public TransactionRelation(StatefulTransaction child, String relationType)
        {
            this.parent = null;
            this.child = child;
            this.relationType = relationType;
        }

        public TransactionRelation(StatefulTransaction parent, StatefulTransaction child, int seqNo, String relationType)
        {
            this.parent = parent;
            this.child = child;
            this.relationType = relationType;
            this.seqNo = seqNo;
        }

        #region persistent

        //protected FundTransaction parent;
        //protected FundTransaction child;

        protected StatefulTransaction parent;
        public virtual StatefulTransaction Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        protected StatefulTransaction child;
        public virtual StatefulTransaction Child
        {
            get { return child; }
            set { child = value; }
        }

        protected int relationID;
        public virtual int RelationID
        {
            get { return relationID; }
            set { relationID = value; }
        }

        protected int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        protected double units;
        public virtual double Units
        {
            get { return units; }
            set { units = value; }
        }

        protected Money unitPrice;
        public virtual Money UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        protected Money amount;
        public virtual Money Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        //protected TreeListNode relationCategory;
        //public virtual TreeListNode RelationCategory
        //{
        //    get { return relationCategory; }
        //    set { relationCategory = value; }
        //}

        protected String relationType = "";
        public virtual String RelationType
        {
            get { return relationType; }
            set { relationType = value; }
        }

        #endregion persistent

        public virtual void Persist(Context context)
        {
            //if (null == this.Parent)
            //    throw new iSabayaException(Messages.TransactionRelationWithNullParent);
            //if (null != this.Child && this.Child.IsToBeSaved)
            //{
            //    this.Child.IsToBeSaved = false;
            //    this.Child.Persist(context);
            //}
            context.PersistenceSession.SaveOrUpdate(this);
        }
    }
}

