using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class Job : PersistentTemporalTitledEntity
    {
        public virtual Money MaxSalary { get; set; }
        public virtual Money MinSalary { get; set; }
        public virtual Organization Organization { get; set; }
    }
} 
