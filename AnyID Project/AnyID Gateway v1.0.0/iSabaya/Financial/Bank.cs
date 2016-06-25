using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    [Serializable]
    public class Bank : Organization
    {
        public virtual int BranchCodePositionInAccountNumber { get; set; }
        public virtual int BranchCodeLength { get; set; }
    }
}
