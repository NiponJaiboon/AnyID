using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace iSabaya
{
    public delegate void SetPropertyValue<T>(T fieldTarget, Object fieldValue) where T : class, new();
    public delegate Object GetPropertyValue<T>(T recordInstance) where T : class, new();

    public class ObjectPropertyAccessor<T> where T : class, new()
    {
        public ObjectPropertyAccessor()
        {
        }

        public ObjectPropertyAccessor(GetPropertyValue<T> getter)
        {
            Getter = getter;
        }

        public ObjectPropertyAccessor(SetPropertyValue<T> setter)
        {
            Setter = setter;
        }

        public ObjectPropertyAccessor(GetPropertyValue<T> getter, SetPropertyValue<T> setter)
        {
            Getter = getter;
            Setter = setter;
        }

        public GetPropertyValue<T> Getter;
        public SetPropertyValue<T> Setter;
    }
}