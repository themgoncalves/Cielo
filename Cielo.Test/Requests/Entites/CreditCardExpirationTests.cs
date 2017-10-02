using System;
using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Entities
{
    [TestFixture]
    public class CreditCardExpirationTests
    {
        [Test]
        public void CreditCardExpiration_ToString_GivenACreditCardWithYear2020AndMonth08_ShouldReturnMMSlashYYYY()
        {
            var expiration = new CardExpiration(2020, 08);

            expiration.ToString().Should().Be("08/2020");
        }

        [Test]
        public void CreditCardExpiration_GivenACreditCardWithYear2001AndMonth06_ShouldThrowException()
        {
            var expiration = new CardExpiration(2020, 08);

            expiration.Invoking(c => new CardExpiration(2001, 06)).ShouldThrow<Exception>().WithMessage("Card Expiration Date is invalid");
        }
    }
}
