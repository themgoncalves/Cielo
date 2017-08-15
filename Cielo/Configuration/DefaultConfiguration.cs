using System.Configuration;

namespace Cielo.Configuration
{
    public class DefaultConfiguration : IConfiguration
    {
        public string DefaultEndpoint
        {
            get { return ConfigurationManager.AppSettings["cielo.endpoint.default"]; }
        }

        public string QueryEndpoint
        {
            get { return ConfigurationManager.AppSettings["cielo.endpoint.query"]; }
        }

        public string MerchantId
        {
            get { return ConfigurationManager.AppSettings["cielo.customer.id"]; }
        }

        public string MerchantKey
        {
            get { return ConfigurationManager.AppSettings["cielo.customer.key"]; }
        }

        public string ReturnUrl
        {
            get { return ConfigurationManager.AppSettings["cielo.return.url"]; }
        }
    }
}
