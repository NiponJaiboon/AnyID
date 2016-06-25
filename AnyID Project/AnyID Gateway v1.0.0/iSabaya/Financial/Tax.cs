using System;
using System.Collections.Generic;
using NHibernate;

namespace iSabaya
{

    public class Tax : PersistentEntity
    {
        #region persistent

        protected TreeListNode Category { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual String Reference { get; set; }
        public virtual String Remark { get; set; }
        private Money BaseAmount { get; set; }
        private Money TaxAmount { get; set; }
        private float TaxRate { get; set; }

        #endregion persistent

    }
}
