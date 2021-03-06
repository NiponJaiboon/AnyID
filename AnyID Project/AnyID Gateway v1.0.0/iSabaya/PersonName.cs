using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using NHibernate;

namespace iSabaya
{

    public class PersonName : PersistentTemporalEntity
    {
        public PersonName()
        {
        }

        public PersonName(Person person, TimeInterval effectivePeriod, NameAffix prefix,
                            MultilingualString firstName, MultilingualString lastName, MultilingualString middleName,
                            NameAffix suffix, string reference, string remark)
        {
            this.Person = person;
            this.EffectivePeriod = effectivePeriod;
            this.Prefix = prefix;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Suffix = suffix;
            this.Reference = reference;
            this.Remark = remark;
        }

        public PersonName(Person person, TimeInterval effectivePeriod, MultilingualString title,
                            MultilingualString firstName, MultilingualString lastName,
                            MultilingualString middleName, string reference, string remark)
        {
            this.Person = person;
            this.EffectivePeriod = effectivePeriod;
            this.Title = title;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Reference = reference;
            this.Remark = remark;
        }

        #region persistent

        public virtual Person Person { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual MultilingualString FirstName { get; set; }
        public virtual MultilingualString LastName { get; set; }
        public virtual MultilingualString MiddleName { get; set; }
        public virtual NameAffix Prefix { get; set; }
        public virtual NameAffix Suffix { get; set; }
        public virtual DateTime OrderedDate { get; set; }

        #endregion persistent

        public virtual MultilingualString ToMultilingualString()
        {
            MultilingualString n = null;

            if (this.Prefix != null)
                n = this.Prefix.Affix.Clone();
            if (this.FirstName != null)
                if (n == null)
                    n = this.FirstName.Clone();
                else
                {
                    n.Append(" ");
                    n.Append(this.FirstName);
                }
            if (this.MiddleName != null)
                if (n == null)
                    n = this.MiddleName.Clone();
                else
                {
                    n.Append(" ");
                    n.Append(this.MiddleName);
                }
            if (this.LastName != null)
                if (n == null)
                    n = this.LastName.Clone();
                else
                {
                    n.Append(" ");
                    n.Append(this.LastName);
                }
            if (this.Suffix != null)
                if (n == null)
                    n = this.Suffix.Affix.Clone();
                else
                {
                    n.Append(" ");
                    n.Append(this.Suffix.Affix);
                }
            return n;
        }

        public virtual string GetValue(string language)
        {
            return
                ((Title == null) ? "" : Title.GetValue(language)) + " " +
                ((FirstName == null) ? "" : FirstName.GetValue(language)) + " " +
                ((MiddleName == null) ? "" : MiddleName.GetValue(language)) + " " +
                ((LastName == null) ? "" : LastName.GetValue(language));
        }

        public override string ToString(String langCode)
        {
            if (null == this.FirstName && null == this.LastName)
                return "";

            StringBuilder builder = new StringBuilder();
            string space = " ";

            if (this.Prefix != null)
            {
                builder.Append(this.Prefix.ToString(langCode));
            }
            if (this.FirstName != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.FirstName.ToString(langCode));
            }
            if (this.MiddleName != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.MiddleName.ToString(langCode));
            }
            if (this.LastName != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.LastName.ToString(langCode));
            }
            if (this.Suffix != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.Suffix.ToString(langCode));
            }
            return builder.ToString();
        }

        public virtual string NameWithoutAffixes
        {
            get
            {
                if (null == this.FirstName && null == this.LastName)
                    return "";

                StringBuilder builder = new StringBuilder();
                string space = " ";

                if (this.FirstName != null)
                {
                    if (builder.Length > 0) builder.Append(space);
                    builder.Append(this.FirstName.ToString());
                }
                if (this.MiddleName != null)
                {
                    if (builder.Length > 0) builder.Append(space);
                    builder.Append(this.MiddleName.ToString());
                }
                if (this.LastName != null)
                {
                    if (builder.Length > 0) builder.Append(space);
                    builder.Append(this.LastName.ToString());
                }
                return builder.ToString();
            }
        }

        public override string ToString()
        {
            if (null == this.FirstName && null == this.LastName)
                return "";

            if (!String.IsNullOrEmpty(this.LanguageCode))
                return this.ToString(this.LanguageCode);

            if (null != this.Person && !String.IsNullOrEmpty(this.Person.LanguageCode))
                return this.ToString(this.Person.LanguageCode);

            StringBuilder builder = new StringBuilder();
            string space = " ";

            if (this.Prefix != null)
            {
                builder.Append(this.Prefix.ToString());
            }
            if (this.FirstName != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.FirstName.ToString());
            }
            if (this.MiddleName != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.MiddleName.ToString());
            }
            if (this.LastName != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.LastName.ToString());
            }
            if (this.Suffix != null)
            {
                if (builder.Length > 0) builder.Append(space);
                builder.Append(this.Suffix.ToString());
            }
            return builder.ToString();
        }

        public override void Persist(Context context)
        {
            if (null != this.Prefix && Prefix.AffixID == 0) Prefix.Persist(context);
            if (null != this.Suffix && Suffix.AffixID == 0) Suffix.Persist(context);
            if (null != this.Title) this.Title.Persist(context);
            if (null != this.FirstName) this.FirstName.Persist(context);
            if (null != this.LastName) this.LastName.Persist(context);
            if (null != this.MiddleName) this.MiddleName.Persist(context);
            context.Persist(this);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.ID == ((PersonName)obj).ID;
        }

        #region static

        private static String illegalFirstChar //อาอำอิอีอะอัอุอูอ่อ้อ๊อ๋อ์
            = "\u0e30\u0e31\u0e32\u0e33\u0e34\u0e35\u0e36\u0e38\u0e39\u0e47\u0e48\u0e49\u0e4a\u0e4b\u0e4c";
        private static String namePrefixPattern = @"(?<prefix>นาย|นางสาว|น\.ส\.|นส\.|นาง|ม\.ล\.|ม\.ร\.ว\."
                                + @"|พล\.ร\.อ\.|พล\.ร\.ท\.|พล\.ร\.ต\.|พล\.ร\.จ\.|น\.อ\.|น\.ท\.|น\.ต\."
                                + @"|ร\.อ\.|ร\.ท\.|ร\.ต\.|พ\.จ\.อ\.|พ\.จ\.ท\.|พ\.จ\.ต\.|จ\.อ\.|จ\.ท\.|จ\.ต\."
                                + @"|พล\.อ\.อ\.|พล\.อ\.ท\.|พล\.อ\.ต\.|พล\.อ\.จ\.|พ\.อ\.อ\.|พ\.อ\.ท\.|พ\.อ\.ต\."
                                + @"|พล\.ต\.อ\.|พล\.ต\.ท\.|พล\.ต\.ต\.|พล\.ต\.จ\.|พ\.ต\.อ\.|พ\.ต\.ท\.|พ\.ต\.ต\."
                                + @"|ร\.ต\.อ\.|ร\.ต\.ท\.|ร\.ต\.ต\.|ด\.ต\.|จ\.ส\.ต\.|ส\.ต\.อ\.|ส\.ต\.ท\.|ส\.ต\.ต\."
                                + @"|พล\.อ\.|พล\.ท\.|พล\.ต\.|พล\.จ\.|พ\.อ\.|พ\.ท\.|พ\.ต\."
                                + @"|จ\.ส\.อ\.|จ\.ส\.ท\.|จ\.ส\.ต\.|ส\.อ\.|ส\.ท\.|ส\.ต\.|ส\.ต\."
                                + @"|Mr\.|Ms\.|Mrs\.)";

        private static Regex threePartNamePattern
            = new Regex(namePrefixPattern + @"\s*(?<firstname>\S*)\s+(?<lastname>\S*\s*\S*\s*\S*)");

        public static void Split(String fullName,
                                    out String namePrefix, out String firstName, out String lastName)
        {
            namePrefix = firstName = lastName = null;

            //MatchCollection mc = regExpThaiNameWithPrefix.Matches(fullName);
            //int i = mc.Count;
            String[] parts = threePartNamePattern.Split(fullName);
            if (parts.Length > 1)
            {
                namePrefix = parts[1];
                firstName = parts[2];
                lastName = parts[3];
                ResplitIfFirstNameIncorrect(ref namePrefix, ref firstName);
            }
            else
            {
                SplitNameWithoutPrefix(fullName, ref firstName, ref lastName);
            }
        }

        private static void ResplitIfFirstNameIncorrect(ref String namePrefix, ref String firstName)
        {
            if (namePrefix == "นางสาว")
                if (firstName == "")
                {
                    namePrefix = "นาง";
                    firstName = "สาว";
                }
                else if (-1 < illegalFirstChar.IndexOf((char)firstName[0]))
                {
                    namePrefix = "นาง";
                    firstName = "สาว" + firstName;
                }
        }

        private static void SplitNameWithoutPrefix(String fullName, ref String firstName, ref String lastName)
        {
            Regex regex = new Regex(@"\s+");
            String[] nameParts = regex.Split(fullName.Trim());

            if (2 == nameParts.Length)
            {
                firstName = nameParts[0];
                lastName = nameParts[1];
            }
            else if (2 < nameParts.Length)
            {
                firstName = nameParts[0];
                StringBuilder lastNameBuilder = new StringBuilder();
                bool firstTime = true; ;
                for (int i = 1; i < nameParts.Length; ++i)
                {
                    if (firstTime)
                        firstTime = false;
                    else
                        lastNameBuilder.Append(" ");
                    lastNameBuilder.Append(nameParts[i]);
                }
                lastName = lastNameBuilder.ToString();
            }
            else
            {
                firstName = "";
                lastName = "";
            }
        }

        public static bool operator !=(PersonName a, PersonName b)
        {
            return !(a == b);
        }

        public static bool operator ==(PersonName a, PersonName b)
        {
            if (Object.ReferenceEquals(a, b)) return true;
            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null)) return false;

            return a.FirstName == b.FirstName
                    && a.LastName == b.LastName
                    && a.MiddleName == b.MiddleName
                    && a.Prefix.AffixID == b.Prefix.AffixID;
        }

        #endregion static
    }
}

