using AuthenticationTest.KKTAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Username: "); string username = Console.ReadLine();
            Console.Write("Password: "); string password = Console.ReadLine();


            var timestamp = DateTime.Now;
            var timestampString = timestamp.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var header = new RequestHeader
            {
                channelId = "AID",
                loginName = "sysanyid",
                loginPassword = "Passw0rd",
                repeatFlag = "Y",
                serviceName = "authenticate",
                transReferenceNo = "AID" + timestamp.ToString("YYMMdd", System.Globalization.CultureInfo.InvariantCulture)
                                    + "0000001",
                transDate = timestampString,
            };
            var authentication = new Authentication
            {
                userId = username,
                userPassword = password,
            };
            var service = new KKTAuthenticationPortTypeClient();
            var response = service.authenticate(header, authentication);
            if (response.responseStatus.status == "0")
            {
                Console.WriteLine("userId: " + response.userInfo.userId);
                Console.WriteLine("userFullName: " + response.userInfo.userFullName);
                Console.WriteLine("userBranchNo: " + response.userInfo.userBranchNo);
                Console.WriteLine("userBranchName: " + response.userInfo.userBranchName);
                foreach (var item in response.userInfo.userRoles)
                {
                    Console.WriteLine("roleCode: " + item.roleCode + " roleName: " + item.roleName);
                }
            }
            Console.WriteLine("status: " + response.responseStatus.status);
            Console.WriteLine("errorCode: " + response.responseStatus.errorCode);
            Console.WriteLine("errorDesc: " + response.responseStatus.errorDesc);
            Console.ReadLine();
        }
    }
}
