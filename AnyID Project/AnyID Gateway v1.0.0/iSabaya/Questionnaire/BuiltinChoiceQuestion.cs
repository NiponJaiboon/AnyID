using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class BuiltinChoiceQuestion : ChoiceQuestion
    {
        public BuiltinChoiceQuestion()
        {
        }

        public BuiltinChoiceQuestion(ChoiceList choiceList, MultilingualString[] choiceRubrics)
        {
            this.choiceList = choiceList;
            int i = 0;

            IList<ChoiceItemQuestionChoice> choices = new List<ChoiceItemQuestionChoice>();
            foreach (ChoiceItem c in this.choiceList.Choices)
            {
                choices.Add(new ChoiceItemQuestionChoice(this, choiceRubrics[i++], c));
            }
            base.choices = choices;
        }

        public BuiltinChoiceQuestion(IQuestionParent parent, BuiltinChoiceQuestion original)
            : base(parent, original)
        {
            IList<ChoiceItemQuestionChoice> choices = new List<ChoiceItemQuestionChoice>();
            foreach (ChoiceItemQuestionChoice c in original.choices)
            {
                choices.Add(new ChoiceItemQuestionChoice(this, c));
            }
            base.choices = choices;
        }

        #region persistent

        protected ChoiceList choiceList;
        public virtual ChoiceList ChoiceList
        {
            get { return this.choiceList; }
            set { this.choiceList = value; }
        }

        public new virtual IList<ChoiceItemQuestionChoice> Choices
        {
            get
            {
                if (null == base.choices)
                    base.Choices = new List<ChoiceItemQuestionChoice>();
                return (IList<ChoiceItemQuestionChoice>)base.Choices;
            }
            set
            {
                base.Choices = value;
            }
        }

        #endregion persistent

        //public override ResponseBase CreateEmptyResponse(Response response, ResponseGroup parent)
        //{
        //    ChoiceResponse r = new ChoiceResponse(response, parent, this);
        //    return r;
        //}

        //public override void Persist(Context context)
        //{
        //    base.Persist(context);
        //}

        public override QuestionBase Clone(QuestionChoice parent)
        {
            return new BuiltinChoiceQuestion(parent, this);
        }

        public override QuestionBase Clone(QuestionGroup parent)
        {
            return new BuiltinChoiceQuestion(parent, this);
        }
    }
}
