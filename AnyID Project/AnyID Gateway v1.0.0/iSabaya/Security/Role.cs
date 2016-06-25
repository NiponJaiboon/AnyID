using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class Role : PersistentTemporalTitledEntity
    {

        public Role()
        {
        }

        public Role(DateTime effectiveDate, string code, OrgUnit orgUnit, MultilingualString title, MultilingualString description, string reference, string remark)
            : base(effectiveDate, code, title, description, reference, remark)
        {
            this.Title = title;
            this.Description = description;
            this.OrgUnit = orgUnit;
        }

        #region persistent

        public virtual int SystemID { get; set; }

        private IList<RoleAccessibility> accessibles;
        public virtual IList<RoleAccessibility> Accessibles
        {
            get { return accessibles; }
            set { accessibles = value; }
        }

        private IList<RoleUseCase> useCases;
        public virtual IList<RoleUseCase> UseCases
        {
            get { return useCases; }
            set { useCases = value; }
        }

        private IList<UserRole> userRoles;
        public virtual IList<UserRole> UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; }
        }

        public virtual OrgUnit OrgUnit { get; set; }
        public virtual bool IsAdministrator { get; set; }
        public virtual bool IsBuiltin { get; set; }
        public virtual int SeqNo { get; set; }

        private int privilegeLevel;
        public virtual int PrivilegeLevel
        {
            get { return privilegeLevel; }
            set
            {
                if (value < 0 || 5 < value)
                    throw new iSabayaException("The privilege value is not in the range 0 to 5.");
                privilegeLevel = value;
            }
        }

        #endregion persistent

        public virtual RoleUseCase GetGroupUseCase(string useCaseCode)
        {
            return this.UseCases.FirstOrDefault(e => e.IsEffective && e.UseCase.Code == useCaseCode);
        }

        public static Role Find(Context context, long id)
        {
            return context.PersistenceSession.Get<Role>(id);
        }

        public static Role Find(Context context, string code)
        {
            return context.PersistenceSession.QueryOver<Role>()
                                            .Where(r => r.Code == code)
                                            .SingleOrDefault();
        }

        public static IList<Role> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria<Role>().List<Role>();
        }

        public static IList<Role> List(Context context, int applicationID)
        {
            return context.PersistenceSession.CreateCriteria<Role>()
                    .Add(Expression.Eq("Application", applicationID))
                    .List<Role>();
        }

        public virtual bool Contains(User user)
        {
            UserRole ur = this.UserRoles.FirstOrDefault(e => e.User == user);
            return ur != null;
        }
    }
}
