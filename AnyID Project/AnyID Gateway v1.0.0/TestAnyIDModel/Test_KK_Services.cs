using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using System.Diagnostics;

namespace TestAnyIDModel
{
    [TestClass]
    public class Test_KK_Services : TestBase
    {
        public static readonly iSystem System = new iSystem(1, "Test Kiatnakin Internal Services");

        [TestMethod]
        public void Test_Get_Customer_Profile()
        {
            var customerID = "1100400139739";
            customerID = "1101200182275";
            int count = 0;
            var service = AnyIDModel.Configuration.CustomerRepository;
            var customers = service.GetCustomerProfiles(out count, SessionContext, customerID, IDType.I);

            //Get bank accounts
            foreach (var c in customers)
            {
                c.Accounts = service.GetCustomerAccounts(SessionContext, customerID, IDType.I);
            }

            Assert.IsTrue(customers.Count == 1);
            var customer = customers[0];
            Assert.IsFalse(string.IsNullOrEmpty(customer.CurrentAddress));
            Assert.IsFalse(string.IsNullOrEmpty(customer.MailingAddress));
            Assert.IsFalse(string.IsNullOrEmpty(customer.OfficeAddress));
            Assert.IsFalse(string.IsNullOrEmpty(customer.RegisteredAddress));
            Assert.IsTrue(customer.Accounts.Count > 0);
        }

        [TestMethod]
        public void Test_Input_From_Console()
        {
            Trace.WriteLine("Please enter the password.");
            var password = Console.ReadLine();
        }

        //[TestMethod]
        //public void Test_Authenticate_Success()
        //{
        //    var s = new AuthenticationService();
        //    var name = Console.ReadLine();
        //    var password = Console.ReadLine();
        //    var user = s.Authenticate(SessionContext, name, password);
        //}

        [TestMethod]
        public void Test_Get_Customer_Accounts()
        {
        }

        [TestMethod]
        public void Test_OTP_Services()
        {
            var s = AnyIDModel.Configuration.AuthenticationService;
            var otpToken = s.GenOTP("10.195.59.51", "0875268263", "Hello", DateTime.Now, "123456");
            var password = Console.ReadLine();
            var result = s.VerifyOTP("10.195.59.51", password, otpToken);
        }

        //[TestMethod]
        //public void Test_Authentication_WebRef()
        //{
        //    var service = new KKTAuthenticationPortTypeClient();
        //    var u = service.authenticate();
        //}

        [TestMethod]
        public void Test_Authentication()
        {
            var s = new AuthenticationService();

            var u = s.Authenticate(SessionContext, "phuthepe", "Gdupi9bok8bo");
            Assert.IsNotNull(u);
            Assert.IsTrue(u.UserRoles[0].Role.Code == "Maker");

            var v = s.Authenticate(SessionContext, "thitiphr", "Gdupi9bok8bo");
            Assert.IsNotNull(v);
            Assert.IsTrue(v.UserRoles[0].Role.Code == "Approver");

            var w = s.Authenticate(SessionContext, "siriphan", "Gdupi9bok8bo");
            Assert.IsNotNull(w);
            Assert.IsTrue(w.UserRoles[0].Role.Code == "Viewer");

            var x = s.Authenticate(SessionContext, "sudaratk", "Gdupi9bok8bo");
            Assert.IsNotNull(x);
            Assert.IsTrue(x.UserRoles.Count == 0);
        }








        [TestMethod]
        public void Test_Address()
        {
            string ADDRESS_NUMBER = "";
            string formattedAddress = (string.IsNullOrEmpty(ADDRESS_NUMBER) ? null : "บ้านเลขที่ " + ADDRESS_NUMBER)
                                            + fmt(" หมู่บ้าน ", " ")
                                            + fmt(" อาคาร ", "  ")
                                            + fmt(" ชั้นที่ ", "")
                                            + fmt(" หมู่ที่ ", "")
                                            + fmt(" ถนน ", "")
                                            + fmt(" ซอย ", "พหลโยธิน 40")
                                            + fmt(" ตำบล ", "เสนานิคม")
                                            + fmt(" อำเภอ ", "จตุจักร")
                                            + fmt(" จังหวัด ", "กรุงเทพมหานคร")
                                            + fmt(" ", "10900")
                                            + fmt(" ", "TH-Thailand");


            string OFFICE_TELEPHONE_NO = "028251619";
            string OFFICE_EXTENSION_NO = "1234";

            string result = "";

            if (!string.IsNullOrEmpty(OFFICE_TELEPHONE_NO))
                if (string.IsNullOrEmpty(OFFICE_EXTENSION_NO))
                    result = OFFICE_TELEPHONE_NO;
                else
                    result = OFFICE_TELEPHONE_NO + " ext " + OFFICE_EXTENSION_NO;
        }

        private string fmt(string label, string addressPart)
        {
            if (string.IsNullOrEmpty(addressPart) || string.IsNullOrWhiteSpace(addressPart))
                return null;
            else
                return label + addressPart;
        }
    }
}
