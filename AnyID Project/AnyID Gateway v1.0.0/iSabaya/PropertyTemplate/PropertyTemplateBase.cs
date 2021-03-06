using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace iSabaya
{

    public abstract class PropertyTemplateBase
    {
        #region persistent

        private int iD;
        public virtual int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private TreeListNode category;
        public virtual TreeListNode Category
        {
            get { return category; }
            set { category = value; }
        }

        private string code;
        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        private MultilingualString description;
        public virtual MultilingualString Description
        {
            get { return description; }
            set { description = value; }
        }

        private bool isMandatory;
        public virtual bool IsMandatory
        {
            get { return isMandatory; }
            set { isMandatory = value; }
        }

        private bool isTemporal;
        public virtual bool IsTemporal
        {
            get { return isTemporal; }
            set { isTemporal = value; }
        }

        private int levelNo;
        public virtual int LevelNo
        {
            get { return levelNo; }
            set { levelNo = value; }
        }

        private int multiplicity = 1;
        /// <summary>
        /// Indicates the upper limit on the number of values for this template.
        /// Default = 1. 0 indicates no upper limit.
        /// </summary>
        public virtual int Multiplicity
        {
            get { return multiplicity; }
            set { 
                if (value <= 0)
                    multiplicity = 0; 
                else
                    multiplicity = value; }
        }

        private PropertyTemplateGroup parent;
        public virtual PropertyTemplateGroup Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        private MultilingualString title;
        public virtual MultilingualString Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion persistent

        public abstract PropertyValueContainerBase CreateValueContainer();

        public abstract void Persist(Context context);

        //public static PropertyTemplateBase Find(Context context, String code)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria<PropertyTemplateBase));
        //    crit.Add(Expression.Eq("Code", code));
        //    return crit.UniqueResult<PropertyTemplateBase>();
        //}

        public override String ToString()
        {
            return this.Code + "-" + this.Title.ToString();
        }
    }
}
