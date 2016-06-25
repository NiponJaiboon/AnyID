using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyIDModel
{
    public enum ProxyTransitionEvent
    {
        Registering,
        RegistrationSuccess,
        RegistrationFail,
        Amending,
        AmendSuccess,
        AmendFail,
        Deactivating,
        DeactivationSuccess,
        DeactivationFail,
    }
}
