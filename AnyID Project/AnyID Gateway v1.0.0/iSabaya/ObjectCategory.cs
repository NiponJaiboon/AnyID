using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;


namespace iSabaya
{
    public class ObjectCategory 
    {
        public ObjectCategory()
        {
        }

        /*
         *  ObjectDiscriminator
            1=Person
            2=Organization
            3=InvestmentPlanner
            4=SellingAgent
            5=Account
         */
        public ObjectCategory(Object obj, TreeListNode category, string value, int rank, 
                            string reference, string remark, TimeInterval effectivePeriod, User updatedBy)
        {
            this.obj = obj;
            this.category = category;
            this.value = value;
            this.rank = rank;
            this.reference = reference;
            this.remark = remark;
            this.effectivePeriod = effectivePeriod;
            this.updatedBy = updatedBy;
        }

        #region persistent

        private int objectCategoryID;
        public virtual int ObjectCategoryID
        {
            get { return objectCategoryID; }
            set { objectCategoryID = value; }
        }

        protected object obj;
        public virtual object Obj
        {
            get { return obj; }
            set { obj = value; }
        }

        protected TreeListNode category;
        public virtual TreeListNode Category
        {
            get { return category; }
            set { category = value; }
        }

        protected int rank = 0;
        public virtual int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        protected string value;
        public virtual string Value
        {
            get { return this.value; }
            set { this.value = value; }
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
            context.Persist(this);    
        }

        public static ObjectCategory FindByCode(Context context, string treeListNodeCode, Type type)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(ObjectCategory));
            TreeListNode node = TreeListNode.FindByCode(context, treeListNodeCode);
            crit.Add(Expression.Eq("Pk.Category", node));
            crit.Add(Expression.Eq("Pk.Discriminator", getDiscriminatorByType(type)));
            return crit.UniqueResult<ObjectCategory>();
        }

        private static String getDiscriminatorByType(Type type)
        {
           
            String discriminator = "";
            if (type.Equals(typeof(Person)))
            {
                discriminator = "1";
            }
            else if (type.Equals(typeof(Organization)))
            {
                discriminator = "2";
            }
            return discriminator;
        }

        public virtual string ToLog()
        {
            return "";
        }

       

    }
} 
