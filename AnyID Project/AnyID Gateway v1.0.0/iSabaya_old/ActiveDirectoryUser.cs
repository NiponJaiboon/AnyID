using System;
using System.Collections.Generic;
using System.DirectoryServices;
//using System.DirectoryServices.ActiveDirectory;

namespace iSabaya
{
    public class ActiveDirectoryUser : User
    {
        public ActiveDirectoryUser()
        {
        }

        public ActiveDirectoryUser(int systemID, Organization organization, string officialIDNo, string loginName, string languageCode, string firstName, string lastName, string middleName, string emailAddress, string mobilePhone)
            : base(systemID, organization, officialIDNo, loginName, languageCode, firstName, lastName, middleName, emailAddress, mobilePhone)
        {
        }

        #region persistent

        public virtual bool IsReinstated { get; set; }

        #endregion persistent

        public static string ADDomainName { get; set; }

        /// <summary>
        /// Authenticate with Active Directory
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public override bool Login(Context context, String passwordText, out bool userMustChangePassword)
        {
            base.PreLogin(context, passwordText);
            string container = System.Configuration.ConfigurationManager.AppSettings["Container_LDAP"];
            bool success = false;
            userMustChangePassword = false;

            try
            {
                //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, System.Configuration.ConfigurationManager.AppSettings["EndPoint_LDAP"].ToString()))
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, System.Configuration.ConfigurationManager.AppSettings["EndPoint_LDAP"].ToString(), container, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer))//by kittikun
                {
                    try
                    {
                        success = pc.ValidateCredentials(this.LoginName, passwordText);
                    }
                    catch
                    {
                        success = false;
                    }

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

                    if (success && LastLoginTimestamp != TimeInterval.MinDate && HasBeenInactiveTooLong())
                    {
                        if (IsReinstated)
                        {
                            IsReinstated = false;
                            base.PostLogin(context, success);
                        }
                        else
                        {
                            throw new Exception(Messages.Security.UserHasBeenInactiveLongerThanLimitAD.Format(context.CurrentLanguage.Code, Configuration.CurrentConfiguration.Security.MaxDaysOfInactivity));
                        }
                    }
                    else
                        base.PostLogin(context, success);

                    return success;
                }
            }
            catch (Exception exc)
            {
                //Convert known message
                //if (exc.Message == Messages.TheServerCouldNotBeContacted)
                //    throw new Exception(Messages.Security.TheServerCouldNotBeContacted.Format(context.CurrentLanguage.Code));
                //if (exc.Message == Messages.TheLDAPServerIsUnavailable)
                //{
                //    base.PostLogin(context, false);
                //}
                //else
                throw new Exception(exc.Message);
            }
        }

        public static IList<UserPrincipal> GetADUsers(string userName, string passwordText)
        {
            IList<UserPrincipal> userPrincipals = new List<UserPrincipal>();
            string container = System.Configuration.ConfigurationManager.AppSettings["Container_LDAP"];
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ADDomainName, container, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer, userName, passwordText))
                {
                    using (PrincipalSearcher searcher = new PrincipalSearcher(new UserPrincipal(pc)))
                    {
                        foreach (UserPrincipal user in searcher.FindAll())
                        {
                            userPrincipals.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == Messages.TheServerCouldNotBeContacted)
                    throw new Exception(Messages.Security.TheServerCouldNotBeContacted.Format(""));
            }

            return userPrincipals;
        }

        public static IList<UserPrincipal> GetADUsers(Context context, string userName, string passwordText)
        {
            IList<UserPrincipal> userPrincipals = new List<UserPrincipal>();
            string container = System.Configuration.ConfigurationManager.AppSettings["Container_LDAP"];
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ADDomainName, container, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer, userName, passwordText))
                {
                    using (PrincipalSearcher searcher = new PrincipalSearcher(new UserPrincipal(pc)))
                    {
                        foreach (UserPrincipal user in searcher.FindAll())
                        {
                            userPrincipals.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == Messages.TheServerCouldNotBeContacted)
                    throw new Exception(Messages.Security.TheServerCouldNotBeContacted.Format(context.CurrentLanguage.Code));
            }

            return userPrincipals;
        }

        /// <summary>
        /// Get a unique AD user of the given domain.
        /// The static property ADDomainName must be set before calling this method.
        /// </summary>
        /// <param name="ADDomainName"></param>
        /// <param name="domainController">"DC=isabaya,DC=net"</param>
        /// <param name="userName">supoj@cimbthai.co.th</param>
        /// <param name="password">adj34!KLM</param>
        /// <returns>AD UserPrincipal</returns>
        public static UserPrincipal GetADUser(Context context, string userName, string password)
        {
            UserPrincipal userPrincipal = null;
            string container = System.Configuration.ConfigurationManager.AppSettings["Container_LDAP"];
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ADDomainName, container, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer, userName, password))
                {
                    using (UserPrincipal user = new UserPrincipal(pc))
                    {
                        PrincipalSearcher searcher = new PrincipalSearcher(user);
                        userPrincipal = (UserPrincipal)searcher.FindOne();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == Messages.TheServerCouldNotBeContacted)
                    throw new Exception(Messages.Security.TheServerCouldNotBeContacted.Format(context.CurrentLanguage.Code));
            }
            return userPrincipal;
        }

        public static UserPrincipal GetADU(Context context, string loginName, string userNameConnectAD, string passwordConnectAD)
        {
            UserPrincipal userPrincipal = null;
            string container = System.Configuration.ConfigurationManager.AppSettings["Container_LDAP"];
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ADDomainName, container, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer, userNameConnectAD, passwordConnectAD))
                {
                    using (UserPrincipal user = new UserPrincipal(pc))
                    {
                        user.SamAccountName = loginName;
                        PrincipalSearcher searcher = new PrincipalSearcher(user);
                        userPrincipal = (UserPrincipal)searcher.FindOne();
                        searcher.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == Messages.TheServerCouldNotBeContacted)
                    throw new Exception(Messages.Security.TheServerCouldNotBeContacted.Format(context.CurrentLanguage.Code));
            }
            return userPrincipal;
        }

        public static ActiveDirectoryUser UpdateADUser(ActiveDirectoryUser activeDirectoryUser, string newFirstName, string newLastName, string newEmailAddress, string languageCode)
        {
            var adUserName = new PersonName
                                 {
                                     EffectivePeriod = new TimeInterval(DateTime.Now),
                                     FirstName = new MultilingualString(new MLSValue(languageCode, newFirstName)),
                                     LastName = new MultilingualString(new MLSValue(languageCode, newLastName)),
                                 };
            activeDirectoryUser.Person.Names.Add(adUserName);
            activeDirectoryUser.EMailAddress = newEmailAddress;
            return activeDirectoryUser;
        }

        public ActiveDirectoryUser(string loginName)
        {
            // TODO: Complete member initialization
            this.LoginName = loginName;
        }

        public virtual bool HasBeenInactiveTooLong()
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

        public override UserStatus Status
        {
            get
            {
                if (this.HasBeenInactiveTooLong())
                    return base.Status | UserStatus.Inactive;
                else
                    return base.Status;
            }
        }

        public override string ToString()
        {
            return this.ID.ToString() + "-" + this.LoginName;
        }
    }
}