using Cielo.Enums;
using Cielo.Requests.Entites;
using Cielo.Requests.Entites.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Requests.Entites
{
    [TestFixture]
    public class TransactionRequestTests
    {
        [Test]
        public void TransactionRequest_ShouldConvertValuesToCieloFormat()
        {
            var customer = new Customer("John Doe");

            CreditCard creditCard = new CreditCard("0000.0000.0000.0001",
                                            "John Doe",
                                            new CardExpiration(2020, 9), "123", CardBrand.Visa);

            var payment = new Payment(PaymentType.CreditCard, 120.30m, 12, "", creditCard: creditCard);

            var transactionRequest = new TransactionRequest("Order1234", customer, payment);

            transactionRequest.Should().NotBeNull();
            transactionRequest.MerchantOrderId.Should().BeOfType(typeof(string)).And.Should().Equals("Order1234");
            transactionRequest.Customer.Should().NotBeNull().And.BeOfType(typeof(Customer));
            transactionRequest.Payment.Should().NotBeNull().And.BeOfType(typeof(Payment));
        }
    }
}
