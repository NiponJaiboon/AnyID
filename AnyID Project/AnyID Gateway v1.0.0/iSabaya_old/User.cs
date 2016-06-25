using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Flags]
    public enum UserStatus
    {
        Active = 0,
        Expired = 1,
        Disable = 2,
        TooManyFailedLogin = 4,
        Inactive = 8
    }

    [Serializable]
    public abstract class User : PersistentTemporalEntity, IComparable<User>
    {
        public User()
            : base()
        {
            this.LastFailedLoginTimestamp = TimeInterval.MinDate;
            this.LastLoginTimestamp = TimeInterval.MinDate;

            //Edit By Watchara
            //this.EffectivePeriod = TimeInterval.Eternal;
            this.EffectivePeriod = TimeInterval.EffectiveNow;
            //
        }

        public User(String loginName)
            : this()
        {
            this.LoginName = loginName;
        }

        public User(int systemID, Organization organization, string officialIDNo, string loginName, string languageCode, string firstName, string lastName, string middleName, string emailAddress, string mobilePhone)
            : this(loginName)
        {
            this.SystemID = systemID;
            this.Organization = organization;
            this.Person = new Person
            {
                EffectivePeriod = new TimeInterval(DateTime.Now),
                OfficialIDNo = officialIDNo,
                CurrentName = new PersonName
                {
                    EffectivePeriod = new TimeInterval(DateTime.Now),
                    FirstName = null == firstName ? null : new MultilingualString(new MLSValue(languageCode, firstName)),
                    LastName = null == lastName ? null : new MultilingualString(new MLSValue(languageCode, lastName)),
                    MiddleName = null == middleName ? null : new MultilingualString(new MLSValue(languageCode, middleName)),
                }
            };
            this.EMailAddress = emailAddress;
            this.MobilePhoneNumber = mobilePhone;
        }

        #region persistent

        private String loginName;
        public virtual String LoginName
        {
            get
            {
                return this.loginName;
            }
            set
            {
                if (null != Configuration.CurrentConfiguration)
                    Configuration.CurrentConfiguration.Security.ValidateUsername(value);

                if (this.IsNotFinalized || null == this.loginName)
                    this.loginName = value;
                else
                    throw new Exception("Cannot change user name.");
            }
        }

        public virtual DateTime LastLoginTimestamp { get; set; }

        public virtual DateTime LastFailedLoginTimestamp { get; set; }

        public virtual int ConsecutiveFailedLoginCount { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Person Person { get; set; }

        public virtual int SystemID { get; set; }

        public virtual string EMailAddress { get; set; }

        public virtual string MobilePhoneNumber { get; set; }

        private bool isBuiltin = false;

        public virtual bool IsBuiltin
        {
            get { return isBuiltin; }
            protected set { isBuiltin = value; }
        }

        private bool isDisable = false;

        public virtual bool IsDisable
        {
            get { return isDisable; }
            set { isDisable = value; }
        }

        //private IList<UserPersonalization> personalizations;
        //public virtual IList<UserPersonalization> Personalizations
        //{
        //    get
        //    {
        //        if (null == personalizations)
        //            personalizations = new List<UserPersonalization>();
        //        return personalizations;
        //    }
        //    set { personalizations = value; }
        //}

        private IList<UserRole> userRoles;
        public virtual IList<UserRole> UserRoles
        {
            get
            {
                if (null == this.userRoles)
                    this.userRoles = new List<UserRole>();
                return userRoles;
            }
            set { userRoles = value; }
        }

        #endregion persistent

        public virtual string status { get; set; }
        public virtual UserStatus Status
        {
            get
            {
                UserStatus status = UserStatus.Active;
                if (!this.IsEffective)
                    status |= UserStatus.Expired;
                if (this.IsDisable)
                    status |= UserStatus.Disable;
                if (this.ConsecutiveFailedLoginCount >= Configuration.CurrentConfiguration.Security.MaxConsecutiveFailedLogonAttempts)
                    status |= UserStatus.TooManyFailedLogin;
                string s = status.ToString();

                return status;
            }
        }

        public virtual int DaysBeforePasswordExpiration { get { return int.MaxValue; } }

        public virtual PersonName Name { get { return this.Person.CurrentName; } }

        public virtual IList<UseCase> AccessibleMenus
        {
            get
            {
                IList<UseCase> menus = new List<UseCase>();
                foreach (UserRole ur in this.UserRoles)
                {
                    foreach (RoleUseCase rm in ur.Role.UseCases)
                    {
                        if (menus.Contains(rm.UseCase)) continue;
                        menus.Add(rm.UseCase);
                    }
                }
                return menus;
            }
        }

        public virtual IList<RoleUseCase> FindCurrentGroups(Context context)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                            .QueryOver<UserRole>()
                                .Where(e => e.EffectivePeriod.From <= now && now <= e.EffectivePeriod.To
                                            && e.User == this)
                            .JoinQueryOver<Role>(e => e.Role)
                                .Where(e => e.EffectivePeriod.From <= now && now <= e.EffectivePeriod.To)
                            .JoinQueryOver<RoleUseCase>(e => e.UseCases)
                                .Where(e => e.EffectivePeriod.From <= now && now <= e.EffectivePeriod.To)
                            .List<RoleUseCase>();
        }

        public virtual bool CanAccess(UseCase useCase, OrgUnit underOrgUnit)
        {
            return this.CanAccess(useCase.Code, underOrgUnit);
        }

        public virtual bool CanAccess(string useCaseCode, OrgUnit underOrgUnit)
        {
            foreach (var e in this.UserRoles)
            {
                if (e.IsEffective && e.Role.OrgUnit == underOrgUnit
                    && e.Role.UseCases.FirstOrDefault(i => i.IsEffective && i.UseCase.Code == useCaseCode) != null)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual IList<UserRole> FindCurrentUserRolesThatCanAccess(UseCase useCase, OrgUnit underOrgUnit)
        {
            IList<UserRole> userRoles = new List<UserRole>();
            foreach (var e in this.UserRoles)
            {
                if (e.IsEffective && e.Role.OrgUnit == underOrgUnit 
                    && e.Role.UseCases.FirstOrDefault(i => i.IsEffective && i.UseCase.ID == useCase.ID) != null)
                {
                    userRoles.Add(e);
                    break;
                }
            }
            return userRoles;
        }

        public virtual IList<Role> Roles
        {
            get
            {
                IList<Role> groups = new List<Role>();
                foreach (UserRole u in UserRoles)
                {
                    if (!groups.Contains(u.Role))
                    {
                        groups.Add(u.Role);
                        u.Role.LanguageCode = this.LanguageCode;
                    }
                }
                return groups;
            }
        }

        public override string ToString()
        {
            return this.ID.ToString() + "-" + this.LoginName;
        }

        public override string ToString(String languageCode)
        {
            return this.ToString();
        }

        public abstract bool Login(Context context, String passwordText, out bool userMustChangePassword);

        public virtual void PreLogin(Context context, String passwordText)
        {
        }

        public virtual void PostLogin(Context context, bool authenticationIsSuccessful)
        {
            if (authenticationIsSuccessful)
            {
                ConsecutiveFailedLoginCount = 0;
                LastLoginTimestamp = DateTime.Now;
            }
            else
            {
                LastFailedLoginTimestamp = DateTime.Now;
                ++this.ConsecutiveFailedLoginCount;
                //if (++this.ConsecutiveFailedLoginCount > context.Configuration.Security.MaxConsecutiveFailedLogonAttempts)
                //    this.IsDisable = true;
            }

            using (ITransaction tx = context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    this.Persist(context);
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                }
            };

            // Edit by Kunakorn
            #region mGate Use Below
            //if (!authenticationIsSuccessful)
            //{
            //    if (this.ConsecutiveFailedLoginCount >= context.Configuration.Security.MaxConsecutiveFailedLogonAttempts && this.LastFailedLoginTimestamp > this.LastLoginTimestamp)
            //        throw new Exception(Messages.Security.UserIsSuspendedForTooManyConsecutiveLoginFailures.Format(context.CurrentLanguage.Code, context.Configuration.Security.MaxConsecutiveFailedLogonAttempts));
            //    else
            //        throw new Exception(Messages.Security.UserIsDisableForExcessiveConsecutiveFailedLoginUnLimit.Format(context.CurrentLanguage.Code,
            //                          this.ConsecutiveFailedLoginCount, context.Configuration.Security.MaxConsecutiveFailedLogonAttempts));
            //}
            #endregion mGate Use Below


            #region iBank Use Below
            //iBank Use Below
            if (!authenticationIsSuccessful)
                throw new Exception(Messages.Security.PasswordIsInvalidCode.Format(context.CurrentLanguage.Code));
            #endregion iBank Use Below

            ////if (this.ConsecutiveFailedLoginCount <= context.Configuration.Security.MaxConsecutiveFailedLogonAttempts
            ////    && this.ConsecutiveFailedLoginCount > 0 && this.LastFailedLoginTimestamp > this.LastLoginTimestamp)
            ////    throw new Exception(Messages.Security.UserIsDisableForExcessiveConsecutiveFailedLoginUnLimit.Format(context.CurrentLanguage.Code,
            ////        this.ConsecutiveFailedLoginCount, context.Configuration.Security.MaxConsecutiveFailedLogonAttempts));

        }

        public virtual List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            foreach (UserRole role in UserRoles)
            {
                if (role.EffectivePeriod.To.Equals(TimeInterval.MaxDate)
                    || DateTime.Now <= role.EffectivePeriod.To)
                {
                    roles.Add(role.Role);
                }
            }
            return roles;
        }

        public virtual RoleUseCase GetEffectiveMenuPermission(iSystem system, int menuID)
        {
            RoleUseCase effectiveRoleMenu = null;
            foreach (UserRole ur in this.GetEffectiveRoles(system))
            {
                foreach (RoleUseCase rm in ur.Role.UseCases)
                {
                    if (rm.UseCase.ID == menuID)
                        rm.MergeMenuPermissionsTo(ref effectiveRoleMenu);
                }
            }
            return effectiveRoleMenu;
        }

        public virtual int GetEffectivePrivilegeLevel(iSystem system)
        {
            int effectivePrivilegeLevel = 0;
            foreach (UserRole ur in this.GetEffectiveRoles(system))
            {
                if (ur.EffectivePeriod.Includes(DateTime.Now)
                    && ur.Role.SystemID == system.SystemID)
                {
                    if (effectivePrivilegeLevel < ur.Role.PrivilegeLevel)
                        effectivePrivilegeLevel = ur.Role.PrivilegeLevel;
                }
            }
            return effectivePrivilegeLevel;
        }

        public virtual List<UserRole> GetEffectiveRoles(iSystem application)
        {
            List<UserRole> roles = new List<UserRole>();
            foreach (UserRole ur in UserRoles)
            {
                if (ur.EffectivePeriod.Includes(DateTime.Now)
                    && ur.Role.SystemID == application.SystemID)
                {
                    roles.Add(ur);
                }
            }
            return roles;
        }

        public virtual IList<UserRole> GetCurrentUserRolesThatCanAccessUseCase(UseCase useCase)
        {
            IList<UserRole> userRolesThatCanAccessUseCase = new List<UserRole>();
            foreach (var e in this.UserRoles)
            {
                if (e.IsEffective && null != e.Role.UseCases.FirstOrDefault(i => i.IsEffective && i.UseCase == useCase))
                {
                    userRolesThatCanAccessUseCase.Add(e);
                }
            }
            return userRolesThatCanAccessUseCase;
        }

        public static User FindCurrentUserWithLoginName(Context context, string loginName)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                            .QueryOver<User>()
                                .Where(e => e.EffectivePeriod.From <= now && now <= e.EffectivePeriod.To
                                            && e.LoginName == loginName)
                            .SingleOrDefault();
        }

        public static IList<User> GetByOrg(Context context, Organization org)
        {
            if (null == org)
                throw new Exception("The parameter org is null.");

            IList<User> users = context.PersistenceSession
                                    .CreateCriteria<User>()
                                    .Add(Expression.Eq("", org))
                                    .List<User>();
            SetLanguage(context, users);
            return users;
        }

        public static IList<User> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria<User>().List<User>();
        }

        public static IList<User> ListEffective(Context context, int applicationID)
        {
            IList<SystemUser> systemUsers = SystemUser.ListEffective(context, applicationID);
            IList<User> users = new List<User>();
            foreach (SystemUser su in systemUsers)
            {
                User user = su.User;
                if (!user.IsDisable && user.IsEffective)
                    users.Add(user);
            }
            return users;
        }

        public static User GetScheduleAutoUser(Context context)
        {
            return context.PersistenceSession.CreateCriteria<User>()
                            .Add(Expression.Eq("IsAutomaticSchedule", true))
                            .UniqueResult<User>();
        }

        public static IList<User> Find(Context context, string loginName)
        {
            return context.PersistenceSession.CreateCriteria<User>()
                .Add(Expression.Eq("LoginName", loginName))
                .List<User>();
        }

        public static User GetEffective(Context context, string loginName)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                            .QueryOver<User>()
                            .Where(u => u.LoginName == loginName
                                    && u.EffectivePeriod.From <= now && u.EffectivePeriod.To >= now)//edit by kittikun
                            .SingleOrDefault();
        }

        public static User Find(Context context, int id)
        {
            return context.PersistenceSession.Get<User>(id);
        }

        public static User FindCurrentUser(Context context, string loginName)
        {
            DateTime today = DateTime.Today;
            return context.PersistenceSession
                            .QueryOver<User>()
                                .Where(e => e.EffectivePeriod.From <= today && today <= e.EffectivePeriod.To
                                            && e.LoginName == loginName)
                            .SingleOrDefault();
        }

        public static User GetEffective(Context context, string loginName, int systemID)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                            .QueryOver<User>()
                            .Where(u => u.LoginName == loginName && u.SystemID == systemID
                                    && u.EffectivePeriod.From <= now && u.EffectivePeriod.To >= now)//edit by kittikun
                            .SingleOrDefault();
        }

        public override void Initiate(Context context, TimeInterval effectivePeriod, UserAction approvedAction)
        {
            base.Initiate(context, effectivePeriod, approvedAction);
            foreach (UserRole gu in this.UserRoles)
            {
                gu.Initiate(context, effectivePeriod, approvedAction);
            }
            foreach (UserRole gu in this.UserRoles)
            {
                gu.Initiate(context, effectivePeriod, approvedAction);
            }

            if (null != this.Person)
                this.Person.Initiate(context, effectivePeriod, approvedAction);
        }

        public override void Terminate(Context context, DateTime expiryDate)
        {
            base.Terminate(context, expiryDate);
            foreach (UserRole gu in this.UserRoles)
            {
                gu.Terminate(context, expiryDate);
            }
            foreach (UserRole gu in this.UserRoles)
            {
                gu.Terminate(context, expiryDate);
            }

            if (null != this.Person)
                this.Person.Terminate(context, expiryDate);
        }

        public override void Persist(Context context)
        {
            if (null == this.Organization)
                throw new Exception("The organization of user " + this.LoginName + " is null.");
            if (null != this.Person && this.Person.ID == 0)
                this.Person.Persist(context);

            foreach (UserRole gu in this.UserRoles)
            {
                gu.User = this;
                gu.Persist(context);
            }

            foreach (UserPersonalization p in Personalizations)
            {
                p.User = this;
                p.Persist(context);
            }
            base.Persist(context);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IComparable<User> Members

        public virtual int CompareTo(User other)
        {
            if (this.ID == other.ID)
                return 0;
            return String.CompareOrdinal(this.LoginName, other.LoginName);
        }

        #endregion IComparable<User> Members
    }
}