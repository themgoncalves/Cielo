using System;
using Cielo.Enums;
using Cielo.Extensions;
using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Requests.Entites
{
    [TestFixture]
    public class CreditCardTests
    {
        [Test]
        public void CreditCard_FirstCtorOverload_ShouldConvertValuesToCieloFormat()
        {
            var creditCard = new CreditCard(Guid.Empty.ToString(), "123", CardBrand.AmericanExpress);

            creditCard.Should().NotBeNull();
            creditCard.CardToken.Should().BeOfType(typeof(string)).And.Equals(Guid.Empty.ToString());
            creditCard.SecurityCode.Should().BeOfType(typeof(string)).And.Equals("123");
            creditCard.Brand.Should().BeOfType(typeof(string)).And.Equals(CardBrand.AmericanExpress.ToDescription());

            creditCard.CardNumber.Should().BeNull();
            creditCard.Holder.Should().BeNull();
            creditCard.ExpirationDate.Should().BeNull();
            creditCard.SaveCard.Should().BeFalse();
        }

        [Test]
        public void CreditCard_SecondCtorOverload_ShouldConvertValuesToCieloFormat()
        {
            var creditCard = new CreditCard("4556-2299-4919-5288", "John Doe", new CardExpiration(2020, 08), "123", CardBrand.Visa);

            creditCard.Should().NotBeNull();


            creditCard.CardNumber.Should().BeOfType(typeof(string)).And.Equals("4556229949195288");
            creditCard.Holder.Should().BeOfType(typeof(string)).And.Equals("John Doe");
            creditCard.ExpirationDate.Should().BeOfType(typeof(string)).And.Equals("08/2020");
            creditCard.SecurityCode.Should().BeOfType(typeof(string)).And.Equals("123");
            creditCard.Brand.Should().BeOfType(typeof(string)).And.Equals(CardBrand.Visa.ToDescription());

            creditCard.SaveCard.Should().BeFalse();
            creditCard.CardToken.Should().BeNull();
        }
    }
}
