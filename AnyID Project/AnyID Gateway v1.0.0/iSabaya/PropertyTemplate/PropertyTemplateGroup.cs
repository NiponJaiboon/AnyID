using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class PropertyTemplateGroup : PropertyTemplateBase
    {
        #region ctors

        public PropertyTemplateGroup()
        {
        }

        #endregion ctors

        #region persistent

        private IList<PropertyTemplateBase> children;
        public virtual IList<PropertyTemplateBase> Children
        {
            get
            {
                if (null == this.children)
                    this.children = new List<PropertyTemplateBase>();
                return this.children;
            }
            set
            {
                this.children = value;
                //SetParentAndSeqNo();
            }
        }

        private bool isRoot;
        public virtual bool IsRoot
        {
            get { return isRoot; }
            set { isRoot = value; }
        }

        #endregion persistent

        private void SetParentAndSeqNo()
        {
            int seqNo = -1;
            int level = base.LevelNo + 1;
            foreach (PropertyTemplateBase child in this.Children)
            {
                SetRelation(++seqNo, level, child);
            }
        }

        private int SetRelation(int seqNo, int level, PropertyTemplateBase child)
        {
            child.LevelNo = level;
            child.Parent = this;
            child.SeqNo = seqNo;
            if (child is PropertyTemplateGroup)
                ((PropertyTemplateGroup)child).IsRoot = false;
            return seqNo;
        }

        public virtual PropertyTemplateBase[] ChildArray
        {
            set
            {
                this.children = new List<PropertyTemplateBase>(value);
                SetParentAndSeqNo();
            }
        }

        public virtual bool AddChild(PropertyTemplateBase child)
        {
            this.children.Add(child);
            child.Parent = this;
            return true;
        }

        public virtual void RemoveChild(PropertyTemplateBase child)
        {
            this.children.Remove(child);
            child.Parent = null;
        }

        public override void Persist(Context context)
        {
            context.Persist(this);
            foreach (PropertyTemplateBase pt in this.children)
            {
                pt.Persist(context);
            }
        }

        //public override PropertyValueContainerBase CreateValueContainer()
        //{
        //    return this.CreateValueContainer();
        //}

        public override PropertyValueContainerBase CreateValueContainer()
        {
            PropertyValueGroupContainer container = new PropertyValueGroupContainer(this);
            //PropertyValueGroup valueGroup = new PropertyValueGroup(container);
            foreach (PropertyTemplateBase child in this.Children)
            {
                container.Children.Add(child.CreateValueContainer());
            }
            //container.Values.Add(valueGroup);
            return container;
        }

        public static PropertyTemplateGroup Find(Context context, int id)
        {
            return context.PersistenceSession.Get<PropertyTemplateGroup>(id);
        }
    }

}
