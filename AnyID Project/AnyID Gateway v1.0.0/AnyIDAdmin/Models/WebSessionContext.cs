using iSabaya;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyIDAdmin.Models
{
    public class WebSessionContext : Context
    {
        public HttpSessionStateBase WebSessionState { get; set; }

        public WebSessionContext(long userID, DateTime loginTS)
            : base(userID, loginTS)
        {
        }

        public virtual int TempID
        {
            get
            {
                if (null == WebSessionState["TempID"])
                    return 0;
                else
                    return (int)WebSessionState["TempID"];
            }
            set
            {
                WebSessionState["TempID"] = value;
            }
        }

        public virtual new Configuration Configuration
        {
            get { return Configuration.CurrentConfiguration; }
        }

        #region Overrides

        //public override int UserID
        //{
        //    get
        //    {
        //        if (0 == this.userID && null != WebSessionState["UserID"])
        //            base.userID = (int)WebSessionState["UserID"];
        //        return base.userID;
        //    }
        //}

        //public override User User
        //{
        //    set
        //    {
        //        if (null == value)
        //            throw new iSabayaException("User is null");
        //        base.User = value;
        //        this.WebSessionState["UserID"] = value.ID;
        //        this.UserID = value.ID;
        //    }
        //}

        public override Language CurrentLanguage
        {
            set
            {
                WebSessionState["LanguageCode"] = value.Code;
                base.currentLanguage = value;
            }
        }

        public override void Close()
        {
            base.Close();

            if (this.WebSessionState != null)
                this.WebSessionState.Clear();
        }

        #endregion Overrides
    }
}