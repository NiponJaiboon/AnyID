using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Text;
using NHibernate;

namespace iSabaya
{
    [Serializable]
    public class SecurityConfig
    {
        #region persistent
        public virtual int MaxConsecutiveFailedLogonAttempts { get; set; }
        public virtual int MaxDaysOfInactivity { get; set; }
        public virtual int MinNumberOfSpecialCharsInPassword { get; set; }
        public virtual int MinNumberOfCapitalLettersInPassword { get; set; }
        public virtual int MinNumberOfSmallLettersInPassword { get; set; }
        public virtual int MinNumberOfDigitsInPassword { get; set; }
        public virtual int MaxPasswordLength { get; set; }
        public virtual int MinPasswordLength { get; set; }
        public virtual int MaxUsernameLength { get; set; }
        public virtual int MinUsernameLength { get; set; }
        public virtual int PasswordAgeInDays { get; set; }
        public virtual int PasswordHistoryDepth { get; set; }
        public virtual int WebSessionTimeoutValueInMinutes { get; set; } 
        
        #endregion
        
        public virtual void Persist(Context context)
        {
            if (MinPasswordLength < MinNumberOfSpecialCharsInPassword + MinNumberOfCapitalLettersInPassword
                + MinNumberOfSmallLettersInPassword
                + MinNumberOfDigitsInPassword)
                MinPasswordLength = MinNumberOfSpecialCharsInPassword
                                    + MinNumberOfCapitalLettersInPassword
                                    + MinNumberOfSmallLettersInPassword
                                    + MinNumberOfDigitsInPassword
                                    + 2;
        }

        public virtual void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception(Messages.SecurityUserIsNull);
        }

        public virtual void ValidateUsernameLength(string username)
        {
            if (this.MinUsernameLength <= this.MaxUsernameLength
                && (this.MinUsernameLength > username.Length
                    || (this.MaxUsernameLength > 0 && username.Length > this.MaxUsernameLength)))
                throw new Exception(Messages.SecurityUserNameLengthViolatesPolicy);
        }

        public virtual bool PasswordIsValid(string plainPasswordText)
        {
            if (this.MaxPasswordLength > 0
                && (this.MinPasswordLength > plainPasswordText.Length || plainPasswordText.Length > this.MaxPasswordLength))
                return false;

            if (!this.DoNotMeetPasswordStrength(plainPasswordText))
                return false;

            return true;
        }

        public virtual void ValidatePassword(string plainPasswordText)
        {
            if (this.MaxPasswordLength > 0
                && (this.MinPasswordLength > plainPasswordText.Length || plainPasswordText.Length > this.MaxPasswordLength))
                throw new Exception(Messages.SecurityPasswordLengthViolatesPolicy);

            if (!this.DoNotMeetPasswordStrength(plainPasswordText))
                throw new Exception(Messages.SecurityPasswordIsWeak);
        }

        private bool DoNotMeetPasswordStrength(string plainPasswordText)
        {
            int occurenceOfCapitalLetters = 0;
            int occurenceOfSmallLetters = 0;
            int occurenceOfDigits = 0;
            int occurenceOfSpecials = 0;
            foreach (char c in plainPasswordText.ToCharArray())
            {
                if (char.IsUpper(c))
                    ++occurenceOfCapitalLetters;
                else if (char.IsLower(c))
                    ++occurenceOfSmallLetters;
                else if (char.IsDigit(c))
                    ++occurenceOfDigits;
                else
                    ++occurenceOfSpecials;
            }
            int requirementCount = 0;

            if (occurenceOfCapitalLetters >= this.MinNumberOfCapitalLettersInPassword) ++requirementCount;
            if (occurenceOfSmallLetters >= this.MinNumberOfSmallLettersInPassword) ++requirementCount;
            if (occurenceOfDigits >= this.MinNumberOfDigitsInPassword) ++requirementCount;
            if (occurenceOfSpecials >= this.MinNumberOfSpecialCharsInPassword) ++requirementCount;

            return requirementCount >= 4;
        }

        public virtual String GeneratePassword()
        {
            string passwordText;
            if (this.MinNumberOfSpecialCharsInPassword > 0)
            {
                do
                {
                    passwordText = System.Web.Security.Membership.GeneratePassword(this.MinPasswordLength, this.MinNumberOfSpecialCharsInPassword);
                }
                while (!this.PasswordIsValid(passwordText));
            }
            else
            {
                passwordText = System.Web.Security.Membership.GeneratePassword(8, 1);
            }
            return passwordText;
        }
    }
}