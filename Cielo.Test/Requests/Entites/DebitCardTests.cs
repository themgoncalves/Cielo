using Cielo.Enums;
using Cielo.Extensions;
using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Requests.Entites
{
    [TestFixture]
    public class DebitCardTests
    {
        [Test]
        public void DebitCard_ShouldConvertValuesToCieloFormat()
        {
            var creditCard = new DebitCard("4556-2299-4919-5288", "John Doe", new CardExpiration(2020, 08), "123", CardBrand.Visa);

            creditCard.Should().NotBeNull();


            creditCard.CardNumber.Should().BeOfType(typeof(string)).And.Equals("4556229949195288");
            creditCard.Holder.Should().BeOfType(typeof(string)).And.Equals("John Doe");
            creditCard.ExpirationDate.Should().BeOfType(typeof(string)).And.Equals("08/2020");
            creditCard.SecurityCode.Should().BeOfType(typeof(string)).And.Equals("123");
            creditCard.Brand.Should().BeOfType(typeof(string)).And.Equals(CardBrand.Visa.ToDescription());
        }
    }
}
