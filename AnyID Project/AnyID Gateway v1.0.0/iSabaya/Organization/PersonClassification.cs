using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class PersonClassification 
    {

        protected int id;
        public virtual int ID
        {
            get { return id; }
            set { id = value; }
        }

        protected string code;
        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        protected MultilingualString name;
        public virtual MultilingualString Name
        {
            get { return name; }
            set { name = value; }
        }

        protected MultilingualString abbreviation;
        public virtual MultilingualString Abbreviation
        {
            get { return abbreviation; }
            set { abbreviation = value; }
        }

        protected TimeInterval effectivePeriod;
        public virtual TimeInterval EffectivePeriod
        {
            get { return effectivePeriod; }
            set { effectivePeriod = value; }
        }

        protected MultilingualString description;
        public virtual MultilingualString Description
        {
            get { return description; }
            set { description = value; }
        }

        private Organization organization;

        public virtual Organization Organization
        {
            get { return organization; }
            set { organization = value; }
        }

        public virtual string ToLog()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.Append("ID:");
            builder.Append(ID);
            builder.Append(", ");

            builder.Append("Code:");
            builder.Append(Code);
            builder.Append(", ");

            //builder.Append("Name:");
            //builder.Append(Name.ToLog());
            //builder.Append(", ");

            //builder.Append("Abbreviation:");
            //builder.Append(Abbreviation.ToLog());
            //builder.Append(", ");

            //builder.Append("EffectivePeriod:");
            //builder.Append(EffectivePeriod.ToLog());
            //builder.Append(", ");

            //builder.Append("Description:");
            //builder.Append(Description.ToLog());
            //builder.Append(", ");

            //builder.Append("Organization:");
            //builder.Append(Organization.ToLog());
            //builder.Append("]");

            return builder.ToString();
        }


    }
} 
