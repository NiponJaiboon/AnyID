using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.UserTypes;
using NHibernate.Engine;
//using NHibernate.Collection.Generic;

namespace iSabaya
{
    public interface ITemporal
    {
        TimeInterval EffectivePeriod { get; }
        bool IsEffective { get; }
        bool IsNotFinalized { get; }
        object PreviousInstance { get; set; }
    }

    public interface ITemporalList<T> : IList<T> where T : ITemporal
    {
        T Current { get; set; }
        void AddAfterExpiringEffectiveInstances(T newInstance);
        T GetInstance(DateTime when);
    }
}