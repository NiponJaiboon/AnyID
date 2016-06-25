using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace iSabaya
{
    public abstract class EntityState : PersistentEntity
    {
        public EntityState()
        {
        }

        public EntityState(Context context, PersistentStatefulEntity statefulEntity, string reference, string remark)
            : base(context)
        {
            this.Entity = statefulEntity;
            this.Reference = reference;
            this.Remark = remark;
        }

        protected virtual PersistentStatefulEntity Entity { get; set; }
        public virtual bool IsFinal { get; set; }
        public virtual int StateCategory { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Remark { get; set; }
    }
}
