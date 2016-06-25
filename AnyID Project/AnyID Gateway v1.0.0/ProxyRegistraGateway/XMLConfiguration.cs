using AnyIDModel;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProxyRegistraGateway
{
    public class XMLConfiguration : ConfigurationSection
    {
        private static XMLConfiguration configuration;
        public static XMLConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                    configuration = ConfigurationManager.GetSection("proxyRegistraWebService") as XMLConfiguration;
                return configuration;
            }
        }

        private const string channelsPropertyName = "authorizedChannel";
        private const string systemsPropertyName = "authorizedSystem";

        [ConfigurationProperty(channelsPropertyName)]
        public CSVStrings AuthorizedChannels
        {
            get { return (CSVStrings)base[channelsPropertyName]; }
            set { base[channelsPropertyName] = value; }
        }

        [ConfigurationProperty(systemsPropertyName)]
        public CSVStrings AuthorizedSystems
        {
            get { return (CSVStrings)base[systemsPropertyName]; }
            set { base[systemsPropertyName] = value; }
        }

        public virtual bool IsAuthorized(Header header)
        {
            return AuthorizedSystems.Includes(header.systemCode) && AuthorizedChannels.Includes(header.systemCode);
        }
    }

    public class CSVStrings : ConfigurationElement
    {
        [ConfigurationProperty("codes")]
        public string csvCodes
        {
            get { return (string)base["codes"]; }
            set
            {
                base["codes"] = value;
                codes = null;
            }
        }

        private string[] codes;
        public string[] Codes
        {
            get
            {
                if (codes == null)
                    codes = csvCodes.Split(',');
                return codes;
            }
        }

        public virtual bool Includes(string code)
        {
            return Array.IndexOf<string>(this.Codes, code) != -1;
        }
    }
}
