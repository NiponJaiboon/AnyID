using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    /// <summary>
    /// Self-authenticated user (using password)
    /// </summary>
    [Serializable]
    public class SelfAuthenticatedUser : User
    {
        public SelfAuthenticatedUser()
        {
            this.MustChangePasswordAfterFirstLogon = true;
        }

        public SelfAuthenticatedUser(int systemID, Organization organization, string officialIDNo, string loginName, string languageCode,
                                    string firstName, string lastName, string middleName, string emailAddress, string mobilePhone)
            : base(systemID, organization, officialIDNo, loginName, languageCode, firstName, lastName, middleName, emailAddress, mobilePhone)
        {
            this.MustChangePasswordAfterFirstLogon = true;
        }

        public SelfAuthenticatedUser(int systemID, Organization organization, string officialIDNo, string loginName, string languageCode,
                                    string firstName, string lastName, string middleName, string emailAddress, string mobilePhone, string password)
            : base(systemID, organization, officialIDNo, loginName, languageCode, firstName, lastName, middleName, emailAddress, mobilePhone)
        {
            if (!string.IsNullOrEmpty(password))
                this.CurrentPassword = new Password(this, password);
            this.MustChangePasswordAfterFirstLogon = true;
        }

        public SelfAuthenticatedUser(int systemID, Organization organization, DateTime effectiveDate, Person person, String loginName, String password)
        {
            this.EffectivePeriod = new TimeInterval(effectiveDate);
            if (null == person)
                throw new Exception(Messages.SecurityUserPersonIsNull);
            if (null != password)
                this.CurrentPassword = new Password(this, password);
            this.Person = person;
            this.Organization = organization;
            this.LoginName = loginName;
            this.SystemID = systemID;
            this.MustChangePasswordAfterFirstLogon = true;
        }

        #region persistent

        public virtual int PasswordAgeInDays { get; set; }
        public virtual bool PasswordNeverExpires { get; set; }
        /// <summary>
        /// Indicate whether user must change password after next successful log-on. Default = false.
        /// </summary>
        public virtual bool MustChangePasswordAtNextLogon { get; set; }

        /// <summary>
        /// Indicate whether user must change password after the first successful log-on. Default = true.
        /// </summary>
        public virtual bool MustChangePasswordAfterFirstLogon { get; set; }

        public virtual bool IsReinstated { get; set; }
        //public virtual bool AllowLoginAfterLongAbsence { get; set; }

        private Password currentPassword;
        /// <summary>
        /// Must not be null.
        /// </summary>
        public virtual Password CurrentPassword
        {
            get
            {
                return this.currentPassword;
            }
            protected set
            {
                DateTime now = DateTime.Now;

                //Expire the current password
                if (null != this.currentPassword)
                    this.currentPassword.EffectivePeriod.ExpiryDate = now;

                //Set effective period of the new password
                Configuration config = Configuration.CurrentConfiguration;
                if (!PasswordNeverExpires && null != config && config.Security.PasswordAgeInDays > 0)
                    value.EffectivePeriod = new TimeInterval(now, now.AddDays(config.Security.PasswordAgeInDays));
                else
                    value.EffectivePeriod = new TimeInterval(now);

                //Replace the current password with the new one
                this.currentPassword = value;
                this.Passwords.Add(value);
            }
        }

        private IList<Password> passwords;

        public virtual IList<Password> Passwords
        {
            get
            {
                if (null == this.passwords) this.passwords = new List<Password>();
                return this.passwords;
            }
            set
            {
                this.passwords = value;
            }
        }

        //private IList<UserRole> userRoles;
        //public virtual IList<UserRole> UserRoles
        //{
        //    get { return userRoles; }
        //    set { userRoles = value; }
        //}

        #endregion persistent

        public override int DaysBeforePasswordExpiration
        {
            get
            {
                if (PasswordNeverExpires || Configuration.CurrentConfiguration.Security.PasswordAgeInDays == 0)
                    return int.MaxValue;
                else
                {
                    int passwordAgeInDays = (DateTime.Now - CurrentPassword.EffectivePeriod.EffectiveDate).Days;
                    return Configuration.CurrentConfiguration.Security.PasswordAgeInDays - passwordAgeInDays;
                }
            }
        }

        //public virtual IList<DynamicMenu> AccessibleMenus
        //{
        //    get
        //    {
        //        IList<DynamicMenu> menus = new List<DynamicMenu>();
        //        foreach (UserRole ur in this.UserRoles)
        //        {
        //            foreach (RoleMenu rm in ur.Role.Menus)
        //            {
        //                if (menus.Contains(rm.Menu)) continue;
        //                menus.Add(rm.Menu);
        //            }
        //        }
        //        return menus;
        //    }
        //}

        //public override bool IsDisable
        //{
        //    get
        //    {
        //        return base.IsDisable;
        //    }
        //    set
        //    {
        //        if (!value)
        //            IsReinstated = HasBeenInactiveTooLong();
        //        base.IsDisable = value;
        //    }
        //}

        public override String LoginName
        {
            get
            {
                return base.LoginName;
            }
            set
            {
                //if (null != Configuration.CurrentConfiguration)
                //    Configuration.CurrentConfiguration.Security.ValidateUsernameLength(value);

                base.LoginName = value;
            }
        }

        public override string ToString()
        {
            return this.LoginName;
        }

        public virtual void ChangePassword(Context context, String currentPasswordText, String newPasswordText, String confirmedPasswordText)
        {
            if (newPasswordText != confirmedPasswordText)
                throw new Exception(Messages.Security.NewPasswordsNotConfirmed.Format(context.Configuration.DefaultLanguage.Code));
            if (this.PasswordMatch(currentPasswordText))
            {
                Password newPassword = new Password(this, newPasswordText);
                if (null != Configuration.CurrentConfiguration
                    && PassPasswordHistoryCheck(Configuration.CurrentConfiguration.Security.PasswordHistoryDepth, newPassword))
                {
                    this.CurrentPassword = newPassword;
                }
                else
                    throw new Exception(Messages.Security.FailPasswordHistory.Format(context.Configuration.DefaultLanguage.Code));
            }
        }

        public virtual bool PasswordMatch(String passwordText)
        {
            bool success = false;
            if (null == this.CurrentPassword && null == passwordText)
                success = true;
            else
                success = this.CurrentPassword.Match(passwordText);
            return success;
        }

        private bool PassPasswordHistoryCheck(int passwordDepth, Password newPassword)
        {
            foreach (Password p in Passwords)
            {
                if (--passwordDepth < 0) break;
                if (p.EncryptedPassword == newPassword.EncryptedPassword)
                    return false;
            }
            return true;
        }

        public virtual void ResetPassword(String newPasswordText)
        {
            Password newPassword = new Password(this, newPasswordText);
            Password previousPassword = this.CurrentPassword;
            if (null != this.CurrentPassword)
                this.CurrentPassword.EffectivePeriod.ExpiryDate = newPassword.EffectivePeriod.From;
            this.CurrentPassword = newPassword;
        }

        public virtual bool Authenticate(String passwordText)
        {
            if (null == this.CurrentPassword)
                return (null == passwordText);
            else
                return this.CurrentPassword.Match(passwordText);
        }

        public override bool Login(Context context, String passwordText, out bool userMustChangePassword)
        {
            //Throw exception if prelogin fails.
            base.PreLogin(context, passwordText);

            bool success = false;
            if (null == this.CurrentPassword && null == passwordText)
                success = true;
            else
                success = this.Authenticate(passwordText);

            if (success)
            {
                if (null == this.EffectivePeriod)
                    throw new Exception(Messages.Security.UserIsNotEffective.Format(context.CurrentLanguage.Code));

                if (!this.IsEffective)
                    throw new Exception(Messages.Security.UserIsExpired.Format(context.CurrentLanguage.Code));

                if (this.ConsecutiveFailedLoginCount >= context.Configuration.Security.MaxConsecutiveFailedLogonAttempts && this.LastFailedLoginTimestamp > this.LastLoginTimestamp)
                    throw new Exception(Messages.Security.UserIsSuspendedForTooManyConsecutiveLoginFailures.Format(context.CurrentLanguage.Code, context.Configuration.Security.MaxConsecutiveFailedLogonAttempts));

                //throw new Exception(Messages.Security.UserIsDisableForExcessiveConsecutiveFailedLogin.Format(context.CurrentLanguage.Code));
                if (this.IsDisable)
                    throw new Exception(Messages.Security.UserIsDisable.Format(context.CurrentLanguage.Code));
            }

            if (success && (!IsStale() || IsReinstated))
                userMustChangePassword = this.MustChangePasswordAtNextLogon
                                        || (this.MustChangePasswordAfterFirstLogon && this.LastLoginTimestamp == TimeInterval.MinDate)
                                        || !this.CurrentPassword.IsEffective
                                        ;
            else
                userMustChangePassword = false;

            if (success && LastLoginTimestamp != TimeInterval.MinDate && IsStale())
            {
                if (IsReinstated)
                {
                    IsReinstated = false;
                    base.PostLogin(context, success);
                }
                else
                {
                    throw new Exception(Messages.Security.UserHasBeenInactiveLongerThanLimit.Format(context.CurrentLanguage.Code, Configuration.CurrentConfiguration.Security.MaxDaysOfInactivity));
                }
            }
            else
                base.PostLogin(context, success);

            return success;
        }

        public virtual bool IsStale()
        {
            if (this.EffectivePeriod.IsNullOrEmpty() || this.LastLoginTimestamp == TimeInterval.MinDate || this.IsBuiltin == true)
                return false;
            else
                return (DateTime.Now - this.LastLoginTimestamp).Days > Configuration.CurrentConfiguration.Security.MaxDaysOfInactivity;

            //if (this.EffectivePeriod.IsNullOrEmpty() || this.IsBuiltin == true)
            //    return false;

            //if (this.LastLoginTimestamp == TimeInterval.MinDate)
            //    //user has never been logged in
            //    return (DateTime.Now - this.EffectivePeriod.From).Days > Configuration.CurrentConfiguration.Security.MaxDaysOfInactivity;
            //else
            //    return (DateTime.Now - this.LastLoginTimestamp).Days > Configuration.CurrentConfiguration.Security.MaxDaysOfInactivity;
        }

        //public virtual List<Role> GetRoles()
        //{
        //    List<Role> roles = new List<Role>();
        //    foreach (UserRole role in UserRoles)
        //    {
        //        if (role.EffectivePeriod.To.Equals(TimeInterval.MaxDate)
        //            || DateTime.Now <= role.EffectivePeriod.To)
        //        {
        //            roles.Add(role.Role);
        //        }
        //    }
        //    return roles;
        //}

        //public virtual RoleMenu GetEffectiveMenuPermission(iSystem applicationID, int menuID)
        //{
        //    RoleMenu effectiveRoleMenu = null;
        //    foreach (UserRole ur in this.GetEffectiveRoles(applicationID))
        //    {
        //        foreach (RoleMenu rm in ur.Role.Menus)
        //        {
        //            if (rm.Menu.Id == menuID)
        //                rm.MergeMenuPermissionsTo(ref effectiveRoleMenu);
        //        }
        //    }
        //    return effectiveRoleMenu;
        //}

        //public virtual int GetEffectivePrivilegeLevel(iSystem application)
        //{
        //    int effectivePrivilegeLevel = 0;
        //    foreach (UserRole ur in this.GetEffectiveRoles(application))
        //    {
        //        if (ur.EffectivePeriod.Includes(DateTime.Now)
        //            && ur.Role.SystemID == application.SystemID)
        //        {
        //            if (effectivePrivilegeLevel < ur.Role.PrivilegeLevel)
        //                effectivePrivilegeLevel = ur.Role.PrivilegeLevel;
        //        }
        //    }
        //    return effectivePrivilegeLevel;
        //}

        //public virtual List<UserRole> GetEffectiveRoles(iSystem application)
        //{
        //    List<UserRole> roles = new List<UserRole>();
        //    foreach (UserRole ur in UserRoles)
        //    {
        //        if (ur.EffectivePeriod.Includes(DateTime.Now)
        //            && ur.Role.SystemID == application.SystemID)
        //        {
        //            roles.Add(ur);
        //        }
        //    }
        //    return roles;
        //}

        //public static IList<User> GetByOrg(Context context, Organization org)
        //{
        //    if (null == org)
        //        throw new Exception("The parameter org is null.");

        //    ICriteria crit = context.PersistenceSession.CreateCriteria<User>().Add(Expression.Eq("", org));
        //    return crit.List<User>();
        //}

        //public static IList<User> List(Context context)
        //{
        //    return context.PersistenceSession.CreateCriteria<User>().List<User>();
        //}

        //public static IList<User> ListEffective(Context context, int applicationID)
        //{
        //    IList<SystemUser> systemUsers = SystemUser.ListEffective(context, applicationID);
        //    IList<User> users = new List<User>();
        //    foreach (SystemUser su in systemUsers)
        //    {
        //        User user = su.User;
        //        if (!user.IsDisable && user.IsEffective())
        //            users.Add(user);
        //    }
        //    return users;
        //}

        //public static User GetScheduleAutoUser(Context context)
        //{
        //    return context.PersistenceSession.CreateCriteria<User>()
        //                    .Add(Expression.Eq("IsAutomaticSchedule", true))
        //                    .UniqueResult<User>();
        //}

        //public static User Find(Context context, int id)
        //{
        //    return context.PersistenceSession.Get<User>(id);
        //}

        public override void Persist(Context context)
        {
            if (null == this.Organization)
                throw new Exception("SelfAuthenticatedUser: Organization is null.");

            if (null != this.Person && this.Person.ID == 0)
                this.Person.Persist(context);

            bool needSecondPassPersist = false;
            if (0 == this.ID)
            {
                base.Persist(context);
            }
            needSecondPassPersist = this.CurrentPassword != null && this.CurrentPassword.ID == 0;
            foreach (Password pwd in this.Passwords)
            {
                context.Persist(pwd);
            }
            //Configuration.SessionFactory.Evict(typeof(SelfAuthenticatedUser), this.ID);
            if (needSecondPassPersist)
                base.Persist(context);
            //context.PersistenceSession.IsDirty();
        }

        public override UserStatus Status
        {
            get
            {
                if (this.IsStale())
                    return base.Status | UserStatus.Inactive;
                else
                    return base.Status;
            }
        }

        public static IList<SelfAuthenticatedUser> GetPasswordExpired(Context context, Organization org)
        {
            if (null == org)
                throw new Exception("The parameter org is null.");
            DateTime n = DateTime.Now;
            IList<SelfAuthenticatedUser> users = context.PersistenceSession
                                    .CreateCriteria<SelfAuthenticatedUser>()
                                    .CreateAlias("CurrentPassword", "cpwd")
                                    .Add(Expression.Le("cpwd.Effective.From", n))
                                    .Add(Expression.Ge("cpwd.Effective.To", n))
                                    .Add(Expression.Eq("Organization", org))
                                    .List<SelfAuthenticatedUser>();
            SetLanguage(context, users);
            return users;
        }
    }
}