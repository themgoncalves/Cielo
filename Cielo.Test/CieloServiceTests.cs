using System;
using System.Configuration;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Requests.Entites;
using Cielo.Requests.Entites.Common;
using Cielo.Responses;
using Cielo.Responses.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test
{
    [TestFixture]
    public class CieloServiceTests
    {
        [Test]
        public void CreateCreditCardRequest_ShouldReturnNewTransactionResponse()
        {
            CieloService cieloService = new CieloService();

            Customer customer = new Customer("John Doe");


            CreditCard creditCard = new CreditCard("0000.0000.0000.0001",
                                            "John Doe",
                                            new CardExpiration(2020, 9), "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

            var transaction = new TransactionRequest("14421", customer, payment);

            var response = cieloService.CreateTransaction(transaction);

            response.Should().NotBeNull();
            response.Should().BeOfType<NewTransactionResponse>();
            response.Tid.Should().NotBeEmpty();
            response.PaymentId.Should().NotBeEmpty();
            response.MerchantOrderId.Should().NotBeEmpty();
            response.ProofOfSale.Should().NotBeEmpty();
            response.AuthorizationCode.Should().NotBeEmpty();
            response.Status.Should().BeOfType<Status>();
            response.ReturnCode.Should().BeOfType<ReturnCode>();
            response.ReturnMessage.Should().NotBeEmpty();
            response.AuthenticationUrl.Should().BeNullOrEmpty();
        }

        [Test]
        public void CreateEletronicTransferRequest_ShouldReturnEletronicTransferResponse()
        {
            CieloService cieloService = new CieloService();

            Customer customer = new Customer("John Doe");                        

            Payment payment = new Payment(PaymentType.EletronicTransfer, 100.00m, EletronicTransferProvider.BancodoBrasil, "http://www.cielo.com.br/");

            var transaction = new TransactionRequest("14421", customer, payment);

            var response = cieloService.CreateEletronicTransfer(transaction);

            response.Should().NotBeNull();
            response.Should().BeOfType<EletronicTransferResponse>();
            response.MerchantOrderId.Should().NotBeEmpty();
            response.PaymentId.Should().NotBeEmpty();
            response.Url.Should().NotBeEmpty();
            response.Url.Should().MatchRegex(@"^http(s)?:\/\/([\w-]+.)+[\w-]+(\/[\w- .\/?%&=])?$");
            response.Amount.Should().Equals(10000);
            response.Status.Should().BeOfType<Status>();
            response.Provider.Should().BeOfType<EletronicTransferProvider>();
            response.Provider.Should().Be(EletronicTransferProvider.Simulado);
        }
        
        [Test]
        public void CreateDebitCard_ShouldReturnNewTransactionResponse()
        {
            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = "http://localhost" + ConfigurationManager.AppSettings["cielo.return.url"] + "/14421"
            };

            CieloService cieloService = new CieloService(configuration);

            Customer customer = new Customer("John Doe");


            DebitCard debitCard = new DebitCard("0000.0000.0000.0001",
                                            "John Doe",
                                            new CardExpiration(2020, 9), "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.DebitCard, 380.2m, 1, "", debitCard: debitCard, returnUrl: configuration.ReturnUrl);

            var transaction = new TransactionRequest("14421", customer, payment);

            var response = cieloService.CreateTransaction(transaction);
            
            response.Should().NotBeNull();
            response.Should().BeOfType<NewTransactionResponse>();
            response.Tid.Should().NotBeEmpty();
            response.PaymentId.Should().NotBeEmpty();
            response.MerchantOrderId.Should().NotBeEmpty();
            response.ProofOfSale.Should().NotBeEmpty();
            response.AuthorizationCode.Should().BeNullOrEmpty();
            response.Status.Should().BeOfType<Status>();
            response.ReturnCode.Should().BeOfType<ReturnCode>();
            response.ReturnMessage.Should().BeNullOrEmpty();
            response.AuthenticationUrl.Should().NotBeNullOrEmpty();
        }
        
        [Test]
        public void CreateRequestWithCardToken_ShouldReturnNewTransactionResponse()
        {
            CieloService cieloService = new CieloService();

            CreditCardRequest creditCardToSave = new CreditCardRequest("John Doe", "0000.0000.0000.0004", "John Doe", new CardExpiration(2020, 8), CardBrand.MasterCard);

            var creditCardResponse = cieloService.SaveCard(creditCardToSave);

            Customer customer = new Customer("John Doe");

            CreditCard creditCard = new CreditCard(creditCardResponse.CardToken.ToString(), "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

            var transaction = new TransactionRequest("14421", customer, payment);

            var response = cieloService.CreateTransaction(transaction);

            response.Should().NotBeNull();
            response.Should().BeOfType<NewTransactionResponse>();
            response.Tid.Should().NotBeEmpty();
            response.PaymentId.Should().NotBeEmpty();
            response.MerchantOrderId.Should().NotBeEmpty();
            response.ProofOfSale.Should().NotBeEmpty();
            response.AuthorizationCode.Should().NotBeEmpty();
            response.Status.Should().BeOfType<Status>();
            response.ReturnCode.Should().BeOfType<ReturnCode>();
            response.ReturnMessage.Should().NotBeEmpty();
        }
        
        [Test]
        public void CancelTransaction_GivenFakeMerchantOrderId_ShouldThrowAnExceptionOfTypeResponseException()
        {
            CieloService cieloService = new CieloService();

            cieloService.Invoking(c => c.CancelTransaction(merchantOrderId: "123123")).ShouldThrow<ResponseException>();
        }

        [Test]
        public void CancelPartialTransaction_GivenFakeMerchantOrderId_ShouldThrowAnExceptionOfTypeResponseException()
        {
            CieloService cieloService = new CieloService();

            cieloService.Invoking(c => c.CancelTransaction(merchantOrderId: "123123", amount: 20m)).ShouldThrow<ResponseException>();
        }

        [Test]
        public void CaptureTransaction_GivenFakePaymentId_ShouldThrowAnExceptionOfTypeResponseException()
        {
            CieloService cieloService = new CieloService();

            cieloService.Invoking(c => c.CaptureTransaction(Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"))).ShouldThrow<ResponseException>();
        }
        
        [Test]
        public void CapturePartialTransaction_GivenFakePaymentId_ShouldThrowAnExceptionOfTypeResponseException()
        {
            CieloService cieloService = new CieloService();

            cieloService.Invoking(c => c.CaptureTransaction(Guid.Parse("55158bb3-2bb9-4e76-a92b-708b51245f4b"), 20.00m)).ShouldThrow<ResponseException>();
        }

        [Test]
        public void CheckTransaction_ShouldReturnCardResponse()
        {
            CieloService cieloService = new CieloService();

            Customer customer = new Customer("John Doe");


            CreditCard creditCard = new CreditCard("0000.0000.0000.0001",
                                            "John Doe",
                                            new CardExpiration(2020, 9), "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

            var transaction = new TransactionRequest("14421", customer, payment);

            var transactionResponse = cieloService.CreateTransaction(transaction);            

            var response = cieloService.CheckTransaction(paymentId: transactionResponse.PaymentId);

            response.Should().NotBeNull();
            response.Should().BeOfType<CheckTransactionResponse>();
            response.Customer.Name.Should().NotBeEmpty();
            response.Payment.Tid.Should().NotBeEmpty();
            response.Payment.AuthorizationCode.Should().NotBeEmpty();
            response.Payment.PaymentId.Should().NotBeEmpty();
            response.Payment.Status.Should().BeOfType<Status>();
        }

        [Test]
        public void SaveCard_ShouldReturnCheckTransactionResponse()
        {
            CieloService cieloService = new CieloService();

            CreditCardRequest request = new CreditCardRequest("John Doe", "0000.0000.0000.0004", "John Doe", new CardExpiration(2020, 8), CardBrand.MasterCard);

            var response = cieloService.SaveCard(request);

            response.Should().NotBeNull();
            response.Should().BeOfType<CardResponse>();
            response.CardToken.Should().NotBeEmpty();
        }
    }
}
