using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace iSabaya
{
    public class HierarchicalCategory : PersistentTemporalTitledEntity
    {
        #region persistent

        public new virtual int ID { get; set; }
        /// <summary>
        /// Is unique only within the same parent
        /// </summary>
        public virtual HierarchicalCategory Root { get; set; }
        public virtual HierarchicalCategory Parent { get; set; }
        private IList<HierarchicalCategory> children;
        public virtual IList<HierarchicalCategory> Children
        {
            get
            {
                if (null == this.children)
                    this.children = new List<HierarchicalCategory>();
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }
        public virtual int LevelNo { get; set; }
        public virtual int SeqNo { get; set; }
        public virtual float Weight { get; set; }

        #endregion

        public HierarchicalCategory() { }

        public HierarchicalCategory(int ID)
        {
            this.ID = ID;
        }

        public static bool operator ==(HierarchicalCategory left, HierarchicalCategory right)
        {
            return ReferenceEquals(left, right) 
                || (null != left && null != right && left.Code == right.Code && left.Parent == right.Parent);
        }

        public static bool operator !=(HierarchicalCategory left, HierarchicalCategory right)
        {
            return !(left == right);
        }

        public static HierarchicalCategory GetInstance(Context context, long categoryID)
        {
            return context.PersistenceSession
                            .QueryOver<HierarchicalCategory>()
                            .Where(c => c.ID == categoryID)
                            .SingleOrDefault();
        }

        public override bool Equals(object obj)
        {
            return obj is HierarchicalCategory && this == (HierarchicalCategory)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Persist(Context context)
        {
            if (null != Description)
                Description.Persist(context);
            base.Persist(context);
            try
            {
                foreach (HierarchicalCategory child in this.Children)
                {
                    child.Parent = this;
                    child.Root = this.Root;
                    child.Persist(context);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

    }
}
