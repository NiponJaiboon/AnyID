using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyIDModel
{
    public enum ProxyTransactionTransitionEvent
    {
        Submit,
        Approve,
        Reject,
        Success,
        Timeout,
        Offline,
        Exported,
        Fail,
        Error,
    }
}
