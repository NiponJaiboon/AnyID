using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace iSabaya
{
    public class SystemUser
    {
        private int systemUserID;
        public virtual int SystemUserID
        {
            get { return systemUserID; }
            set { systemUserID = value; }
        }

        public virtual int SystemID { get; set; }

        private TimeInterval effectivePeriod = TimeInterval.Eternal;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set
            {
                if (value == null)
                    effectivePeriod = TimeInterval.Eternal;
                else
                    effectivePeriod = value;
            }
        }

        private bool isDisable = false;
        public virtual bool IsDisable
        {
            get { return isDisable; }
            set { isDisable = value; }
        }

        //private int systemID;
        //public virtual int SystemID
        //{
        //    get { return systemID; }
        //    set { systemID = value; }
        //}

        public virtual User User { get; set; }

        public static IList<SystemUser> ListEffective(Context context, int applicationID)
        {
            DateTime date = DateTime.Now;
            return context.PersistenceSession.CreateCriteria<SystemUser>()
                            .Add(Expression.Eq("SystemID", applicationID))
                            .Add(Expression.Le("EffectivePeriod.From", date))
                            .Add(Expression.Ge("EffectivePeriod.To", date))
                            .List<SystemUser>();
        }

        public static IList<SystemUser> List(Context context, int applicationID)
        {
            return context.PersistenceSession.CreateCriteria<SystemUser>()
                            .Add(Expression.Eq("SystemID", applicationID))
                            .List<SystemUser>();
        }

        public static SystemUser Find(Context context, int applicationID, String userName)
        {
            IList<SystemUser> systemUsers = context.PersistenceSession.CreateCriteria<SystemUser>()
                                                    .Add(Expression.Eq("SystemID", applicationID))
                                                    .CreateAlias("User", "u")
                                                    .Add(Expression.Eq("u.LoginName", userName))
                                                    .List<SystemUser>();
            SystemUser sytemUser = null;
            foreach (SystemUser u in systemUsers)
            {
                if (u.User.Organization == context.SystemOwnerOrg)
                {
                    sytemUser = u;
                    break;
                }
            }
            return sytemUser;
        }

        public static SystemUser FindEffective(Context context, int applicationID, String orgCode, String userName)
        {
            DateTime now = DateTime.Now;
            IList<SystemUser> systemUsers = context.PersistenceSession.CreateCriteria<SystemUser>()
                                                    .Add(Expression.Eq("SystemID", applicationID))
                                                    .Add(Expression.Le("EffectivePeriod.From", now))
                                                    .Add(Expression.Ge("EffectivePeriod.To", now))
                                            
                                                    .CreateAlias("User", "u")
                                                    .Add(Expression.Eq("u.LoginName", userName))
                                                    .List<SystemUser>();
            SystemUser sytemUser = null;
            foreach (SystemUser u in systemUsers)
            {
                if (u.User.Organization.Code == orgCode)
                {
                    sytemUser = u;
                    break;
                }
            }
            return sytemUser;
        }
    }
}
