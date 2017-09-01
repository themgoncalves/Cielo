using System;
using System.Configuration;
using System.Diagnostics;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Requests.Entites;
using Cielo.Requests.Entites.Common;
using Cielo.Responses.Exceptions;

namespace Cielo.Demo.Services
{
    public class CreateDebitCardTransaction : ICieloDemo
    {
        private ICieloDemoInterface _app;

        public static CieloDemoInfo Info
        {
            get
            {
                var info = new CieloDemoInfo(
                    typeof(CreateDebitCardTransaction),
                    "new-debit",
                    "Create a new debit card transaction",
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
            
            ConsoleHelper.WriteHeader("Creating a Transaction with Debit Card");

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
            
            DebitCard debitCard = new DebitCard("0000.0000.0000.0001",
                                            "John Doe",
                                            new CardExpiration(2017, 9), "123", CardBrand.Visa);

            Payment payment = new Payment(PaymentType.DebitCard, 380.2m, 1, "", debitCard: debitCard, returnUrl: configuration.ReturnUrl);

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
