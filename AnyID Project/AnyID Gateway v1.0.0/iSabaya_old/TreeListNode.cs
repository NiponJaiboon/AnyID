using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace iSabaya
{
    public delegate bool BusinessRuleProcedure(params Object[] parameters);

    [Serializable]
    public class TreeListNode : PersistentTemporalTitledEntity /*: IValueGroup, IEnumerator<IValueNode>*/
    {
        public const String NodePathDelimiter = "/";

        public TreeListNode()
        {
        }

        public TreeListNode(String code)
        {
            this.Code = code;
            this.Remark = code;
        }

        public TreeListNode(TreeListNode parent, int seqNo, String code, MultilingualString title)
        {
            this.SeqNo = seqNo;
            this.Code = code;
            this.Title = title;
            if (null != parent)
                parent.AddChild(this);
        }

        public TreeListNode(TreeListNode parent, int seqNo, String code, MultilingualString title, MultilingualString shortTitle)
        {
            this.SeqNo = seqNo;
            this.Code = code;
            this.Title = title;
            this.ShortTitle = shortTitle;
            if (null != parent)
                parent.AddChild(this);
        }

        public TreeListNode(TreeListNode parent, int seqNo, String code, MultilingualString title,
                            MultilingualString shortTitle, bool isActive, bool isDefault, bool isImmutable,
                            String valueString, double valueNumber, DateTime valueDate)
        {
            this.SeqNo = seqNo;
            this.Code = code;
            this.Title = title;
            this.ShortTitle = shortTitle;
            this.ValueDate = valueDate;
            this.ValueNumber = valueNumber;
            this.ValueString = valueString;
            this.IsActive = isActive;
            this.IsDefault = isDefault;
            this.IsImmutable = isImmutable;
            if (null != parent)
                parent.AddChild(this);
        }

        #region persistent

        protected IList<TreeListNode> children;
        public virtual IList<TreeListNode> Children
        {
            get
            {
                if (children == null) children = new List<TreeListNode>();
                return children;
            }
            set { children = value; }
        }

        public override String Code
        {
            get { return base.Code; }
            set
            {
                if (base.Code != value)
                {
                    base.Code = value;
                    return;
                }
                this.ResetPath();
            }
        }

        public virtual Country Country { get; set; }
        public virtual int Level { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsBuiltin { get; set; }
        public virtual bool IsCredit { get; set; }
        public virtual bool IsDebit { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual bool IsImmutable { get; set; }
        public virtual bool IsMandatory { get; set; }
        public virtual bool IsParent { get; set; }

        protected TreeListNode parent;
        public virtual TreeListNode Parent
        {
            get { return parent; }
            set
            {
                //if (null != parent) parent.Children.Remove(this);
                this.parent = value;
                this.SetRoot(null == this.parent ? this : this.parent.root);
                //if (null != parent) parent.Children.Add(this);
            }
        }
        public virtual String Path { get; set; }
        public virtual TreeListNode RelatedNode { get; set; }
        public virtual MultilingualString RelatedNodeTitle { get; set; }

        private TreeListNode root;
        public virtual TreeListNode Root
        {
            get
            {
                if (null == this.root && null != this.parent)
                    root = this.parent.Root;
                return this.root;

            }
            set { root = value; }
        }

        public virtual int SeqNo { get; set; }
        /// <summary>
        /// ValueTypes is an or-ed bits of enum AttributeValueType.
        /// </summary>
        public virtual AttributeValueTypes ValueTypes { get; set; }
        public virtual DateTime ValueDate { get; set; }
        public virtual MultilingualString ValueMLS { get; set; }
        public virtual double ValueNumber { get; set; }
        public virtual String ValueString { get; set; }
        public virtual double Weight { get; set; }

        #endregion persistent

        public virtual BusinessRuleProcedure BusinessRuleProcedure { get; set; }

        private void SetRoot(TreeListNode root)
        {
            this.Root = root;
            foreach (TreeListNode child in this.Children)
                child.SetRoot(root);
        }

        private void ResetPath()
        {
            if (null != this.Parent)
                this.Path = this.Parent.Path + NodePathDelimiter + this.Code;
            else
                this.Path = this.Code;

            foreach (TreeListNode n in this.Children)
            {
                n.ResetPath();
            }
        }

        public override String ToString(String languageCode)
        {
            if (null == this.Title)
                return this.Code;
            else
                return this.Title.ToString(languageCode);
            //if (parent == null)
            //    if (null == this.Title)
            //        return this.Code;
            //    else
            //        return this.Title.ToString(languageCode);
            //else
            //    if (null == this.Title)
            //        return parent.ToString(languageCode) + "/" + this.Code;
            //    else
            //        return parent.ToString(languageCode) + "/" + this.Title.ToString(languageCode);
        }

        public override String ToString()
        {
            if (null == this.Title)
                return this.Code;
            else
                return this.Title.ToString();
            //if (parent == null)
            //    if (null == this.Title)
            //        return this.Code;
            //    else
            //        return this.Title.ToString();
            //else
            //    if (null == this.Title)
            //        return parent.ToString() + "/" + this.Code;
            //    else
            //        return parent.ToString() + "/" + this.Title.ToString();
        }

        public virtual bool IsMeOrMyAncestor(TreeListNode node)
        {
            TreeListNode n = this;

            do
            {
                if (node == n) return true;
                n = n.Parent;
            } while (n != null);

            return false;
        }

        //public virtual TreeListNode GetChild(String code)
        //{
        //    foreach (TreeListNode c in this.Children)
        //    {
        //        if (c.Code == code) return c;
        //    }
        //    return null;
        //}

        public virtual TreeListNode GetDescendant(params String[] codes)
        {
            TreeListNode d = null;
            if (codes == null || codes.Length == 0)
                return d;

            string code = codes[0];
            foreach (TreeListNode c in this.Children)
            {
                if (c.Code == code)
                    d = c.GetDescendant(codes, 1);
            }
            return d;
        }

        private TreeListNode GetDescendant(string[] codes, int i)
        {
            TreeListNode d = this;
            if (codes == null || codes.Length <= i)
                return d;

            string code = codes[i];
            foreach (TreeListNode c in this.Children)
            {
                if (c.Code == code)
                    d = c.GetDescendant(codes, i + 1);
            }
            return d;
        }

        public virtual TreeListNode GetDescendant(String code)
        {
            TreeListNode d = null;
            foreach (TreeListNode c in this.Children)
            {
                if (c.Code == code) return c;
                d = c.GetDescendant(code);
                if (null != d) break;
            }
            return d;
        }

        public virtual bool AddChild(TreeListNode child)
        {
            //prevent null
            if (child == null) return false;

            //prevents cycle
            if (IsMeOrMyAncestor(child)) return false;

            //add new child
            child.Parent = this;
            this.Children.Add(child);
            child.ResetPath();
            this.IsParent = true;
            return true;
        }

        public virtual bool RemoveChild(TreeListNode child)
        {
            bool success = this.Children.Remove(child);
            if (success)
            {
                this.IsParent = this.Children.Count > 0;
                child.Root = child;
                child.Parent = null;
                child.ResetPath();
            }
            return success;
        }

        /// <summary>
        /// Return the child node whose code equals index value.
        /// </summary>
        /// <param name="childCode"></param>
        /// <returns></returns>
        public virtual TreeListNode this[string childCode]
        {
            get { return this.Children == null ? null : this.Children.FirstOrDefault(c => c.Code == childCode); }
        }

        /// <summary>
        /// Return the ith child node, i starts at 0
        /// </summary>
        /// <param name="i"></param>
        /// <returns>.</returns>
        public virtual TreeListNode this[int i]
        {
            get { return this.Children == null || this.Children.Count <= i ? null : this.Children[i]; }
        }

        public static bool operator ==(TreeListNode lhs, TreeListNode rhs)
        {
            if (Object.ReferenceEquals(lhs, rhs)) return true;
            if (Object.ReferenceEquals(lhs, null) || Object.ReferenceEquals(rhs, null)) return false;
            if (lhs.ID == 0 || rhs.ID == 0)
                return lhs.Code == rhs.Code && lhs.SeqNo == rhs.SeqNo && lhs.parent == rhs.parent;
            else
                return lhs.ID == rhs.ID;
        }

        public static bool operator !=(TreeListNode lhs, TreeListNode rhs)
        {
            return !(lhs == rhs);
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            if (this.ValueMLS != null) this.ValueMLS.Persist(context);
            if (this.RelatedNodeTitle != null && this.RelatedNodeTitle.ID == 0) this.RelatedNodeTitle.Persist(context);
            //if (this.ShortTitle != null) this.ShortTitle.Persist(context);
            //if (this.Description != null) this.Description.Persist(context);
            //context.PersistenceSession.SaveOrUpdate(this);
            foreach (TreeListNode n in children)
            {
                n.Parent = this;
                n.Persist(context);
            }
        }

        public static IList<TreeListNode> GetTreeFromCode(Context context, String rootCode)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(TreeListNode));
            crit.CreateAlias("Parent", "p");
            crit.Add(Expression.Eq("p.Code", rootCode));
            IList<TreeListNode> listNodes = crit.List<TreeListNode>();
            return listNodes;
        }

        public static TreeListNode FindByCode(Context context, String rootCode, String parentCode, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(TreeListNode));

            crit.Add(Expression.Eq("Code", code));
            if (!String.IsNullOrEmpty(rootCode))
            {
                crit.CreateAlias("Root", "r")
                    .Add(Expression.Eq("r.Code", rootCode));
            }
            if (!String.IsNullOrEmpty(parentCode))
            {
                crit.CreateAlias("Parent", "p")
                    .Add(Expression.Eq("p.Code", parentCode));
            }
            return crit.UniqueResult<TreeListNode>();
        }

        public static TreeListNode FindByCode(Context context, TreeListNode parent, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(TreeListNode));

            return crit.Add(Expression.Eq("Code", code))
                        .Add(Expression.Eq("Parent", parent))
                        .UniqueResult<TreeListNode>();
        }

        public static TreeListNode FindByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(TreeListNode));
            crit.Add(Expression.IsNotNull("Parent"));// is not root nat
            crit.Add(Expression.Eq("Code", code));
            TreeListNode node = crit.UniqueResult<TreeListNode>();
            return node;
        }

        public static TreeListNode FindRootByCode(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(TreeListNode));
            crit.Add(Expression.IsNull("Parent"));// is root
            crit.Add(Expression.Eq("Code", code));
            TreeListNode node = crit.UniqueResult<TreeListNode>();
            return node;
        }

        public static TreeListNode Find(Context context, int nodeId)
        {
            return (TreeListNode)context.PersistenceSession.Get<TreeListNode>(nodeId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is TreeListNode)) return false;
            TreeListNode node = obj as TreeListNode;
            if (node.ID == this.ID)
                return true;
            else
                return object.ReferenceEquals(node, this);
        }

        public override int GetHashCode()
        {
            if (this.ID > 0)
                return this.ID.GetHashCode();
            else
                return base.GetHashCode();
        }

        public virtual void Update(Context context)
        {
            context.PersistenceSession.Update(this);
        }

        //public virtual String Desc
        //{
        //    get
        //    {
        //        if (null == this.Title)
        //            return "";
        //        else
        //            return this.Title.GetValue();
        //    }
        //}

        #region IRelatable Members

        public virtual long GetID()
        {
            return ID;
        }

        #endregion
    }

    public class TreeListNodeComparer : IComparer
    {
        public int Compare(Object xx, Object yy)
        {
            TreeListNode x = (TreeListNode)xx;
            TreeListNode y = (TreeListNode)yy;
            if (x.ID > y.ID)
            {
                return -1;
            }
            else if (x.ID < y.ID)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

} // iSabaya
