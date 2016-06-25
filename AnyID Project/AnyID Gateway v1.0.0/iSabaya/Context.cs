using System;
using System.Globalization;
using NHibernate;
using log4net;

namespace iSabaya
{

    public class Context
    {
        public Context()
        {
        }

        public Context(long userID, DateTime loginTS)
        {
            this.UserID = userID;
            this.LoginTS = loginTS;
        }

        public ILog Log
        {
            get
            {
                if (this.User == null)
                    return LogManager.GetLogger(Configuration.MySystem.Title);
                else 
                    return LogManager.GetLogger(this.User.LoginName);
            }
        }

        public Configuration Configuration
        {
            get
            {
                return MySystem.Configuration;
            }
        }

        public iSystem MySystem
        {
            get { return Configuration.MySystem; }
        }

        protected User user;

        public virtual User User
        {
            get
            {
                if (null == this.user && this.UserID != 0)
                    this.user = this.PersistenceSession.Get<User>(this.UserID);
                return this.user;
            }
            //protected set
            //{
            //    if (null == value)
            //        throw new iSabayaException("User is null");
            //    this.user = value;
            //    UserID = value.ID;
            //    //UserSession = StartNewSession(value);
            //}
        }

        public virtual long UserID { get; set; } = 0;
        public virtual DateTime LoginTS { get; set; }

        protected Language currentLanguage;
        public virtual Language CurrentLanguage
        {
            get
            {
                if (null == this.currentLanguage)
                    this.CurrentLanguage = Configuration.DefaultLanguage;
                return this.currentLanguage;
            }
            set
            {
                this.currentLanguage = value;
            }
        }

        protected Organization systemOwnerOrg;
        public virtual Organization SystemOwnerOrg
        {
            get
            {
                if (null == this.systemOwnerOrg)
                    if (null == this.Configuration)
                        return null;
                    else
                        this.systemOwnerOrg = this.Configuration.SystemOwnerOrg;
                return this.systemOwnerOrg;
            }
            set
            {
                this.systemOwnerOrg = value;
            }
        }

        public virtual CultureInfo CurrentCulture
        {
            get
            {
                CultureInfo culture;
                if (null == this.CurrentLanguage)
                    culture = CultureInfo.CurrentCulture;
                else
                {
                    culture = CultureInfo.GetCultureInfo(this.CurrentLanguage.Code);
                    if (null == culture)
                        culture = CultureInfo.CreateSpecificCulture(this.CurrentLanguage.Code);
                }
                return culture;
            }
        }

        private ISession persistenceSession;
        public virtual ISession PersistenceSession
        {
            get
            {
                if (null == this.persistenceSession)
                {
                    this.persistenceSession = Configuration.SessionFactory.OpenSession();
                    this.persistenceSession.FlushMode = FlushMode.Commit;
                }
                return this.persistenceSession;
            }
            internal set { this.persistenceSession = value; }
        }

        //private ISession logSession;
        //public virtual ISession LogSession
        //{
        //    get
        //    {
        //        if (null == this.logSession)
        //        {
        //            this.logSession = Configuration.SessionFactory.OpenSession();
        //            this.logSession.FlushMode = FlushMode.Always;
        //        }
        //        return this.logSession;
        //    }
        //}

        //public abstract String GenReceiptNo(Receipt receipt);
        //public ReceiptToString GenReceiptNo;

        public static String GetEnumResourceName<T>(T enumInstance)
        {
            return typeof(T).Name + "_" + enumInstance.ToString();
        }

        public virtual void Close()
        {
            if (null != this.persistenceSession)
            {
                this.persistenceSession.Flush();
                this.persistenceSession.Close();
                this.persistenceSession.Dispose();
                this.persistenceSession = null;
            }
            //if (null != this.logSession)
            //{
            //    this.logSession.Flush();
            //    this.logSession.Close();
            //    this.logSession.Dispose();
            //    this.logSession = null;
            //}
        }

        public void Update(object obj)
        {
            this.PersistenceSession.Update(obj);
        }

        public virtual void Persist(object obj)
        {
            this.PersistenceSession.SaveOrUpdate(obj);
        }
    }
}