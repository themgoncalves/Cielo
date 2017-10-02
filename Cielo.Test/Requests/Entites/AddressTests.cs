using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Requests.Entites
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        public void AddressTests_ShouldConvertValuesToCieloFormat()
        {
            var address = new Address("Street name", "1234", "Complement", "00000-000", "São Paulo", "SP");

            address.Should().NotBeNull();
            address.Street.Should().BeOfType(typeof(string)).And.Should().Equals("Street name");
            address.Number.Should().BeOfType(typeof(string)).And.Should().Equals("1234");
            address.Complement.Should().BeOfType(typeof(string)).And.Should().Equals("Complement");
            address.ZipCode.Should().BeOfType(typeof(string)).And.Should().Equals("00000-000");
            address.City.Should().BeOfType(typeof(string)).And.Should().Equals("São Paulo");
            address.Street.Should().BeOfType(typeof(string)).And.Should().Equals("SP");
            address.Country.Should().BeOfType(typeof(string)).And.Should().Equals("BRA");
        }
    }
}
