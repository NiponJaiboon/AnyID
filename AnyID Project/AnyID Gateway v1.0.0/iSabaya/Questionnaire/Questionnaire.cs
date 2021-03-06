using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;

namespace iSabaya
{

    public class Questionnaire
    {
        public const String ItemNoDelimiter = ".";
        #region ctors

        public Questionnaire()
        {
            this.UnderConstruction = true;
        }

        #endregion ctors

        #region persistent

        private String code;
        public virtual String Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual User CreatedBy { get; set; }
        public virtual DateTime CreatedTS { get; set; }
        public virtual bool UnderConstruction { get; set; }

        private MultilingualString description;
        public virtual MultilingualString Description
        {
            get { return description; }
            set { description = value; }
        }
        public virtual VisualStyle DescriptionStyle { get; set; }

        private TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        private int questionnaireID;
        public virtual int QuestionnaireID
        {
            get { return questionnaireID; }
            set { questionnaireID = value; }
        }

        private QuestionGroup questions;
        public virtual QuestionGroup Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        public virtual String Reference { get; set; }
        public virtual String Remark { get; set; }

        //private static char SeqNoDilimiter = ' ';
        //public virtual String PageSeqNumbers
        //{
        //    get
        //    {
        //        if (null == this.PageLastQuestionSeqNumbers)
        //            return null;

        //        return this.PageLastQuestionSeqNumbers.ToString(SeqNoDilimiter);
        //    }
        //    set
        //    {
        //        if (String.IsNullOrEmpty(value))
        //            PageLastQuestionSeqNumbers = null;
        //        else
        //        {
        //            String[] seqNos = value.Split(new char[] { SeqNoDilimiter }, StringSplitOptions.RemoveEmptyEntries);
        //            this.pageLastQuestionSeqNumbers = new int[seqNos.Length];
        //            int i = -1;
        //            foreach (String seqNoString in seqNos)
        //            {
        //                this.pageLastQuestionSeqNumbers[++i] = int.Parse(seqNoString);
        //            }
        //        }
        //    }
        //}

        private MultilingualString title;
        public virtual MultilingualString Title
        {
            get { return title; }
            set { title = value; }
        }
        public virtual VisualStyle TitleStyle { get; set; }

        public virtual User UpdatedBy { get; set; }
        public virtual DateTime UpdatedTS { get; set; }

        #endregion persistent

        //private int[] pageLastQuestionSeqNumbers;
        //public virtual int[] PageLastQuestionSeqNumbers
        //{
        //    get { return this.pageLastQuestionSeqNumbers; }
        //    set
        //    {
        //        if (null != value)
        //        {
        //            int questionCount = this.Questions.QuestionCount;
        //            int prevSeqNo = -1;
        //            foreach (int seqNo in value)
        //            {
        //                if (seqNo >= questionCount)
        //                    throw new iSabayaException("A sequence number of the last question in a page exceeds the number of questions.");
        //                if (seqNo <= prevSeqNo)
        //                    throw new iSabayaException("The sequence numbers of the last question in a page is not in ascending order.");
        //                prevSeqNo = seqNo;
        //            }
        //        }
        //        this.pageLastQuestionSeqNumbers = value;
        //    }

        //}

        public virtual Response CreateEmptyResponse()
        {
            Response r = new Response(this);
            r.Responses = (ResponseGroup)this.Questions.CreateEmptyResponse(r, null);
            return r;
        }

        public virtual Questionnaire Clone(User user)
        {
            Questionnaire clone = new Questionnaire();
            clone.code = this.code;
            clone.CreatedBy = user;
            clone.CreatedTS = DateTime.Now;
            clone.description = this.description.Clone();
            clone.DescriptionStyle = this.DescriptionStyle.Clone();
            clone.effectivePeriod = TimeInterval.EmptyInterval;
            clone.questions = this.questions.Clone(clone);
            clone.Reference = this.Reference;
            clone.Remark= this.Remark;
            clone.title= this.title.Clone();
            clone.TitleStyle = this.TitleStyle.Clone();
            clone.UpdatedBy = user;
            clone.UpdatedTS = DateTime.Now;
            return clone;
        }

        public virtual void Persist(Context context)
        {
            if (this.CreatedTS == DateTime.MinValue) this.CreatedTS = DateTime.Now;
            if (this.UpdatedTS == DateTime.MinValue) this.UpdatedTS = DateTime.Now;
            this.Questions.TitleIsVisible = false;
            this.Questions.SetItemOutlineNo();
            //if (0 == this.QuestionnaireID)
            //    context.Persist(this);
            if (null != this.Questions)
                this.Questions.Persist(context);
            if (null != this.Description)
                this.Description.Persist(context);
            if (null != this.DescriptionStyle && this.DescriptionStyle.ID == 0)
                this.DescriptionStyle.Persist(context);
            if (null != this.Title)
                this.Title.Persist(context);
            if (null != this.TitleStyle && this.TitleStyle.ID == 0)
                this.TitleStyle.Persist(context);
            context.PersistenceSession.SaveOrUpdate(this);
        }

        /// <summary>
        /// List all questionaires.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IList<Questionnaire> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria<Questionnaire>()
                                    .List<Questionnaire>();
        }

        /// <summary>
        /// Find a questionaire with the given id.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Questionnaire Find(Context context, int id)
        {
            return context.PersistenceSession.Get<Questionnaire>(id);
        }

        /// <summary>
        /// Find a finished questionaire with the given code and is effective on the given date.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="questionnaireCode"></param>
        /// <returns></returns>
        public static Questionnaire FindFinisedQuestionnaire(Context context, String questionnaireCode, DateTime onDate)
        {
            return context.PersistenceSession.CreateCriteria<Questionnaire>()
                                    .Add(Expression.Eq("Code", questionnaireCode))
                                    .Add(Expression.Eq("UnderConstruction", false))
                                    .Add(Expression.Le("EffectivePeriod.From", onDate))
                                    .Add(Expression.Ge("EffectivePeriod.To", onDate))
                                    .UniqueResult<Questionnaire>();
        }

        public static IList<Questionnaire> ListAll(Context context, DateTime effectiveDate)
        {
            return context.PersistenceSession.CreateCriteria<Questionnaire>()
                                    .Add(Expression.Le("EffectivePeriod.From", effectiveDate))
                                    .Add(Expression.Ge("EffectivePeriod.To", effectiveDate))
                                    .List<Questionnaire>();
        }

        /// <summary>
        /// Find all (finished or under-construction) questionaires of a given code.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="questionnaireCode"></param>
        /// <returns></returns>
        public static IList<Questionnaire> ListAll(Context context, String questionnaireCode)
        {
            return context.PersistenceSession.CreateCriteria<Questionnaire>()
                                    .Add(Expression.Eq("Code", questionnaireCode))
                                    .List<Questionnaire>();
        }

        /// <summary>
        /// Find all under-construction questionaires.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="questionnaireCode"></param>
        /// <returns></returns>
        public static IList<Questionnaire> ListUnderConstructionQuestionaires(Context context)
        {
            return context.PersistenceSession.CreateCriteria<Questionnaire>()
                                    .Add(Expression.Eq("UnderConstruction", true))
                                    .List<Questionnaire>();
        }

        /// <summary>
        /// Find all under-construction questionaires with the given code.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="questionnaireCode"></param>
        /// <returns></returns>
        public static IList<Questionnaire> ListUnderConstructionQuestionaires(Context context, String questionnaireCode)
        {
            return context.PersistenceSession.CreateCriteria<Questionnaire>()
                                    .Add(Expression.Eq("Code", questionnaireCode))
                                    .Add(Expression.Eq("UnderConstruction", true))
                                    .List<Questionnaire>();
        }
    }
}
