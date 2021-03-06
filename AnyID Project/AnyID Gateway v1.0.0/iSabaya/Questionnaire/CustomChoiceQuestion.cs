using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class CustomChoiceQuestion : ChoiceQuestion
    {
        public CustomChoiceQuestion()
        {
        }

        public CustomChoiceQuestion(IQuestionParent parent, CustomChoiceQuestion original)
            : base(parent, original)
        {
            IList<CustomQuestionChoice> choices = new List<CustomQuestionChoice>();
            foreach (CustomQuestionChoice c in original.Choices)
            {
                choices.Add(c.Clone(this));
            }
            base.choices = choices;
        }

        #region persistent

        //protected IList<CustomQuestionChoice> choices;
        public new virtual IList<CustomQuestionChoice> Choices
        {
            get
            {
                if (null == base.choices)
                    base.Choices = new List<CustomQuestionChoice>();
                return (IList<CustomQuestionChoice>)base.Choices;
            }
            set
            {
                base.Choices = value;
            }
        }

        #endregion persistent

        public override ResponseBase CreateEmptyResponse(Response response, ResponseGroup parent)
        {
            ChoiceResponse r = new ChoiceResponse(response, parent, this);
            return r;
        }


        public override QuestionBase Clone(QuestionChoice parent)
        {
            return new CustomChoiceQuestion(parent, this);
        }

        public override QuestionBase Clone(QuestionGroup parent)
        {
            return new CustomChoiceQuestion(parent, this);
        }
    }
}
