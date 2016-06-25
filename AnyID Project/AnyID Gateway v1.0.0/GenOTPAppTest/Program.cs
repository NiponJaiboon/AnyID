using AnyIDModel;
using KiatnakinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenOTPAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string IPAddress = "127.0.0.1";
                string mobilePhoneNo = "0871234567";
                string message = "Hello GenOTP";
                DateTime transactionTS = DateTime.Now;

                var transactionTimestamp = transactionTS.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                var referenceNo = transactionTS.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                string OTPH_ChannelID = "ANYID";
                string OTPH_ReferenceNo = referenceNo;
                string OTPH_ServiceName = "GenerateOTP";
                string OTPH_SystemCode = "ANYID";
                string OTPH_TransactionDateTime = transactionTimestamp;
                string OTPD_MobileNumber = mobilePhoneNo;
                string OTPD_Template = "anyid_otp";
                string OTPD_Policy = "AnyIdSmsOtpPolicy";
                string OTPD_ClientIp = IPAddress;
                string OTPD_MsgPrefix = "รหัส OTP";
                string OTPD_MsgDetail = message;


                Console.WriteLine("Message Value");
                Console.WriteLine("OTPH_ChannelID:" + OTPH_ChannelID);
                Console.WriteLine("OTPH_ReferenceNo:" + OTPH_ReferenceNo);
                Console.WriteLine("OTPH_ServiceName:" + OTPH_ServiceName);
                Console.WriteLine("OTPH_SystemCode:" + OTPH_SystemCode);
                Console.WriteLine("OTPH_TransactionDateTime:" + OTPH_TransactionDateTime);
                Console.WriteLine("OTPD_MobileNumber:" + OTPD_MobileNumber);
                Console.WriteLine("OTPD_Template:" + OTPD_Template);
                Console.WriteLine("OTPD_Policy:" + OTPD_Policy);
                Console.WriteLine("OTPD_ClientIp:" + OTPD_ClientIp);
                Console.WriteLine("OTPD_MsgPrefix:" + OTPD_MsgPrefix);
                Console.WriteLine("OTPD_MsgDetail:" + OTPD_MsgDetail);
                Console.WriteLine("===========================================");




                var OTP = Configuration.AuthenticationService;
                OTPReference otpResult = OTP.GenOTP(IPAddress, mobilePhoneNo, message, transactionTS, "");
                Console.WriteLine("Success!!");
                Console.WriteLine("ReferenceNo: " + otpResult.ReferenceNo);
                Console.WriteLine("TokenGUID: " + otpResult.TokenGUID);
                Console.WriteLine("ExpiryTime: " + otpResult.ExpiryTime.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("TransactionTS: " + otpResult.TransactionTS.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("TransactionNo: " + otpResult.TransactionNo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed!!");
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();



        }
    }
}
