using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class RoleAccessibility
    {
        #region constructors

        public RoleAccessibility()
        {
        }

        public RoleAccessibility(RoleAccessibility original, User updatedBy)
        {
            this.role = original.Role;
            this.accessibleObject = original.AccessibleObject;
            this.permission = original.Permission;
            this.effectivePeriod = new TimeInterval(original.EffectivePeriod);
            this.description = original.Description;
            this.reference = original.Reference;
            this.remark = original.Remark;
            this.updatedBy = updatedBy;
        }

        public RoleAccessibility(Role role, Object accessibleObject, TreeListNode permission, 
                                string description, string reference, string remark, 
                                TimeInterval effectivePeriod, User updatedBy)
        {
            this.role = role;
            this.accessibleObject = accessibleObject;
            this.permission = permission;
            this.description = description;
            this.accessibleObject = accessibleObject;
            this.effectivePeriod = effectivePeriod;
            this.remark = remark;
            this.updatedBy = updatedBy;
        }

        #endregion constructors

        #region persistent

        protected int roleAccessibilityID;
        public virtual int RoleAccessibilityID
        {
            get { return roleAccessibilityID; }
            set { roleAccessibilityID = value; }
        }

        protected Role role;
        public virtual Role Role
        {
            get { return role; }
            set { role = value; }
        }

        protected Object accessibleObject;
        public virtual Object AccessibleObject
        {
            get { return accessibleObject; }
            set { accessibleObject = value; }
        }

        protected TreeListNode permission;
        public virtual TreeListNode Permission
        {
            get { return permission; }
            set{permission = value; }
        }

        protected String description;
        public virtual String Description
        {
            get { return description; }
            set { this.description = value; }
        }

        protected String reference;
        public virtual String Reference
        {
            get { return reference; }
            set { this.reference = value; }
        }

        private String remark;
        public virtual String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        protected DateTime updatedTS = DateTime.Now;
        public virtual DateTime UpdatedTS
        {
            get { return updatedTS; }
            set { updatedTS = value; }
        }

        private User updatedBy;
        public virtual User UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        #endregion persistent


        public virtual String PermissionName
        {
            get { return this.Permission.Title.ToString(); }
        }

        public virtual void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }

        //public static IList<UserAccessible> Find(Context context, TreeListNode categoryRoot, Person person)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(RoleAccessibility));
        //    crit.Add(Expression.Eq("CategoryRoot", categoryRoot))
        //        .Add(Expression.Eq("Party", person));
        //    return crit.List<RoleAccessibility>();
        //}

        //public static IList<UserAccessible> Find(Context context, TreeListNode categoryRoot, Person person, DateTime effectiveDate)
        //{
        //    ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(RoleAccessibility));
        //    crit.Add(Expression.Eq("CategoryRoot", categoryRoot))
        //        .Add(Expression.Eq("Party", person))
        //        .Add(Expression.Le("EffectivePeriod.From", effectiveDate))
        //        .Add(Expression.Ge("EffectivePeriod.To", effectiveDate));
        //    return crit.List<RoleAccessibility>();
        //}
    }
}
