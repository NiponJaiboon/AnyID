using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{

    public abstract class QuestionChoice : IQuestionParent
    {
        public QuestionChoice()
        {
        }

        public QuestionChoice(MultilingualString title, QuestionBase furtherQuestion,
                                MultilingualString rubric)
        {
            this.Title = title;
            this.FurtherQuestion = furtherQuestion;
            this.Rubric = rubric;
        }

        public QuestionChoice(ChoiceQuestion parent, QuestionChoice original)
        {
            this.ParentQuestion = parent;
            if (null != this.FurtherQuestion)
                this.FurtherQuestion = original.FurtherQuestion.Clone(this);
            this.FurtherQuestionStartsOnTheNextRow = original.FurtherQuestionStartsOnTheNextRow;
            this.Rubric = original.Rubric.Clone();
            this.RubricIsVisible = original.RubricIsVisible;
            this.score = original.score;
            this.seqNo = original.seqNo;
            this.TitleStyle = original.TitleStyle.Clone();
        }

        #region persistent

        public virtual int ID { get; set; }
        public virtual QuestionBase FurtherQuestion { get; set; }
        public virtual bool FurtherQuestionStartsOnTheNextRow { get; set; }
        //public virtual ChoiceQuestion ParentQuestion { get; set; }
        public virtual ChoiceQuestion ParentQuestion { get; set; }
        public virtual MultilingualString Rubric { get; set; }
        public virtual bool RubricIsVisible { get; set; }

        protected double score;
        public virtual double Score
        {
            get { return score; }
            set { this.score = value; }
        }

        private int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        public virtual MultilingualString Title { get; set; }
        public virtual VisualStyle TitleStyle { get; set; }

        #endregion persistent

        public virtual void Persist(Context context)
        {
            if (null != this.Rubric)
                this.Rubric.Persist(context);
            if (null != this.TitleStyle && this.TitleStyle.ID == 0)
                this.TitleStyle.Persist(context);
            if (null != this.FurtherQuestion && 0 == this.FurtherQuestion.ID)
            {
                this.FurtherQuestion.Persist(context);
            }
            if (0 == this.ID)
                context.Persist(this);
            if (null != this.FurtherQuestion)
            {
                if (0 == this.FurtherQuestion.ID)
                    this.FurtherQuestion.Parent = this;
                this.FurtherQuestion.Persist(context);
                context.PersistenceSession.Update(this);
            }
        }

        public abstract QuestionChoice Clone(ChoiceQuestion parent);
    }
}
