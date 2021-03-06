using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    public enum ParameterDirection
    {
        IN,
        OUT,
        INOUT
    }

    public class RuleParameter
    {
        public RuleParameter()
        { 
        }

		public RuleParameter(ParameterDirection direction, string name)
		{
			this.direction = direction;
			this.name = name;
			this.parValue = null;
		}

		public RuleParameter(ParameterDirection direction, string name, Type valueType)
		{
			this.direction = direction;
			this.name = name;
			this.valueType = valueType;
			this.parValue = null;
		}

		public RuleParameter(ParameterDirection direction, string name, object value)
		{
			this.direction = direction;
			this.name = name;
			this.parValue = value;
		}

		public RuleParameter(ParameterDirection direction, string name, Type valueType, object value)
        {
			this.direction = direction;
			this.name = name;
            this.parValue = value;
            this.valueType = valueType;
        }

        protected string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected object parValue;
        public virtual object Value
        {
            get { return parValue; }
            set 
			{
                if (value == null || null == valueType)
                {
                    this.parValue = value;
                }
                else 
                {
                    Type t = value.GetType();

                    if (!(t.IsSubclassOf(valueType) || t == valueType))
                    {
                        //throw new iSabayaException(iSabayaResources.RuleParameterIncorrectTypeOfValueMessage + " " + valueType.ToString());
                        throw new iSabayaException(valueType.ToString());
                    }
                    this.parValue = value;
                }
			}
        }

        protected Type valueType;
        public virtual Type ValueType
        {
            get { return valueType; }
            set { valueType = value; }
        }

        protected ParameterDirection direction;
        public virtual ParameterDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public virtual string ToLog()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.Append("Name:");
            builder.Append(Name);
            builder.Append(", ");

            builder.Append("Value:");
            builder.Append(Value);
            builder.Append(", ");

            builder.Append("ValueType:");
            builder.Append(ValueType);
            builder.Append(", ");

            builder.Append("Direction:");
            builder.Append(Direction);
            builder.Append("]");

            return builder.ToString();
        }

    }

} // iSabaya
