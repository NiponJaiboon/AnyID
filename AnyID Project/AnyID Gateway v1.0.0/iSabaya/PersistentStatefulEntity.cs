using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iSabaya
{

    public abstract class PersistentStatefulEntity : PersistentEntity
    {
        public PersistentStatefulEntity()
        {
        }

        public PersistentStatefulEntity(Context context)
            : base(context)
        {
        }

        public virtual EntityState CurrentState { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Remark { get; set; }

        protected IEnumerable<EntityState> states;
        public virtual IEnumerable<EntityState> States
        {
            get { return this.states; }
            set { this.states = value; }
        }
    }
}
