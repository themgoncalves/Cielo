using System;
using System.Configuration;
using System.Diagnostics;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Request.Entites;
using Cielo.Request.Entites.Common;
using Cielo.Responses.Exceptions;

namespace Cielo.Demo.Services
{
    public class CreateRequestWithCardToken : ICieloDemo
    {
        private ICieloDemoInterface _app;

        public static CieloDemoInfo Info
        {
            get
            {
                var info = new CieloDemoInfo(
                    typeof(CreateRequestWithCardToken),
                    "new-cardtoken",
                    "Create a new transaction with a Card Token",
                    "");
                return info;
            }
        }

        #region ICieloDemo Members

        public void Execute(ICieloDemoInterface app)
        {
            this._app = app;
            this.GetArgs();
            this.ExecuteRequest();
        }

        #endregion

        private void GetArgs()
        {
            foreach (var arg in _app.Args)
            {

            }
        }

        private void ExecuteRequest()
        {
            var watch = Stopwatch.StartNew();
            
            ConsoleHelper.WriteHeader("Creating a Transaction with Card Token");

            CustomConfiguration configuration = new CustomConfiguration()
            {
                DefaultEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.default"],
                QueryEndpoint = ConfigurationManager.AppSettings["cielo.endpoint.query"],
                MerchantId = ConfigurationManager.AppSettings["cielo.customer.id"],
                MerchantKey = ConfigurationManager.AppSettings["cielo.customer.key"],
                ReturnUrl = ConfigurationManager.AppSettings["cielo.return.url"],
            };

            CieloService cieloService = new CieloService(configuration);

            Customer customer = new Customer("John Doe");

            CreditCard creditCard = new CreditCard("ea9b8398-e8bb-4e77-a865-66109fc4563e", "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.CreditCard, 380.2m, 1, "", creditCard: creditCard);

            var transaction = new TransactionRequest("14421", customer, payment);

            try
            {
                var response = cieloService.CreateTransaction(transaction);

                ConsoleHelper.WriteResult(response);
            }
            catch (ResponseException ex)
            {
                ConsoleHelper.WriteError(ex);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError(ex);
            }

            watch.Stop();
            ConsoleHelper.WriteFooter(watch.ElapsedMilliseconds);
        }
    }
}
