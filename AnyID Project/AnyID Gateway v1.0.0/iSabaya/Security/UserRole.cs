using System;

namespace iSabaya
{

    public class UserRole : PersistentTemporalEntity
    {
        public UserRole()
        {
        }

        public UserRole(DateTime effectiveDate, Role role)
            : base(effectiveDate)
        {
            this.Role = role;
        }

        public UserRole(DateTime effectiveDate, User user)
            :base(effectiveDate)
        {
            this.User = user;
        }

        public UserRole(DateTime effectiveDate, User user, Role role)
            : base(effectiveDate)
        {
            this.User = user;
            this.Role = role;
        }

        #region persistent

        public virtual Role Role {get;set;}
        public virtual User User {get;set;}

        #endregion persistent

    }
}