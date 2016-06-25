using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public enum ProbationResult
    {
        Complete,
        Failed,
        Reduced,
        Extended,
    }

    public class Probation : PersistentEntity
    {
        public virtual TimeInterval ProbationPeriod { get; set; }
        public virtual ProbationResult Result { get; set; }
        public virtual DateTime ResultDate { get; set; }

    }
}
