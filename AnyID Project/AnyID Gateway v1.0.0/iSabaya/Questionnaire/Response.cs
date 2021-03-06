using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class Response
    {
        #region ctors

        public Response()
        {
        }

        public Response(Questionnaire questionnaire)
        {
            this.questionnaire = questionnaire;
        }

        #endregion ctors

        #region persistent

        public virtual int ResponseID { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual DateTime CreatedTS { get; set; }

        private Questionnaire questionnaire;
        public virtual Questionnaire Questionnaire
        {
            get { return questionnaire; }
            set { questionnaire = value; }
        }

        private DateTime respondedDate;
        public virtual DateTime RespondedDate
        {
            get { return respondedDate; }
            set { respondedDate = value; }
        }

        private Person respondent;
        public virtual Person Respondent
        {
            get { return respondent; }
            set { respondent = value; }
        }

        public virtual String RespondentFirstName { get; set; }
        public virtual String RespondentMiddleName { get; set; }
        public virtual String RespondentLastName { get; set; }

        public virtual ResponseGroup Responses { get; set; }
        public virtual double Score { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual DateTime UpdatedTS { get; set; }

        #endregion persistent

        public virtual double ComputeScore()
        {
            return this.Score = this.Responses.ComputeScore();
        }

        public virtual void Persist(Context context)
        {
            if (this.CreatedTS == DateTime.MinValue) this.CreatedTS = DateTime.Now;
            if (this.UpdatedTS == DateTime.MinValue) this.UpdatedTS = DateTime.Now;
            if (this.RespondedDate == DateTime.MinValue) this.RespondedDate = DateTime.Now;
            this.ComputeScore();
            if (0 == this.ResponseID)
                context.Persist(this);
            if (null != this.Responses)
                this.Responses.Persist(context);
            if (null != this.Respondent && 0 == this.Respondent.ID)
                this.Respondent.Persist(context);
            context.PersistenceSession.Update(this);
        }

        public static Response Find(Context context, int id)
        {
            return context.PersistenceSession.Get<Response>(id);
        }

        public static IList<Response> List(Context context, String questionnaireCode, Person respondent)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<Response>()
                                    .Add(Expression.Eq("Respondent", respondent))
                                    .CreateAlias("Questionnaire", "q")
                                    .Add(Expression.Eq("q.Code", questionnaireCode));
            return crit.List<Response>();
        }

        public static IList<Response> List(Context context, String questionnaireCode)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<Response>()
                                    .CreateAlias("Questionnaire", "q")
                                    .Add(Expression.Eq("q.Code", questionnaireCode));
            return crit.List<Response>();
        }

        public static IList<Response> List(Context context, String questionnaireCode, 
                                            DateTime from, DateTime to)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<Response>()
                                    .Add(Expression.Ge("RespondedDate", from))
                                    .Add(Expression.Le("RespondedDate", to))                                      
                                    .CreateAlias("Questionnaire", "q")
                                    .Add(Expression.Eq("q.Code", questionnaireCode));
            return crit.List<Response>();
        }
    }
}
