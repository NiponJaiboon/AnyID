using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class ProfessionCategory : PersistentTemporalTitledEntity
    {
        public virtual int PositionLevel { get; set; }
        public virtual ProfessionCategory Parent { get; set; }
        
        private IList<ProfessionCategory> children;
        public virtual IList<ProfessionCategory> Children
        {
            get
            {
                if (this.children == null)
                    this.children = new List<ProfessionCategory>();
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            foreach (var e in Children)
            {
                e.Parent = this;
                e.Persist(context);
            }
            
        }
    }
} 
