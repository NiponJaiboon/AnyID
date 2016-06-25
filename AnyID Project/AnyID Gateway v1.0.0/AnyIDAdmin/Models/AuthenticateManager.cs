using iSabaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace HRMWeb.Security
{

    public static class AuthenticateManager
    {
        public enum AuthenState
        {
            AuthenticationSuccess,
            AuthenticationFail,
            AlreadyLogin
        }

        public static bool Authenticate(Context context, iSystem systemID, string email, string password, ref User us)
        {
            SelfAuthenticatedUser user = context.PersistenceSession.QueryOver<SelfAuthenticatedUser>()
                .Where(u => u.LoginName == email).SingleOrDefault();
            us = user;
            return user.Authenticate(password);
        }

    }
}