using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public abstract class PropertyFieldMapping<T> where T : class, new()
    {
        public PropertyFieldMapping()
        {
        }

        public PropertyFieldMapping(int fieldAccessorID)
        {
            this.FieldAccessorID = fieldAccessorID;
        }

        #region persistent

        /// <summary>
        /// Auto-generated Primary Key
        /// </summary>
        public virtual int FieldFormatID { get; set; }
        public virtual int ColumnNo { get; set; }
        public virtual String Description { get; set; }
        public virtual bool IsMandatory { get; set; }
        public virtual ObjectRecordMapping<T> Owner { get; set; }

        private int fieldAccessorID = -1;
        public virtual int FieldAccessorID
        {
            get { return this.fieldAccessorID; }
            set { this.fieldAccessorID = value; }
        }

        public virtual String Name { get; set; }

        #endregion persistent

        #region abstract
        
        public abstract Object Convert(String value);
        public abstract void FormatValue(IFileWriter writer, T recordInstance);
        public abstract String GetTypeName();
        public abstract bool ExtractIntoTarget(T target, Object source);

        #endregion        
        

        public virtual bool HasValueGetter()
        {
            return null != InstancePropertyAccessor && null != InstancePropertyAccessor.Getter;
        }

        public virtual bool HasValueSetter()
        {
            return null != InstancePropertyAccessor && null != InstancePropertyAccessor.Setter;
        }

        /// <summary>
        /// Code to access (get and/or set) a property of the instance.
        /// </summary>
        public virtual ObjectPropertyAccessor<T> InstancePropertyAccessor { get; set; }

        public virtual Object GetTargetValue(T instance)
        {
            if (this.HasValueGetter())
                return InstancePropertyAccessor.Getter(instance);
            else
                return null;
        }

        public virtual void SetTargetValue(PropertyFieldMapping<T> field, T fieldTarget, Object fieldValue)
        {
            if (this.HasValueSetter())
                InstancePropertyAccessor.Setter(fieldTarget, fieldValue);
        }

        public virtual Object Value { get; set; }

        //public virtual void Persist(Context context)
        //{
        //    context.PersistenceSession.SaveOrUpdate(this);
        //}
    }
}