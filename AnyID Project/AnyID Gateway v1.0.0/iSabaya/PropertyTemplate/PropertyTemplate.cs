using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class PropertyTemplate : PropertyTemplateBase, IProperty
    {
        #region ctors

        public PropertyTemplate()
        {
        }

        #endregion ctors

        #region persistent

        private PropertyValue defaultValue;
        public virtual PropertyValue DefaultValue
        {
            get { return defaultValue; }
            set
            {
                this.defaultValue = value;
                if (null != this.defaultValue)
                    this.defaultValue.Property = this;
            }
        }

        private PropertyValueType valueType;
        public virtual PropertyValueType ValueType
        {
            get { return valueType; }
            set { this.valueType = value; }
        }

        public virtual String ValueTypeName
        {
            get { return this.valueType.ValueTypeName; }
            set { this.valueType = new PropertyValueType(value); }
        }

        #endregion persistent

        public override PropertyValueContainerBase CreateValueContainer()
        {
            return new PropertyValueContainer(this, new PropertyValue(this, this.DefaultValue));
        }

        public virtual bool IsInstanceOfType(object instance)
        {
            if (null != this.ValueType)
                return false;
            return this.ValueType.ValueType.IsInstanceOfType(instance);
        }

        public override void Persist(Context context)
        {
            context.Persist(this);
        }

        #region IProperty Members

        string IProperty.ToValueString(object value)
        {
            return this.ValueType.ToValueString(value);
        }

        byte[] IProperty.ToBytes(object value)
        {
            return this.ValueType.ToBytes(value);
        }

        object IProperty.FromBytes(byte[] bytes)
        {
            return this.ValueType.FromBytes(bytes);
        }

        #endregion
    }
}
