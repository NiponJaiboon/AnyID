using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using iSabaya;

namespace iSabaya
{
    [Serializable]
    public class Password : PersistentTemporalEntity
    {
        public Password()
        {
        }

        public Password(SelfAuthenticatedUser user, String plainPasswordText)
        {
            if (null == user)
                throw new Exception(Messages.SecurityUserPersonIsNull);

            
            Configuration config = Configuration.CurrentConfiguration;
            if (null != config)
                config.Security.ValidatePassword(plainPasswordText);

            this.User = user;
            this.encryptedPassword = Encrypt(user.LoginName + plainPasswordText);
        }

        #region persistent

        public virtual SelfAuthenticatedUser User { get; set; }

        protected String encryptedPassword; // NHibernate will access this property
        public virtual String EncryptedPassword
        {
            get { return encryptedPassword; }
        }

        #endregion persistent

        public virtual bool Match(string passwordText)
        {
            if (null == this.EncryptedPassword && null == passwordText) return true;
            return this.EncryptedPassword == Encrypt(this.User.LoginName + passwordText);
        }

        public static String Encrypt(String plainPassword)
        {
            try
            {
                Encoder enc = Encoding.UTF8.GetEncoder();
                byte[] plainPasswordBytes = new byte[plainPassword.Length * 2];
                char[] plainPasswordChars = plainPassword.ToCharArray();
                int charUsed;
                int byteUsed;
                bool completed;
                enc.Convert(plainPasswordChars, 0, plainPasswordChars.Length, plainPasswordBytes, 0,
                            plainPasswordBytes.Length, true, out charUsed, out byteUsed, out completed);
                SHA512 shaM = new SHA512Managed();
                return Convert.ToBase64String(shaM.ComputeHash(plainPasswordBytes));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}