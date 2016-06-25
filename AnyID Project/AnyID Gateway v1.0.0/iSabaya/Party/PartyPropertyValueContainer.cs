using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class PartyPropertyValueContainer : PartyPropertyTemplate
    {
        #region constructors

        public PartyPropertyValueContainer()
        {
        }

        public PartyPropertyValueContainer(PartyPropertyValueContainer original, User user)
            : base(original, user)
        {
            this.propertyValueContainer = original.propertyValueContainer;
        }

        public PartyPropertyValueContainer(Party party, PropertyTemplateBase propertyTemplate,
                            PropertyValueContainerBase propertyValueContainer,
                            String description, String reference, String remark,
                            TimeInterval effectivePeriod, User user)
            : base(party, propertyTemplate, description, reference, remark, effectivePeriod, user)
        {
            this.propertyValueContainer = propertyValueContainer;
        }

        #endregion constructors

        #region persistent

        private PropertyValueContainerBase propertyValueContainer;
        public virtual PropertyValueContainerBase PropertyValueContainer
        {
            get { return propertyValueContainer; }
            set { propertyValueContainer = value; }
        }

        #endregion persistent

        public override void Persist(Context context)
        {
            if (0 == this.PropertyTemplate.ID)
                this.PropertyTemplate.Persist(context);
            if (0 == this.propertyValueContainer.PropertyValueContainerID)
                this.propertyValueContainer.Persist(context);
            context.PersistenceSession.SaveOrUpdate(this);
        }

        public override string ToLog()
        {
            return "";
        }

        //public override String ToString(String languageCode)
        //{
        //    return base.Category.ToString(languageCode) + ":" + this.PropertyTemplate.ToString(languageCode);
        //}

        public static new PartyPropertyValueContainer Find(Context context, int id)
        {
            return context.PersistenceSession.Get<PartyPropertyValueContainer>(id);
        }

        public static IList<PartyPropertyValueContainer> Find(Context context, Party party, int NodeID)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<PartyPropertyValueContainer>()
                                    .Add(Expression.Eq("Party", party));
            return crit.List<PartyPropertyValueContainer>();
        }
    }
}
