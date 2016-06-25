using System;
using System.Collections.Generic;
using System.Globalization;
using AnyIDModel;
using iSabaya;
using dto.kktutility.services.kiatnakinbank.com.xsd;
using dto.authentication.kktutility.services.kiatnakinbank.com.xsd;
using www.kiatnakinbank.com.services.CAA.CAACommon.data;
using www.kiatnakinbank.com.services.CAA.CAATokenService.data;

namespace KiatnakinServices
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Mapping from KK role code to the system's role code
        /// </summary>
        public static Dictionary<string, string> RoleMapping;
        static AuthenticationService()
        {
            RoleMapping = new Dictionary<string, string>
            {
                {"0002", "Maker" },
                {"0003", "Approver" },
                {"0004", "Maker" },
                {"0005", "Approver" },
                {"CCC3", "Viewer" },
            };
        }

        private static int SequenceNo = 0;

        private static string Mock_GenAuthenticationDailySequenceNo(Context context, DateTime date)
        {
            return (++SequenceNo).ToString("D7");
        }

        private static string GenAuthenticationDailySequenceNo(Context context, DateTime date)
        {
            var seq = SequenceNoGenerator.GetInstance(context.MySystem.SystemID, AnyIDModel.Configuration.AuthenticationSequenceType, date.Year * 1000L + date.Month * 100L + date.Day);
            return seq.GenSquenceNumber(context).ToString("D7");
        }

        public virtual User Authenticate(Context context, string loginName, string password)
        {
            var timestamp = DateTime.Now;
            var timestampString = timestamp.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var header = new RequestHeader
            {
                channelId = "AID",
                loginName = "sysanyid",
                loginPassword = "Passw0rd",
                repeatFlag = "Y",
                serviceName = "authenticate",
                transReferenceNo = "AID" + timestamp.ToString("YYMMdd", CultureInfo.InvariantCulture) 
                                    + GenAuthenticationDailySequenceNo(context, timestamp),
                transDate = timestampString,
            };
            var authentication = new Authentication
            {
                userId = loginName,
                userPassword = password,
            };
            var service = new KKTAuthenticationPortTypeClient();
            var response = service.authenticate(header, authentication);
            var status = response.responseStatus;
            if (status.status == "0")
            {
                var userInfo = response.userInfo;

                User user = new ActiveDirectoryUser
                {
                    LoginName = loginName,
                    Name = userInfo.userFullName,
                    BranchCode = userInfo.userBranchNo,
                };
                var userRoles = userInfo.userRoles;
                foreach (var r in userInfo.userRoles)
                {
                    string roleCode;
                    if (RoleMapping.TryGetValue(r.roleCode, out roleCode))
                    {
                        user.UserRoles.Add(new iSabaya.UserRole { User = user, Role = Role.Find(context, roleCode), EffectivePeriod = new TimeInterval(DateTime.Today) });
                    }
                }
                return user;
            }
            throw new Exception(status.errorCode + ":" + status.errorDesc);
        }
        public virtual OTPReference GenOTP(string IPAddress, string mobilePhoneNo, string message, DateTime transactionTS, string transactionNo)
        {
            var referenceNo = transactionTS.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            var transactionTimestamp = transactionTS.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            var header = new www.kiatnakinbank.com.services.CAA.CAACommon.data.Header
            {
                ChannelID = "ANYID",
                ReferenceNo = referenceNo,
                ServiceName = "GenerateOTP",
                SystemCode = "ANYID",
                TransactionDateTime = transactionTimestamp,
            };
            var parameters = new GenerateOTPParam
            {
                MobileNumber = mobilePhoneNo,
                Template = "anyid_otp",
                Policy = "AnyIdSmsOtpPolicy",
                ClientIp = IPAddress,
                MessageParam = new MessageParam
                {
                    MsgPrefix = "รหัส OTP",
                    MsgDetail = message,
                }
            };

            www.kiatnakinbank.com.services.CAA.CAACommon.data.ResponseStatus response;

            var caa = new CAATokenServiceClient();
            var x = caa.GenerateOTP(ref header, parameters, out response);
            if (response.ResponseMessage != "SUCCESS")
                throw new Exception(response.ResponseCode + " - " + response.ResponseMessage);

            return new OTPReference
            {
                ExpiryTime = transactionTS.AddSeconds(int.Parse(x.OTPTimeout)),
                ReferenceNo = x.ReferenceNo,
                TokenGUID = x.TokenUUID,
                TransactionNo = transactionNo,
                TransactionTS = transactionTS,
            };
        }

        public virtual bool VerifyOTP(string IPAddress, string password, OTPReference token)
        {
            var referenceNo = DateTime.Now.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            var transactionTimestamp = DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            var header = new www.kiatnakinbank.com.services.CAA.CAACommon.data.Header
            {
                ChannelID = "ANYID",
                ReferenceNo = referenceNo, //token.ReferenceNo,
                ServiceName = "VerifyOTP",
                SystemCode = "ANYID",
                TransactionDateTime = transactionTimestamp,
            };
            var parameters = new VerifyOTPParam
            {
                ClientIp = IPAddress,
                ReferenceNo = token.ReferenceNo,
                TokenUUID = token.TokenGUID,
                OTP = password,
            };

            var caa = new CAATokenServiceClient();
            var x = caa.VerifyOTP(ref header, parameters);
            if (x.ResponseCode == "CAA-I-0000")
                return true;
            if (x.ResponseCode == "CAA-I-E3001")
                return false;
            else
                throw new Exception(x.ResponseCode + " - " + x.ResponseMessage);
        }
    }
}
