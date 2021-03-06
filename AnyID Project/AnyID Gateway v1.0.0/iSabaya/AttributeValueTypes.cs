using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;

namespace iSabaya
{
    public enum AttributeValueType
    {
        None = 0,
        DateTime = 1,
        Image = 2,
        MLS = 4,
        Node = 8,
        Number = 16,
        Text = 32,
        Party = 64,
        NamePrefix = 128,
    }


    public class AttributeValueTypes
    {
        public int Types { get; set; }

        public void Clear()
        {
            this.Types = 0;
        }

        public void SetType(AttributeValueType type)
        {
            this.Types = (int)type;
        }

        public void AddType(AttributeValueType type)
        {
            this.Types |= (int)type;
        }

        public void RemoveType(AttributeValueType type)
        {
            this.Types &= ~(int)type;
        }

        public bool IncludeType(AttributeValueType type)
        {
            return (this.Types & (int)type) > 0;
        }
    }
} 
