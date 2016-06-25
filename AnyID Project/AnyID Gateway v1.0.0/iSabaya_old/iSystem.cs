using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    //public enum string
    //{
    //    Admin = 0,

    //    MutualFund = 100,
    //    MutualFundCustomer = 101,
    //    MutualFundSellingAgent = 102,

    //    ProvidentFund = 200,
    //    ProvidentFundEmployer = 201,
    //    ProvidentFundMember = 202,

    //    SecurityRegistrar = 300,

    //    Unknown = 9999,
    //}

    public class iSystem
    {
        public readonly static iSystem MySystem;
        //static iSystem()
        //{
        //}

        //public static iSystem GetSystem(int systemID)
        //{
        //    foreach (iSystem s in systems)
        //    {
        //        if (s.SystemID == systemID)
        //            return s;
        //    }
        //    return null;
        //}

        public virtual int SystemID { get; protected set; }
        public virtual string Title { get; set; }
        public virtual MultilingualString Description { get; set; }

        public iSystem()
        {
        }

        public iSystem(int systemID)
        {
            this.SystemID = systemID;
        }

        public void Initialize(ISession session)
        {
            DateTime today = DateTime.Today;
            this.Configuration = session.QueryOver<Configuration>()
                                    .Where(c => c.SystemID == this.SystemID
                                                && c.EffectivePeriod.From < today
                                                && today <= c.EffectivePeriod.To)
                                    .SingleOrDefault();
            this.UseCases = session.QueryOver<UseCase>()
                                    .Where(c => c.SystemID == this.SystemID
                                                && c.EffectivePeriod.From < today
                                                && today <= c.EffectivePeriod.To)
                                    .List();
            Language.GetAll(session);
            //Country.GetAll(session);
        }

        public virtual IList<UseCase> UseCases { get; set; }
        public virtual Configuration Configuration { get; set; }

        //public virtual void Initialize(Context context)
        //{
        //    DateTime today = DateTime.Today;
        //    this.Configuration = context.PersistenceSession
        //                                .QueryOver<Configuration>()
        //                                    .Where(c => c.SystemID == this.SystemID
        //                                                && c.EffectivePeriod.From < today 
        //                                                && today <= c.EffectivePeriod.To)
        //                                .SingleOrDefault();
        //}

        public virtual IList<UseCase> GetRootMenus(Context context)
        {
            if (context.User.IsDisable) return null;

            IList<UseCase> rootMenus;
            rootMenus = UseCase.GetTopMenus(context, this.SystemID);

            //mark accessible menus
            foreach (UserRole ur in context.User.UserRoles)
            {
                if (ur.Role.SystemID == this.SystemID && ur.IsEffective)
                {
                    foreach (RoleUseCase rm in ur.Role.UseCases)
                    {
                        if (rm.UseCase.IsObsolete) continue;
                        bool found = rootMenus.MarkMenuAsAccessible(rm.UseCase);
                        if (!found)
                            throw new Exception(String.Format("The role menu (id={0}) does not belong to the system (SystemID={1}).",
                                                                rm.UseCase.ID, this.SystemID));
                    }
                }
            }

            return rootMenus;
        }

        private IList<Role> roles;
        public virtual IList<Role> GetRoles(Context context)
        {
            if (null == roles)
                roles = Role.List(context, this.SystemID);
            return roles;
        }

        private IList<User> users;
        public virtual IList<User> GetUsers(Context context)
        {
            if (null == users)
                users = User.ListEffective(context, this.SystemID);
            return users;
        }

        private IList<User> usersToBePersisted;
        public bool AddUser(User user)
        {
            if (this.UserExist(user)) return false;
            if (null == usersToBePersisted)
                usersToBePersisted = new List<User>();
            usersToBePersisted.Add(user);
            return true;
        }

        private bool UserExist(User user)
        {
            if (null == this.users || -1 == this.users.IndexOf(user))
                return (null != usersToBePersisted && -1 != this.usersToBePersisted.IndexOf(user));
            return true;
        }

        public virtual User Login(Context context, User loginUser, String passwordText, out bool userMustChangePassword)
        {
            if (null == loginUser)
                throw new Exception(Messages.Security.UsernameIsInvalidCode.Format(context.CurrentLanguage.Code));

            loginUser.Login(context, passwordText, out userMustChangePassword);
            return loginUser;
        }

        public virtual User Login(Context context, String userName, String passwordText, out bool userMustChangePassword)
        {
            User loginUser = User.GetEffective(context, userName, this.SystemID);
            return Login(context, loginUser, passwordText, out userMustChangePassword);
        }

        //public virtual UserSession Login(Context context, String orgCode, String userName, String passwordText)
        //{
        //    SystemUser suser = SystemUser.FindEffective(context, this.SystemID, orgCode, userName);

        //    if (null != suser)
        //    {
        //        //if (suser.IsDisable || suser.User.IsDisable)
        //        //    throw new Exception(Messages.SecurityUserIsDisable);

        //        if (suser.User.Login(context, passwordText))
        //        {
        //            //Login success
        //            UserSession session = new UserSession(this, suser.User);
        //            return session;
        //        }
        //    }
        //    return null;
        //}
    }
}