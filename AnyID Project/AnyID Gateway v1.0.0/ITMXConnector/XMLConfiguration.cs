using System;
using System.Configuration;

namespace ITMXConnector
{
    public class XMLConfiguration : ConfigurationSection
    {
        //public static readonly Uri AmendEndPoint = new Uri(@"https://regsit.nitmx.co.th:443/mpp-registration/v1.0/registration/participant/KKB/amend/registrationId");
        //public static readonly Uri DeactivateEndPoint = new Uri(@"https://regsit.nitmx.co.th:443/mpp-registration/v1.0/registration/participant/KKB/deactivate/registrationId");
        //public static readonly Uri RegisterEndPoint = new Uri(@"https://regsit.nitmx.co.th:443/mpp-registration/v1.0/registration/participant/KKB/register");
        //public static readonly string InquiryByRegistrionIDEndPoint = @"https://regsit.nitmx.co.th:443/mpp-registration/v1.0/registration/participant/KKB/enquiry/registrationId";
        //public static readonly string InquiryByAnyIDEndPoint = @"https://regsit.nitmx.co.th:443/mpp-registration/v1.0/registration/participant/KKB/enquiry/proxy";

        public static readonly string InquiryByRegistrionIDParameterFormat = @"?registrationId={0}";
        public static readonly string InquiryByAnyIDParameterFormat = @"?proxyType={0}&proxyValue={1}&registrationStatus={2}";

        private static XMLConfiguration configuration;
        public static XMLConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                    configuration = ConfigurationManager.GetSection("itmx") as XMLConfiguration;
                return configuration;
            }
        }

        private const string amendPropertyName = "amend";
        private const string deactivatePropertyName = "deactivate";
        private const string inquiryByAnyIDPropertyName = "inquiryByAnyID";
        private const string inquiryByRegistrionIDPropertyName = "inquiryByRegistrionID";
        private const string registerPropertyName = "register";

        [ConfigurationProperty(amendPropertyName)]
        public EndPoint Amend
        {
            get { return (EndPoint)base[amendPropertyName]; }
            set { base[amendPropertyName] = value; }
        }

        [ConfigurationProperty(deactivatePropertyName)]
        public EndPoint Deactivate
        {
            get { return (EndPoint)base[deactivatePropertyName]; }
            set { base[deactivatePropertyName] = value; }
        }

        [ConfigurationProperty(registerPropertyName)]
        public EndPoint Register
        {
            get { return (EndPoint)base[registerPropertyName]; }
            set { base[registerPropertyName] = value; }
        }

        [ConfigurationProperty(inquiryByRegistrionIDPropertyName)]
        public EndPoint InquiryByRegistrionID
        {
            get { return (EndPoint)base[inquiryByRegistrionIDPropertyName]; }
            set { base[inquiryByRegistrionIDPropertyName] = value; }
        }


        [ConfigurationProperty(inquiryByAnyIDPropertyName)]
        public EndPoint InquiryByAnyID
        {
            get { return (EndPoint)base[inquiryByAnyIDPropertyName]; }
            set { base[inquiryByAnyIDPropertyName] = value; }
        }
    }

    public class EndPoint : ConfigurationElement
    {
        [ConfigurationProperty("url")]
        public string Url
        {
            get { return (string)base["url"]; }
            set
            {
                base["url"] = value;
                uri = null;
            }
        }

        private Uri uri;
        public Uri Uri
        {
            get
            {
                if (uri == null)
                    uri = new Uri(Url);
                return uri;
            }
        }
    }
}
