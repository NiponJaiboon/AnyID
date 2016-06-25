using System;
using System.Collections.Generic;
using System.Text;
using iSabaya;

namespace iSabaya
{

    public class UserSession
    {
        public UserSession()
        {
        }

        public UserSession(iSystem system, User user, string applicationSessionID, string ipAddress = null)
        {
            this.System = system;
            this.User = user;
            this.ApplicationSessionID = applicationSessionID;
            this.FromIPAddress = ipAddress;
            this.SignIn();
        }

        private iSystem system;
        public virtual iSystem System
        {
            get { return this.system; }
            set
            {
                this.system = value;
                if (null == this.system)
                    this.SystemID = 0;
                else
                    this.SystemID = this.system.SystemID;
            }
        }

        #region persistent

        public virtual String FromIPAddress { get; set; }
        public virtual String ApplicationSessionID { get; set; }
        public virtual TimeInterval SessionPeriod { get; set; }        public virtual bool IsTimeOut { get; set; }
        public virtual User User { get; set; }
        public virtual long ID { get; set; }
        public virtual int SystemID { get; set; }

        #endregion persistent

        public virtual void SignIn()
        {
            this.SessionPeriod = new TimeInterval(DateTime.Now);
        }

        public virtual void SignOut(Context context)
        {
            this.SessionPeriod.To = DateTime.Now;
            this.Persist(context);
        }

        public virtual void TimeOut(Context context)
        {
            this.SessionPeriod.To = DateTime.Now;
            this.IsTimeOut = true;
            this.Persist(context);
        }

        public virtual void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }
    }
}