using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class MLS : IEnumerable<LS>
    {
        public MLS()
        {
        }

        public MLS(string languageCode, string stringValue, string languageCode2, string stringValue2)
        {
            this.values = new List<LS>();
            this.values.Add(new LS(this, languageCode, stringValue));
            this.values.Add(new LS(this, languageCode2, stringValue2));
        }

        public MLS(string[] strings)
        {
            if (strings != null)
                for (int i = 0; i < strings.Length; ++i)
                    this.values.Add(new LS(this, (strings[i]), strings[++i]));
        }

        public virtual LS this[int i]
        {
            get { return this.values[i]; }
        }

        private IList<LS> values { get; set; }
        protected virtual IList<LS> Values
        {
            get { return this.values; }
            set { this.values = (IList<LS>)value; }
        }
        public virtual int Count { get { return this.values.Count; } }

        public virtual IEnumerator<LS> GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }
    }
}
