using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    public enum MLSCategory
    {
        Undefined,
        Model,
        Controller,
        View,
        Report,
        Config,
        Master,
        Transaction,
    }


    public class MultilingualString : IComparable, IComparable<MultilingualString>
    {
        #region constructors
        
        public MultilingualString()
            : base()
        {
            this.Category = MLSCategory.Undefined;
        }

        public MultilingualString(MultilingualString original)
        {
            this.Category = original.Category;
            this.Code = original.Code;
            this.Description = original.Description;
            foreach (MLSValue v in original.Values)
                this.Values.Add(new MLSValue(this, v));
        }

        public MultilingualString(Language language, String value)
        {
            this.Category = MLSCategory.Undefined;
            this.Code = "";
            this.Values.Add(new MLSValue(this, language, value));
        }

        /// <summary>
        /// </summary>
        /// <param name="languageCodeValuePairs">array of pairs of LanguageCode and StringValue </param>
        public MultilingualString(params String[] languageCodeValuePairs)
        {
            if (null == languageCodeValuePairs)
                return;

            if (1 == languageCodeValuePairs.Length % 2)
                throw new iSabayaException("The number elememnts in Language code-value array is not an even number.");

            this.Category = MLSCategory.Undefined;
            this.Code = "";
            for (int i = 0; i < languageCodeValuePairs.Length; i += 2)
            {
                this.Values.Add(new MLSValue(languageCodeValuePairs[i], languageCodeValuePairs[i + 1]));
            }
        }

        public MultilingualString(MLSValue mlsValue)
        {
            this.Category = MLSCategory.Undefined;
            this.Code = "";
            this.Values.Add(mlsValue);
        }

        public MultilingualString(Dictionary<Language, String> dic)
        {
            this.Category = MLSCategory.Undefined;
            this.Code = "";

            DateTime updatedTS = DateTime.Now;
            foreach (Language lang in dic.Keys)
            {
                MLSValue valueTH = new MLSValue(this, lang, dic[lang]);
                this.Values.Add(valueTH);
            }
        }

        public MultilingualString(MLSCategory category, String code, Language language, String value)
        {
            this.Category = category;
            this.Code = code;
            this.Values.Add(new MLSValue(this, language, value));
        }

        public MultilingualString(MLSCategory category, String code, String[] languageCodeValuePairs)
        {
            this.Category = category;
            this.Code = code;
            for (int i = 0; i < languageCodeValuePairs.Length; i += 2)
                this.Values.Add(new MLSValue(languageCodeValuePairs[i], languageCodeValuePairs[i + 1]));
        }

        public MultilingualString(MLSCategory category, String code, MLSValue mlsValue)
        {
            this.Category = category;
            this.Code = code;
            this.Values.Add(mlsValue);
        }

        public MultilingualString(MLSCategory category, String code, Dictionary<Language, String> dic)
        {
            this.Category = category;
            this.Code = code;

            foreach (Language lang in dic.Keys)
                this.Values.Add(new MLSValue(this, lang, dic[lang]));
        }

        #endregion

        #region persistent

        public virtual long ID { get; set; }
        public virtual MLSCategory Category { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }

        protected IList<MLSValue> values;
        public virtual IList<MLSValue> Values
        {
            get
            {
                if (this.values == null) this.values = new List<MLSValue>();
                return this.values;
            }
            set
            {
                this.values = value;
            }
        }

        #endregion persistent

        #region operations

        public virtual MLSValue this[int i]
        {
            get { return this.Values[i]; }
        }

        public virtual string this[string languageCode]
        {
            get
            {
                foreach (MLSValue v in this.Values)
                {
                    if (v.LanguageCode == languageCode)
                        return v.Value;
                }
                return null;
            }
            set
            {
                foreach (MLSValue v in this.Values)
                {
                    if (v.LanguageCode == languageCode)
                    {
                        v.Value = value;
                        return;
                    }
                }
                this.Values.Add(new MLSValue(this, languageCode, value));
            }
        }

        public virtual Context Context { get; set; }

        public virtual void AddOrReplace(MLSValue mlsValue)
        {
            foreach (MLSValue v in values)
            {
                if (v.LanguageCode == mlsValue.Language.Code)
                {
                    v.Value = mlsValue.Value;
                    return;
                }
            }
            Values.Add(mlsValue);
        }

        public virtual void AddOrReplace(string languageCode, String value)
        {
            foreach (MLSValue v in values)
            {
                if (v.LanguageCode == languageCode)
                {
                    v.Value = value;
                    return;
                }
            }
            Values.Add(new MLSValue(this, languageCode, value));
        }

        public virtual void AddOrReplace(Language language, String value)
        {
            foreach (MLSValue v in values)
            {
                if (v.LanguageCode == language.Code)
                {
                    v.Value = value;
                    return;
                }
            }
            Values.Add(new MLSValue(this, language, value));
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (MLSValue v in this.Values)
            {
                sb.Append(v.LanguageCode);
                sb.Append(",");
                sb.Append(v.Value);
                sb.Append(", ");
            }
            return sb.ToString();
            //foreach (MLSValue v in Values)
            //{
            //    if (null == v.Language || v.Language.SeqNo == 0)
            //        return v.Value;
            //}
            //if (null == this.Context)
            //{
            //    if (null != Configuration.CurrentConfiguration && null != Configuration.CurrentConfiguration.DefaultLanguage)
            //    {
            //        string defaultLanguageCode = Configuration.CurrentConfiguration.DefaultLanguage.Code;
            //        foreach (MLSValue v in Values)
            //        {
            //            if (null == v.Language || v.Language.Code == defaultLanguageCode)
            //                return v.Value;
            //        }
            //    }
            //    else
            //    {
            //        foreach (MLSValue v in Values)
            //        {
            //            if (null == v.Language || v.Language.SeqNo == 0)
            //                return v.Value;
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (MLSValue v in Values)
            //    {
            //        if (null == v.Language || v.Language == this.Context.CurrentLanguage)
            //            return v.Value;
            //    }
            //}
            //return this.Values.Count > 0 ? this.Values[0].Value : "";
        }

        public virtual String ToString(Language language)
        {
            return this.ToString(language.Code);
        }

        public virtual String ToString(String langCode)
        {
            foreach (MLSValue v in Values)
            {
                if (v.LanguageCode == langCode)
                    return v.Value;
            }
            return "";
        }

        public virtual String GetValue()
        {
            return this.ToString();
        }

        public virtual String GetValue(String langCode)
        {
            return this.ToString(langCode);
        }

        public virtual void Persist(Context context)
        {
            context.Persist(this);
            foreach (var e in this.Values)
            {
                e.Owner = this;
                context.Persist(e);
            }
        }

        public virtual void UpdateData(MultilingualString newValue)
        {
            DateTime now = DateTime.Now;
            foreach (MLSValue mlsValue in Values)
            {
                String code = mlsValue.LanguageCode;
                mlsValue.Value = newValue.GetValue(code);
            }
        }

        public virtual void Update(Context context)
        {
            foreach (MLSValue mlsValue in Values)
            {
                context.PersistenceSession.Update(mlsValue);
            }
        }

        public virtual void ChangeValueTo(MultilingualString newValue)
        {
            foreach (MLSValue val in Values)
            {
                foreach (MLSValue nval in newValue.Values)
                {
                    if (val.Language.Equals(nval))
                    {
                        val.Value = nval.Value;
                    }
                }
            }
        }

        public virtual void Append(MultilingualString mls)
        {
            if (mls == null) return;

            foreach (MLSValue lv in this.Values)
            {
                foreach (MLSValue rv in mls.Values)
                {
                    if (lv.LanguageCode == rv.LanguageCode)
                    {
                        lv.Value += rv.Value;
                        rv.Matched = true;
                        break;
                    }
                }
            }

            //check for values of the languages not found in this
            //xxx
            foreach (MLSValue rv in mls.Values)
            {
                if (rv.Matched)
                    rv.Matched = false;
                else
                    this.Values.Add(new MLSValue(this, rv));
            }
        }

        public virtual void Append(String s)
        {
            foreach (MLSValue lv in this.Values)
            {
                lv.Value += s;
            }
        }

        public virtual String ToLog()
        {
            throw new iSabayaException("The method or operation is not implemented.");
        }

        public virtual bool IsMatched(String p)
        {
            foreach (MLSValue v in this.Values)
            {
                if (p == v.Value) return true;
            }
            return false;
        }

        #endregion operations

        #region static

        public static String ValueInCurrentLanguage(Context context, String code)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<MultilingualString>()
                                    .Add(Expression.Eq("Code", code));
            IList<MultilingualString> mlss = crit.List<MultilingualString>();
            MultilingualString mls = null;
            if (mlss.Count > 0)
            {
                mls = mlss[0];
                if (mls.Values.Count > 0)
                {
                    foreach (MLSValue mlsValue in mls.Values)
                    {
                        if (mlsValue.LanguageCode == context.CurrentLanguage.Code)
                            return mlsValue.Value;
                    }
                }
            }
            return null;
        }

        public static MultilingualString CreateMLS(Context context, String[] languageCodes, String[] texts)
        {
            MultilingualString mls = new MultilingualString();
            for (int i = 0; i < languageCodes.Length; i++)
            {
                Language lang = Language.FindByCode(context, languageCodes[i]);
                //mls.Code = RunningNumber.NextMLSID(session).ToString();
                MLSValue mlsValue = new MLSValue(mls, lang, texts[i]);
                mls.Values.Add(mlsValue);
            }
            return mls;
        }

        public static MultilingualString operator +(MultilingualString left, MultilingualString right)
        {
            if (left == null)
                if (right == null)
                    return null;
                else
                    right.Clone();
            else
                if (right == null)
                    left.Clone();

            MultilingualString result = new MultilingualString();
            bool noMatch = true;
            foreach (MLSValue lv in left.Values)
            {
                foreach (MLSValue rv in right.Values)
                {
                    if (lv.LanguageCode == rv.LanguageCode)
                    {
                        result.Values.Add(new MLSValue(result, lv.Language, lv.Value + rv.Value));
                        rv.Matched = true;
                        noMatch = false;
                        break;
                    }
                }
                if (noMatch) //language in left that is not found in right
                {
                    result.Values.Add(new MLSValue(result, lv));
                    noMatch = true;
                }
            }

            //check for values in right but not in left
            foreach (MLSValue rv in right.Values)
            {
                if (rv.Matched)
                    rv.Matched = false;
                else
                    result.Values.Add(new MLSValue(result, rv));
            }
            return result;
        }

        public static MultilingualString operator +(MultilingualString left, string right)
        {
            if (left == null) return null;

            MultilingualString result = new MultilingualString();
            foreach (MLSValue v in left.Values)
            {
                result.Values.Add(new MLSValue(result, v.Language, v.Value + right));
            }
            return result;
        }

        public static MultilingualString operator +(string left, MultilingualString right)
        {
            if (right == null) return null;

            MultilingualString result = new MultilingualString();
            foreach (MLSValue v in right.Values)
            {
                result.Values.Add(new MLSValue(result, v.Language, left + v.Value));
            }
            return result;
        }

        #endregion static

        #region IComparable<TimeInterval> Members

        public virtual int CompareTo(MultilingualString other)
        {
            if (Object.ReferenceEquals(null, other))
                return 1;
            if (Object.ReferenceEquals(this, other))
                return 0;
            return String.Compare(this.ToString(), other.ToString());
        }

        #endregion IComparable<TimeInterval> Members

        #region IComparable Members

        public virtual int CompareTo(object obj)
        {
            return String.Compare(this.ToString(), ((MultilingualString)obj).ToString());
        }

        #endregion IComparable Members

        public static bool IsNullOrEmpty(MultilingualString mls)
        {
            if (null == mls || 0 == mls.Values.Count)
                return true;

            bool isEmpty = true;
            foreach (MLSValue v in mls.Values)
            {
                isEmpty &= (null == v || String.IsNullOrEmpty(v.Value));
            }
            return isEmpty;
        }
    }
}