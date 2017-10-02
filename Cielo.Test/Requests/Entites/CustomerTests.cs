using System;
using Cielo.Enums;
using Cielo.Extensions;
using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;


namespace Cielo.Test.Requests.Entites
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void CustomerTests_SimpleEntity_ShouldConvertValuesToCieloFormat()
        {
            var customer = new Customer("John Doe");

            customer.Should().NotBeNull();
            customer.Name.Should().BeOfType(typeof(string)).And.Equals("John Doe");

            customer.Identity.Should().BeNull();
            customer.IdentityType.Should().BeNull();
            customer.Birthdate.Should().BeNull();
            customer.Address.Should().BeNull();
            customer.DeliveryAddress.Should().BeNull();
        }


        [Test]
        public void CustomerTests_CompleteEntity_ShouldConvertValuesToCieloFormat()
        {
            var customer = new Customer("John Doe", "754.366.290-67", CustomerIdentityType.CPF, new DateTime(1960, 10, 08));

            customer.Should().NotBeNull();
            customer.Name.Should().BeOfType(typeof(string)).And.Equals("John Doe");

            customer.Identity.Should().BeOfType(typeof(string)).And.Equals("75436629067");
            customer.IdentityType.Should().BeOfType(typeof(string)).And.Equals(CustomerIdentityType.CPF.ToDescription());
            customer.Birthdate.Should().BeOfType(typeof(string)).And.Equals("1960-10-08");
            customer.Address.Should().BeNull();
            customer.DeliveryAddress.Should().BeNull();
        }
    }
}
