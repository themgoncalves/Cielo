using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test
{
    [TestFixture]
    public class CreditCardExpirationTests
    {
        [Test]
        public void ToString_GivenACreditCardWithYear2020AndMonth08_ShouldReturnMMSlashYYYY()
        {
            var expiration = new CardExpiration(2020, 08);

            expiration.ToString().Should().Be("08/2020");
        }
    }
}
