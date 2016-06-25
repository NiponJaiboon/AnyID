using System;
using iSabaya;

namespace AnyIDModel
{
    public struct OTPReference
    {
        public string ReferenceNo;
        public string TokenGUID;
        public DateTime ExpiryTime;
        public DateTime TransactionTS;
        public string TransactionNo;
    }

    public interface IAuthenticationService
    {
        User Authenticate(Context context, string loginName, string password);
        OTPReference GenOTP(string IPAddress, string mobilePhoneNo, string message, DateTime transactionTS, string transactionNo);
        bool VerifyOTP(string IPAddress, string password, OTPReference token);
    }
}
