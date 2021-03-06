using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    public enum RuleResultCategory
    {
        Success,
        Failed, //but can be retried
        Error,  //unrecoverble error - abort
    }


    //not safe for multi-threading
    public class RuleResult
    {
        public static RuleResult Success
        {
            get { return new RuleResult(RuleResultCategory.Success); }
        }

        public static RuleResult Failed
        {
            get { return new RuleResult(RuleResultCategory.Failed); }
        }

        public static RuleResult Error
        {
            get { return new RuleResult(RuleResultCategory.Error); }
        }

        private RuleResult(RuleResultCategory category)
        {
            this.Category = category;
        }

        public String Message;
        public int ErrorCount;
        public int WarningCount;
        //public Object DestinationState;
        public Object Tag = null;
        public Exception ExceptionObject = null;

        public RuleResultCategory Category;

        public static bool operator ==(RuleResult x, RuleResult y)
        {
            return x.Category == y.Category;
        }

        public static bool operator !=(RuleResult x, RuleResult y)
        {
            return x.Category != y.Category;
        }

        public override bool Equals(object obj)
        {
            return this.Category == ((RuleResult)obj).Category;
        }

        public override int GetHashCode()
        {
            return (int)this.Category;
        }
    }
}
