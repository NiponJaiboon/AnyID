using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMXConnector
{
    public enum ITMXResponseCode
    {
        //602 Structural validation failure
        //702 Participant is suspended
        //703 Participant is retired
        //710 Maximum number of registrations already exist for this Proxy and Account Type for the Participant
        //802 Proxy type is not valid on MP
        //800 Proxy is registered with different participant
        //803 The proxy must not have a status of suspended
        //908 The registration cannot have an account holder of person and business
        //902 Account type is not valid on MPP
        //926 Account name does not match existing registration
        //927 Account exists for a different participant
        //932 Requesting participant does not support the specified account type
        //936 Account status is not valid for registration
        //708 The participant does not support sending accounts for the specified account type
        /*
        403 Forbidden
        601 Authentication Failure
        602 Structural validation failure
        702 Participant is suspended
        703 Participant is retired
        708 The participant does not support sending accounts for the specified account type
        710 Maximum number of Registrations already exist for this Proxy and Account Type for the Participant
        800 Proxy is registered with different Participant
        802 Proxy type is not valid on MPP
        803 The proxy must not have a status of suspended
        804 The Proxy type must not be amended
        902 Account type is not valid on MPP
        903 Proxy and Account combination is not registered with requesting Participant
        907 Proxy and Account combination is not registered on MPP
        909 The Account holder type must not be amended
        910 The Account type must not be amended
        912 Registration ID does not exist
        913 Registration ID does not exist for Participant
        917 Registration ID is deactivated
        914 Operation invalid (no update fields requested on an amend)
        926 Account name does not match existing registration
        927 Account exists for a different participant
        932 Requesting participant does not support the specified account type
        936 Account status is not valid for registration
        944 Maximum permitted number of proxies already linked to specified account.
*/
    }
}

