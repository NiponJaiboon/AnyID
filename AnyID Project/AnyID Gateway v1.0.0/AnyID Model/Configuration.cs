using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    public delegate void TransactionTransitionEventHandler(Context context, ProxyTransaction statefulEntity, string reference, string remark);
    public delegate ICustomerRepository CustomerRepositoryCreatorDelegate();
    public delegate IProxyRegistra ProxyRegistraCreatorDelegate();
    public delegate IAuthenticationService AuthenticationServiceCreatorDelegate();
    public class Configuration : iSabaya.Configuration
    {
        #region persistent

        public virtual string CustomerTypeCSV { get; set; }
        public virtual string DocumentTypeCSV { get; set; }
        public virtual int AnyIDPerAccountBinding { get; set; }

        #endregion

        public static int AuthenticationSequenceType { get; } = 10;
        public static int DummyAccountNumberSequenceType { get; } = 20;
        public static int TransactionNumberSequenceType { get; } = 30;

        public static string GenDummyAccountNo(Context context, int year)
        {
            int lastTwoDigitOfYear = year - 2000;
            var seq = SequenceNoGenerator.GetInstance(context.MySystem.SystemID, Configuration.DummyAccountNumberSequenceType, lastTwoDigitOfYear);
            return lastTwoDigitOfYear.ToString("D2") + seq.GenSquenceNumber(context).ToString("D8");
        }

        public static string GenTransactionNo(Context context, int year)
        {
            int lastTwoDigitOfYear = year - 2000;
            var seq = SequenceNoGenerator.GetInstance(context.MySystem.SystemID, Configuration.TransactionNumberSequenceType, lastTwoDigitOfYear);
            return lastTwoDigitOfYear.ToString("D2") + seq.GenSquenceNumber(context).ToString("D8");
        }

        private string[] customerTypes;
        public virtual string[] CustomerTypes
        {
            get
            {
                if (this.customerTypes == null)
                    this.customerTypes = this.CustomerTypeCSV.Split(',');
                return this.customerTypes;
            }
        }

        private string[] documentTypes;
        public virtual string[] DocumentTypes
        {
            get
            {
                if (this.documentTypes == null)
                    this.documentTypes = this.CustomerTypeCSV.Split(',');
                return this.documentTypes;
            }
        }

        private static string ThailandInternationalAccessCode = "+66";
        public static string NormalizeMobilePhoneNo(string mobileNo)
        {
            if (string.IsNullOrEmpty(mobileNo))
                throw new Exception("Mobile phone no. is empty.");

            if (mobileNo.Substring(0, 1) == "+" && mobileNo.Length == 12)
                return mobileNo;

            if (mobileNo[0] != '0' || mobileNo.Length < 10)
                throw new Exception("Mobile phone no. is incorrect. {" + mobileNo + "}");

            return ThailandInternationalAccessCode + mobileNo.Substring(1);
        }

        //private static SequenceNoGenerator DummyAccountNoSequenceGenerator { get; set; }
        //public static string DummyAccountNoGenerator(Context context)
        //{
        //    int lastTwoDigitOfYear = DateTime.Today.Year - 2000;
        //    if (DummyAccountNoSequenceGenerator == null || DummyAccountNoSequenceGenerator.SubsequenceType != lastTwoDigitOfYear)
        //        DummyAccountNoSequenceGenerator = SequenceNoGenerator.GetInstance(context.MySystem.SystemID, 1, lastTwoDigitOfYear);
        //    return lastTwoDigitOfYear.ToString("D2") + DummyAccountNoSequenceGenerator.GenSquenceNumber(context).ToString("D8");
        //}

        private static IProxyRegistra proxyRegistra;
        public static IProxyRegistra ProxyRegistra
        {
            get
            {
                if (ProxyRegistraCreator != null)
                    proxyRegistra = ProxyRegistraCreator();
                return proxyRegistra;
            }
        }

        public static ProxyRegistraCreatorDelegate ProxyRegistraCreator { get; set; }

        public static int RegistraSendingTryLimit { get; private set; } = 1;

        public static AuthenticationServiceCreatorDelegate AuthenticationServiceCreator;

        private static IAuthenticationService authenticationService;
        public static IAuthenticationService AuthenticationService
        {
            get
            {
                if (authenticationService == null && AuthenticationServiceCreator != null)
                    authenticationService = AuthenticationServiceCreator();
                return authenticationService;
            }
        }

        public static CustomerRepositoryCreatorDelegate CustomerRepositoryCreator;

        private static ICustomerRepository customerRepository;
        public static ICustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null && CustomerRepositoryCreator != null)
                    customerRepository = CustomerRepositoryCreator.Invoke();
                return customerRepository;
            }
        }

    }
}
