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
    public enum AccountProxyStateCategory
    {
        Registering, 
        Active,
        /// <summary>
        /// Old version of amended account proxy -> Inactive if success
        /// </summary>
        Old,
        Deactivating, 
        Inactive,
        /// <summary>
        /// New version of amending account proxy -> Active if success
        /// </summary>
        New, 
    }
}
