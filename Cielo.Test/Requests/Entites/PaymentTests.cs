using System;
using Cielo.Enums;
using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Requests.Entites
{
    [TestFixture]
    public class PaymentTests
    {
        [Test]
        public void Payment_FirstCtorOverload_ShouldConvertValuesToCieloFormat()
        {
            var payment = new Payment(PaymentType.CreditCard, 120.30m, 
                EletronicTransferProvider.Bradesco, "/success");

            payment.Should().NotBeNull();
            payment.Type.Should().BeOfType(typeof(string)).And.Equals("CreditCard");
            payment.Amount.Should().BeOfType(typeof(int)).And.Equals(12030);
            payment.Provider.Should().BeOfType(typeof(string)).And.Equals("Bradesco");
            payment.ReturnUrl.Should().BeOfType(typeof(string)).And.Equals("/success");


            payment.Installments.Should().BeOfType(typeof(byte)).And.Equals(0);
            payment.SoftDescriptor.Should().BeNull();
            payment.Capture.Should().BeFalse();
            payment.Authenticate.Should().BeFalse();
        }

        [Test]
        public void Payment_SecondCtorOverload_WithCreditCard_ShouldConvertValuesToCieloFormat()
        {
            CreditCard creditCard = new CreditCard("0000.0000.0000.0001",
                                            "John Doe",
                                            new CardExpiration(2020, 9), "123", CardBrand.Visa);

            var payment = new Payment(PaymentType.CreditCard, 120.30m, 12, "", creditCard: creditCard);

            payment.Should().NotBeNull();
            payment.Type.Should().BeOfType(typeof(string)).And.Equals("CreditCard");
            payment.Amount.Should().BeOfType(typeof(int)).And.Equals(12030);
            payment.Installments.Should().BeOfType(typeof(byte)).And.Equals(12);
            payment.SoftDescriptor.Should().BeOfType(typeof(string)).And.Equals(String.Empty);
            payment.Capture.Should().BeFalse();
            payment.ReturnUrl.Should().BeNull();
            payment.Authenticate.Should().BeFalse();
            payment.Provider.Should().BeNull();

            payment.CreditCard.Should().BeOfType(typeof(CreditCard)).And.NotBeNull();
            payment.DebitCard.Should().BeNull();
        }
    }
}
