using System.Configuration;
using Cielo.Configuration;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void ConfigurationShouldSetItsValueFromAppConfig()
        {
            IConfiguration configuration = new DefaultConfiguration();
            IConfiguration customConfiguration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            configuration.DefaultEndpoint.Should().Be(customConfiguration.DefaultEndpoint);
            configuration.QueryEndpoint.Should().Be(customConfiguration.QueryEndpoint);
            configuration.MerchantId.Should().Be(customConfiguration.MerchantId);
            configuration.MerchantKey.Should().Be(customConfiguration.MerchantKey);
        }
    }
}