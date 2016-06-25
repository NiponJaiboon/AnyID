using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// This class is the the children of ChoiceQuestionGroup
    /// </summary>

    public class GroupChoiceQuestion : ChoiceQuestion
    {
        public GroupChoiceQuestion()
        {
        }

        public GroupChoiceQuestion(ChoiceQuestionGroup parent, GroupChoiceQuestion original)
            : base(parent, original)
        {
        }

        public GroupChoiceQuestion(ChoiceQuestionGroup parent, MultilingualString title)
        {
            base.Title = title;
            this.Parent = parent;
            CreateQuestionChoices(parent.ChoiceList);
        }

        public GroupChoiceQuestion(MultilingualString title, ChoiceList choiceList)
        {
            base.Title = title;
            CreateQuestionChoices(choiceList);
        }

        public GroupChoiceQuestion(MultilingualString title, ChoiceList choiceList, MultilingualString[] choiceRubrics)
        {
            base.Title = title;
            CreateQuestionChoices(choiceList, choiceRubrics);
        }

        #region persistent

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

        public new virtual ChoiceQuestionGroup Parent
        {
            get { return (ChoiceQuestionGroup)base.Parent; }
            set { base.Parent = value; }
        }

        #endregion persistent

        private MultilingualString[] choiceRubrics;

        public virtual void CreateQuestionChoices(ChoiceList choiceList)
        {
            this.Choices.Clear();
            if (null == this.choiceRubrics)
                foreach (ChoiceItem c in choiceList.Choices)
                {
                    this.Choices.Add(new ChoiceItemQuestionChoice(this, null, c));
                }
            else
            {
                int i = 0;
                foreach (ChoiceItem c in choiceList.Choices)
                {
                    this.Choices.Add(new ChoiceItemQuestionChoice(this, this.choiceRubrics[i++], c));
                }
            }
        }

        public virtual void CreateQuestionChoices(MultilingualString[] choiceRubrics)
        {
            this.Choices.Clear();
            this.choiceRubrics = choiceRubrics;
        }

        public virtual void CreateQuestionChoices(ChoiceList choiceList, MultilingualString[] choiceRubrics)
        {
            this.Choices.Clear();
            int i = 0;
            foreach (ChoiceItem c in choiceList.Choices)
            {
                this.Choices.Add(new ChoiceItemQuestionChoice(this, choiceRubrics[i++], c));
            }
        }

        public override QuestionBase Clone(QuestionGroup parent)
        {
            return new GroupChoiceQuestion((ChoiceQuestionGroup)parent, this);
        }

        public override QuestionBase Clone(QuestionChoice parent)
        {
            throw new NotImplementedException();
        }
    }
}
