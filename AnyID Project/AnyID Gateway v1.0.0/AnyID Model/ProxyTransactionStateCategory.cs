using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    /// <summary>
    /// Do not change the order of the enum elements. 
    /// </summary>
    public enum ProxyTransactionStateCategory
    {
        Submitted,
        Approved,
        Success,
        Rejected,
        Failed,
        Timeout,
        Offline,
        Exported,
    }
}