using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class PersonAttribute : PersistentTemporalEntity
    {
        #region Constructor

        public PersonAttribute()
        {
        }

        public PersonAttribute(long id)
        {
            this.ID = id;
        }

        public PersonAttribute(Person person, TreeListNode attributeRoot, TreeListNode attribute, DateTime effectiveDate, string reference, string remark)
            : base(effectiveDate, null, reference, remark)
        {
            this.AttributeCategory = attributeRoot;
            this.AttributeValue = attribute;
            this.Person = person;
        }

        #endregion

        #region persistent
        public virtual Person Person { get; set; }
        public virtual TreeListNode AttributeCategory { get; set; }
        public virtual TreeListNode AttributeValue { get; set; }
        public virtual string Description { get; set; }

        #endregion persistent

        #region static

        public static PersonAttribute Find(Context context, long id)
        {
            return context.PersistenceSession.Get<PersonAttribute>(id);
        }

        #endregion

    }
}
