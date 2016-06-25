//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Collections;
//using NHibernate;
//using NHibernate.Criterion;

//namespace iSabaya
//{
//
//    public class Relation 
//    {
//        public Relation()
//        {
//        }

//        public Relation(Relationship relationship, TreeListNode category, IRelatable firstEntity, IRelatable secondEntity,
//                        object info, string reference, string remark, TimeInterval effectivePeriod)
//        {
//            if (relationship.IsPermanent)
//                this.effectivePeriod = TimeInterval.Eternal;
//            else if (effectivePeriod == null)
//                throw new iSabayaException("Relation.Relation(): Effective period must not be null for transient relationship.");
//            else
//                this.effectivePeriod = effectivePeriod;
//            this.category = category;
//            this.firstEntity = firstEntity;
//            this.secondEntity = secondEntity;
//            this.info = info;
//            this.reference = reference;
//            this.remark = remark;
//            this.Relationship = relationship;
//        }

//        #region persistent

//        protected int relationID;
//        public virtual int RelationID
//        {
//            get { return relationID; }
//            set { this.relationID = value; }
//        }

//        protected Relationship relationship;
//        public virtual Relationship Relationship
//        {
//            get { return relationship; }
//            set
//            {
//                this.relationship = value;
//                if (null != value && !value.Verify(this))
//                    throw new iSabayaException("Relation.Relationship.Set: one or both entities are not of the types specified in the relationship.");
//            }
//        }

//        protected TreeListNode category;
//        public virtual TreeListNode Category
//        {
//            get { return category; }
//            set { this.category = value; }
//        }

//        protected Object firstEntity;
//        public virtual Object FirstEntity
//        {
//            get { return firstEntity; }
//            set { firstEntity = value; }
//        }

//        protected Object secondEntity;
//        public virtual Object SecondEntity
//        {
//            get { return secondEntity; }
//            set { secondEntity = value; }
//        }
//        //protected String firstEntityType;
//        //public virtual String FirstEntityType
//        //{
//        //    get { return firstEntityType; }
//        //    set { this.firstEntityType = value; }
//        //}

//        //protected String secondEntityType;
//        //public virtual String SecondEntityType
//        //{
//        //    get { return secondEntityType; }
//        //    set { this.secondEntityType = value; }
//        //}

//        //protected int firstEntityId;
//        //public virtual int FirstEntityId
//        //{
//        //    get { return firstEntityId; }
//        //    set { this.firstEntityId = value; }
//        //}

//        //protected int secondEntityId;
//        //public virtual int SecondEntityId
//        //{
//        //    get { return secondEntityId; }
//        //    set { this.secondEntityId = value; }
//        //}

//        protected TimeInterval effectivePeriod;
//        public virtual TimeInterval EffectivePeriod
//        {
//            get { return effectivePeriod; }
//            set { this.effectivePeriod = value; }
//        }

//        protected object info;
//        public virtual object Info
//        {
//            get { return info; }
//            set { this.info = value; }
//        }

//        protected DateTime recordedDate = DateTime.Now;
//        public virtual DateTime RecordedDate
//        {
//            get { return recordedDate; }
//            set { this.recordedDate = value; }
//        }

//        protected string remark;
//        public virtual string Remark
//        {
//            get { return remark; }
//            set { this.remark = value; }
//        }

//        protected string reference;
//        public virtual string Reference
//        {
//            get { return reference; }
//            set { this.reference = value; }
//        }

//        #endregion persistent

//        public virtual void Persist(Context context)
//        {
//            context.PersistenceSession.SaveOrUpdate(this);
//        }

//        public override string ToString()
//        {
//            StringBuilder builder = new StringBuilder();

//            builder.Append("Relation ");
//            builder.Append(RelationID);

//            if (firstEntity != null)
//                builder.Append(": ").Append(firstEntity.ToString());
//            else
//                builder.Append(": null");

//            if (secondEntity != null)
//                builder.Append(" - ").Append(secondEntity.ToString());
//            else
//                builder.Append(" - null");

//            if (category != null)
//                builder.Append(", category ").Append(category.ToString());

//            if (effectivePeriod != null)
//                builder.Append(", effective ").Append(effectivePeriod.ToString());

//            //builder.Append(", PropertyValue:").Append(PropertyValue.ToLog());

//            builder.Append(", recorded ").Append(RecordedDate);
//            if (reference != "") builder.Append(", reference '").Append(Reference).Append("'");
//            if (remark != "") builder.Append(", remark '").Append(Remark).Append("'");

//            return builder.ToString();
//        }

//        public static IList<Relation> GetRelations(Context context, Relationship relationship,
//                                                    object firstEntity, object secondEntity)
//        {
//            return GetRelations(context, relationship, firstEntity, secondEntity, DateTime.Now);
//        }

//        public static IList<Relation> GetRelations(Context context, Relationship relationship,
//                                                    object firstEntity, object secondEntity,
//                                                    DateTime effectiveDate)
//        {
//            ICriteria crit = context.PersistenceSession.CreateCriteria<Relation>()
//                            .Add(Expression.Eq("Relationship", relationship))
//                            .Add(Expression.Le("EffectivePeriod.To", effectiveDate))
//                            .Add(Expression.Ge("EffectivePeriod.From", effectiveDate));
//            if (firstEntity != null) crit.Add(Expression.Eq("FirstEntity", firstEntity));
//            if (secondEntity != null) crit.Add(Expression.Eq("SecondEntity", secondEntity));
//            return crit.List<Relation>();
//        }

//        public static IList<Relation> GetRelations(Context context, Relationship relationship, DateTime effectiveDate,
//                                                object firstEntity, object secondEntity, TreeListNode category)
//        {
//            ICriteria relationCriteria = context.PersistenceSession.CreateCriteria(typeof(Relation));

//            if (relationship != null) relationCriteria.Add(Expression.Eq("Relationship", relationship));
//            if (firstEntity != null) relationCriteria.Add(Expression.Eq("FirstEntity", firstEntity));
//            if (secondEntity != null) relationCriteria.Add(Expression.Eq("SecondEntity", secondEntity));
//            if (category != null) relationCriteria.Add(Expression.Eq("Category", category));
//            if (effectiveDate > TimeInterval.MinDate && effectiveDate < TimeInterval.MaxDate)
//            {
//                relationCriteria.Add(Expression.Le("EffectivePeriod.To", effectiveDate));
//                relationCriteria.Add(Expression.Ge("EffectivePeriod.From", effectiveDate));
//            }
//            return relationCriteria.List<Relation>();
//        }

//        public static IList<Relation> GetRelations(Context context, Relationship relationship,
//                                                    object firstEntity, object secondEntity, TreeListNode category)
//        {
//            return GetRelations(context, relationship, TimeInterval.MinDate, firstEntity, secondEntity, category);
//        }

//        public static Relation Find(Context context, int id)
//        {
//            return (Relation)context.PersistenceSession.Get(typeof(Relation), id);
//        }

//        public static IList<Relationship> List(Context context)
//        {
//            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(Relationship));
//            return crit.List<Relationship>();
//        }
//    }
//}