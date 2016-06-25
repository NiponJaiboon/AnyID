using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace iSabaya
{
    [ServiceContract(Namespace = "http://schemas.datacontract.org/2004/07/iSabaya")]
    public interface ITemporal
    {
        TimeInterval EffectivePeriod { get; }
        bool IsEffective { get; }
        bool IsNotFinalized { get; }
        //object PreviousInstance { get; set; }
    }

    public interface ITemporalList<T> : IList<T> where T : ITemporal
    {
        T Current { get; set; }
        void AddAfterExpiringEffectiveInstances(T newInstance);
        T GetInstance(DateTime when);
    }
}